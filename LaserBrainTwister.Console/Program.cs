using LaserBrainTwister.Domain;


#region tree0
var grid = new CoordinatesGrid();
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

var tree = grid.GenerateTree();
var routesCount = 0;
var routesWithAllNodesCount = 0;
Console.WriteLine("Tree 0 :");
foreach (var routeWithAllNodes in tree.GetRoutes())
{
    if (routeWithAllNodes.NodesNumber() == tree.NodesNumber())
    {
        Console.WriteLine($"Possible solution : {routeWithAllNodes}");
        routesWithAllNodesCount++;
    }
    routesCount++;
}
Console.WriteLine($"{routesWithAllNodesCount} routes with all nodes / {routesCount} total routes");
Console.WriteLine("");
#endregion

#region tree1
grid = new CoordinatesGrid();
coordinates = new List<Coordinate>
{
    Coordinate.From(0, 0), Coordinate.From(4, 0), Coordinate.From(5, 0), Coordinate.From(7, 0), Coordinate.From(9, 0), Coordinate.From(12, 0),
    Coordinate.From(8, 1), Coordinate.From(12, 1),
    Coordinate.From(2, 2), Coordinate.From(6, 2),
    Coordinate.From(1, 3), Coordinate.From(3, 3), Coordinate.From(2, 4),
    Coordinate.From(7, 4), Coordinate.From(10, 4), Coordinate.From(12, 4),
    Coordinate.From(4, 5), Coordinate.From(6, 5), Coordinate.From(9, 5), Coordinate.From(12, 5),
    Coordinate.From(3, 6), Coordinate.From(8, 6), Coordinate.From(1, 7),
    Coordinate.From(5, 7), Coordinate.From(7, 7), Coordinate.From(10, 7),
    Coordinate.From(2, 8), Coordinate.From(9, 8), Coordinate.From(11, 8), Coordinate.From(12, 8),
    Coordinate.From(2, 9), Coordinate.From(3, 9), Coordinate.From(5, 9), Coordinate.From(7, 9), Coordinate.From(9, 9), Coordinate.From(12, 9),
    Coordinate.From(3, 10), Coordinate.From(5, 10),
    Coordinate.From(11, 11), Coordinate.From(13, 11),
};
grid.SwitchCoordinatesStatus(coordinates);

tree = grid.GenerateTree();
routesCount = 0;
routesWithAllNodesCount = 0;
Console.WriteLine("Tree 1 :");
foreach (var routeWithAllNodes in tree.GetRoutes(true))
{
    if (routeWithAllNodes.NodesNumber() == tree.NodesNumber())
    {
        Console.WriteLine($"Possible solution : {routeWithAllNodes}");
        routesWithAllNodesCount++;
    }
    routesCount++;
}
Console.WriteLine($"{routesWithAllNodesCount} routes with all nodes / {routesCount} total routes");
Console.WriteLine("");
#endregion

#region tree2
grid = new CoordinatesGrid();
coordinates = new List<Coordinate>
{
    Coordinate.From(-1, 0), Coordinate.From(4, 0), Coordinate.From(8, 0), Coordinate.From(13, 0),
    Coordinate.From(1, 1), Coordinate.From(3, 1), Coordinate.From(6, 1), Coordinate.From(8, 1), Coordinate.From(10, 1), Coordinate.From(12, 1),
    Coordinate.From(2, 2), Coordinate.From(5, 2), Coordinate.From(8, 2), Coordinate.From(10, 2), Coordinate.From(11, 2),
    Coordinate.From(3, 3), Coordinate.From(10, 3),
    Coordinate.From(0, 4), Coordinate.From(6, 4),
    Coordinate.From(2, 5), Coordinate.From(13, 5),
    Coordinate.From(2, 6), Coordinate.From(4, 6), Coordinate.From(7, 6), Coordinate.From(10, 6), Coordinate.From(12, 6), Coordinate.From(13, 6),
    Coordinate.From(0, 7), Coordinate.From(1, 7), Coordinate.From(5, 7), Coordinate.From(8, 7), Coordinate.From(9, 7), Coordinate.From(11, 7),
    Coordinate.From(0, 8), Coordinate.From(1, 8), Coordinate.From(2, 8), Coordinate.From(7, 8), Coordinate.From(11, 8), Coordinate.From(13, 8),
    Coordinate.From(1, 9), Coordinate.From(4, 9),
    Coordinate.From(0, 10), Coordinate.From(9, 10), Coordinate.From(11, 10), Coordinate.From(14, 10),
};
grid.SwitchCoordinatesStatus(coordinates);
tree = grid.GenerateTree();

Console.WriteLine("Tree 2 :");
routesWithAllNodesCount = 0;
foreach (var routeWithAllNodes in tree.GetRoutesWithAllNodes())
{
    Console.WriteLine($"Possible route with all nodes : {routeWithAllNodes}");
    routesWithAllNodesCount++;
}
Console.WriteLine($"{routesWithAllNodesCount} routes with all nodes");
Console.WriteLine("");
var shortestRoute = tree.GetRouteWithLeastNodes();
Console.WriteLine($"Shortest solution : {shortestRoute}");

#endregion

#region tree3
grid = new CoordinatesGrid();
coordinates = new List<Coordinate>
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
tree = grid.GenerateTree();
routesCount = 0;
routesWithAllNodesCount = 0;
Console.WriteLine("Tree 3 :");
foreach (var routeWithAllNodes in tree.GetRoutes(true))
{
    if (routeWithAllNodes.NodesNumber() == tree.NodesNumber())
    {
        Console.WriteLine($"Possible solution : {routeWithAllNodes}");
        routesWithAllNodesCount++;
    }
    routesCount++;
}
Console.WriteLine($"{routesWithAllNodesCount} routes with all nodes / {routesCount} total routes");
Console.WriteLine("");

#endregion
