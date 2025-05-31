using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Source.Sandbox
{
    public class StartButtonNode : Node, IDisposable
    {
        private const int COUNT = 2;

        private EventBus _eventBus;
        private int _count;
        private Runner _runner;

        public StartButtonNode(
            AppContext context,
            Runner runner,
            Vector2? position = null,
            string? title = "START",
            Color? titleBarColor = null,
            Color? nodeColor = null,
            double cornerRadius = 8
        )
            : base(
                context: context,
                position: position,
                title: title,
                titleBarColor: titleBarColor,
                nodeColor: nodeColor,
                cornerRadius: cornerRadius
            )
        {
            _eventBus = context.EventBus;
            _runner = runner;

            _eventBus.nodeTapped.Subscribe(_StartTapped);
        }

        public void Dispose()
        {
            _eventBus.nodeTapped.Unsubscribe(_StartTapped);
        }

        public override void Execute()
        {
            _runner.Start();
        }

        private void _StartTapped(Node node)
        {
            if (node != this)
            {
                _count = 0;
                return;
            }

            _count++;
            if (_count >= COUNT)
            {
                _count = 0;
                Execute();
            }
        }
    }
}
