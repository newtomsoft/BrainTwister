namespace LaserBrainTwister.Domain;

public interface ITree
{
    List<Node> Nodes { get; }
    ISegment LinkFrom(int fromNodeNumber);
    ISegment LinkFromOriginTo(params int[] nodesNumber);
    IEnumerable<Route> GetRoutesFromStartToDeadEnds();
}

public interface ITree<T>
{
    List<Node<T>> Nodes { get; }
    ISegment<T> LinkFrom(T item, int fromNodeNumber);
    ISegment<T> LinkFromOriginTo(T item, int nodeNumber);
    IEnumerable<Route<T>> GetRoutesFromStartToDeadEnds();
}