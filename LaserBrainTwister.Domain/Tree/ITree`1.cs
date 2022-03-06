namespace LaserBrainTwister.Domain.Tree;

public interface ITree<T>
{
    List<Node<T>> Nodes { get; }
    ISegment<T> LinkFrom(T item, int fromNodeNumber);
    ISegment<T> LinkFromOriginTo(T item, int nodeNumber);
    IEnumerable<Route<T>> GetRoutesFromStartToDeadEnds();
}