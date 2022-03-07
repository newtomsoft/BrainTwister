namespace LaserBrainTwister.Domain.Segments;

public interface ISegment<in T>
{
    ISegment<T> To(T item, int nodeNumber);
    void Then(T item, int nodeNumber);
    ISegment<T> Next(T item);
}