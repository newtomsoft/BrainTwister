using LaserBrainTwister.Domain;

var nodeTree = new NodesTree(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21);


nodeTree.AddLink(0,1);
nodeTree.AddLink(1, 2);
nodeTree.AddLink(1, 11);