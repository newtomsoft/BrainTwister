namespace LaserBrainTwister.Tests;

public class TreeTests
{
    [Fact]
    public void TreeWith1Node()
    {
        var tree = new Tree(0);
        var node0 = Node.New(0);
        tree.Nodes.Add(node0);
        tree.Nodes.Count.ShouldBe(1);
    }

    [Fact]
    public void RouteWith2Ways()
    {
        Tree tree = new(0);
        Node node0 = Node.New(0);
        Node node1 = Node.New(1);
        Node node2 = Node.New(2);
        Node node3 = Node.New(3);

        tree.Nodes.Add(node0);
        tree.Nodes.Add(node1);
        tree.Nodes.Add(node2);
        tree.Nodes.Add(node3);

        node0.AddLinkedNode(node1);
        node0.AddLinkedNode(node2);
        node1.AddLinkedNode(node3);
        node2.AddLinkedNode(node3);

        var routes = tree.GetRoutes();
        routes.Count.ShouldBe(2);
        routes[0].Nodes.Count.ShouldBe(3);
        routes[0].Nodes[0].ShouldBe(node0);
        routes[0].Nodes[1].ShouldBe(node1);
        routes[0].Nodes[2].ShouldBe(node3);
        routes[1].Nodes.Count.ShouldBe(3);
        routes[1].Nodes[0].ShouldBe(node0);
        routes[1].Nodes[1].ShouldBe(node2);
        routes[1].Nodes[2].ShouldBe(node3);
    }


    [Fact]
    public void BrowseNodeTreeWithMoreWays()
    {
        Tree tree = new(0);
        Node node0 = Node.New(0);
        Node node1 = Node.New(1);
        Node node2 = Node.New(2);
        Node node3 = Node.New(3);
        Node node4 = Node.New(4);
        Node node5 = Node.New(5);
        Node node6 = Node.New(6);

        tree.Nodes.Add(node0);
        tree.Nodes.Add(node1);
        tree.Nodes.Add(node2);
        tree.Nodes.Add(node3);
        tree.Nodes.Add(node4);
        tree.Nodes.Add(node5);
        tree.Nodes.Add(node6);

        node0.AddLinkedNode(node1);
        node0.AddLinkedNode(node2);
        node1.AddLinkedNode(node3);
        node1.AddLinkedNode(node4);
        node2.AddLinkedNode(node5);
        node3.AddLinkedNode(node6);
        node4.AddLinkedNode(node6);
        node5.AddLinkedNode(node6);

        var routes = tree.GetRoutes();
        routes.Count.ShouldBe(3);
        routes[0].Nodes.Count.ShouldBe(4);
        routes[0].Nodes[0].ShouldBe(node0);
        routes[0].Nodes[1].ShouldBe(node1);
        routes[0].Nodes[2].ShouldBe(node3);
        routes[0].Nodes[3].ShouldBe(node6);

        routes[1].Nodes.Count.ShouldBe(4);
        routes[1].Nodes[0].ShouldBe(node0);
        routes[1].Nodes[1].ShouldBe(node1);
        routes[1].Nodes[2].ShouldBe(node4);
        routes[1].Nodes[3].ShouldBe(node6);

        routes[2].Nodes[0].ShouldBe(node0);
        routes[2].Nodes[1].ShouldBe(node2);
        routes[2].Nodes[2].ShouldBe(node5);
        routes[2].Nodes[3].ShouldBe(node6);
    }

    [Fact]
    public void BrowseWithCycle()
    {
        Tree tree = new(0);
        Node node0 = Node.New(0);
        Node node1 = Node.New(1);
        Node node2 = Node.New(2);

        tree.Nodes.Add(node0);
        tree.Nodes.Add(node1);
        tree.Nodes.Add(node2);

        node0.AddLinkedNode(node1);
        node1.AddLinkedNode(node2);
        node1.AddLinkedNode(node0);

        var routes = tree.GetRoutes();
        routes.Count.ShouldBe(1);
        routes[0].Nodes.Count.ShouldBe(3);
        routes[0].Nodes[0].ShouldBe(node0);
        routes[0].Nodes[1].ShouldBe(node1);
        routes[0].Nodes[2].ShouldBe(node2);
    }
}
