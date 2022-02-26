using LaserBrainTwister.Domain;

var Tree = new Tree(22);

Tree.LinkFrom(0).To(1);
Tree.LinkFrom(1).To(2).To(11);
Tree.LinkFrom(2).To(1).To(3).To(12);
Tree.LinkFrom(3).To(2).To(4).To(14);
Tree.LinkFrom(4).To(3).To(9);
Tree.LinkFrom(5).To(6).To(17);
Tree.LinkFrom(6).To(5).To(7).To(8);
Tree.LinkFrom(7).To(6).To(13);
Tree.LinkFrom(8).To(6).To(9).To(18);
Tree.LinkFrom(9).To(4).To(8);
Tree.LinkFrom(10).To(11).To(16);
Tree.LinkFrom(11).To(10).To(12);
Tree.LinkFrom(12).To(11).To(13).To(2);
Tree.LinkFrom(13).To(7).To(12).To(15);
Tree.LinkFrom(14).To(3).To(15).To(19);
Tree.LinkFrom(15).To(13).To(14).To(20);
Tree.LinkFrom(16).To(10).To(17);
Tree.LinkFrom(17).To(16).To(5).To(18);
Tree.LinkFrom(18).To(17).To(8).To(19);
Tree.LinkFrom(19).To(18).To(14).To(20);
Tree.LinkFrom(20).To(21).To(15).To(19);

var routes = Tree.GetRoutes();
var longestRoute = routes.MaxBy(r => r.Nodes.Count);
if (longestRoute!.Nodes.Count == Tree.Nodes.Count) Console.WriteLine($"Possible solution : {longestRoute}");
else Console.WriteLine($"No route found which passed by all nodes. The longest : {longestRoute}");