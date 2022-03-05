namespace LaserBrainTwister.Domain;

public interface ISegment
{
    ISegment To(params int[] nodesNumber);
    ISegment Then(params int[] nodesNumber);
    ISegment NextTo(params int[] nodesNumber);
    ISegment Next();
    ISegment Reverse();
}

public interface ISegment<in T>
{
    ISegment<T> To(T item, int nodeNumber);
    ISegment<T> Then(T item, int nodeNumber);
    ISegment<T> NextTo(T currentItem, T item, int nodeNumber);
    ISegment<T> Next(T item);
    ISegment<T> Reverse();
}