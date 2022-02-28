﻿namespace LaserBrainTwister.Tests;

public class FluentTests
{
    [Fact]
    public void Add3LinksToNode0()
    {
        var tree = new Tree(4);
        tree.LinkFromOrigin().To(1).To(2).To(3);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(3);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[0].LinkedNodes[2].ShouldBe(tree.Nodes[3]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(0);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(0);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void Add3LinksToNode0WithParams()
    {
        var tree = new Tree(4);
        tree.LinkFromOrigin().To(1, 2, 3);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(3);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[0].LinkedNodes[2].ShouldBe(tree.Nodes[3]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(0);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(0);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void Add3SuccessivesLinks()
    {
        var tree = new Tree(4);
        tree.LinkFrom(0).To(1).Then(2).Then(3);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[1].LinkedNodes[0].ShouldBe(tree.Nodes[2]);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[2].LinkedNodes[0].ShouldBe(tree.Nodes[3]);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void Add3SuccessivesLinksWithParams()
    {
        var tree = new Tree(4);
        tree.LinkFrom(0).To(1).Then(2, 3);
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
        var tree = new Tree(4);
        tree.LinkFrom(0).To(1, 2)
                 .Next().To(2, 3)
                 .Next().To(1, 3);

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
