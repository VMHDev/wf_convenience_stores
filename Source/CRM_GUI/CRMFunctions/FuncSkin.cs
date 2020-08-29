using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_GUI.CRMFunctions
{
    public class FuncSkin
    {
        /// <summary>
        /// Load skin giao diện
        /// </summary>
        /// <param name="_SkinName">Tên Skin</param>
        /// <param name="_PaintStyle">Thông tin giao diện</param>
        public static void LoadSkins(string _SkinName, string _PaintStyle)
        {
            if (_PaintStyle == "Skin")
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_SkinName);
            }
            else
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetDefaultStyle();
            }
        }
    }
}
