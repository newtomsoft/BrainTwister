namespace LaserBrainTwister.Domain.Trees;

public interface ITree
{
    List<Node> Nodes { get; }
    int NodesNumber();
    ISegment LinkFrom(int fromNodeNumber);
    ISegment LinkFromOriginTo(params int[] nodesNumber);
    IEnumerable<Route> GetRoutesFromStartToDeadEnds();
}