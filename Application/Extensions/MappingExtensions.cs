using System.Collections;
using System.Collections.Concurrent;
using System.Reflection;

namespace Application.Extensions;

public static class MappingExtensions
{
  private static readonly ConcurrentDictionary<Type, PropertyInfo[]> ReadableProperties = new();
  private static readonly ConcurrentDictionary<Type, PropertyInfo[]> WritableProperties = new();

  public static TDestination MapTo<TDestination>(this object? source)
  {
    if (source is null)
      return default!;

    return (TDestination)MapValue(source, typeof(TDestination), null, new HashSet<object>(ReferenceEqualityComparer.Instance))!;
  }

  public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
  {
    ArgumentNullException.ThrowIfNull(source);
    ArgumentNullException.ThrowIfNull(destination);

    return (TDestination)MapValue(source, typeof(TDestination), destination, new HashSet<object>(ReferenceEqualityComparer.Instance))!;
  }

  public static List<TDestination> MapToList<TDestination>(this IEnumerable? source)
  {
    if (source is null)
      return [];

    var result = new List<TDestination>();
    var visited = new HashSet<object>(ReferenceEqualityComparer.Instance);
    foreach (var item in source)
    {
      if (item is not null)
        result.Add((TDestination)MapValue(item, typeof(TDestination), null, visited)!);
    }

    return result;
  }

  private static object? MapValue(object? source, Type destinationType, object? destination, HashSet<object> visited)
  {
    if (source is null)
      return null;

    var sourceType = source.GetType();
    var effectiveDestinationType = Nullable.GetUnderlyingType(destinationType) ?? destinationType;
    if (IsSimpleType(effectiveDestinationType))
      return effectiveDestinationType.IsInstanceOfType(source) ? source : Convert.ChangeType(source, effectiveDestinationType);

    if (source is IEnumerable sourceItems && source is not string)
      return MapCollection(sourceItems, destinationType, destination, visited);

    if (!effectiveDestinationType.IsClass && !effectiveDestinationType.IsInterface)
      return source;

    var destinationObject = destination ?? Activator.CreateInstance(effectiveDestinationType)
      ?? throw new InvalidOperationException($"Cannot create an instance of {effectiveDestinationType.FullName}.");

    if (!sourceType.IsValueType && !visited.Add(source))
      return destination;

    try
    {
      var sourceProperties = ReadableProperties.GetOrAdd(sourceType, type => type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Where(property => property.CanRead && property.GetIndexParameters().Length == 0)
        .ToArray())
        .ToDictionary(property => property.Name, StringComparer.Ordinal);

      foreach (var destinationProperty in WritableProperties.GetOrAdd(effectiveDestinationType, type => type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Where(property => property.CanWrite && property.GetIndexParameters().Length == 0)
        .ToArray()))
      {
        if (!sourceProperties.TryGetValue(destinationProperty.Name, out var sourceProperty))
          continue;

        var sourceValue = sourceProperty.GetValue(source);
        var mappedValue = sourceValue is null && IsCollectionType(destinationProperty.PropertyType)
          ? MapCollection(Array.Empty<object>(), destinationProperty.PropertyType, null, visited)
          : MapValue(sourceValue, destinationProperty.PropertyType, null, visited);
        if (mappedValue is null && destinationProperty.PropertyType.IsValueType && Nullable.GetUnderlyingType(destinationProperty.PropertyType) is null)
          continue;

        destinationProperty.SetValue(destinationObject, mappedValue);
      }

      return destinationObject;
    }
    finally
    {
      if (!sourceType.IsValueType)
        visited.Remove(source);
    }
  }

  private static object MapCollection(IEnumerable sourceItems, Type destinationType, object? destination, HashSet<object> visited)
  {
    var elementType = destinationType.IsArray
      ? destinationType.GetElementType()!
      : destinationType.GetInterfaces()
          .Append(destinationType)
          .FirstOrDefault(type => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
          ?.GetGenericArguments()[0]
        ?? throw new InvalidOperationException($"Cannot determine the collection element type for {destinationType.FullName}.");

    var mappedItems = sourceItems.Cast<object?>()
      .Select(item => item is null ? null : MapValue(item, elementType, null, visited))
      .ToList();

    if (destinationType.IsArray)
    {
      var array = Array.CreateInstance(elementType, mappedItems.Count);
      for (var index = 0; index < mappedItems.Count; index++)
        array.SetValue(mappedItems[index], index);
      return array;
    }

    var listType = typeof(List<>).MakeGenericType(elementType);
    var list = (IList)Activator.CreateInstance(listType)!;
    foreach (var item in mappedItems)
      list.Add(item);

    if (destinationType.IsAssignableFrom(listType))
      return list;

    var collection = destination is not null && destinationType.IsInstanceOfType(destination)
      ? destination
      : Activator.CreateInstance(destinationType);
    if (collection is IList collectionList)
    {
      foreach (var item in mappedItems)
        collectionList.Add(item);
      return collectionList;
    }

    var addMethod = destinationType.GetMethod("Add", [elementType]);
    if (collection is not null && addMethod is not null)
    {
      foreach (var item in mappedItems)
        addMethod.Invoke(collection, [item]);
      return collection;
    }

    throw new InvalidOperationException($"Cannot create a collection of type {destinationType.FullName}.");
  }

  private static bool IsCollectionType(Type type)
  {
    return type.IsArray
      || type.GetInterfaces()
        .Append(type)
        .Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IEnumerable<>));
  }

  private static bool IsSimpleType(Type type)
  {
    return type.IsPrimitive
      || type.IsEnum
      || type == typeof(string)
      || type == typeof(decimal)
      || type == typeof(Guid)
      || type == typeof(DateTime)
      || type == typeof(DateTimeOffset)
      || type == typeof(DateOnly)
      || type == typeof(TimeOnly)
      || type == typeof(TimeSpan);
  }
}
