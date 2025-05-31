using System;

namespace MauiApp1
{
    public class AppContext
    {
        public EventBus EventBus { get; private set; }
        public VariableValidator VariableValidator { get; private set; }
        public VariableRegistry VariableRegistry { get; private set; }
        public AbsoluteLayout RootLayout { get; private set; }

        public AppContext()
        {
            EventBus = new();
            VariableValidator = new();
            VariableRegistry = new();
            RootLayout = new()
            {
                BackgroundColor = new(29, 29, 29, 255) 
            };
        }
    }
}
