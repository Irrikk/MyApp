using System;

namespace MauiApp1
{
    public struct NodesUnlinkedEventArgs
    {
        public readonly Channel output;
        public readonly Channel input;

        public NodesUnlinkedEventArgs(Channel output, Channel input)
        {
            this.output = output;
            this.input = input;
        }
    }
}
