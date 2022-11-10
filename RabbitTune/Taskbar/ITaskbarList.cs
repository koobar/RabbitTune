using System;
using System.Runtime.InteropServices;

namespace RabbitTune.Taskbar
{
    [ComImport(), Guid("EA1AFB91-9E28-4B86-90E9-9E9F8A5EEFAF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ITaskbarList
    {
        #region ITaskbarList
        void HrInit();
        void AddTab(IntPtr hWnd);
        void DeleteTab(IntPtr hWnd);
        void ActivateTab(IntPtr hWnd);
        void SetActiveAlt(IntPtr hWnd);
        #endregion

        #region ITaskbarList2
        IntPtr MarkFullscreenWindow(IntPtr hWnd, bool fFullscreen);
        #endregion

        #region ITaskbarList3

        void SetProgressValue(IntPtr hWnd, ulong Completed, ulong Total);
        void SetProgressState(IntPtr hWnd, TbpFlag Flags);
        void RegisterTab(IntPtr hWndTab, IntPtr hWndMDI);
        void UnregisterTab(IntPtr hWndTab);
        void SetTabOrder(IntPtr hWndTab, IntPtr hwndInsertBefore);
        void SetTabActive(IntPtr hWndTab, IntPtr hWndMDI, uint dwReserved);
        void ThumbBarAddButtons(IntPtr hWnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray)] ThumbButton[] pButtons);
        void ThumbBarUpdateButtons(IntPtr hWnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray)] ThumbButton[] pButtons);
        void ThumbBarSetImageList(IntPtr hWnd, IntPtr himl);
        void SetOverlayIcon(IntPtr hWnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);
        void SetThumbnailTooltip(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);
        void SetThumbnailClip(IntPtr hWnd, ref tagRECT prcClip);

        #endregion

        #region ITaskbarList4

        IntPtr SetTabProperties(IntPtr hWndTab, STPFLAG stpFlags);

        #endregion
    }
}
