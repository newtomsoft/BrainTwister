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
        tree.LinkFromOriginTo(1).Then(2);
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
        tree.LinkFromOriginTo(1).Then(2).Then(3);
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

    [Fact]
    public void RoutesWithComplexTwoWayTree()
    {
        var tree = new TwoWayTree();
        tree.LinkFromOriginTo(1)
            .NextTo(2)
            .NextTo(3, 10)
            .NextTo(4, 11)
            .NextTo(8)
            .NextTo(6, 9)
            .NextTo(7)
            .NextTo(8)
            .Next()
            .NextTo(10)
            .NextTo(11)
            .NextTo(12);

        var expectedStringRoutesWithAllNodes = new List<string>
        {
            "0 1 2 3 4 8 7 6 5 9 10 11 12",
            "0 1 2 10 9 5 6 7 8 4 3 11 12",
        };
        var expectedRoutesCount = expectedStringRoutesWithAllNodes.Count;

        var routeCount = 0;
        foreach (var allNodesRoute in tree.GetRoutesFromStartToDeadEnds().Where(r => r.NodesNumber() == tree.NodesNumber()))
        {
            routeCount++;
            var founded = expectedStringRoutesWithAllNodes.FirstOrDefault(str => str == allNodesRoute.ToString());
            founded.ShouldNotBeNull();
            expectedStringRoutesWithAllNodes.Remove(founded);
        }
        routeCount.ShouldBe(expectedRoutesCount);
    }
}
