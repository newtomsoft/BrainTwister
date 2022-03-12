//namespace LaserBrainTwister.Tests;

//public class RouteTests
//{
//    [Fact]
//    public void CreateTreeWithoutNode()
//    {
//        var tree = new Tree();
//        tree.LinkFromOriginTo(1);
//        var routes = tree.GetRoutesFromStartToDeadEnds().ToList();
//        routes[0].ToString().ShouldBe("0 1");
//    }

//    [Fact]
//    public void ToStringTest()
//    {
//        var tree = new Tree();
//        tree.LinkFrom(0).To(1).Then(2);
//        var routes = tree.GetRoutesFromStartToDeadEnds().ToList();
//        routes[0].ToString().ShouldBe("0 1 2");
//    }

//    [Fact]
//    public void RouteToDeadEndsSimple()
//    {
//        var tree = new Tree();
//        tree.LinkFrom(0).To(1).Then(2);

//        var routes = tree.GetRoutesFromStartToDeadEnds().ToList();
//        routes.Count.ShouldBe(1);
//        routes[0].NodesNumber().ShouldBe(3);
//        routes[0].Nodes[0].Number.ShouldBe(0);
//        routes[0].Nodes[1].Number.ShouldBe(1);
//        routes[0].Nodes[2].Number.ShouldBe(2);
//    }

//    [Fact]
//    public void RouteToDeadEndsWith2Ways()
//    {
//        var tree = new Tree();
//        tree.LinkFrom(0).To(1).To(2);
//        tree.LinkFrom(1).To(3);
//        tree.LinkFrom(2).To(3);

//        var routes = tree.GetRoutesFromStartToDeadEnds().ToList();
//        routes.Count.ShouldBe(2);
//        routes[0].NodesNumber().ShouldBe(3);
//        routes[0].Nodes[0].Number.ShouldBe(0);
//        routes[0].Nodes[1].Number.ShouldBe(1);
//        routes[0].Nodes[2].Number.ShouldBe(3);
//        routes[1].NodesNumber().ShouldBe(3);
//        routes[1].Nodes[0].Number.ShouldBe(0);
//        routes[1].Nodes[1].Number.ShouldBe(2);
//        routes[1].Nodes[2].Number.ShouldBe(3);
//    }

//    [Fact]
//    public void RoutesToDeadEndsWithWithMoreWays()
//    {
//        var tree = new Tree();
//        tree.LinkFrom(0).To(1).To(2);
//        tree.LinkFrom(1).To(3).To(4);
//        tree.LinkFrom(2).To(5);
//        tree.LinkFrom(3).To(6);
//        tree.LinkFrom(4).To(6);
//        tree.LinkFrom(5).To(6);

//        var routes = tree.GetRoutesFromStartToDeadEnds().ToList();
//        routes.Count.ShouldBe(3);
//        routes[0].NodesNumber().ShouldBe(4);
//        routes[0].Nodes[0].Number.ShouldBe(0);
//        routes[0].Nodes[1].Number.ShouldBe(1);
//        routes[0].Nodes[2].Number.ShouldBe(3);
//        routes[0].Nodes[3].Number.ShouldBe(6);
//        routes[1].NodesNumber().ShouldBe(4);
//        routes[1].Nodes[0].Number.ShouldBe(0);
//        routes[1].Nodes[1].Number.ShouldBe(1);
//        routes[1].Nodes[2].Number.ShouldBe(4);
//        routes[1].Nodes[3].Number.ShouldBe(6);
//        routes[2].Nodes[0].Number.ShouldBe(0);
//        routes[2].Nodes[1].Number.ShouldBe(2);
//        routes[2].Nodes[2].Number.ShouldBe(5);
//        routes[2].Nodes[3].Number.ShouldBe(6);
//    }

//    [Fact]
//    public void RoutesToDeadEndsWithWithCycle()
//    {
//        var tree = new Tree();
//        tree.LinkFrom(0).To(1);
//        tree.LinkFrom(1).To(2);
//        tree.LinkFrom(1).To(0);

//        var routes = tree.GetRoutesFromStartToDeadEnds().ToList();
//        routes.Count.ShouldBe(1);
//        routes[0].NodesNumber().ShouldBe(3);
//        routes[0].Nodes[0].Number.ShouldBe(0);
//        routes[0].Nodes[1].Number.ShouldBe(1);
//        routes[0].Nodes[2].Number.ShouldBe(2);
//    }

//    [Fact]
//    public void EnumerateSimpleRoute()
//    {
//        var tree = new Tree();
//        tree.LinkFrom(0).To(1).Then(2);

//        var expectedStringRoutes = new List<string>
//        {
//            "0 1 2"
//        };

//        var routes = tree.GetRoutesFromStartToDeadEnds();

//        var routeCount = 0;
//        foreach (var allNodesRoute in tree.GetRoutesFromStartToDeadEnds())
//        {
//            routeCount++;
//            var founded = expectedStringRoutes.FirstOrDefault(str => str == allNodesRoute.ToString());
//            founded.ShouldNotBeNull();
//            expectedStringRoutes.Remove(founded);
//        }
//        routeCount.ShouldBe(1);
//    }

//    [Fact]
//    public void RoutesWithComplexTree0()
//    {
//        var tree = new Tree();
//        tree.LinkFromOriginTo(1)
//            .NextTo(2, 11)
//            .NextTo(1, 3, 12)
//            .NextTo(2, 4, 14)
//            .NextTo(3, 9)
//            .NextTo(6, 17)
//            .NextTo(5, 7, 8)
//            .NextTo(6, 13)
//            .NextTo(6, 9, 18)
//            .NextTo(4, 8)
//            .NextTo(11, 16)
//            .NextTo(10, 12)
//            .NextTo(11, 13, 2)
//            .NextTo(7, 12, 15)
//            .NextTo(3, 15, 19)
//            .NextTo(13, 14, 20)
//            .NextTo(10, 17)
//            .NextTo(16, 5, 18)
//            .NextTo(17, 8, 19)
//            .NextTo(18, 14, 20)
//            .NextTo(21, 15, 19);

//        var expectedStringRoutesWithAllNodes = new List<string>
//        {
//            "0 1 2 12 11 10 16 17 5 6 7 13 15 14 3 4 9 8 18 19 20 21",
//            "0 1 11 10 16 17 5 6 7 13 12 2 3 4 9 8 18 19 14 15 20 21",
//        };
//        var expectedRoutesCount = expectedStringRoutesWithAllNodes.Count;

//        var routeCount = 0;
//        foreach (var allNodesRoute in tree.GetRoutesFromStartToDeadEnds().Where(r => r.NodesNumber() == tree.NodesNumber()))
//        {
//            routeCount++;
//            var founded = expectedStringRoutesWithAllNodes.FirstOrDefault(str => str == allNodesRoute.ToString());
//            founded.ShouldNotBeNull();
//            expectedStringRoutesWithAllNodes.Remove(founded);
//        }
//        routeCount.ShouldBe(expectedRoutesCount);
//    }

//    [Fact]
//    public void RoutesWithComplexTree1()
//    {
//        var tree = new Tree();
//        tree.LinkFromOriginTo(1)
//            .NextTo(0, 2, 24)
//            .NextTo(1, 3, 21)
//            .NextTo(2, 4, 25)
//            .NextTo(3, 5, 17)
//            .NextTo(4, 11)
//            .NextTo(7, 20)
//            .NextTo(6, 8, 15)
//            .NextTo(7, 9, 16)
//            .NextTo(8, 13)
//            .NextTo(11, 14)
//            .NextTo(10, 5, 12)
//            .NextTo(11, 13, 23)
//            .NextTo(12, 9, 19)
//            .NextTo(10, 15)
//            .NextTo(14, 7, 16)
//            .NextTo(15, 8, 17)
//            .NextTo(16, 4, 18)
//            .NextTo(17, 19, 22)
//            .NextTo(18, 13, 26)
//            .NextTo(6, 21)
//            .NextTo(20, 2, 22)
//            .NextTo(21, 18, 23)
//            .NextTo(22, 12)
//            .NextTo(1, 25)
//            .NextTo(24, 3, 26)
//            .NextTo(25, 19, 27);

//        var expectedStringRoutesWithAllNodes = new List<string>
//        {
//            "0 1 24 25 3 2 21 20 6 7 15 14 10 11 5 4 17 16 8 9 13 12 23 22 18 19 26 27"
//        };
//        var expectedRoutesCount = expectedStringRoutesWithAllNodes.Count;

//        var routeCount = 0;
//        foreach (var allNodesRoute in tree.GetRoutesFromStartToDeadEnds().Where(r => r.NodesNumber() == tree.NodesNumber()))
//        {
//            routeCount++;
//            var founded = expectedStringRoutesWithAllNodes.FirstOrDefault(str => str == allNodesRoute.ToString());
//            founded.ShouldNotBeNull();
//            expectedStringRoutesWithAllNodes.Remove(founded);
//        }
//        routeCount.ShouldBe(expectedRoutesCount);
//    }

//    [Fact]
//    public void RoutesWithComplexTree2()
//    {
//        var tree = new Tree();
//        tree.LinkFromOriginTo(1)
//            .NextTo(0, 2, 16)
//            .NextTo(1, 3, 23)
//            .NextTo(2, 4, 13)
//            .NextTo(3, 5, 18)
//            .NextTo(4, 7)
//            .NextTo(7, 21)
//            .NextTo(6, 5, 15)
//            .NextTo(9, 12)
//            .NextTo(8, 17)
//            .NextTo(11, 22)
//            .NextTo(10, 20)
//            .NextTo(8, 13, 26)
//            .NextTo(12, 3, 14, 21)
//            .NextTo(13, 15, 25)
//            .NextTo(14, 7, 19)
//            .NextTo(1, 17)
//            .NextTo(16, 9, 18)
//            .NextTo(17, 4, 19, 27)
//            .NextTo(18, 15, 29)
//            .NextTo(11, 21, 31)
//            .NextTo(20, 6)
//            .NextTo(10, 23)
//            .NextTo(22, 2, 24, 32)
//            .NextTo(23, 13, 25, 33)
//            .NextTo(24, 14, 28)
//            .NextTo(12, 27, 30)
//            .NextTo(26, 18, 28, 34)
//            .NextTo(27, 25, 29, 36)
//            .NextTo(28, 19)
//            .NextTo(26, 31)
//            .NextTo(30, 32, 37)
//            .NextTo(31, 23, 33, 38)
//            .NextTo(32, 24, 34)
//            .NextTo(33, 27, 35)
//            .NextTo(34, 29)
//            .NextTo(28, 39)
//            .NextTo(31, 38)
//            .NextTo(37, 32);

//        var expectedStringRoutesWithAllNodes = new List<string>
//        {
//            "0 1 16 17 9 8 12 13 3 2 23 22 10 11 20 21 6 7 5 4 18 19 15 14 25 24 33 32 38 37 31 30 26 27 34 35 29 28 36 39",
//            "0 1 16 17 9 8 12 26 30 31 37 38 32 33 24 13 3 2 23 22 10 11 20 21 6 7 5 4 18 27 34 35 29 19 15 14 25 28 36 39",
//            "0 1 16 17 9 8 12 26 30 31 37 38 32 33 34 35 29 19 15 14 25 24 13 3 2 23 22 10 11 20 21 6 7 5 4 18 27 28 36 39",
//        };
//        var expectedRoutesCount = expectedStringRoutesWithAllNodes.Count;

//        var routeCount = 0;
//        foreach (var allNodesRoute in tree.GetRoutesFromStartToDeadEnds().Where(r => r.NodesNumber() == tree.NodesNumber()))
//        {
//            routeCount++;
//            var founded = expectedStringRoutesWithAllNodes.FirstOrDefault(str => str == allNodesRoute.ToString());
//            founded.ShouldNotBeNull();
//            expectedStringRoutesWithAllNodes.Remove(founded);
//        }
//        routeCount.ShouldBe(expectedRoutesCount);
//    }
//}
