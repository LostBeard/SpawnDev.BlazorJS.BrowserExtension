using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// Extension event
    /// </summary>
    public class FuncEvent<TResult> : Event
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<TResult> operator +(FuncEvent<TResult> a, Callback callback)
        {
            a.AddListener(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<TResult> operator -(FuncEvent<TResult> a, Callback callback)
        {
            a.RemoveListener(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<TResult> operator +(FuncEvent<TResult> a, Func<TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<TResult> operator -(FuncEvent<TResult> a, Func<TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FuncEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void AddListener(Func<TResult> callback) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void RemoveListener(Func<TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            RemoveListener(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// Extension event
    /// </summary>
    public class FuncEvent<T1, TResult> : FuncEvent<TResult>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, TResult> operator +(FuncEvent<T1, TResult> a, Callback b)
        {
            a.AddListener(b);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, TResult> operator -(FuncEvent<T1, TResult> a, Callback b)
        {
            a.RemoveListener(b);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, TResult> operator +(FuncEvent<T1, TResult> a, Func<TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, TResult> operator -(FuncEvent<T1, TResult> a, Func<TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, TResult> operator +(FuncEvent<T1, TResult> a, Func<T1, TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, TResult> operator -(FuncEvent<T1, TResult> a, Func<T1, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FuncEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void AddListener(Func<T1, TResult> callback) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void RemoveListener(Func<T1, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            RemoveListener(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// Extension event
    /// </summary>
    public class FuncEvent<T1, T2, TResult> : FuncEvent<T1, TResult>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator +(FuncEvent<T1, T2, TResult> a, Callback b)
        {
            a.AddListener(b);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator -(FuncEvent<T1, T2, TResult> a, Callback b)
        {
            a.RemoveListener(b);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator +(FuncEvent<T1, T2, TResult> a, Func<TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator -(FuncEvent<T1, T2, TResult> a, Func<TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator +(FuncEvent<T1, T2, TResult> a, Func<T1, TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator -(FuncEvent<T1, T2, TResult> a, Func<T1, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator +(FuncEvent<T1, T2, TResult> a, Func<T1, T2, TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator -(FuncEvent<T1, T2, TResult> a, Func<T1, T2, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FuncEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void AddListener(Func<T1, T2, TResult> callback) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void RemoveListener(Func<T1, T2, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            RemoveListener(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// Extension event
    /// </summary>
    public class FuncEvent<T1, T2, T3, TResult> : FuncEvent<T1, T2, TResult>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator +(FuncEvent<T1, T2, T3, TResult> a, Callback b)
        {
            a.AddListener(b);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator -(FuncEvent<T1, T2, T3, TResult> a, Callback b)
        {
            a.RemoveListener(b);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator +(FuncEvent<T1, T2, T3, TResult> a, Func<TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator -(FuncEvent<T1, T2, T3, TResult> a, Func<TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator +(FuncEvent<T1, T2, T3, TResult> a, Func<T1, TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator -(FuncEvent<T1, T2, T3, TResult> a, Func<T1, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator +(FuncEvent<T1, T2, T3, TResult> a, Func<T1, T2, TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator -(FuncEvent<T1, T2, T3, TResult> a, Func<T1, T2, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator +(FuncEvent<T1, T2, T3, TResult> a, Func<T1, T2, T3, TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator -(FuncEvent<T1, T2, T3, TResult> a, Func<T1, T2, T3, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FuncEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void AddListener(Func<T1, T2, T3, TResult> callback) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void RemoveListener(Func<T1, T2, T3, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            RemoveListener(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// Extension event
    /// </summary>
    public class FuncEvent<T1, T2, T3, T4, TResult> : FuncEvent<T1, T2, TResult>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator +(FuncEvent<T1, T2, T3, T4, TResult> a, Callback b)
        {
            a.AddListener(b);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator -(FuncEvent<T1, T2, T3, T4, TResult> a, Callback b)
        {
            a.RemoveListener(b);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator +(FuncEvent<T1, T2, T3, T4, TResult> a, Func<TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator -(FuncEvent<T1, T2, T3, T4, TResult> a, Func<TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator +(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator -(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator +(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, T2, TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator -(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, T2, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator +(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, T2, T3, TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator -(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, T2, T3, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator +(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, T2, T3, T4, TResult> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator -(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, T2, T3, T4, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.RemoveListener(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FuncEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void AddListener(Func<T1, T2, T3, T4, TResult> callback) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void RemoveListener(Func<T1, T2, T3, T4, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            RemoveListener(callback);
            CallbackRef.RefDel(listener);
        }
    }
}
