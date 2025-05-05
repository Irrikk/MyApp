using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class NodeSelector : IDisposable
    {
        private Event<INode> _nodeTouched;

        public INode? CurrentNode { get; private set; }
        public Event<INode> nodeSelected { get; private set; }
        public Event<INode> nodeUnselected { get; private set; }

        public NodeSelector(Event<INode> nodeTouched)
        {
            _nodeTouched = nodeTouched;
            nodeTouched.Subscribe(_OnNodeTouched);

            nodeSelected = new();
            nodeUnselected = new();
        }

        public void Dispose()
        {
            _nodeTouched.Unsubscribe(_OnNodeTouched);
        }

        private void _OnNodeTouched(INode node)
        {
            if(CurrentNode != null) nodeUnselected.Invoke(CurrentNode);
            CurrentNode = node;
            nodeSelected.Invoke(node);
        }
    }
}
