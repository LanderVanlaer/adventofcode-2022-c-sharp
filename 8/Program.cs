﻿using _8;

StreamReader file = new(args[0]);

Forest forest = new();

while (!file.EndOfStream)
    forest.AddTrees(file.ReadLine() ?? throw new InvalidOperationException());

forest.CalculateView();

Console.WriteLine(forest.GetViewableTrees());