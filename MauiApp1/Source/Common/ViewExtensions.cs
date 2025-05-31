using System;

namespace MauiApp1
{
    public static class ViewExtensions
    {
        public static T AddGestureRecognizer<T>(this View target) where T : GestureRecognizer
        {
            var result = (T)Activator.CreateInstance(typeof(T))!;
            target.GestureRecognizers.Add(result);
            return result;
        }
    }
}
