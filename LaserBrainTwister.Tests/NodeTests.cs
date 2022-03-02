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
}