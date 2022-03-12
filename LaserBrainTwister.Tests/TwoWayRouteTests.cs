using LaserBrainTwister.Domain.Trees;

namespace LaserBrainTwister.Tests;

public class TwoWayRouteTests
{
    [Fact]
    public void ToStringTest()
    {
        var tree = new TwoWayTree<int>();
        tree.LinkFrom(0).To(1).Then(2);
        var routes = tree.GetRoutes().ToList();
        routes[0].ToString().ShouldBe("0 1 2");
    }

    [Fact]
    public void RouteSimple()
    {
        var tree = new TwoWayTree<int>();
        tree.LinkFrom(0).To(1).Then(2);

        var routes = tree.GetRoutes().ToList();
        routes.Count.ShouldBe(1);
        routes[0].NodesNumber().ShouldBe(3);
        routes[0].Nodes[0].Item.ShouldBe(0);
        routes[0].Nodes[1].Item.ShouldBe(1);
        routes[0].Nodes[2].Item.ShouldBe(2);
    }

    [Fact]
    public void RouteToDeadEndsWith2Ways()
    {
        var tree = new TwoWayTree<int>();
        tree.LinkFrom(0).To(1).To(2);
        tree.LinkFrom(1).To(3);
        tree.LinkFrom(2).To(3);
        tree.LinkFrom(3).To(4);

        var routes = tree.GetRoutes(true).ToList();
        routes.Count.ShouldBe(2);
        routes[0].NodesNumber().ShouldBe(4);
        routes[0].Nodes[0].Item.ShouldBe(0);
        routes[0].Nodes[1].Item.ShouldBe(1);
        routes[0].Nodes[2].Item.ShouldBe(3);
        routes[0].Nodes[3].Item.ShouldBe(4);
        routes[1].NodesNumber().ShouldBe(4);
        routes[1].Nodes[0].Item.ShouldBe(0);
        routes[1].Nodes[1].Item.ShouldBe(2);
        routes[1].Nodes[2].Item.ShouldBe(3);
        routes[1].Nodes[3].Item.ShouldBe(4);
    }

    [Fact]
    public void RoutesToDeadEndsWithWithMoreWays()
    {
        var tree = new TwoWayTree<int>();
        tree.LinkFrom(0).To(1).To(2);
        tree.LinkFrom(1).To(3).To(4);
        tree.LinkFrom(2).To(5);
        tree.LinkFrom(3).To(6);
        tree.LinkFrom(4).To(6);
        tree.LinkFrom(5).To(6);
        tree.LinkFrom(6).To(7);

        var routes = tree.GetRoutes(true).ToList();
        routes.Count.ShouldBe(3);
        routes[0].NodesNumber().ShouldBe(5);
        routes[0].Nodes[0].Item.ShouldBe(0);
        routes[0].Nodes[1].Item.ShouldBe(1);
        routes[0].Nodes[2].Item.ShouldBe(3);
        routes[0].Nodes[3].Item.ShouldBe(6);
        routes[0].Nodes[4].Item.ShouldBe(7);
        routes[1].NodesNumber().ShouldBe(5);
        routes[1].Nodes[0].Item.ShouldBe(0);
        routes[1].Nodes[1].Item.ShouldBe(1);
        routes[1].Nodes[2].Item.ShouldBe(4);
        routes[1].Nodes[3].Item.ShouldBe(6);
        routes[1].Nodes[4].Item.ShouldBe(7);
        routes[2].NodesNumber().ShouldBe(5);
        routes[2].Nodes[0].Item.ShouldBe(0);
        routes[2].Nodes[1].Item.ShouldBe(2);
        routes[2].Nodes[2].Item.ShouldBe(5);
        routes[2].Nodes[3].Item.ShouldBe(6);
        routes[2].Nodes[4].Item.ShouldBe(7);
    }

    [Fact]
    public void EnumerateSimpleRoute()
    {
        var tree = new TwoWayTree<int>();
        tree.LinkFrom(0).To(1).Then(2);

        var expectedStringRoutes = new List<string>
        {
            "0 1 2"
        };

        var routeCount = 0;
        foreach (var allNodesRoute in tree.GetRoutesWithAllNodes())
        {
            routeCount++;
            var founded = expectedStringRoutes.FirstOrDefault(str => str == allNodesRoute.ToString());
            founded.ShouldNotBeNull();
            expectedStringRoutes.Remove(founded);
        }
        routeCount.ShouldBe(1);
    }

    [Fact]
    public void RoutesWithComplexTree0()
    {
        var tree = new OneWayTree<int>();
        tree.LinkFrom(0).To(1)
            .Next(1).To(2).To(11)
            .Next(2).To(1).To(3).To(12)
            .Next(3).To(2).To(4).To(14)
            .Next(4).To(3).To(9)
            .Next(5).To(6).To(17)
            .Next(6).To(5).To(7).To(8)
            .Next(7).To(6).To(13)
            .Next(8).To(6).To(9).To(18)
            .Next(9).To(4).To(8)
            .Next(10).To(11).To(16)
            .Next(11).To(10).To(12)
            .Next(12).To(11).To(13).To(2)
            .Next(13).To(7).To(12).To(15)
            .Next(14).To(3).To(15).To(19)
            .Next(15).To(13).To(14).To(20)
            .Next(16).To(10).To(17)
            .Next(17).To(16).To(5).To(18)
            .Next(18).To(17).To(8).To(19)
            .Next(19).To(18).To(14).To(20)
            .Next(20).To(21).To(15).To(19);

        var expectedStringRoutesWithAllNodes = new List<string>
        {
            "0 1 2 12 11 10 16 17 5 6 7 13 15 14 3 4 9 8 18 19 20 21",
            "0 1 11 10 16 17 5 6 7 13 12 2 3 4 9 8 18 19 14 15 20 21",
        };
        var expectedRoutesCount = expectedStringRoutesWithAllNodes.Count;

        var routeCount = 0;
        foreach (var allNodesRoute in tree.GetRoutesWithAllNodes(true))
        {
            routeCount++;
            var founded = expectedStringRoutesWithAllNodes.FirstOrDefault(str => str == allNodesRoute.ToString());
            founded.ShouldNotBeNull();
            expectedStringRoutesWithAllNodes.Remove(founded);
        }
        routeCount.ShouldBe(expectedRoutesCount);
    }

    [Fact]
    public void RoutesWithComplexTree1()
    {
        var tree = new OneWayTree<int>();
        tree.LinkFrom(0).To(1)
            .Next(1).To(0).To(2).To(24)
            .Next(2).To(1).To(3).To(21)
            .Next(3).To(2).To(4).To(25)
            .Next(4).To(3).To(5).To(17)
            .Next(5).To(4).To(11)
            .Next(6).To(7).To(20)
            .Next(7).To(6).To(8).To(15)
            .Next(8).To(7).To(9).To(16)
            .Next(9).To(8).To(13)
            .Next(10).To(11).To(14)
            .Next(11).To(10).To(5).To(12)
            .Next(12).To(11).To(13).To(23)
            .Next(13).To(12).To(9).To(19)
            .Next(14).To(10).To(15)
            .Next(15).To(14).To(7).To(16)
            .Next(16).To(15).To(8).To(17)
            .Next(17).To(16).To(4).To(18)
            .Next(18).To(17).To(19).To(22)
            .Next(19).To(18).To(13).To(26)
            .Next(20).To(6).To(21)
            .Next(21).To(20).To(2).To(22)
            .Next(22).To(21).To(18).To(23)
            .Next(23).To(22).To(12)
            .Next(24).To(1).To(25)
            .Next(25).To(24).To(3).To(26)
            .Next(26).To(25).To(19).To(27);

        var expectedStringRoutesWithAllNodes = new List<string>
        {
            "0 1 24 25 3 2 21 20 6 7 15 14 10 11 5 4 17 16 8 9 13 12 23 22 18 19 26 27"
        };
        var expectedRoutesCount = expectedStringRoutesWithAllNodes.Count;

        var routeCount = 0;
        foreach (var allNodesRoute in tree.GetRoutesWithAllNodes(true))
        {
            routeCount++;
            var founded = expectedStringRoutesWithAllNodes.FirstOrDefault(str => str == allNodesRoute.ToString());
            founded.ShouldNotBeNull();
            expectedStringRoutesWithAllNodes.Remove(founded);
        }
        routeCount.ShouldBe(expectedRoutesCount);
    }

    [Fact]
    public void RoutesWithComplexTree2()
    {
        var tree = new OneWayTree<int>();
        tree.LinkFrom(0).To(1)
            .Next(1).To(0).To(2).To(16)
            .Next(2).To(1).To(3).To(23)
            .Next(3).To(2).To(4).To(13)
            .Next(4).To(3).To(5).To(18)
            .Next(5).To(4).To(7)
            .Next(6).To(7).To(21)
            .Next(7).To(6).To(5).To(15)
            .Next(8).To(9).To(12)
            .Next(9).To(8).To(17)
            .Next(10).To(11).To(22)
            .Next(11).To(10).To(20)
            .Next(12).To(8).To(13).To(26)
            .Next(13).To(12).To(3).To(14).To(21)
            .Next(14).To(13).To(15).To(25)
            .Next(15).To(14).To(7).To(19)
            .Next(16).To(1).To(17)
            .Next(17).To(16).To(9).To(18)
            .Next(18).To(17).To(4).To(19).To(27)
            .Next(19).To(18).To(15).To(29)
            .Next(20).To(11).To(21).To(31)
            .Next(21).To(20).To(6)
            .Next(22).To(10).To(23)
            .Next(23).To(22).To(2).To(24).To(32)
            .Next(24).To(23).To(13).To(25).To(33)
            .Next(25).To(24).To(14).To(28)
            .Next(26).To(12).To(27).To(30)
            .Next(27).To(26).To(18).To(28).To(34)
            .Next(28).To(27).To(25).To(29).To(36)
            .Next(29).To(28).To(19)
            .Next(30).To(26).To(31)
            .Next(31).To(30).To(32).To(37)
            .Next(32).To(31).To(23).To(33).To(38)
            .Next(33).To(32).To(24).To(34)
            .Next(34).To(33).To(27).To(35)
            .Next(35).To(34).To(29)
            .Next(36).To(28).To(39)
            .Next(37).To(31).To(38)
            .Next(38).To(37).To(32);

        var expectedStringRoutesWithAllNodes = new List<string>
        {
            "0 1 16 17 9 8 12 13 3 2 23 22 10 11 20 21 6 7 5 4 18 19 15 14 25 24 33 32 38 37 31 30 26 27 34 35 29 28 36 39",
            "0 1 16 17 9 8 12 26 30 31 37 38 32 33 24 13 3 2 23 22 10 11 20 21 6 7 5 4 18 27 34 35 29 19 15 14 25 28 36 39",
            "0 1 16 17 9 8 12 26 30 31 37 38 32 33 34 35 29 19 15 14 25 24 13 3 2 23 22 10 11 20 21 6 7 5 4 18 27 28 36 39",
        };
        var expectedRoutesCount = expectedStringRoutesWithAllNodes.Count;

        var routeCount = 0;
        foreach (var allNodesRoute in tree.GetRoutesWithAllNodes(true))
        {
            routeCount++;
            var founded = expectedStringRoutesWithAllNodes.FirstOrDefault(str => str == allNodesRoute.ToString());
            founded.ShouldNotBeNull();
            expectedStringRoutesWithAllNodes.Remove(founded);
        }
        routeCount.ShouldBe(expectedRoutesCount);
    }
}
