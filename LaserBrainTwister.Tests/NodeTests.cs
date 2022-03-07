using LaserBrainTwister.Domain.Nodes;

namespace LaserBrainTwister.Tests;

public class NodeTests
{
    [Fact]
    public void Create1Node()
    {
        var node = new Node(0);
        node.Number.ShouldBe(0);
        node.LinkedNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void Create1NodeWithCoordinate()
    {
        var coordinate = Coordinate.From(5, 7);
        var node = new Node<Coordinate>(coordinate, 0);
        node.Number.ShouldBe(0);
        node.Item.ShouldBe(coordinate);
        node.LinkedNodes.Count.ShouldBe(0);
    }
}