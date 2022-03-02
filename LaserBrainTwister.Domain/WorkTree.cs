namespace LaserBrainTwister.Domain;


public class WorkTree : Tree
{
    public WorkTree(Tree originTree)
    {
        Nodes.AddRange(originTree.Nodes);
    }

    public readonly List<Route> RoutedNodes = new();

    public void FirstPass()
    {
        StartRoute();
        //nodeToAdd.LinkedNodes.


        //foreach (var endNode in Nodes.Where(n => n.LinkedNodes.Count == 0))
        //{
        //    foreach (var node in Nodes.Where(n => n.LinkedNodes.Contains(endNode)))
        //    {
        //        var nodeToAdd = new Node(node);
        //        //nodeToAdd.LinkedNodes.
        //        RoutedNodes.Add(nodeToAdd);
        //    }
        //}
        //foreach (var originNode in Nodes.Where(n => n.LinkedNodes.Count == 2))
        //{
        //    foreach (var node in originNode.LinkedNodes)
        //    {
        //        RoutedNodes.Add(new Node(node));
        //    }
        //}

    }

    private void StartRoute()
    {
        var allLinkedNodes = new HashSet<Node>();
        foreach (var node in Nodes)
        {
            allLinkedNodes.UnionWith(node.LinkedNodes);
        }

        var originNodes = Nodes.Where(node => allLinkedNodes.Contains(node) is not true);
        foreach (var originNode in originNodes)
        {
            RoutedNodes.Add(new Route(originNode));
        }
    }
}