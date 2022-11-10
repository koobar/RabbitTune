using RabbitTune.WinApi;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RabbitTune.Taskbar
{
    internal class TaskbarListWrapper
    {
        // 非公開フィールド
        private IntPtr pTaskbarList = IntPtr.Zero;
        private ITaskbarList taskbar = null;
        private readonly Guid CLSID_TaskbarList = new Guid(0x56fdf344, 0xfd6d, 0x11d0, 0x95, 0x8a, 0x00, 0x60, 0x97, 0xc9, 0xa0, 0x90);
        private readonly IntPtr formHandle;
        public readonly uint WM_TBC;

        // 定数
        public const int CLSCTX_ALL = 0x17;

        #region コンストラクタ

        // コンストラクタ
        public TaskbarListWrapper(IntPtr form)
        {
            Ole32.CoCreateInstance(CLSID_TaskbarList, IntPtr.Zero, CLSCTX_ALL, typeof(ITaskbarList).GUID, out pTaskbarList);

            if (pTaskbarList == IntPtr.Zero)
            {
                throw new Exception();
            }

            this.taskbar = Marshal.GetTypedObjectForIUnknown(pTaskbarList, typeof(ITaskbarList)) as ITaskbarList;
            this.formHandle = form;

            WM_TBC = User32.RegisterWindowMessage("TaskbarButtonCreated");
        }

        // コンストラクタ
        public TaskbarListWrapper(Form form) : this(form.Handle) { }

        #endregion


        /// <summary>
        /// タスクバー
        /// </summary>
        public ITaskbarList Taskbar
        {
            get { return taskbar; }
        }

        /// <summary>
        /// ThumbBarにボタンを追加する。
        /// </summary>
        /// <param name="button"></param>
        public void ThumbBarAddButton(ThumbButton button)
        {
            this.taskbar.ThumbBarAddButtons(this.formHandle, 1, new ThumbButton[] { button });
        }

        /// <summary>
        /// ThumbBarにボタンを追加する。
        /// </summary>
        /// <param name="buttons"></param>
        public void ThumbBarAddButtons(params ThumbButton[] buttons)
        {
            this.taskbar.ThumbBarAddButtons(this.formHandle, (uint)buttons.Length, buttons);
        }

        /// <summary>
        /// ThumbBarのイメージリストを設定する。
        /// </summary>
        /// <param name="imagelist"></param>
        public void ThumbBarSetImageList(ImageList imagelist)
        {
            this.taskbar.ThumbBarSetImageList(this.formHandle, imagelist.Handle);
        }
    }
}
