namespace LaserBrainTwister.Tests;

public class NodeTests
{
    [Fact]
    public void CreateIntNode()
    {
        var node = new Node<int>(0, 0);
        node.Id.ShouldBe(0);
        node.Item.ShouldBe(0);
        node.LinkedNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void CreateCoordinateNode()
    {
        var coordinate = Coordinate.From(5, 7);
        var node = new Node<Coordinate>(coordinate, 0);
        node.Id.ShouldBe(0);
        node.Item.ShouldBe(coordinate);
        node.LinkedNodes.Count.ShouldBe(0);
    }
}