﻿using System.Reflection;

int day = 1;
int step = 2;
var env = Env.Run;
















Console.WriteLine("Hello, World!");
var assembly = Assembly.GetExecutingAssembly();
var dayType = assembly.GetType($"Day{day}_{step}");
var myDay = (Day)Activator.CreateInstance(dayType);
if (env == Env.Test)
    myDay.Test();
else
    myDay.Solve();
Console.WriteLine("THE END");