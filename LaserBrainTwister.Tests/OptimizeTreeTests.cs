namespace LaserBrainTwister.Tests;

public class OptimizeTreeTests
{
    [Fact]
    public void OptimizeRoutes1()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(2, 0),
            Coordinate.From(1, 1), Coordinate.From(2, 1), Coordinate.From(3, 1),
            Coordinate.From(3, 2),

        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();
        var routes = tree.OptimizeRoutes();
        routes.Count.ShouldBe(1);
        routes[0].ToString().ShouldBe("(0,0) (2,0) (2,1) (3,1) (3,2)");
    }

    [Fact]
    public void OptimizeRoutes2()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(4, 0),
            Coordinate.From(1, 1),
            Coordinate.From(4, 2), Coordinate.From(1, 2), Coordinate.From(6, 2),

        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();
        var routes = tree.OptimizeRoutes();
        routes.Count.ShouldBe(1);
        routes[0].ToString().ShouldBe("(0,0) (4,0) (4,2) (1,2) (1,1)");
    }

    [Fact]
    public void OptimizeRoutes3()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(2, 0), Coordinate.From(4, 0), Coordinate.From(6, 0),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();
        var routes = tree.OptimizeRoutes();
        routes.Count.ShouldBe(1);
        routes[0].ToString().ShouldBe("(0,0) (2,0) (4,0) (6,0)");
    }

    [Fact]
    public void OptimizeRoutes4()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(2, 0), Coordinate.From(4, 0), Coordinate.From(7, 0), Coordinate.From(9, 0),
            Coordinate.From(1, 1), Coordinate.From(4, 1), Coordinate.From(9, 1),
            Coordinate.From(1, 2), Coordinate.From(3, 2), Coordinate.From(9, 2),
            Coordinate.From(3, 3), Coordinate.From(4, 3),
            Coordinate.From(4, 5), Coordinate.From(7, 5), Coordinate.From(9, 5),
            Coordinate.From(4, 6),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();
        var routes = tree.OptimizeRoutes();

        routes.Count.ShouldBe(1);
        routes[0].ToString().ShouldBe("(0,0) (2,0) (4,0) (7,0) (9,0) (9,1) (9,2) (9,5) (7,5) (4,5) (4,3) (3,3) (3,2) (1,2) (1,1) (4,1)");
    }

    [Fact]
    public void OptimizeRoutes5()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(2, 0), Coordinate.From(4, 0), Coordinate.From(7, 0), Coordinate.From(9, 0),
            Coordinate.From(1, 1), Coordinate.From(4, 1), Coordinate.From(6, 1), Coordinate.From(9, 1),
            Coordinate.From(1, 2), Coordinate.From(3, 2), Coordinate.From(9, 2),
            Coordinate.From(3, 3), Coordinate.From(4, 3),
            Coordinate.From(4, 5), Coordinate.From(7, 5), Coordinate.From(9, 5),
            Coordinate.From(4, 6), Coordinate.From(6, 6),
            Coordinate.From(4, 7), Coordinate.From(12, 7),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();
        var routes = tree.OptimizeRoutes();

        routes.Count.ShouldBe(1);
        routes[0].ToString().ShouldBe(tree.GetLongestRoute().ToString());
    }

    [Fact]
    public void OptimizeRoutes6()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(5, 0), Coordinate.From(8, 0), Coordinate.From(10, 0), Coordinate.From(12, 0), Coordinate.From(13, 0), Coordinate.From(15, 0),
            Coordinate.From(6, 1), Coordinate.From(7, 1), Coordinate.From(9, 1), Coordinate.From(10, 1),
            Coordinate.From(1, 2), Coordinate.From(3, 2), Coordinate.From(4, 2), Coordinate.From(5, 2), Coordinate.From(12, 2), Coordinate.From(15, 2),
            Coordinate.From(3, 3), Coordinate.From(6, 3), Coordinate.From(8, 3), Coordinate.From(10, 3), Coordinate.From(13, 3),
            Coordinate.From(5, 4), Coordinate.From(6, 4), Coordinate.From(7, 4), Coordinate.From(9, 4), Coordinate.From(10, 4), Coordinate.From(12, 4),
            Coordinate.From(7, 5), Coordinate.From(9, 5), Coordinate.From(10, 5), Coordinate.From(13, 5), Coordinate.From(14, 5), Coordinate.From(15, 5),
            Coordinate.From(2, 6), Coordinate.From(5, 6), Coordinate.From(6, 6), Coordinate.From(12, 6),
            Coordinate.From(2, 7), Coordinate.From(4, 7), Coordinate.From(5, 7), Coordinate.From(7, 7), Coordinate.From(9, 7), Coordinate.From(10, 7), Coordinate.From(13, 7), Coordinate.From(14, 7), Coordinate.From(15, 7),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();
        var routes = tree.OptimizeRoutes();

    }
}
