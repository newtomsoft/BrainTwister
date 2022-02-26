namespace LaserBrainTwister.Tests;

public class RouteTests
{
    [Fact]
    public void RouteSimple()
    {
        var tree = new Tree(3);
        tree.LinkFrom(0).To(1).Then(2);

        var routes = tree.GetRoutes();
        routes.Count.ShouldBe(1);
        routes[0].Nodes.Count.ShouldBe(3);
        routes[0].Nodes[0].Number.ShouldBe(0);
        routes[0].Nodes[1].Number.ShouldBe(1);
        routes[0].Nodes[2].Number.ShouldBe(2);
    }

    [Fact]
    public void RouteWith2Ways()
    {
        var tree = new Tree(4);
        tree.LinkFrom(0).To(1).To(2);
        tree.LinkFrom(1).To(3);
        tree.LinkFrom(2).To(3);

        var routes = tree.GetRoutes();
        routes.Count.ShouldBe(2);
        routes[0].Nodes.Count.ShouldBe(3);
        routes[0].Nodes[0].Number.ShouldBe(0);
        routes[0].Nodes[1].Number.ShouldBe(1);
        routes[0].Nodes[2].Number.ShouldBe(3);
        routes[1].Nodes.Count.ShouldBe(3);
        routes[1].Nodes[0].Number.ShouldBe(0);
        routes[1].Nodes[1].Number.ShouldBe(2);
        routes[1].Nodes[2].Number.ShouldBe(3);
    }

    [Fact]
    public void RoutesWithWithMoreWays()
    {
        var tree = new Tree(7);
        tree.LinkFrom(0).To(1).To(2);
        tree.LinkFrom(1).To(3).To(4);
        tree.LinkFrom(2).To(5);
        tree.LinkFrom(3).To(6);
        tree.LinkFrom(4).To(6);
        tree.LinkFrom(5).To(6);

        var routes = tree.GetRoutes();
        routes.Count.ShouldBe(3);
        routes[0].Nodes.Count.ShouldBe(4);
        routes[0].Nodes[0].Number.ShouldBe(0);
        routes[0].Nodes[1].Number.ShouldBe(1);
        routes[0].Nodes[2].Number.ShouldBe(3);
        routes[0].Nodes[3].Number.ShouldBe(6);
        routes[1].Nodes.Count.ShouldBe(4);
        routes[1].Nodes[0].Number.ShouldBe(0);
        routes[1].Nodes[1].Number.ShouldBe(1);
        routes[1].Nodes[2].Number.ShouldBe(4);
        routes[1].Nodes[3].Number.ShouldBe(6);
        routes[2].Nodes[0].Number.ShouldBe(0);
        routes[2].Nodes[1].Number.ShouldBe(2);
        routes[2].Nodes[2].Number.ShouldBe(5);
        routes[2].Nodes[3].Number.ShouldBe(6);
    }

    [Fact]
    public void RoutesWithWithCycle()
    {
        Tree tree = new(3);
        tree.LinkFrom(0).To(1);
        tree.LinkFrom(1).To(2);
        tree.LinkFrom(1).To(0);

        var routes = tree.GetRoutes();
        routes.Count.ShouldBe(1);
        routes[0].Nodes.Count.ShouldBe(3);
        routes[0].Nodes[0].Number.ShouldBe(0);
        routes[0].Nodes[1].Number.ShouldBe(1);
        routes[0].Nodes[2].Number.ShouldBe(2);
    }

    [Fact]
    public void ToStringTest()
    {
        var tree = new Tree(3);
        tree.LinkFrom(0).To(1).Then(2);
        var routes = tree.GetRoutes();
        routes[0].ToString().ShouldBe("0 1 2");
    }
}
