using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_OnlyWinFormTranslucent
{
    public partial class sub_FrmForeground : Form
    {
        #region win32 api
        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        private const int LWA_ALPHA = 0;

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(
            IntPtr hwnd,
            int nIndex,
            uint dwNewLong
        );

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(
            IntPtr hwnd,
            int nIndex
        );

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(
            IntPtr hwnd,
            int crKey,
            int bAlpha,
            int dwFlags
        );
        #endregion

        public void SetPenetrate()
        {
            GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
        }

        public sub_FrmForeground()
        {
            InitializeComponent();

        }

        private void sub_FrmForeground_Load(object sender, EventArgs e)
        {
            // 設置背景全透明
            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = Color.AliceBlue;

            // 設置窗體鼠標穿透
            //SetPenetrate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
