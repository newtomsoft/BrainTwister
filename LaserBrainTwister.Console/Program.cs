using LaserBrainTwister.Domain;
using LaserBrainTwister.Domain.Trees;

#region tree0
ITree tree = new Tree();
tree.LinkFromOriginTo(1)
    .NextTo(2, 11)
    .NextTo(1, 3, 12)
    .NextTo(2, 4, 14)
    .NextTo(3, 9)
    .NextTo(6, 17)
    .NextTo(5, 7, 8)
    .NextTo(6, 13)
    .NextTo(6, 9, 18)
    .NextTo(4, 8)
    .NextTo(11, 16)
    .NextTo(10, 12)
    .NextTo(11, 13, 2)
    .NextTo(7, 12, 15)
    .NextTo(3, 15, 19)
    .NextTo(13, 14, 20)
    .NextTo(10, 17)
    .NextTo(16, 5, 18)
    .NextTo(17, 8, 19)
    .NextTo(18, 14, 20)
    .NextTo(21, 15, 19);

var routesCount = 0;
var routesWithAllNodesCount = 0;
Console.WriteLine("Tree 0:");
foreach (var routeWithAllNodes in tree.GetRoutesFromStartToDeadEnds())
{
    if (routeWithAllNodes.Nodes.Count == tree.Nodes.Count)
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
tree = new Tree();
tree.LinkFromOriginTo(1)
    .NextTo(0, 2, 24)
    .NextTo(1, 3, 21)
    .NextTo(2, 4, 25)
    .NextTo(3, 5, 17)
    .NextTo(4, 11)
    .NextTo(7, 20)
    .NextTo(6, 8, 15)
    .NextTo(7, 9, 16)
    .NextTo(8, 13)
    .NextTo(11, 14)
    .NextTo(10, 5, 12)
    .NextTo(11, 13, 23)
    .NextTo(12, 9, 19)
    .NextTo(10, 15)
    .NextTo(14, 7, 16)
    .NextTo(15, 8, 17)
    .NextTo(16, 4, 18)
    .NextTo(17, 19, 22)
    .NextTo(18, 13, 26)
    .NextTo(6, 21)
    .NextTo(20, 2, 22)
    .NextTo(21, 18, 23)
    .NextTo(22, 12)
    .NextTo(1, 25)
    .NextTo(24, 3, 26)
    .NextTo(25, 19, 27);

var routes = tree.GetRoutesFromStartToDeadEnds().ToList();
var allNodesRoutes = routes.Where(r => r.Nodes.Count == tree.Nodes.Count).ToList();
Console.WriteLine("Tree 1:");
foreach (var route in allNodesRoutes)
    Console.WriteLine($"Possible solution : {route}");
if (allNodesRoutes.Count == 0)
{
    var longestRoute = routes.MaxBy(r => r.Nodes.Count);
    Console.WriteLine($"No route found that passe by all nodes. The longest is : {longestRoute}");
}
Console.WriteLine($"{routesWithAllNodesCount} routes with all nodes / {routesCount} total routes");
Console.WriteLine("");
#endregion

#region tree2
tree = new Tree();
tree.LinkFromOriginTo(1)
    .NextTo(0, 2, 16)
    .NextTo(1, 3, 23)
    .NextTo(2, 4, 13)
    .NextTo(3, 5, 18)
    .NextTo(4, 7)
    .NextTo(7, 21)
    .NextTo(6, 5, 15)
    .NextTo(9, 12)
    .NextTo(8, 17)
    .NextTo(11, 22)
    .NextTo(10, 20)
    .NextTo(8, 13, 26)
    .NextTo(12, 3, 14, 21)
    .NextTo(13, 15, 25)
    .NextTo(14, 7, 19)
    .NextTo(1, 17)
    .NextTo(16, 9, 18)
    .NextTo(17, 4, 19, 27)
    .NextTo(18, 15, 29)
    .NextTo(11, 21, 31)
    .NextTo(20, 6)
    .NextTo(10, 23)
    .NextTo(22, 2, 24, 32)
    .NextTo(23, 13, 25, 33)
    .NextTo(24, 14, 28)
    .NextTo(12, 27, 30)
    .NextTo(26, 18, 28, 34)
    .NextTo(27, 25, 29, 36)
    .NextTo(28, 19)
    .NextTo(26, 31)
    .NextTo(30, 32, 37)
    .NextTo(31, 23, 33, 38)
    .NextTo(32, 24, 34)
    .NextTo(33, 27, 35)
    .NextTo(34, 29)
    .NextTo(28, 39)
    .NextTo(31, 38)
    .NextTo(37, 32);

routesCount = 0;
routesWithAllNodesCount = 0;
Console.WriteLine("Tree 2 :");
foreach (var routeWithAllNodes in tree.GetRoutesFromStartToDeadEnds())
{
    if (routeWithAllNodes.Nodes.Count == tree.Nodes.Count)
    {
        Console.WriteLine($"Possible solution : {routeWithAllNodes}");
        routesWithAllNodesCount++;
    }
    routesCount++;
}
Console.WriteLine($"{routesWithAllNodesCount} routes with all nodes / {routesCount} total routes");
Console.WriteLine("");
#endregion 

#region tree3
var grid = new Grid();
var coordinates = new List<Coordinate>
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
grid.SetStartCoordinate(new Coordinate(0, 0));
grid.SetEndCoordinate(new Coordinate(13, 11));

var treeWithCoordinate = grid.GenerateTree();
routesCount = 0;
routesWithAllNodesCount = 0;
Console.WriteLine("Tree 3 :");
foreach (var routeWithAllNodes in treeWithCoordinate.GetRoutesFromStartToDeadEnds())
{
    if (routeWithAllNodes.Nodes.Count == tree.Nodes.Count)
    {
        Console.WriteLine($"Possible solution : {routeWithAllNodes}");
        routesWithAllNodesCount++;
    }
    routesCount++;
}
Console.WriteLine($"{routesWithAllNodesCount} routes with all nodes / {routesCount} total routes");
Console.WriteLine("");
#endregion

#region tree3bis
grid = new Grid();
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
grid.SetStartCoordinate(new Coordinate(0, 0));
grid.SetEndCoordinate(new Coordinate(13, 11));

treeWithCoordinate = grid.GenerateTree();
routesCount = 0;
routesWithAllNodesCount = 0;
Console.WriteLine("Tree 3 bis :");
foreach (var routeWithAllNodes in treeWithCoordinate.GetRoutesFromStartToDeadEnds(true))
{
    if (routeWithAllNodes.Nodes.Count == tree.Nodes.Count)
    {
        Console.WriteLine($"Possible solution : {routeWithAllNodes}");
        routesWithAllNodesCount++;
    }
    routesCount++;
}
Console.WriteLine($"{routesWithAllNodesCount} routes with all nodes / {routesCount} total routes");
Console.WriteLine("");
#endregion

#region tree4
tree = new Tree();
tree.LinkFromOriginTo(1)
    .NextTo(0, 2, 15)
    .NextTo(1, 3, 20)
    .NextTo(2, 4, 11)
    .NextTo(3, 5, 16)
    .NextTo(4, 6, 22)
    .NextTo(5, 17)
    .NextTo(8, 12)
    .NextTo(7, 9, 19)
    .NextTo(8, 10, 25)
    .NextTo(9, 11, 26)
    .NextTo(10, 3, 21)
    .NextTo(7, 13)
    .NextTo(12, 14, 18)
    .NextTo(13, 15, 40)
    .NextTo(14, 1, 16, 23)
    .NextTo(15, 4, 17, 28)
    .NextTo(16, 6, 34)
    .NextTo(13, 19)
    .NextTo(18, 8, 20, 24)
    .NextTo(19, 2, 21)
    .NextTo(20, 11, 22, 27)
    .NextTo(21, 5, 32)
    .NextTo(15, 24, 36)
    .NextTo(23, 19, 25, 37)
    .NextTo(24, 9, 26, 29)
    .NextTo(25, 10, 27, 30)
    .NextTo(26, 21, 28, 31)
    .NextTo(27, 16, 38)
    .NextTo(25, 30, 42)
    .NextTo(29, 26, 31, 43)
    .NextTo(30, 27, 32, 44)
    .NextTo(31, 22, 33, 45)
    .NextTo(32, 34, 46)
    .NextTo(33, 47)
    .NextTo(36, 39)
    .NextTo(35, 23, 37, 41)
    .NextTo(36, 24, 38)
    .NextTo(37, 28)
    .NextTo(35, 40)
    .NextTo(39, 14, 41)
    .NextTo(40, 36, 42)
    .NextTo(41, 29, 43)
    .NextTo(42, 30, 44)
    .NextTo(43, 31, 45)
    .NextTo(44, 32, 46)
    .NextTo(45, 33, 47)
    .NextTo(46, 34, 48);

routesCount = 0;
routesWithAllNodesCount = 0;
Console.WriteLine("Tree 4 :");
foreach (var routeWithAllNodes in tree.GetRoutesFromStartToDeadEnds())
{
    if (routeWithAllNodes.Nodes.Count == tree.Nodes.Count)
    {
        Console.WriteLine($"Possible solution : {routeWithAllNodes}");
        routesWithAllNodesCount++;
    }
    routesCount++;
}
Console.WriteLine($"{routesWithAllNodesCount} routes with all nodes / {routesCount} total routes");
Console.WriteLine("");
#endregion

#region tree4 with coordinates
grid = new Grid();
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
grid.SetDefaultStartCoordinate();
grid.SetDefaultEndCoordinate();
treeWithCoordinate = grid.GenerateTree();
routesCount = 0;
routesWithAllNodesCount = 0;
Console.WriteLine("Tree 4 with coordinates :");
foreach (var routeWithAllNodes in treeWithCoordinate.GetRoutesFromStartToDeadEnds(true))
{
    if (routeWithAllNodes.Nodes.Count == tree.Nodes.Count)
    {
        Console.WriteLine($"Possible solution : {routeWithAllNodes}");
        routesWithAllNodesCount++;
    }
    routesCount++;
}
Console.WriteLine($"{routesWithAllNodesCount} routes with all nodes / {routesCount} total routes");
Console.WriteLine("");

#endregion

#region tree5
tree = new Tree();
tree.LinkFromOriginTo(1)
     .NextTo(2, 8)
     .NextTo(1, 3, 20)
     .NextTo(2, 4, 21)
     .NextTo(3, 5, 18)
     .NextTo(4, 6, 29)
     .NextTo(5, 25)
     .NextTo(8, 19)
     .NextTo(7, 1, 9, 15)
     .NextTo(8, 10, 16)
     .NextTo(9, 11, 17)
     .NextTo(10, 12, 36)
     .NextTo(11, 13, 23)
     .NextTo(12, 14, 24)
     .NextTo(13, 31)
     .NextTo(8, 16, 33)
     .NextTo(15, 9, 17, 42)
     .NextTo(16, 10, 18, 28)
     .NextTo(17, 4, 22)
     .NextTo(7, 20, 26)
     .NextTo(19, 2, 21, 34)
     .NextTo(20, 3, 22, 27)
     .NextTo(21, 18, 23, 37)
     .NextTo(22, 12, 24, 38)
     .NextTo(23, 13, 25, 40)
     .NextTo(24, 6, 30)
     .NextTo(19, 27, 32)
     .NextTo(26, 21, 28, 35)
     .NextTo(27, 17, 29, 43)
     .NextTo(28, 5, 30, 39)
     .NextTo(29, 25, 31, 52)
     .NextTo(30, 14, 47)
     .NextTo(26, 33)
     .NextTo(32, 15, 34)
     .NextTo(33, 20, 35, 50)
     .NextTo(34, 27, 36, 51)
     .NextTo(35, 11, 37)
     .NextTo(36, 22, 38)
     .NextTo(37, 23, 39, 44)
     .NextTo(38, 29, 40, 45)
     .NextTo(39, 24, 46)
     .NextTo(42, 49)
     .NextTo(41, 16, 43, 55)
     .NextTo(42, 28, 44)
     .NextTo(43, 38, 45)
     .NextTo(44, 39, 46, 56)
     .NextTo(45, 40, 47, 57)
     .NextTo(46, 31, 48, 53)
     .NextTo(47, 54)
     .NextTo(41, 50)
     .NextTo(49, 34, 51)
     .NextTo(50, 35, 52)
     .NextTo(51, 30, 53)
     .NextTo(52, 47, 54, 58)
     .NextTo(53, 48, 59)
     .NextTo(42, 56)
     .NextTo(55, 45, 57)
     .NextTo(56, 46, 58)
     .NextTo(57, 53, 59)
     .NextTo(58, 54, 60);

routesCount = 0;
routesWithAllNodesCount = 0;
Console.WriteLine("Tree 5 :");
foreach (var routeWithAllNodes in tree.GetRoutesFromStartToDeadEnds())
{
    if (routeWithAllNodes.Nodes.Count == tree.Nodes.Count)
    {
        Console.WriteLine($"Possible solution : {routeWithAllNodes}");
        routesWithAllNodesCount++;
    }
    routesCount++;
}

Console.WriteLine($"{routesWithAllNodesCount} routes with all nodes / {routesCount} total routes");
Console.WriteLine("");
#endregion