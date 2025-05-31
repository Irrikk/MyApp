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

        public LinkDrawer(AppContext context)
        {
            _rootLayout = context.RootLayout;
            _eventBus = context.EventBus;
            _graphicsView = new();

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
            throw new NotImplementedException();
        }

        private void _OnNodesLinked(NodesLinkedEventArgs args)
        {

        }

        private void _OnNodesUnlinked(NodesUnlinkedEventArgs args)
        {

        }

        private void _OnNodePositionChanged(NodePositionChangedArgs args)
        {

        }


    }
}


//using System;
//using System.Collections.Generic;

//namespace MauiApp1
//{
//    public class LinkDrawer : IDrawable
//    {
//        private GraphicsView _view;
//        private List<PathF> _paths;
//        private bool _isEnabled;
//        private Color _strokeColor;
//        private float _strokeSize;

//        public bool IsEnabled
//        {
//            get => _isEnabled;
//            set
//            {
//                _isEnabled = value;
//                _view.Invalidate();
//            }
//        }

//        public Color StrokeColor
//        {
//            get => _strokeColor;
//            set
//            {
//                _strokeColor = value;
//                _view.Invalidate();
//            }
//        }

//        public float StrokeSize
//        {
//            get => _strokeSize;
//            set
//            {
//                _strokeSize = value;
//                _view.Invalidate();
//            }
//        }

//        public LinkDrawer(GraphicsView view)
//        {
//            _view = view;
//            _paths = new();
//            view.Drawable = this;
//        }

//        public void Draw(ICanvas canvas, RectF dirtyRect)
//        {
//            if (!IsEnabled) return;
//            canvas.StrokeColor = StrokeColor;
//            canvas.StrokeSize = StrokeSize;
//            for (int i = 0; i < _paths.Count; i++)
//            {
//                var path= _paths[i];
//                canvas.DrawPath(path);
//            }
//        }

//        public void AddPath(PathF path) => _paths.Add(path);
//    }
//}
