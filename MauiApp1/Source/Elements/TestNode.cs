using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1;

public class TestNode : Node
{
    public TestNode() : base(
        size: new(100, 50),
        title: "Test Node",
        titleBarColor: new(0, 180, 20, 255),
        nodeColor: new(100, 100, 100, 255))
    {

    }
}
