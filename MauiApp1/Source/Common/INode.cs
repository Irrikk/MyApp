using System;
using System.Numerics;

namespace MauiApp1
{
    public interface INode
    {
        Vector2 Position { get; set; }
        Size Size { get; set; }
        string Title { get; set; }
        Color TitleBarColor { get; set; }
        Color BodyColor { get; set; }
        double CornerRadius { get; set; }
    }
}
