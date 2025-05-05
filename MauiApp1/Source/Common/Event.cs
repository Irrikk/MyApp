namespace MauiApp1
{
    public class Event
    {
        private event Action _event;

        public Event() => _event = () => { };

        public void Subscribe(Action action) => _event += action;

        public void Unsubscribe(Action action) => _event -= action;

        public void Invoke() => _event.Invoke();
    }

    public class Event<T>
    {
        private event Action<T> _event;

        public Event() => _event = (arg) => { };

        public void Subscribe(Action<T> action) => _event += action;

        public void Unsubscribe(Action<T> action) => _event -= action;

        public void Invoke(T arg) => _event.Invoke(arg);
    }

    public class Event<T1, T2>
    {
        private event Action<T1, T2> _event;

        public Event() => _event = (arg1, arg2) => { };

        public void Subscribe(Action<T1, T2> action) => _event += action;

        public void Unsubscribe(Action<T1, T2> action) => _event -= action;

        public void Invoke(T1 arg1, T2 arg2) => _event.Invoke(arg1, arg2);
    }

    public class Event<T1, T2, T3>
    {
        private event Action<T1, T2, T3> _event;

        public Event() => _event = (arg1, arg2, arg3) => { };

        public void Subscribe(Action<T1, T2, T3> action) => _event += action;

        public void Unsubscribe(Action<T1, T2, T3> action) => _event -= action;

        public void Invoke(T1 arg1, T2 arg2, T3 arg3) => _event.Invoke(arg1, arg2, arg3);
    }
}
