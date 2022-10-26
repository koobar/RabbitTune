using System.ComponentModel;

namespace RabbitTune.Controls
{
    internal static class ControlUtils
    {
        /// <summary>
        /// このメソッドがVisual StudioのWindows Forms デザイナーから呼び出されていればtrueを、
        /// そうでなければfalseを返す。
        /// </summary>
        /// <returns></returns>
        public static bool IsDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }
    }
}
