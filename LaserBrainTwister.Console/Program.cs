using LaserBrainTwister.Domain;

var tree = new Tree(22);
tree.LinkFromOrigin().To(1)
              .Next().To(2, 11)
              .Next().To(1, 3, 12)
              .Next().To(2, 4, 14)
              .Next().To(3, 9)
              .Next().To(6, 17)
              .Next().To(5, 7, 8)
              .Next().To(6, 13)
              .Next().To(6, 9, 18)
              .Next().To(4, 8)
              .Next().To(11, 16)
              .Next().To(10, 12)
              .Next().To(11, 13, 2)
              .Next().To(7, 12, 15)
              .Next().To(3, 15, 19)
              .Next().To(13, 14, 20)
              .Next().To(10, 17)
              .Next().To(16, 5, 18)
              .Next().To(17, 8, 19)
              .Next().To(18, 14, 20)
              .Next().To(21, 15, 19);

var routes = tree.GetRoutes();
var allNodesRoutes = routes.Where(r => r.Nodes.Count == tree.Nodes.Count).ToList();
foreach (var route in allNodesRoutes)
    Console.WriteLine($"Possible solution : {route}");
if (allNodesRoutes.Count == 0)
{
    var longestRoute = routes.MaxBy(r => r.Nodes.Count);
    Console.WriteLine($"No route found that passe by all nodes. The longest is : {longestRoute}");
}
Console.WriteLine("");


tree = new Tree(28);
tree.LinkFromOrigin().To(1)
              .Next().To(0, 2, 12)
              .Next().To(1, 3, 23)
              .Next().To(2, 4, 13)
              .Next().To(3, 5, 19)
              .Next().To(4, 11)
              .Next().To(7, 22)
              .Next().To(6, 8, 17)
              .Next().To(7, 9, 18)
              .Next().To(8, 15)
              .Next().To(11, 16)
              .Next().To(10, 5, 14)
              .Next().To(1, 13)
              .Next().To(12, 3, 14)
              .Next().To(13, 11, 15, 25)
              .Next().To(14, 9, 21)
              .Next().To(10, 17)
              .Next().To(16, 7, 18)
              .Next().To(17, 8, 19)
              .Next().To(18, 4, 20)
              .Next().To(19, 21, 24)
              .Next().To(20, 15, 26)
              .Next().To(6, 23)
              .Next().To(22, 2, 24)
              .Next().To(23, 20, 25)
              .Next().To(24, 14, 26)
              .Next().To(25, 21, 27);

routes = tree.GetRoutes();
allNodesRoutes = routes.Where(r => r.Nodes.Count == tree.Nodes.Count).ToList();
foreach (var route in allNodesRoutes)
    Console.WriteLine($"Possible solution : {route}");
if (allNodesRoutes.Count == 0)
{
    var longestRoute = routes.MaxBy(r => r.Nodes.Count);
    Console.WriteLine($"No route found that passe by all nodes. The longest is : {longestRoute}");
}

var tree2 = new Tree(61);
tree2.LinkFromOrigin().To(1)
               .Next().To(2).To(8)
               .Next().To(1).To(3).To(20)
               .Next().To(2).To(4).To(21)
               .Next().To(3).To(5).To(18)
               .Next().To(4).To(6).To(29)
               .Next().To(5).To(25)
               .Next().To(8).To(19)
               .Next().To(7).To(1).To(9)
               .Next().To(8).To(10).To(16)
               .Next().To(9).To(11).To(17)
               .Next().To(10).To(12).To(36)
               .Next().To(11).To(13).To(23)
               .Next().To(12).To(14).To(24)
               .Next().To(13).To(31)
               .Next().To(8).To(16).To(33)
               .Next().To(15).To(9).To(17).To(42)
               .Next().To(16).To(10).To(18).To(28)
               .Next().To(17).To(4).To(22)
               .Next().To(7).To(20).To(26)
               .Next().To(19).To(2).To(21).To(34)
               .Next().To(20).To(3).To(22).To(27)
               .Next().To(21).To(4).To(23).To(37)
               .Next().To(22).To(12).To(24).To(38)
               .Next().To(23).To(13).To(25).To(40)
               .Next().To(24).To(6).To(30)
               .Next().To(19).To(27).To(32)
               .Next().To(26).To(21).To(28).To(35)
               .Next().To(27).To(17).To(29).To(43)
               .Next().To(28).To(5).To(30).To(39)
               .Next().To(29).To(25).To(31).To(52)
               .Next().To(30).To(14).To(47)
               .Next().To(26).To(33)
               .Next().To(32).To(15).To(34)
               .Next().To(33).To(20).To(35).To(50)
               .Next().To(34).To(27).To(36).To(51)
               .Next().To(35).To(11).To(37)
               .Next().To(36).To(22).To(38)
               .Next().To(37).To(23).To(39).To(44)
               .Next().To(38).To(29).To(40).To(45)
               .Next().To(39).To(24).To(46)
               .Next().To(49)
               .Next().To(41).To(16).To(55)
               .Next().To(42).To(28).To(44)
               .Next().To(43).To(38).To(45)
               .Next().To(44).To(39).To(46).To(56)
               .Next().To(45).To(40).To(47).To(57)
               .Next().To(46).To(31).To(48).To(53)
               .Next().To(47)
               .Next().To(41).To(50)
               .Next().To(49).To(34).To(51)
               .Next().To(50).To(35).To(52)
               .Next().To(51).To(30).To(53)
               .Next().To(52).To(47).To(54)
               .Next().To(53).To(48).To(59)
               .Next().To(42).To(56)
               .Next().To(55).To(45).To(57)
               .Next().To(56).To(46).To(58)
               .Next().To(57).To(53).To(59)
               .Next().To(58).To(54).To(60)
               .Next().To(8).To(19);

//var routes2 = tree2.GetRoutes();
//var longestRoute2 = routes2.MaxBy(r => r.Nodes.Count);
//if (longestRoute2!.Nodes.Count == tree2.Nodes.Count) Console.WriteLine($"Possible solution : {longestRoute2}");
//else Console.WriteLine($"No route found that passe by all nodes. The longest is : {longestRoute2}");