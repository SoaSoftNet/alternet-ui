using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

[module: DefaultCharSet(CharSet.Unicode)]

namespace Alternet.UI.Native
{
    [SuppressUnmanagedCodeSecurity]
    internal abstract class NativeApiProvider
    {
#if NETCOREAPP
        public const string NativeModuleName = "Alternet.UI.Pal";
#else
        public const string NativeModuleName = "Alternet.UI.Pal.dll";
#endif

        private static bool initialized;

        public static void Initialize()
        {
            if (!initialized)
            {
                WindowsNativeModulesLocator.SetNativeModulesDirectory();

                Debug.Assert(!unhandledExceptionCallbackHandle.IsAllocated);
                Debug.Assert(!caughtExceptionCallbackHandle.IsAllocated);

                var unhandledExceptionCallbackSink = new NativeExceptionsMarshal.NativeExceptionCallbackType(NativeExceptionsMarshal.OnUnhandledNativeException);
                unhandledExceptionCallbackHandle = GCHandle.Alloc(unhandledExceptionCallbackSink);

                var caughtExceptionCallbackSink = new NativeExceptionsMarshal.NativeExceptionCallbackType(NativeExceptionsMarshal.OnCaughtNativeException);
                caughtExceptionCallbackHandle = GCHandle.Alloc(caughtExceptionCallbackSink);

                SetExceptionCallback(unhandledExceptionCallbackSink, caughtExceptionCallbackSink);

                initialized = true;
            }
        }

        [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
        static extern void SetExceptionCallback(
            NativeExceptionsMarshal.NativeExceptionCallbackType unhandledExceptionCallback,
            NativeExceptionsMarshal.NativeExceptionCallbackType caughtExceptionCallback);

        static GCHandle unhandledExceptionCallbackHandle;
        static GCHandle caughtExceptionCallbackHandle;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public delegate void PInvokeCallbackActionType();

        private class WindowsNativeModulesLocator
        {
            public static void SetNativeModulesDirectory()
            {
#if NETCOREAPP
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return;
#endif
                var assemblyDirectory = Path.GetDirectoryName(new Uri(typeof(NativeApiProvider).Assembly.EscapedCodeBase).LocalPath)!;
                var nativeModulesDirectory = Path.Combine(assemblyDirectory, IntPtr.Size == 8 ? "x64" : "x86");
                if (!Directory.Exists(nativeModulesDirectory))
                    return;

                var ok = SetDllDirectory(nativeModulesDirectory);
                if (!ok)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern bool SetDllDirectory(string path);
        }
    }
}