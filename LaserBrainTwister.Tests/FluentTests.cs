namespace LaserBrainTwister.Tests;

public class FluentTests
{
    [Fact]
    public void Add3SuccessivesLinks()
    {
        var tree = new Tree(4);
        tree.LinkFrom(0).To(1).To(2).To(3);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(3);
        tree.Nodes[0].LinkedNodes[0].ShouldBe(tree.Nodes[1]);
        tree.Nodes[0].LinkedNodes[1].ShouldBe(tree.Nodes[2]);
        tree.Nodes[0].LinkedNodes[2].ShouldBe(tree.Nodes[3]);
    }
}
