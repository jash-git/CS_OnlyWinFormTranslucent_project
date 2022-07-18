namespace CS_OnlyWinFormTranslucent
{
    public partial class main_FrmBackgound : Form
    {
        public static Form frmBack;
        sub_FrmForeground sub_FrmForeground;//
        public main_FrmBackgound()
        {
            InitializeComponent();
        }

        public static void Show(Form frmTop, Form frmBackOwner, Color frmBackColor, double frmBackOpacity)
        {
            // 背景窗體設置          
            frmBack.FormBorderStyle = FormBorderStyle.None;
            frmBack.StartPosition = FormStartPosition.Manual;
            frmBack.ShowIcon = false;
            frmBack.ShowInTaskbar = false;
            frmBack.Opacity = frmBackOpacity;
            frmBack.BackColor = frmBackColor;
            frmBack.Owner = frmBackOwner;
            frmBack.Size = frmTop.Size;
            frmBack.Location = frmTop.Location;

            // 頂部窗體設置
            frmTop.Owner = frmBack;
            frmTop.StartPosition = FormStartPosition.Manual;
            frmTop.LocationChanged += (o, args) => { frmBack.Location = frmTop.Location; };

            // 顯示窗體
            frmTop.Show();
            frmBack.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(frmBack!=null)
            {
                frmBack.Close();
                frmBack = null;
            }
            frmBack = new Form();
            sub_FrmForeground = new sub_FrmForeground();
            Show(sub_FrmForeground, this, Color.Yellow, 0.8);

        }
    }
}