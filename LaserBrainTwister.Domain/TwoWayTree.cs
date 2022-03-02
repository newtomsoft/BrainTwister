namespace LaserBrainTwister.Domain;

public class TwoWayTree : Tree
{
    public new TwoWaySegment LinkFrom(int fromNodeNumber)
    {
        var fromNode = Nodes.FirstOrDefault(n => n.Number == fromNodeNumber);
        return fromNode is null ? new(AddNode(fromNodeNumber), new(0), this) : new(fromNode, new(0), this);
    }
    public new ISegment LinkFromOriginTo(params int[] nodesNumber) => LinkFrom(0).To(nodesNumber);
}