using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.Threading;

namespace ScWebBrowser.util
{
    #region WebPreview的类库
    /// <summary>
    /// ActiveX 组件快照类
    /// AcitveX 必须实现 IViewObject 接口
    /// 
    /// 作者:随飞
    /// http://chinasf.cnblogs.com
    /// chinasf@hotmail.com
    /// </summary>
    class Snapshot
    {
        /// <summary>
        /// 取快照
        /// </summary>
        /// <param name="pUnknown">Com 对象</param>
        /// <param name="bmpRect">图象大小</param>
        /// <returns></returns>
        public Bitmap TakeSnapshot(object pUnknown, Rectangle bmpRect)
        {
            if (pUnknown == null)
                return null;
            //必须为com对象
            if (!Marshal.IsComObject(pUnknown))
                return null;
            //IViewObject 接口
            UnsafeNativeMethods.IViewObject ViewObject = null;
            IntPtr pViewObject = IntPtr.Zero;
            //内存图
            Bitmap pPicture = new Bitmap(bmpRect.Width, bmpRect.Height);
            Graphics hDrawDC = Graphics.FromImage(pPicture);
            //获取接口
            object hret = Marshal.QueryInterface(Marshal.GetIUnknownForObject(pUnknown),
                ref UnsafeNativeMethods.IID_IViewObject, out pViewObject);
            try
            {
                ViewObject = Marshal.GetTypedObjectForIUnknown(pViewObject, typeof(UnsafeNativeMethods.IViewObject)) as UnsafeNativeMethods.IViewObject;
                //调用Draw方法
                ViewObject.Draw((int)DVASPECT.DVASPECT_CONTENT,
                    -1,
                    IntPtr.Zero,
                    null,
                    IntPtr.Zero,
                    hDrawDC.GetHdc(),
                    new NativeMethodsTemp.COMRECT(bmpRect),
                    null,
                    IntPtr.Zero,
                    0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            //释放
            hDrawDC.Dispose();
            return pPicture;
        }
    }

    /// <summary>
    /// 从 .Net 2.0 的 System.Windows.Forms.Dll 库提取
    /// 版权所有：微软公司
    /// </summary>
    internal static class NativeMethodsTemp
    {
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagDVTARGETDEVICE
        {
            [MarshalAs(UnmanagedType.U4)]
            public int tdSize;
            [MarshalAs(UnmanagedType.U2)]
            public short tdDriverNameOffset;
            [MarshalAs(UnmanagedType.U2)]
            public short tdDeviceNameOffset;
            [MarshalAs(UnmanagedType.U2)]
            public short tdPortNameOffset;
            [MarshalAs(UnmanagedType.U2)]
            public short tdExtDevmodeOffset;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class COMRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public COMRECT()
            {
            }

            public COMRECT(Rectangle r)
            {
                this.left = r.X;
                this.top = r.Y;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }

            public COMRECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public static NativeMethodsTemp.COMRECT FromXYWH(int x, int y, int width, int height)
            {
                return new NativeMethodsTemp.COMRECT(x, y, x + width, y + height);
            }

            public override string ToString()
            {
                return string.Concat(new object[] { "Left = ", this.left, " Top ", this.top, " Right = ", this.right, " Bottom = ", this.bottom });
            }

        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagLOGPALETTE
        {
            [MarshalAs(UnmanagedType.U2)]
            public short palVersion;
            [MarshalAs(UnmanagedType.U2)]
            public short palNumEntries;
        }
    }

    /// <summary>
    /// 从 .Net 2.0 的 System.Windows.Forms.Dll 库提取
    /// 版权所有：微软公司
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static class UnsafeNativeMethods
    {
        public static Guid IID_IViewObject = new Guid("{0000010d-0000-0000-C000-000000000046}");

        [ComImport, Guid("0000010d-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IViewObject
        {
            [PreserveSig]
            int Draw([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [In] NativeMethodsTemp.tagDVTARGETDEVICE ptd, IntPtr hdcTargetDev, IntPtr hdcDraw, [In] NativeMethodsTemp.COMRECT lprcBounds, [In] NativeMethodsTemp.COMRECT lprcWBounds, IntPtr pfnContinue, [In] int dwContinue);
            [PreserveSig]
            int GetColorSet([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [In] NativeMethodsTemp.tagDVTARGETDEVICE ptd, IntPtr hicTargetDev, [Out] NativeMethodsTemp.tagLOGPALETTE ppColorSet);
            [PreserveSig]
            int Freeze([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [Out] IntPtr pdwFreeze);
            [PreserveSig]
            int Unfreeze([In, MarshalAs(UnmanagedType.U4)] int dwFreeze);
            void SetAdvise([In, MarshalAs(UnmanagedType.U4)] int aspects, [In, MarshalAs(UnmanagedType.U4)] int advf, [In, MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink);
            void GetAdvise([In, Out, MarshalAs(UnmanagedType.LPArray)] int[] paspects, [In, Out, MarshalAs(UnmanagedType.LPArray)] int[] advf, [In, Out, MarshalAs(UnmanagedType.LPArray)] IAdviseSink[] pAdvSink);
        }

        /// <summary>
        /// retrieves the status of the specified virtual key
        /// </summary>
        /// <param name="KeyCode">Specifies a virtual key</param>
        /// <returns>
        /// The return value specifies the status of the specified virtual key, as follows: 
        ///  If the high-order bit is 1, the key is down; otherwise, it is up.
        ///  If the low-order bit is 1, the key is toggled. A key, such as the CAPS LOCK key, 
        ///  is toggled if it is turned on. The key is off and untoggled if the low-order bit is 0.
        ///  A toggle key's indicator light (if any) on the keyboard will be on when the key is
        ///  toggled, and off when the key is untoggled.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetKeyState(int KeyCode);
    }
    #endregion
}
