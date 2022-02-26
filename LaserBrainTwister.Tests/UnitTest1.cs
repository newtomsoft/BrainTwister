using LaserBrainTwister.Domain;
using Shouldly;
using Xunit;

namespace LaserBrainTwister.Tests;
public class UnitTest1
{
    [Fact]
    public void Create1Node()
    {
        Node node = Node.New(0);
        node.Number.ShouldBe(0);
        node.LinkedNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void Add1Link()
    {
        Node node0 = Node.New(0);
        Node node1 = Node.New(1);

        node0.AddLinkedNode(node1);
        node0.LinkedNodes.Count.ShouldBe(1);
        node0.LinkedNodes[0].ShouldBe(node1);
    }

    [Fact]
    public void AddMoreLinkedNodes()
    {
        Node node0 = Node.New(0);
        Node node1 = Node.New(1);
        Node node2 = Node.New(2);
        node0.AddLinkedNode(node1);
        node0.AddLinkedNode(node2);
        node0.LinkedNodes.Count.ShouldBe(2);
        node0.LinkedNodes[0].ShouldBe(node1);
        node0.LinkedNodes[1].ShouldBe(node2);
    }
}