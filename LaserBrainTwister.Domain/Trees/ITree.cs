namespace LaserBrainTwister.Domain.Trees;

public interface ITree<T> where T : IEquatable<T>
{
    List<Node<T>> Nodes { get; }
    int NodesNumber();
    ISegment<T> LinkFrom(T item);
    IEnumerable<Route<T>> GetRoutes(bool bruteForce = false);
    IEnumerable<Route<T>> GetRoutesWithAllNodes(bool bruteForce = false);
    Route<T>? GetRouteWithMostNodes();
    Route<T>? GetRouteWithLeastNodes();
    List<Route<T>> OptimizeRoutes();
}