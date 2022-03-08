namespace LaserBrainTwister.Domain.Trees;

public class TwoWayTree<T> : ITree<T>
{
    public List<Node<T>> Nodes { get; } = new();

    public ISegment<T> LinkFrom(T item, int fromNodeNumber)
    {
        var fromNode = Nodes.FirstOrDefault(n => n.Number == fromNodeNumber);
        return fromNode is null
            ? new TwoWaySegment<T>(AddNode(item, fromNodeNumber), new(item, 0), this)
            : new TwoWaySegment<T>(fromNode, new(item, 0), this);
    }
    public ISegment<T> LinkFromOriginTo(T item, int nodeNumber) => LinkFrom(item, 0).To(item, nodeNumber);

    public IEnumerable<Route<T>> GetRoutesFromStartToDeadEnds(bool bruteForce = false)
    {
        if (bruteForce is not true) OptimizeRoutes();
        var route = new Route<T>(Nodes.First());
        foreach (var currentRoute in GetRoutesToDeadEnd(route))
            yield return currentRoute;
    }

    public IEnumerable<Route<T>> GetRoutesWithAllNodes() => GetRoutesFromStartToDeadEnds().Where(r => r.Nodes.Count == Nodes.Count);
    public Route<T> GetLongestRoutesFromStartToDeadEnd() => GetRoutesFromStartToDeadEnds().OrderByDescending(r => r.Nodes.Count).First();
    public Route<T> GetShortestRoutesFromStartToDeadEnd() => GetRoutesFromStartToDeadEnds().OrderBy(r => r.Nodes.Count).First();

    public List<Route<T>> OptimizeRoutes()
    {
        while (true)
        {
            var routes = LinkNodesWith2LinkedNodes();
            routes = MergeRoutes(routes);
            var changed0 = RemoveLinksWhereLinkedNodesHaveAlready2Links(routes);
            var changed1 = RemoveLinksIfCycle(routes);
            if (!changed0 && !changed1) return routes;
        }
    }
    private List<Route<T>> LinkNodesWith2LinkedNodes()
    {
        var allPartRoutes = new List<Route<T>>();
        foreach (var node in Nodes.Where(node => node.LinkedNodes.Count == 2))
        {
            var nodesToExclude = allPartRoutes.SelectMany(r => r.Nodes.Where(n => n != r.Nodes[0] && n != r.Nodes[^1]).ToList());
            if (nodesToExclude.Contains(node)) continue;

            var isJoin = false;
            var nodes = new List<Node<T>> { node.LinkedNodes[0], node, node.LinkedNodes[1] };
            foreach (var route in allPartRoutes)
            {
                var intersect = route.Nodes.Intersect(nodes).ToList();
                if (intersect.Count == 1) // ex : 0,1,2 et 2,3,4 
                {
                    isJoin = true;
                    var element = intersect.First();
                    if (route.Nodes[0] == element && nodes[^1] == element) // ex : 2,1,0 et 4,3,2 
                    {
                        nodes.RemoveAt(nodes.Count - 1);
                        route.Nodes.InsertRange(0, nodes);
                        break;
                    }
                    if (route.Nodes[^1] == element && nodes[0] == element) // ex : 0,1,2 et 2,3,4
                    {
                        nodes.RemoveAt(0);
                        route.Nodes.AddRange(nodes);
                        break;
                    }
                    if (route.Nodes[0] == element && nodes[0] == element) // ex : 2,1,0 et 2,3,4
                    {
                        nodes.RemoveAt(0);
                        nodes.Reverse();
                        route.Nodes.InsertRange(0, nodes);
                        break;
                    }
                    if (route.Nodes[^1] == element && nodes[^1] == element) // ex : 0,1,2 et 4,3,2 
                    {
                        nodes.RemoveAt(nodes.Count - 1);
                        nodes.Reverse();
                        route.Nodes.AddRange(nodes);
                        break;
                    }
                }
                if (intersect.Count == 2) // 1234 et 345
                {
                    isJoin = true;
                    var routeFirst = route.Nodes[0];
                    var routeSecond = route.Nodes[1];
                    var routeSecondToLast = route.Nodes[^2];
                    var routeLast = route.Nodes[^1];
                    var nodes0 = nodes[0];
                    var nodes1 = nodes[1];
                    var nodes2 = nodes[2];
                    if (routeLast == nodes1) // ex 1234 345
                    {
                        if (routeSecondToLast == nodes0)
                        {
                            route.Nodes.Add(nodes[2]);
                            break;
                        }
                        if (routeSecondToLast == nodes2)
                        {
                            route.Nodes.Add(nodes[0]);
                            break;
                        }
                    }
                    if (routeFirst == nodes1)
                    {
                        if (routeSecond == nodes0)
                        {
                            route.Nodes.Insert(0, nodes[2]);
                            break;
                        }
                        if (routeSecond == nodes2)
                        {
                            route.Nodes.Insert(0, nodes[0]);
                            break;
                        }
                    }
                }
            }
            if (isJoin is false) allPartRoutes.Add(new Route<T>(nodes));
        }
        return allPartRoutes;
    }
    
    private static List<Route<T>> MergeRoutes(List<Route<T>> routes)
    {
        while (true)
        {
            Route<T> routeToDelete = null;
            for (var i = 0; i < routes.Count; i++)
            {
                if (routeToDelete is not null) break;
                for (var j = i + 1; j < routes.Count; j++)
                {
                    var intersect = routes[i].Nodes.Intersect(routes[j].Nodes).ToList();
                    if (intersect.Count == 1) // 12345 with 56789 or 98765 or 1789 or 9871
                    {
                        routeToDelete = routes[j];
                        var element = intersect.First();
                        if (routes[i].Nodes[0] == element && routes[j].Nodes[^1] == element) // ex : 2,1,0 et 4,3,2 
                        {
                            routes[j].Nodes.RemoveAt(routes[j].Nodes.Count - 1);
                            routes[i].Nodes.InsertRange(0, routes[j].Nodes);
                            break;
                        }

                        if (routes[i].Nodes[^1] == element && routes[j].Nodes[0] == element) // ex : 0,1,2 et 2,3,4
                        {
                            routes[j].Nodes.RemoveAt(0);
                            routes[i].Nodes.AddRange(routes[j].Nodes);
                            break;
                        }

                        if (routes[i].Nodes[0] == element && routes[j].Nodes[0] == element) // ex : 2,1,0 et 2,3,4
                        {
                            routes[j].Nodes.RemoveAt(0);
                            routes[j].Nodes.Reverse();
                            routes[i].Nodes.InsertRange(0, routes[j].Nodes);
                            break;
                        }

                        if (routes[i].Nodes[^1] == element && routes[j].Nodes[^1] == element) // ex : 0,1,2 et 4,3,2 
                        {
                            routes[j].Nodes.RemoveAt(routes[j].Nodes.Count - 1);
                            routes[j].Nodes.Reverse();
                            routes[i].Nodes.AddRange(routes[j].Nodes);
                            break;
                        }
                    }

                    if (intersect.Count == 2) // 1234 et 345
                    {
                        routeToDelete = routes[j];
                        var routeFirst = routes[i].Nodes[0];
                        var routeSecond = routes[i].Nodes[1];
                        var routeSecondToLast = routes[i].Nodes[^2];
                        var routeLast = routes[i].Nodes[^1];
                        var nodes0 = routes[j].Nodes[0];
                        var nodes1 = routes[j].Nodes[1];
                        var nodesSecondToLast = routes[j].Nodes[^2];
                        var nodesLast = routes[j].Nodes[^1];

                        if (routeSecondToLast == nodes0 && routeLast == nodes1)
                        {
                            routes[j].Nodes.RemoveRange(0, 2);
                            routes[i].Nodes.AddRange(routes[j].Nodes);
                            break;
                        }

                        if (routeSecondToLast == nodesLast && routeLast == nodesSecondToLast)
                        {
                            routes[j].Nodes.Reverse();
                            routes[j].Nodes.RemoveRange(0, 2);
                            routes[i].Nodes.AddRange(routes[j].Nodes);
                            break;
                        }

                        if (routeSecond == nodes0 && routeFirst == nodes1)
                        {
                            routes[j].Nodes.RemoveRange(0, 2);
                            routes[j].Nodes.Reverse();
                            routes[i].Nodes.InsertRange(0, routes[j].Nodes);
                            break;
                        }

                        if (routeSecond == nodesLast && routeFirst == nodesSecondToLast)
                        {
                            routes[j].Nodes.RemoveRange(routes[j].Nodes.Count - 2, 2);
                            routes[i].Nodes.InsertRange(0, routes[j].Nodes);
                            break;
                        }
                    }
                }
            }
            if (routeToDelete is null) break;
            routes.Remove(routeToDelete);
        }
        return routes;
    }

    private static bool RemoveLinksWhereLinkedNodesHaveAlready2Links(List<Route<T>> routes)
    {
        var result = false;
        foreach (var route in routes)
        {
            var withoutLimitsNodesRoute = new List<Node<T>>(route.Nodes);
            withoutLimitsNodesRoute.RemoveAt(0);
            withoutLimitsNodesRoute.RemoveAt(withoutLimitsNodesRoute.Count - 1);

            for (var i = 1; i < route.Nodes.Count - 1; i++)
            {
                var node = route.Nodes[i];
                var previousNode = route.Nodes[i - 1];
                var nextNode = route.Nodes[i + 1];
                if (node.LinkedNodes.Count > 2)
                {
                    result = true;
                    var nodeToRemove = node.LinkedNodes.Where(n => n != previousNode && n != nextNode).ToList();
                    nodeToRemove.ForEach(n =>
                    {
                        node.LinkedNodes.Remove(n);
                        n.LinkedNodes.Remove(node);
                    });
                }
            }
        }
        return result;
    }

    private static bool RemoveLinksIfCycle(List<Route<T>> routes)
    {
        var result = false;
        foreach (var route in routes)
        {
            var commonNode = route.Nodes[0].LinkedNodes.FirstOrDefault(n => n == route.Nodes[^1]);
            if (commonNode is not null)
            {
                result = true;
                route.Nodes[0].LinkedNodes.Remove(commonNode);
                commonNode.LinkedNodes.Remove(route.Nodes[0]);
            }
        }
        return result;
    }

    private static IEnumerable<Route<T>> GetRoutesToDeadEnd(Route<T> startTree)
    {
        var startNode = startTree.Nodes.Last();
        if (startNode.LinkedNodes.Count == 1 && startTree.Nodes.Count > 1)
            yield return new Route<T>(startTree.Nodes);

        foreach (var node in startNode.LinkedNodes)
        {
            if (startTree.Nodes.Any(n => n.Number == node.Number)) continue;
            var route = new Route<T>(startTree.Nodes);
            route.AddNode(node);
            foreach (var suitRoute in GetRoutesToDeadEnd(route))
                yield return suitRoute;
        }
    }

    private Node<T> AddNode(T item, int number)
    {
        var node = new Node<T>(item, number);
        Nodes.Add(node);
        return node;
    }
}