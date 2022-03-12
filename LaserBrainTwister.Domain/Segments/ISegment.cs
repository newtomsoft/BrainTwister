namespace LaserBrainTwister.Domain.Segments;

public interface ISegment<in T>
{
    ISegment<T> ToOld(T item, int nodeId);
    ISegment<T> To(T item);
    ISegment<T> ThenOld(T item, int nodeId);
    ISegment<T> Then(T item);
    ISegment<T> Next(T item);
}