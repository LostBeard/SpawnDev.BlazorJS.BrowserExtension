using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// Extension event
    /// </summary>
    public class ActionEvent : ExtensionEvent
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent operator +(ActionEvent a, Callback b)
        {
            a.AddListener(b);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent operator -(ActionEvent a, Callback b)
        {
            a.RemoveListener(b);
            return a;
        }
        
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent operator +(ActionEvent a, System.Action listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent operator -(ActionEvent a, System.Action listener)
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
        public ActionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void AddListener(System.Action callback) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void RemoveListener(System.Action listener)
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
    public class ActionEvent<T1> : ActionEvent
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1> operator +(ActionEvent<T1> a, Callback b)
        {
            a.AddListener(b);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1> operator -(ActionEvent<T1> a, Callback b)
        {
            a.RemoveListener(b);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1> operator +(ActionEvent<T1> a, System.Action listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1> operator -(ActionEvent<T1> a, System.Action listener)
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
        public static ActionEvent<T1> operator +(ActionEvent<T1> a, Action<T1> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1> operator -(ActionEvent<T1> a, Action<T1> listener)
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
        public ActionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void AddListener(Action<T1> callback) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void RemoveListener(Action<T1> listener)
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
    public class ActionEvent<T1, T2> : ActionEvent<T1>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2> operator +(ActionEvent<T1, T2> a, Callback b)
        {
            a.AddListener(b);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2> operator -(ActionEvent<T1, T2> a, Callback b)
        {
            a.RemoveListener(b);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2> operator +(ActionEvent<T1, T2> a, System.Action listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2> operator -(ActionEvent<T1, T2> a, System.Action listener)
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
        public static ActionEvent<T1, T2> operator +(ActionEvent<T1, T2> a, Action<T1> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2> operator -(ActionEvent<T1, T2> a, Action<T1> listener)
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
        public static ActionEvent<T1, T2> operator +(ActionEvent<T1, T2> a, Action<T1, T2> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2> operator -(ActionEvent<T1, T2> a, Action<T1, T2> listener)
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
        public ActionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void AddListener(Action<T1, T2> callback) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void RemoveListener(Action<T1, T2> listener)
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
    public class ActionEvent<T1, T2, T3> : ActionEvent<T1, T2>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator +(ActionEvent<T1, T2, T3> a, Callback b)
        {
            a.AddListener(b);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator -(ActionEvent<T1, T2, T3> a, Callback b)
        {
            a.RemoveListener(b);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator +(ActionEvent<T1, T2, T3> a, System.Action listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator -(ActionEvent<T1, T2, T3> a, System.Action listener)
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
        public static ActionEvent<T1, T2, T3> operator +(ActionEvent<T1, T2, T3> a, Action<T1> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator -(ActionEvent<T1, T2, T3> a, Action<T1> listener)
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
        public static ActionEvent<T1, T2, T3> operator +(ActionEvent<T1, T2, T3> a, Action<T1, T2> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator -(ActionEvent<T1, T2, T3> a, Action<T1, T2> listener)
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
        public static ActionEvent<T1, T2, T3> operator +(ActionEvent<T1, T2, T3> a, Action<T1, T2, T3> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator -(ActionEvent<T1, T2, T3> a, Action<T1, T2, T3> listener)
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
        public ActionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void AddListener(Action<T1, T2, T3> callback) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void RemoveListener(Action<T1, T2, T3> listener)
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
    public class ActionEvent<T1, T2, T3, T4> : ActionEvent<T1, T2, T3>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator +(ActionEvent<T1, T2, T3, T4> a, Callback b)
        {
            a.AddListener(b);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator -(ActionEvent<T1, T2, T3, T4> a, Callback b)
        {
            a.RemoveListener(b);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator +(ActionEvent<T1, T2, T3, T4> a, System.Action listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator -(ActionEvent<T1, T2, T3, T4> a, System.Action listener)
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
        public static ActionEvent<T1, T2, T3, T4> operator +(ActionEvent<T1, T2, T3, T4> a, Action<T1> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator -(ActionEvent<T1, T2, T3, T4> a, Action<T1> listener)
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
        public static ActionEvent<T1, T2, T3, T4> operator +(ActionEvent<T1, T2, T3, T4> a, Action<T1, T2> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator -(ActionEvent<T1, T2, T3, T4> a, Action<T1, T2> listener)
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
        public static ActionEvent<T1, T2, T3, T4> operator +(ActionEvent<T1, T2, T3, T4> a, Action<T1, T2, T3> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator -(ActionEvent<T1, T2, T3, T4> a, Action<T1, T2, T3> listener)
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
        public static ActionEvent<T1, T2, T3, T4> operator +(ActionEvent<T1, T2, T3, T4> a, Action<T1, T2, T3, T4> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator -(ActionEvent<T1, T2, T3, T4> a, Action<T1, T2, T3, T4> listener)
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
        public ActionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void AddListener(Action<T1, T2, T3, T4> callback) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void RemoveListener(Action<T1, T2, T3, T4> listener)
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
    public class ActionEvent<T1, T2, T3, T4, T5> : ActionEvent<T1, T2, T3, T4>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Callback b)
        {
            a.AddListener(b);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Callback b)
        {
            a.RemoveListener(b);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, System.Action listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, System.Action listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2, T3> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2, T3> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2, T3, T4> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2, T3, T4> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2, T3, T4, T5> listener)
        {
            a.AddListener(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2, T3, T4, T5> listener)
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
        public ActionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="callback"></param>
        public virtual void AddListener(Action<T1, T2, T3, T4, T5> callback) => JSRef!.CallVoid("addListener", CallbackRef.RefAdd(callback));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void RemoveListener(Action<T1, T2, T3, T4, T5> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            RemoveListener(callback);
            CallbackRef.RefDel(listener);
        }
    }
}
