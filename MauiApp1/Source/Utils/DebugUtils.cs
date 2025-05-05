using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public static class DebugUtils
    {
        public static void Print(string message)
        {
            Application.Current!.MainPage!.DisplayAlert("Debug message", message, "Ok");
        }
    }
}
