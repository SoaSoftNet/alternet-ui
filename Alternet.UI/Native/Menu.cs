// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class Menu : Control
    {
        static Menu()
        {
        }
        
        public Menu()
        {
            SetNativePointer(NativeApi.Menu_Create_());
        }
        
        public Menu(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public int ItemsCount
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Menu_GetItemsCount_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public void InsertItemAt(int index, MenuItem item)
        {
            CheckDisposed();
            NativeApi.Menu_InsertItemAt_(NativePointer, index, item.NativePointer);
        }
        
        public void RemoveItemAt(int index)
        {
            CheckDisposed();
            NativeApi.Menu_RemoveItemAt_(NativePointer, index);
        }
        
        public void ShowContextMenu(Control control, Alternet.Drawing.Point position)
        {
            CheckDisposed();
            NativeApi.Menu_ShowContextMenu_(NativePointer, control.NativePointer, position);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Menu_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int Menu_GetItemsCount_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Menu_InsertItemAt_(IntPtr obj, int index, IntPtr item);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Menu_RemoveItemAt_(IntPtr obj, int index);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Menu_ShowContextMenu_(IntPtr obj, IntPtr control, NativeApiTypes.Point position);
            
        }
    }
}
