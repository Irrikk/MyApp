using System;

namespace MauiApp1
{
    public struct NodesLinkedEventArgs
    {
        public readonly Channel output;
        public readonly Channel input;

        public NodesLinkedEventArgs(Channel output, Channel input)
        {
            this.output = output;
            this.input = input;
        }
    }
}
