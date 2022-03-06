using LaserBrainTwister.Domain.Tree;

namespace LaserBrainTwister.Tests;
public class WorkTreeTests
{
    [Fact]
    public void RouteToDeadEndsWith2Ways()
    {
        var tree = new Tree();
        tree.LinkFrom(0).To(1).To(2);
        tree.LinkFrom(1).To(3);
        tree.LinkFrom(2).To(3);

        var workTree = new WorkTree(tree);

        workTree.FirstPass();
        var routeNodes = workTree.RoutedNodes;
    }
}
