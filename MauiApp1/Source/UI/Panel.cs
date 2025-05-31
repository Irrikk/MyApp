//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MauiApp1
//{
//    public abstract class Panel : UiElement
//    {
//        public override Layout Layout { get; protected set; }
//        public Border TitleBar { get; private set; }
//        public Border Body { get; private set; }

//        public Panel(AppContext context)
//        {
//            _root = context.RootLayout;
//            Layout = new StackLayout();
//            Border = new();

//            Layout.Add(Layout);
//        }
//    }
//}
