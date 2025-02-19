// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class Timer : NativeObject
    {
        static Timer()
        {
            SetEventCallback();
        }
        
        public Timer()
        {
            SetNativePointer(NativeApi.Timer_Create_());
        }
        
        public Timer(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public bool Enabled
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Timer_GetEnabled_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Timer_SetEnabled_(NativePointer, value);
            }
        }
        
        public int Interval
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Timer_GetInterval_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Timer_SetInterval_(NativePointer, value);
            }
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.TimerEventCallbackType((obj, e, parameter) =>
                UI.Application.HandleThreadExceptions(() =>
                {
                    var w = NativeObject.GetFromNativePointer<Timer>(obj, p => new Timer(p));
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                ));
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.Timer_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.TimerEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.TimerEvent.Tick:
                {
                    Tick?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                default: throw new Exception("Unexpected TimerEvent value: " + e);
            }
        }
        
        public event EventHandler? Tick;
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr TimerEventCallbackType(IntPtr obj, TimerEvent e, IntPtr param);
            
            public enum TimerEvent
            {
                Tick,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Timer_SetEventCallback_(TimerEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Timer_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Timer_GetEnabled_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Timer_SetEnabled_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int Timer_GetInterval_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Timer_SetInterval_(IntPtr obj, int value);
            
        }
    }
}
