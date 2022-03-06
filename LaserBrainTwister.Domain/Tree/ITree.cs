namespace LaserBrainTwister.Domain.Tree;

public interface ITree
{
    List<Node.Node> Nodes { get; }
    ISegment LinkFrom(int fromNodeNumber);
    ISegment LinkFromOriginTo(params int[] nodesNumber);
    IEnumerable<Route.Route> GetRoutesFromStartToDeadEnds();
}