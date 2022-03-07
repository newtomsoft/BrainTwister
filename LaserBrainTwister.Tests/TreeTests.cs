using System;

namespace LaserBrainTwister.Tests;

public class TreeTests
{
    [Fact]
    public void AddLinkFromOriginWithoutNodes()
    {
        var tree = new Tree();
        var action = () => tree.LinkFromOriginTo();
        action.ShouldThrow<ArgumentException>();
    }

    [Fact]
    public void Add3LinksToNode0()
    {
        var tree = new Tree();
        tree.LinkFromOriginTo(1).To(2).To(3);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(3);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[0].LinkedNodes[2].ShouldBe(tree.Nodes[3]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(0);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(0);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void Add3LinksToNode0UsingParams()
    {
        var tree = new Tree();
        tree.LinkFromOriginTo(1, 2, 3);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(3);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[0].LinkedNodes[2].ShouldBe(tree.Nodes[3]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(0);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(0);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(0);
    }


    [Fact]
    public void AddSuccessiveLinksWithoutNodes()
    {
        var tree = new Tree();
        var action = () => tree.LinkFromOriginTo(1).Then();
        action.ShouldThrow<ArgumentException>();
    }

    [Fact]
    public void Add3SuccessiveLinks()
    {
        var tree = new Tree();
        tree.LinkFromOriginTo(1).Then(2).Then(3);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[1].LinkedNodes[0].ShouldBe(tree.Nodes[2]);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[2].LinkedNodes[0].ShouldBe(tree.Nodes[3]);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void Add3SuccessiveLinksUsingParams()
    {
        var tree = new Tree();
        tree.LinkFromOriginTo(1).Then(2, 3);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[1].LinkedNodes[0].ShouldBe(tree.Nodes[2]);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[2].LinkedNodes[0].ShouldBe(tree.Nodes[3]);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void AddComplexesLinks()
    {
        var tree = new Tree();
        tree.LinkFromOriginTo(1, 2)
            .NextTo(2, 3)
            .NextTo(1, 3);

        tree.Nodes[0].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[1].LinkedNodes[0].ShouldBe(tree.Nodes[2]);
        tree.Nodes[1].LinkedNodes[1].ShouldBe(tree.Nodes[3]);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[2].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[2].LinkedNodes[1].ShouldBe(tree.Nodes[3]);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(0);
    }
}
