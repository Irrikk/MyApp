using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace MauiApp1
{
    public class LinkDrawer : IDisposable, IDrawable
    {
        private Layout _rootLayout;
        private EventBus _eventBus;
        private GraphicsView _graphicsView;
        private List<Channel> _links;

        public LinkDrawer(AppContext context)
        {
            _rootLayout = context.RootLayout;
            _eventBus = context.EventBus;
            _graphicsView = new();
            _links = new();

            _rootLayout.Add(_graphicsView);
            _graphicsView.BackgroundColor = Colors.White;

            _eventBus.nodesLinked.Subscribe(_OnNodesLinked);
            _eventBus.nodesUnlinked.Subscribe(_OnNodesUnlinked);
            _eventBus.nodePositionChanged.Subscribe(_OnNodePositionChanged);
        }

        public void Dispose()
        {
            _eventBus.nodesLinked.Unsubscribe(_OnNodesLinked);
            _eventBus.nodesUnlinked.Unsubscribe(_OnNodesUnlinked);
            _eventBus.nodePositionChanged.Unsubscribe(_OnNodePositionChanged);
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Green;
            canvas.StrokeSize = 2;

            foreach (var item in _links)
            {
                double fromX = item.TranslationX;
                double fromY = item.TranslationY;
                double toX = item.LinkedParent.TranslationX;
                double toY = item.LinkedParent.TranslationY;

                canvas.DrawLine((float)fromX, (float)fromY, (float)toX, (float)toY);
            }
        }

        private void _OnNodesLinked(NodesLinkedEventArgs args)
        {
            _links.Add(args.input);
            _graphicsView.Invalidate();
        }

        private void _OnNodesUnlinked(NodesUnlinkedEventArgs args)
        {
            _links.Remove(args.input);
            _graphicsView.Invalidate();
        }

        private void _OnNodePositionChanged(NodePositionChangedArgs args)
        {
            _graphicsView.Invalidate();
        }
    }
}