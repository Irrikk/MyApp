using System;
using System.Collections.Generic;

namespace MauiApp1;

public class TestNode : Node
{
    public TestNode(Event<INode>? nodeTouched = null)
    : base(
        position: new(0, 0),
        size: new(100, 50),
        title: "Test Node",
        titleBarColor: new(0, 180, 20, 255),
        bodyColor: new(100, 100, 100, 255),
        nodeTouched: nodeTouched
    )
    { }
}
