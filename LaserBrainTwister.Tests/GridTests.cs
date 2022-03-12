using System.Diagnostics;

namespace LaserBrainTwister.Tests;

public class GridTests
{
    [Fact]
    public void IsActivatedTest()
    {
        var grid = new Grid();
        var coordinate = Coordinate.From(0, 0);
        grid.SwitchCoordinateStatus(coordinate);
        grid.IsEnable(coordinate).ShouldBeTrue();
        grid.ToString().ShouldBe("1 nodes");

        grid.SwitchCoordinateStatus(coordinate);
        grid.IsEnable(coordinate).ShouldBeFalse();
        grid.ToString().ShouldBe("0 nodes");
    }

    [Fact]
    public void GridWithoutStartNode()
    {
        var grid = new Grid();
        grid.SetEndCoordinate(new Coordinate(0, 0));
        var action = () => grid.GenerateTree();
        action.ShouldThrow<ArgumentException>().Message.ShouldBe("Start not defined");
    }

    [Fact]
    public void GridWithoutEndNode()
    {
        var grid = new Grid();
        grid.SetStartCoordinate(new Coordinate(0, 0));
        var action = () => grid.GenerateTree();
        action.ShouldThrow<ArgumentException>().Message.ShouldBe("End not defined"); ;
    }

    [Fact]
    public void GridWithOnlyStartAndEndNode()
    {
        var grid = new Grid();
        var startCoordinate = Coordinate.From(0, 0);
        var endCoordinate = Coordinate.From(1, 0);
        grid.SetStartCoordinate(startCoordinate);
        grid.SetEndCoordinate(endCoordinate);
        var tree = grid.GenerateTree();
        tree.NodesNumber().ShouldBe(2);
        tree.Nodes[0].Id.ShouldBe(0);
        tree.Nodes[0].Item.ShouldBe(startCoordinate);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].Id.ShouldBe(1);
        tree.Nodes[1].Id.ShouldBe(1);
        tree.Nodes[1].Item.ShouldBe(endCoordinate);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[1].LinkedNodes[0].Id.ShouldBe(0);
        tree.GetRouteWithMostNodes()!.Nodes.Count.ShouldBe(2);
        tree.GetRouteWithMostNodes()!.Nodes[0].Item.ToString().ShouldBe("(0,0)");
        tree.GetRouteWithMostNodes()!.Nodes[1].Item.ToString().ShouldBe("(1,0)");
    }

    [Fact]
    public void GridWithOnlyDefaultStartAndEndNode()
    {
        var grid = new Grid();
        var startCoordinate = Coordinate.From(0, 0);
        var endCoordinate = Coordinate.From(1, 0);
        var coordinates = new List<Coordinate> { startCoordinate, endCoordinate };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();
        var tree = grid.GenerateTree();
        tree.NodesNumber().ShouldBe(2);
        tree.Nodes[0].Id.ShouldBe(0);
        tree.Nodes[0].Item.ShouldBe(startCoordinate);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].Id.ShouldBe(1);
        tree.Nodes[1].Id.ShouldBe(1);
        tree.Nodes[1].Item.ShouldBe(endCoordinate);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[1].LinkedNodes[0].Id.ShouldBe(0);
        tree.GetRouteWithMostNodes()!.Nodes.Count.ShouldBe(2);
        tree.GetRouteWithMostNodes()!.Nodes[0].Item.ToString().ShouldBe("(0,0)");
        tree.GetRouteWithMostNodes()!.Nodes[1].Item.ToString().ShouldBe("(1,0)");
    }

    [Fact]
    public void GridWith3Nodes()
    {
        var grid = new Grid();
        var startCoordinate = Coordinate.From(0, 0);
        var coordinates = new List<Coordinate> { Coordinate.From(0, 10), };
        var endCoordinate = Coordinate.From(10, 10);
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetStartCoordinate(startCoordinate);
        grid.SetEndCoordinate(endCoordinate);

        var tree = grid.GenerateTree();
        tree.NodesNumber().ShouldBe(3);
        tree.Nodes[0].Id.ShouldBe(0);
        tree.Nodes[0].Item.ShouldBe(startCoordinate);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].Id.ShouldBe(1);
        tree.Nodes[1].Id.ShouldBe(1);
        tree.Nodes[1].Item.ShouldBe(coordinates[0]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[1].LinkedNodes[0].Id.ShouldBe(0);
        tree.Nodes[1].LinkedNodes[1].Id.ShouldBe(2);
        tree.Nodes[2].Id.ShouldBe(2);
        tree.Nodes[2].Item.ShouldBe(endCoordinate);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[2].LinkedNodes[0].Id.ShouldBe(1);
    }

    [Fact]
    public void GridWith4Nodes()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0,  2),
            Coordinate.From(10,  2),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetStartCoordinate(new Coordinate(0, 0));
        grid.SetEndCoordinate(new Coordinate(10, 10));

        var tree = grid.GenerateTree();
        tree.NodesNumber().ShouldBe(4);
        tree.Nodes[0].Id.ShouldBe(0);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].Id.ShouldBe(1);
        tree.Nodes[1].Id.ShouldBe(1);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[1].LinkedNodes[0].Id.ShouldBe(0);
        tree.Nodes[1].LinkedNodes[1].Id.ShouldBe(2);
        tree.Nodes[2].Id.ShouldBe(2);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[2].LinkedNodes[0].Id.ShouldBe(1);
        tree.Nodes[2].LinkedNodes[1].Id.ShouldBe(3);
        tree.Nodes[3].Id.ShouldBe(3);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[3].LinkedNodes[0].Id.ShouldBe(2);
    }

    [Fact]
    public void GetRoutesWhenNoRouteFound()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0),
            Coordinate.From(5, 1),
            Coordinate.From(8, 4),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();
        tree.GetRoutesWithAllNodes().Count().ShouldBe(0);

        var routes = tree.GetRouteWithMostNodes();
        routes.ShouldBeNull();
    }

    [Fact]
    public void GetRoutesWhenNoRouteWithAllNodesFound()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(1, 0), Coordinate.From(2, 0),
            Coordinate.From(1, 1),
            Coordinate.From(2, 2),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();
        tree.GetRoutesWithAllNodes().Count().ShouldBe(0);
        tree.GetRouteWithMostNodes()!.ToString().ShouldBe("(0,0) (1,0) (2,0) (2,2)");
    }

    [Fact]
    public void GetRouteWithLessNodes()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(1, 0), Coordinate.From(5, 0),
            Coordinate.From(1, 1), Coordinate.From(2, 1), Coordinate.From(3, 1), Coordinate.From(4, 1),
            Coordinate.From(2, 2), Coordinate.From(4, 2), Coordinate.From(5, 2), Coordinate.From(6, 2),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();
        const string expectedStringRoutesWithLessNodes = "(0,0) (1,0) (5,0) (5,2) (6,2)";
        tree.GetRouteWithLeastNodes()!.ToString().ShouldBe(expectedStringRoutesWithLessNodes);
    }

    [Fact]
    public void GetRoutesWithAllNodesGridWithComplexesWith12Nodes()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(3, 0), Coordinate.From(5, 0), Coordinate.From(7, 0),
            Coordinate.From(3, 1), Coordinate.From(5, 1),
            Coordinate.From(1, 2), Coordinate.From(2, 2),
            Coordinate.From(1, 3), Coordinate.From(7, 3),
            Coordinate.From(2, 4), Coordinate.From(8, 4),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();

        var expectedStringRoutesWithAllNodes = new List<string> { "(0,0) (3,0) (3,1) (5,1) (5,0) (7,0) (7,3) (1,3) (1,2) (2,2) (2,4) (8,4)", };

        foreach (var allNodesRouteFound in tree.GetRoutesWithAllNodes())
        {
            var found = expectedStringRoutesWithAllNodes.FirstOrDefault(str => str == allNodesRouteFound.ToString());
            found.ShouldNotBeNull();
            expectedStringRoutesWithAllNodes.Remove(allNodesRouteFound.ToString());
        }
        expectedStringRoutesWithAllNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void GetRoutesWithAllNodesGridWithComplexesWith29Nodes()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(2, 0),
            Coordinate.From(1, 1), Coordinate.From(3, 1), Coordinate.From(5, 1), Coordinate.From(11, 1),
            Coordinate.From(8, 2), Coordinate.From(9, 2),
            Coordinate.From(2, 3), Coordinate.From(4, 3), Coordinate.From(6, 3), Coordinate.From(10, 3),
            Coordinate.From(1, 4), Coordinate.From(2, 4), Coordinate.From(4, 4), Coordinate.From(11, 4),
            Coordinate.From(5, 5), Coordinate.From(7, 5), Coordinate.From(9, 5),
            Coordinate.From(6, 6), Coordinate.From(8, 6),
            Coordinate.From(3, 7), Coordinate.From(7, 7), Coordinate.From(9, 7), Coordinate.From(10, 7),
            Coordinate.From(2, 8), Coordinate.From(7, 8), Coordinate.From(9, 8), Coordinate.From(12, 8),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();

        var expectedStringRoutesWithAllNodes = new List<string>
        {
            "(0,0) (2,0) (2,3) (4,3) (4,4) (11,4) (11,1) (5,1) (5,5) (7,5) (9,5) (9,2) (8,2) (8,6) (6,6) (6,3) (10,3) (10,7) (9,7) (7,7) (3,7) (3,1) (1,1) (1,4) (2,4) (2,8) (7,8) (9,8) (12,8)",
        };

        foreach (var allNodesRouteFound in tree.GetRoutesWithAllNodes())
        {
            var found = expectedStringRoutesWithAllNodes.FirstOrDefault(str => str == allNodesRouteFound.ToString());
            found.ShouldNotBeNull();
            expectedStringRoutesWithAllNodes.Remove(allNodesRouteFound.ToString());
        }
        expectedStringRoutesWithAllNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void GetRoutesWithAllNodesGridWithComplexesWith29NodesRandomPlaces()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0),
            Coordinate.From(2, 0),
            Coordinate.From(1, 1),
            Coordinate.From(3, 1),
            Coordinate.From(5, 1),
            Coordinate.From(11, 1),
            Coordinate.From(8, 2),
            Coordinate.From(9, 2),
            Coordinate.From(10, 3),
            Coordinate.From(11, 4),
            Coordinate.From(6, 3),
            Coordinate.From(4, 3),
            Coordinate.From(4, 4),
            Coordinate.From(2, 3),
            Coordinate.From(2, 4),
            Coordinate.From(1, 4),
            Coordinate.From(9, 5),
            Coordinate.From(7, 5),
            Coordinate.From(5, 5),
            Coordinate.From(6, 6),
            Coordinate.From(8, 6),
            Coordinate.From(7, 7),
            Coordinate.From(7, 8),
            Coordinate.From(9, 7),
            Coordinate.From(9, 8),
            Coordinate.From(10, 7),
            Coordinate.From(2, 8),
            Coordinate.From(3, 7),
            Coordinate.From(12, 8),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();

        var expectedStringRoutesWithAllNodes = new List<string>
        {
            "(0,0) (2,0) (2,3) (4,3) (4,4) (11,4) (11,1) (5,1) (5,5) (7,5) (9,5) (9,2) (8,2) (8,6) (6,6) (6,3) (10,3) (10,7) (9,7) (7,7) (3,7) (3,1) (1,1) (1,4) (2,4) (2,8) (7,8) (9,8) (12,8)",
        };

        foreach (var allNodesRouteFound in tree.GetRoutesWithAllNodes())
        {
            var found = expectedStringRoutesWithAllNodes.FirstOrDefault(str => str == allNodesRouteFound.ToString());
            found.ShouldNotBeNull();
            expectedStringRoutesWithAllNodes.Remove(allNodesRouteFound.ToString());
        }
        expectedStringRoutesWithAllNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void GetRoutesWithAllNodesGridWithComplexesNodes()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(4, 0), Coordinate.From(5, 0), Coordinate.From(7, 0), Coordinate.From(9, 0), Coordinate.From(12, 0),
            Coordinate.From(8, 1), Coordinate.From(12, 1),
            Coordinate.From(2, 2), Coordinate.From(6, 2),
            Coordinate.From(1, 3), Coordinate.From(3, 3),
            Coordinate.From(2, 4), Coordinate.From(7, 4), Coordinate.From(10, 4), Coordinate.From(12, 4),
            Coordinate.From(4, 5), Coordinate.From(6, 5), Coordinate.From(9, 5), Coordinate.From(12, 5),
            Coordinate.From(3, 6), Coordinate.From(8, 6),
            Coordinate.From(1, 7), Coordinate.From(5, 7), Coordinate.From(7, 7), Coordinate.From(10, 7),
            Coordinate.From(2, 8), Coordinate.From(9, 8), Coordinate.From(11, 8), Coordinate.From(12, 8),
            Coordinate.From(2, 9), Coordinate.From(3, 9), Coordinate.From(5, 9), Coordinate.From(7, 9), Coordinate.From(9, 9), Coordinate.From(12, 9),
            Coordinate.From(3, 10), Coordinate.From(5, 10),
            Coordinate.From(11, 11), Coordinate.From(13, 11),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetStartCoordinate(new Coordinate(0, 0));
        grid.SetEndCoordinate(new Coordinate(13, 11));

        var tree = grid.GenerateTree();

        var expectedStringRoutesWithAllNodes = new List<string>
        {
            "(0,0) (4,0) (4,5) (6,5) (6,2) (2,2) (2,4) (7,4) (7,0) (5,0) (5,7) (1,7) (1,3) (3,3) (3,6) (8,6) (8,1) (12,1) (12,0) (9,0) (9,5) (12,5) (12,4) (10,4) (10,7) (7,7) (7,9) (5,9) (5,10) (3,10) (3,9) (2,9) (2,8) (9,8) (9,9) (12,9) (12,8) (11,8) (11,11) (13,11)",
            "(0,0) (4,0) (4,5) (6,5) (6,2) (2,2) (2,4) (2,8) (2,9) (3,9) (3,10) (5,10) (5,9) (7,9) (9,9) (12,9) (12,8) (12,5) (12,4) (10,4) (10,7) (7,7) (7,4) (7,0) (5,0) (5,7) (1,7) (1,3) (3,3) (3,6) (8,6) (8,1) (12,1) (12,0) (9,0) (9,5) (9,8) (11,8) (11,11) (13,11)",
        };

        foreach (var allNodesRouteFound in tree.GetRoutesWithAllNodes())
        {
            var found = expectedStringRoutesWithAllNodes.FirstOrDefault(str => str == allNodesRouteFound.ToString());
            found.ShouldNotBeNull();
            expectedStringRoutesWithAllNodes.Remove(allNodesRouteFound.ToString());
        }
        expectedStringRoutesWithAllNodes.Count.ShouldBe(0);
    }

    [Fact]
    public void GetRoutesWithAllNodesOptimizeFasterThanBruteForce()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(3, 0),
            Coordinate.From(4, 1), Coordinate.From(6, 1), Coordinate.From(8, 1), Coordinate.From(10, 1), Coordinate.From(12, 1),
            Coordinate.From(5, 2), Coordinate.From(8, 2), Coordinate.From(11, 2),
            Coordinate.From(4, 3), Coordinate.From(6, 3), Coordinate.From(8, 3), Coordinate.From(10, 3),
            Coordinate.From(7, 4), Coordinate.From(9, 4), Coordinate.From(12, 4),
            Coordinate.From(1, 5), Coordinate.From(5, 5), Coordinate.From(8, 5), Coordinate.From(12, 5),
            Coordinate.From(4, 6), Coordinate.From(7, 6), Coordinate.From(8, 6), Coordinate.From(12, 6),
            Coordinate.From(6, 7), Coordinate.From(9, 7),
            Coordinate.From(5, 8), Coordinate.From(10, 8), Coordinate.From(12, 8),
            Coordinate.From(4, 9), Coordinate.From(5, 9), Coordinate.From(6, 9), Coordinate.From(8, 9), Coordinate.From(11,9),
            Coordinate.From(3, 10), Coordinate.From(12, 10),
            Coordinate.From(1,11), Coordinate.From(14, 11),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();
        var sameTree = grid.GenerateTree();

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var routeOptimized = sameTree.GetRoutesWithAllNodes().ToList();
        var elapsedOptimized = stopwatch.Elapsed;

        stopwatch.Stop();
        stopwatch.Restart();
        var routeBruteForce = tree.GetRoutesWithAllNodes(true).ToList();
        var elapsedBruteForce = stopwatch.Elapsed;

        elapsedOptimized.ShouldBeLessThanOrEqualTo(elapsedBruteForce);
        routeOptimized.ToString().ShouldBe(routeBruteForce.ToString());
    }
}
