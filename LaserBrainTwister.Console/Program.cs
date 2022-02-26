using LaserBrainTwister.Domain;

var Tree = new Tree(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21);

Tree.AddLink(0, 1);

Tree.AddLink(1, 2);
Tree.AddLink(1, 11);

Tree.AddLink(2, 1);
Tree.AddLink(2, 3);
Tree.AddLink(2, 12);

Tree.AddLink(3, 2);
Tree.AddLink(3, 4);
Tree.AddLink(3, 14);

Tree.AddLink(4, 3);
Tree.AddLink(4, 9);

Tree.AddLink(5, 6);
Tree.AddLink(5, 17);

Tree.AddLink(6, 5);
Tree.AddLink(6, 7);
Tree.AddLink(6, 8);

Tree.AddLink(7, 6);
Tree.AddLink(7, 13);

Tree.AddLink(8, 6);
Tree.AddLink(8, 9);
Tree.AddLink(8, 18);

Tree.AddLink(9, 4);
Tree.AddLink(9, 8);

Tree.AddLink(10, 11);
Tree.AddLink(10, 16);

Tree.AddLink(11, 10);
Tree.AddLink(11, 12);

Tree.AddLink(12, 11);
Tree.AddLink(12, 13);
Tree.AddLink(12, 2);

Tree.AddLink(13, 7);
Tree.AddLink(13, 12);
Tree.AddLink(13, 15);

Tree.AddLink(14, 3);
Tree.AddLink(14, 15);
Tree.AddLink(14, 19);

Tree.AddLink(15, 13);
Tree.AddLink(15, 14);
Tree.AddLink(15, 20);

Tree.AddLink(16, 10);
Tree.AddLink(16, 17);

Tree.AddLink(17, 16);
Tree.AddLink(17, 5);
Tree.AddLink(17, 18);

Tree.AddLink(18, 17);
Tree.AddLink(18, 8);
Tree.AddLink(18, 19);

Tree.AddLink(19, 18);
Tree.AddLink(19, 14);
Tree.AddLink(19, 20);

Tree.AddLink(20, 21);
Tree.AddLink(20, 15);
Tree.AddLink(20, 19);