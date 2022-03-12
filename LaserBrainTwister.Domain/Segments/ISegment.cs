namespace LaserBrainTwister.Domain.Segments;

public interface ISegment<in T>
{
    ISegment<T> To(T item);
    ISegment<T> Then(T item);
    ISegment<T> Next(T item);
}