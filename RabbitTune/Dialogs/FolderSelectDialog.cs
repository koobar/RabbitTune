using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static RabbitTune.WinApi.Shell32;
using static RabbitTune.WinApi.User32;

namespace RabbitTune.Dialogs
{
    // このクラスは、以下のページを参考に作成しました。
    // https://stackoverflow.com/questions/15368771/show-detailed-folder-browser-from-a-propertygrid
    public class FolderSelectDialog
    {
        // 非公開定数
        private const uint ERROR_CANCELLED = 0x800704C7;

        /// <summary>
        /// 選択されたパス
        /// </summary>
        public string SelectedPath { get; set; }

        /// <summary>
        /// ダイアログを表示する。
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowDialog()
        {
            return ShowDialog(null);
        }

        /// <summary>
        /// ダイアログを表示する。
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(IWin32Window owner)
        {
            IntPtr hwndOwner = owner != null ? owner.Handle : GetActiveWindow();
            IFileOpenDialog dialog = (IFileOpenDialog)new FileOpenDialog();

            try
            {
                IShellItem item;

                if (!string.IsNullOrEmpty(this.SelectedPath))
                {
                    IntPtr idl;
                    uint atts = 0;

                    if (SHILCreateFromPath(this.SelectedPath, out idl, ref atts) == 0)
                    {
                        if (SHCreateShellItem(IntPtr.Zero, IntPtr.Zero, idl, out item) == 0)
                        {

                            dialog.SetFolder(item);
                        }

                        Marshal.FreeCoTaskMem(idl);
                    }
                }

                // ダイアログの種類を、フォルダ選択モードに設定する。
                dialog.SetOptions(FOS.FOS_PICKFOLDERS | FOS.FOS_FORCEFILESYSTEM);
                uint hr = dialog.Show(hwndOwner);

                // キャンセル操作が行われたか？
                if (hr == ERROR_CANCELLED)
                {
                    return DialogResult.Cancel;
                }

                if (hr != 0) return DialogResult.Abort;

                dialog.GetResult(out item);
                item.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out string path);
                this.SelectedPath = path;

                return DialogResult.OK;
            }
            finally
            {
                Marshal.ReleaseComObject(dialog);
            }
        }

        
    }
}
