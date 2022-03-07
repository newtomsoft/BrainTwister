namespace LaserBrainTwister.Domain.Trees;

public interface ITree
{
    List<Node> Nodes { get; }
    ISegment LinkFrom(int fromNodeNumber);
    ISegment LinkFromOriginTo(params int[] nodesNumber);
    IEnumerable<Routes.Route> GetRoutesFromStartToDeadEnds();
}