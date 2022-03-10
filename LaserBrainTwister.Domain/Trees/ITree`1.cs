namespace LaserBrainTwister.Domain.Trees;

public interface ITree<T>
{
    List<Node<T>> Nodes { get; }
    ISegment<T> LinkFrom(T item, int fromNodeNumber);
    ISegment<T> LinkFromOriginTo(T item, int nodeNumber);
    IEnumerable<Route<T>> GetRoutes(bool bruteForce = false);
    IEnumerable<Route<T>> GetRoutesWithAllNodes();
    Route<T>? GetLongestRoute();
    Route<T>? GetShortestRoute();
    List<Route<T>> OptimizeRoutes();
}