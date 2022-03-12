using LaserBrainTwister.Domain.Trees;

namespace LaserBrainTwister.Tests;

public class OneWayTreeTests
{
    [Fact]
    public void Add3LinksToNode0()
    {
        var tree = new OneWayTree<string>();
        tree.LinkFrom("node 0").To("node 1").To("node 2").To("node 3");
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(3);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[0].LinkedNodes[2].ShouldBe(tree.Nodes[3]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(0);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(0);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void Add3SuccessiveLinks()
    {
        var tree = new OneWayTree<string>();
        tree.LinkFrom("node 0").To("node 1").Then("node 2").Then("node 3");
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
        var tree = new OneWayTree<string>();
        tree.LinkFrom("0").To("1").To("2")
            .Next("1").To("2").To("3")
            .Next("2").To("3");

        tree.Nodes[0].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[1].LinkedNodes[0].ShouldBe(tree.Nodes[2]);
        tree.Nodes[1].LinkedNodes[1].ShouldBe(tree.Nodes[3]);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[2].LinkedNodes[0].ShouldBe(tree.Nodes[3]);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(0);
    }
}
