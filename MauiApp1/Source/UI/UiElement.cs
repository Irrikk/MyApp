using System;

namespace MauiApp1
{
    public abstract class UiElement
    {
        protected Layout _rootLayout;
        private bool _isActive;

        public abstract View View { get; }

        public virtual bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                if (value) _rootLayout.Add(View);
                else _rootLayout.Remove(View);
            }
        }

        public UiElement(AppContext context)
        {
            _rootLayout = context.RootLayout;
        }
    }
}
