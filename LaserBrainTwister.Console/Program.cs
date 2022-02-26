using LaserBrainTwister.Domain;

NodesTree nodeTree = new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21);


node0.AddLinkedNode(node1);
node1.AddLinkedNode(node2);
node1.AddLinkedNode(node0);