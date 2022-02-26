namespace LaserBrainTwister.Tests;

public class FluentTests
{
    [Fact]
    public void Add3SuccessivesLinks()
    {
        var tree = new Tree(0, 1, 2, 3);
        tree.AddLink(0, 1).And(2).And(3);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(3);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[0].LinkedNodes[2].ShouldBe(tree.Nodes[3]);
    }
}
