using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class NodeSelector : IDisposable
    {
        private EventBus _eventBus;

        public Node? CurrentNode { get; private set; }

        public NodeSelector(AppContext context)
        {
            _eventBus = context.EventBus;
            _eventBus.nodeTapped.Subscribe(_OnNodeTouched);
        }

        public void Dispose()
        {
            _eventBus.nodeTapped.Unsubscribe(_OnNodeTouched);
        }

        private void _OnNodeTouched(Node node)
        {
            if(CurrentNode != null) _eventBus.nodeUnselected.Invoke(CurrentNode);
            CurrentNode = node;
            _eventBus.nodeSelected.Invoke(node);
        }
    }
}
