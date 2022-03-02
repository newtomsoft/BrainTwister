using System;

namespace LaserBrainTwister.Tests;
public class TwoWayTreeTests
{
    [Fact]
    public void AddLinkFromOriginWithoutNodes()
    {
        var tree = new TwoWayTree();
        var action = () => tree.LinkFromOriginTo();
        action.ShouldThrow<ArgumentException>();
    }

    [Fact]
    public void Add1LinksToNode0()
    {
        var tree = new TwoWayTree();
        tree.LinkFromOriginTo(1);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[1].LinkedNodes[0].ShouldBe(tree.Nodes[0]);
    }

    [Fact]
    public void Add2LinksToNode0()
    {
        var tree = new TwoWayTree();
        tree.LinkFromOriginTo(1).To(2);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[1].LinkedNodes[0].ShouldBe(tree.Nodes[0]);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[2].LinkedNodes[0].ShouldBe(tree.Nodes[0]);

    }

    [Fact]
    public void Add3LinksToNode0()
    {
        var tree = new TwoWayTree();
        tree.LinkFromOriginTo(1).To(2).To(3);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(3);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[0].LinkedNodes[2].ShouldBe(tree.Nodes[3]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[1].LinkedNodes[0].ShouldBe(tree.Nodes[0]);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[2].LinkedNodes[0].ShouldBe(tree.Nodes[0]);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[3].LinkedNodes[0].ShouldBe(tree.Nodes[0]);

    }

    [Fact]
    public void Add3LinksToNode0UsingParams()
    {
        var tree = new TwoWayTree();
        tree.LinkFromOriginTo(1, 2, 3);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(3);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[0].LinkedNodes[2].ShouldBe(tree.Nodes[3]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[1].LinkedNodes[0].ShouldBe(tree.Nodes[0]);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[2].LinkedNodes[0].ShouldBe(tree.Nodes[0]);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[3].LinkedNodes[0].ShouldBe(tree.Nodes[0]);
    }


    [Fact]
    public void AddSuccessiveLinksWithoutNodes()
    {
        var tree = new TwoWayTree();
        var action = () => tree.LinkFromOriginTo(1).Then();
        action.ShouldThrow<ArgumentException>();
    }

    [Fact]
    public void Add2SuccessiveLinks()
    {
        var tree = new TwoWayTree();
        var segment = tree.LinkFromOriginTo(1);
        segment = segment.Then(2);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[1].LinkedNodes[0].ShouldBe(tree.Nodes[0]);
        tree.Nodes[1].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[2].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
    }

    [Fact]
    public void Add3SuccessiveLinks()
    {
        var tree = new TwoWayTree();
        var segment = tree.LinkFromOriginTo(1);
        segment = segment.Then(2);
        segment = segment.Then(3);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[1].LinkedNodes[0].ShouldBe(tree.Nodes[0]);
        tree.Nodes[1].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[2].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[2].LinkedNodes[1].ShouldBe(tree.Nodes[3]);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[3].LinkedNodes[0].ShouldBe(tree.Nodes[2]);

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
    public void AddComplexesTwoWayLinks()
    {
        var tree = new TwoWayTree();
        tree.LinkFromOriginTo(1, 2)
            .NextTo(2, 3)
            .NextTo(3);

        tree.Nodes[0].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(3);
        tree.Nodes[1].LinkedNodes[0].ShouldBe(tree.Nodes[0]);
        tree.Nodes[1].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[1].LinkedNodes[2].ShouldBe(tree.Nodes[3]);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(3);
        tree.Nodes[2].LinkedNodes[0].ShouldBe(tree.Nodes[0]);
        tree.Nodes[2].LinkedNodes[1].ShouldBe(tree.Nodes[1]);
        tree.Nodes[2].LinkedNodes[2].ShouldBe(tree.Nodes[3]);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[3].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[3].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
    }
}
