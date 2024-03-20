using SpawnDev.BlazorJS;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Adds a few methods to JSObject instances that allow them to access the underlying proxy (if one)
    /// </summary>
    public static class WrappedObjectJSObjectExtensions
    {
        /// <summary>
        /// Returns true if the JSObject is a wrappedObject proxy
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsWrappedObject(this JSObject _this) => !_this.JSRef!.PropertyIsUndefined("__wrappedObjectRelease");
        /// <summary>
        /// Releases the object on the main content side
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool WrappedObjectRelease(this JSObject _this) => _this.JSRef!.Call<bool>("__wrappedObjectRelease");
        /// <summary>
        /// Requests a "clean" version of the object from the main side<br />
        /// The object is cleaned by running it through JSON.Parse(JSON.stringify(object))<br />
        /// This call may fail if the JSON.stringify method fails (possibly due to circular references)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static T WrappedObjectDecon<T>(this JSObject _this) => _this.JSRef!.Call<T>("__wrappedObjectDecon");
        /// <summary>
        /// Requests and unwrapped (direct) version of the object<br />
        /// This call may fail if the main side prevents the object from being returned
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static T WrappedObjectDirect<T>(this JSObject _this) => _this.JSRef!.Call<T>("__wrappedObjectDirect");
    }
}
