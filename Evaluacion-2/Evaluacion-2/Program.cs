// See https://aka.ms/new-console-template for more information

using SFML.Graphics;
using SFML.System;
using SFML.Window;

VideoMode videoMode = VideoMode.DesktopMode;
RenderWindow renderWindow = new RenderWindow(videoMode, "TEST");
Console.WriteLine("Hello, World!");
Console.ReadKey();