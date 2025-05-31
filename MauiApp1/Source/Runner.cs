using System;
using System.Collections.Generic;

namespace MauiApp1
{
    public class Runner
    {
        private Node _node;
        private HashSet<Node> _executed;

        public Runner(Node node)
        {
            _node = node;
            _executed = new();
        }

        public void Start()
        {
            _Iterate(_node);
        }

        private void _Iterate(Node node)
        {
            foreach (var parent in node.ParentNodes)
            {
                if (_executed.Contains(node)) continue;
                _Iterate(parent);
            }

            _executed.Add(node);
            node.Execute();

            if (node.ChildNode == null) _executed.Clear();
        }
    }
}
