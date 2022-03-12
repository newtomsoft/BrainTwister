using LaserBrainTwister.Domain.Trees;

namespace LaserBrainTwister.Tests;

public class OneWayTreeTests
{
    [Fact]
    public void Add3LinksToNode0()
    {
        var tree = new OneWayTree<string>();
        tree.LinkFrom("0").To("1").To("2").To("3");

        tree.Nodes[0].LinkedNodes.ShouldBe(new[] { tree.Nodes[1], tree.Nodes[2], tree.Nodes[3] });
        tree.Nodes[1].LinkedNodes.ShouldBe(Array.Empty<Node<string>>());
        tree.Nodes[2].LinkedNodes.ShouldBe(Array.Empty<Node<string>>());
        tree.Nodes[3].LinkedNodes.ShouldBe(Array.Empty<Node<string>>());
    }

    [Fact]
    public void Add3SuccessiveLinks()
    {
        var tree = new OneWayTree<string>();
        tree.LinkFrom("0").To("1").Then("2").Then("3");

        tree.Nodes[0].LinkedNodes.ShouldBe(new[] { tree.Nodes[1] });
        tree.Nodes[1].LinkedNodes.ShouldBe(new[] { tree.Nodes[2] });
        tree.Nodes[2].LinkedNodes.ShouldBe(new[] { tree.Nodes[3] });
        tree.Nodes[3].LinkedNodes.ShouldBe(Array.Empty<Node<string>>());
    }

    [Fact]
    public void AddComplexesLinks()
    {
        var tree = new OneWayTree<string>();
        tree.LinkFrom("0").To("1").To("2")
            .Next("1").To("2").To("3")
            .Next("2").To("3");

        tree.Nodes[0].LinkedNodes.ShouldBe(new[] { tree.Nodes[1], tree.Nodes[2] });
        tree.Nodes[1].LinkedNodes.ShouldBe(new[] { tree.Nodes[2], tree.Nodes[3] });
        tree.Nodes[2].LinkedNodes.ShouldBe(new[] { tree.Nodes[3] });
        tree.Nodes[3].LinkedNodes.ShouldBe(Array.Empty<Node<string>>());
    }
}
