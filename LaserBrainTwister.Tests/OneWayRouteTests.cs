using LaserBrainTwister.Domain.Trees;

namespace LaserBrainTwister.Tests;

public class OneWayRouteTests
{
    [Fact]
    public void RoutesWithCycle()
    {
        var tree = new OneWayTree<int>();
        tree.LinkFrom(0).To(1).Then(2).Then(3);
        tree.LinkFrom(2).To(1);

        var routes = tree.GetRoutes(true).ToList();
        routes.Count.ShouldBe(1);
        routes[0].NodesNumber().ShouldBe(4);
        routes[0].Nodes[0].Item.ShouldBe(0);
        routes[0].Nodes[1].Item.ShouldBe(1);
        routes[0].Nodes[2].Item.ShouldBe(2);
        routes[0].Nodes[3].Item.ShouldBe(3);
    }
}
