// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class RadioButton : Control
    {
        static RadioButton()
        {
            SetEventCallback();
        }
        
        public RadioButton()
        {
            SetNativePointer(NativeApi.RadioButton_Create_());
        }
        
        public RadioButton(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public string Text
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.RadioButton_GetText_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.RadioButton_SetText_(NativePointer, value);
            }
        }
        
        public bool IsChecked
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.RadioButton_GetIsChecked_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.RadioButton_SetIsChecked_(NativePointer, value);
            }
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.RadioButtonEventCallbackType((obj, e, parameter) =>
                UI.Application.HandleThreadExceptions(() =>
                {
                    var w = NativeObject.GetFromNativePointer<RadioButton>(obj, p => new RadioButton(p));
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                ));
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.RadioButton_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.RadioButtonEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.RadioButtonEvent.CheckedChanged:
                {
                    CheckedChanged?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                default: throw new Exception("Unexpected RadioButtonEvent value: " + e);
            }
        }
        
        public event EventHandler? CheckedChanged;
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr RadioButtonEventCallbackType(IntPtr obj, RadioButtonEvent e, IntPtr param);
            
            public enum RadioButtonEvent
            {
                CheckedChanged,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void RadioButton_SetEventCallback_(RadioButtonEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr RadioButton_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string RadioButton_GetText_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void RadioButton_SetText_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool RadioButton_GetIsChecked_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void RadioButton_SetIsChecked_(IntPtr obj, bool value);
            
        }
    }
}
