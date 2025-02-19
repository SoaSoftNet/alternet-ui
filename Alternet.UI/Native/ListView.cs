// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class ListView : Control
    {
        static ListView()
        {
            SetEventCallback();
        }
        
        public ListView()
        {
            SetNativePointer(NativeApi.ListView_Create_());
        }
        
        public ListView(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public int ItemsCount
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ListView_GetItemsCount_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public ImageList? SmallImageList
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ListView_GetSmallImageList_(NativePointer);
                var m = NativeObject.GetFromNativePointer<ImageList>(n, p => new ImageList(p));
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ListView_SetSmallImageList_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public ImageList? LargeImageList
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ListView_GetLargeImageList_(NativePointer);
                var m = NativeObject.GetFromNativePointer<ImageList>(n, p => new ImageList(p));
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ListView_SetLargeImageList_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public ListViewView CurrentView
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ListView_GetCurrentView_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ListView_SetCurrentView_(NativePointer, value);
            }
        }
        
        public ListViewSelectionMode SelectionMode
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ListView_GetSelectionMode_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ListView_SetSelectionMode_(NativePointer, value);
            }
        }
        
        public System.Int32[] SelectedIndices
        {
            get
            {
                CheckDisposed();
                var array = NativeApi.ListView_OpenSelectedIndicesArray_(NativePointer);
                try
                {
                    var count = NativeApi.ListView_GetSelectedIndicesItemCount_(NativePointer, array);
                    var result = new System.Collections.Generic.List<int>(count);
                    for (int i = 0; i < count; i++)
                    {
                        var n = NativeApi.ListView_GetSelectedIndicesItemAt_(NativePointer, array, i);
                        var item = n;
                        result.Add(item);
                    }
                    return result.ToArray();
                }
                finally
                {
                    NativeApi.ListView_CloseSelectedIndicesArray_(NativePointer, array);
                }
            }
            
        }
        
        public void InsertItemAt(int index, string text, int columnIndex, int imageIndex)
        {
            CheckDisposed();
            NativeApi.ListView_InsertItemAt_(NativePointer, index, text, columnIndex, imageIndex);
        }
        
        public void RemoveItemAt(int index)
        {
            CheckDisposed();
            NativeApi.ListView_RemoveItemAt_(NativePointer, index);
        }
        
        public void ClearItems()
        {
            CheckDisposed();
            NativeApi.ListView_ClearItems_(NativePointer);
        }
        
        public void InsertColumnAt(int index, string header)
        {
            CheckDisposed();
            NativeApi.ListView_InsertColumnAt_(NativePointer, index, header);
        }
        
        public void RemoveColumnAt(int index)
        {
            CheckDisposed();
            NativeApi.ListView_RemoveColumnAt_(NativePointer, index);
        }
        
        public void ClearSelected()
        {
            CheckDisposed();
            NativeApi.ListView_ClearSelected_(NativePointer);
        }
        
        public void SetSelected(int index, bool value)
        {
            CheckDisposed();
            NativeApi.ListView_SetSelected_(NativePointer, index, value);
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.ListViewEventCallbackType((obj, e, parameter) =>
                UI.Application.HandleThreadExceptions(() =>
                {
                    var w = NativeObject.GetFromNativePointer<ListView>(obj, p => new ListView(p));
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                ));
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.ListView_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.ListViewEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.ListViewEvent.SelectionChanged:
                {
                    SelectionChanged?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                default: throw new Exception("Unexpected ListViewEvent value: " + e);
            }
        }
        
        public event EventHandler? SelectionChanged;
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr ListViewEventCallbackType(IntPtr obj, ListViewEvent e, IntPtr param);
            
            public enum ListViewEvent
            {
                SelectionChanged,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_SetEventCallback_(ListViewEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr ListView_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int ListView_GetItemsCount_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr ListView_GetSmallImageList_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_SetSmallImageList_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr ListView_GetLargeImageList_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_SetLargeImageList_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern ListViewView ListView_GetCurrentView_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_SetCurrentView_(IntPtr obj, ListViewView value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern ListViewSelectionMode ListView_GetSelectionMode_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_SetSelectionMode_(IntPtr obj, ListViewSelectionMode value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr ListView_OpenSelectedIndicesArray_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int ListView_GetSelectedIndicesItemCount_(IntPtr obj, System.IntPtr array);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int ListView_GetSelectedIndicesItemAt_(IntPtr obj, System.IntPtr array, int index);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_CloseSelectedIndicesArray_(IntPtr obj, System.IntPtr array);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_InsertItemAt_(IntPtr obj, int index, string text, int columnIndex, int imageIndex);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_RemoveItemAt_(IntPtr obj, int index);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_ClearItems_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_InsertColumnAt_(IntPtr obj, int index, string header);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_RemoveColumnAt_(IntPtr obj, int index);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_ClearSelected_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ListView_SetSelected_(IntPtr obj, int index, bool value);
            
        }
    }
}
