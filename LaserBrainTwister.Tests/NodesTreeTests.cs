namespace LaserBrainTwister.Tests;

public class NodesTreeTests
{
    [Fact]
    public void NodeTreeWith1Node()
    {
        var nodesTree = new NodesTree();
        var node0 = Node.New(0);
        nodesTree.Nodes.Add(node0);
        nodesTree.Nodes.Count.ShouldBe(1);
    }

    [Fact]
    public void Add1Link()
    {
        var nodesTree = new NodesTree(0, 1);
        nodesTree.AddLink(0, 1);
        nodesTree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        nodesTree.Nodes[0].LinkedNodes[0].ShouldBe(nodesTree.Nodes[1]);
    }

    [Fact]
    public void BrowseNodeTreeWith3SimpleNodesUsingTreeOnly()
    {
        NodesTree nodeTree = new(0, 1, 2);
        nodeTree.AddLink(0, 1);
        nodeTree.AddLink(1, 2);

        var browsedTrees = nodeTree.TreeRoutes();
        browsedTrees.Count.ShouldBe(1);
        browsedTrees[0].Nodes.Count.ShouldBe(3);
        browsedTrees[0].Nodes[0].ShouldBe(nodeTree.Nodes[0]);
        browsedTrees[0].Nodes[1].ShouldBe(nodeTree.Nodes[1]);
        browsedTrees[0].Nodes[2].ShouldBe(nodeTree.Nodes[2]);
    }

    [Fact]
    public void BrowseNodeTreeWith2Ways()
    {
        NodesTree nodeTree = new();
        Node node0 = Node.New(0);
        Node node1 = Node.New(1);
        Node node2 = Node.New(2);
        Node node3 = Node.New(3);

        nodeTree.Nodes.Add(node0);
        nodeTree.Nodes.Add(node1);
        nodeTree.Nodes.Add(node2);
        nodeTree.Nodes.Add(node3);

        node0.AddLinkedNode(node1);
        node0.AddLinkedNode(node2);
        node1.AddLinkedNode(node3);
        node2.AddLinkedNode(node3);

        var browsedTrees = nodeTree.TreeRoutes();
        browsedTrees.Count.ShouldBe(2);
        browsedTrees[0].Nodes.Count.ShouldBe(3);
        browsedTrees[0].Nodes[0].ShouldBe(node0);
        browsedTrees[0].Nodes[1].ShouldBe(node1);
        browsedTrees[0].Nodes[2].ShouldBe(node3);
        browsedTrees[1].Nodes.Count.ShouldBe(3);
        browsedTrees[1].Nodes[0].ShouldBe(node0);
        browsedTrees[1].Nodes[1].ShouldBe(node2);
        browsedTrees[1].Nodes[2].ShouldBe(node3);
    }


    [Fact]
    public void BrowseNodeTreeWithMoreWays()
    {
        NodesTree nodeTree = new();
        Node node0 = Node.New(0);
        Node node1 = Node.New(1);
        Node node2 = Node.New(2);
        Node node3 = Node.New(3);
        Node node4 = Node.New(4);
        Node node5 = Node.New(5);
        Node node6 = Node.New(6);

        nodeTree.Nodes.Add(node0);
        nodeTree.Nodes.Add(node1);
        nodeTree.Nodes.Add(node2);
        nodeTree.Nodes.Add(node3);
        nodeTree.Nodes.Add(node4);
        nodeTree.Nodes.Add(node5);
        nodeTree.Nodes.Add(node6);

        node0.AddLinkedNode(node1);
        node0.AddLinkedNode(node2);
        node1.AddLinkedNode(node3);
        node1.AddLinkedNode(node4);
        node2.AddLinkedNode(node5);
        node3.AddLinkedNode(node6);
        node4.AddLinkedNode(node6);
        node5.AddLinkedNode(node6);

        var browsedTrees = nodeTree.TreeRoutes();
        browsedTrees.Count.ShouldBe(3);
        browsedTrees[0].Nodes.Count.ShouldBe(4);
        browsedTrees[0].Nodes[0].ShouldBe(node0);
        browsedTrees[0].Nodes[1].ShouldBe(node1);
        browsedTrees[0].Nodes[2].ShouldBe(node3);
        browsedTrees[0].Nodes[3].ShouldBe(node6);

        browsedTrees[1].Nodes.Count.ShouldBe(4);
        browsedTrees[1].Nodes[0].ShouldBe(node0);
        browsedTrees[1].Nodes[1].ShouldBe(node1);
        browsedTrees[1].Nodes[2].ShouldBe(node4);
        browsedTrees[1].Nodes[3].ShouldBe(node6);

        browsedTrees[2].Nodes[0].ShouldBe(node0);
        browsedTrees[2].Nodes[1].ShouldBe(node2);
        browsedTrees[2].Nodes[2].ShouldBe(node5);
        browsedTrees[2].Nodes[3].ShouldBe(node6);
    }

    [Fact]
    public void BrowseWithCycle()
    {
        NodesTree nodeTree = new();
        Node node0 = Node.New(0);
        Node node1 = Node.New(1);
        Node node2 = Node.New(2);

        nodeTree.Nodes.Add(node0);
        nodeTree.Nodes.Add(node1);
        nodeTree.Nodes.Add(node2);

        node0.AddLinkedNode(node1);
        node1.AddLinkedNode(node2);
        node1.AddLinkedNode(node0);

        var browsedTrees = nodeTree.TreeRoutes();
        browsedTrees.Count.ShouldBe(1);
        browsedTrees[0].Nodes.Count.ShouldBe(3);
        browsedTrees[0].Nodes[0].ShouldBe(node0);
        browsedTrees[0].Nodes[1].ShouldBe(node1);
        browsedTrees[0].Nodes[2].ShouldBe(node2);
    }
}
