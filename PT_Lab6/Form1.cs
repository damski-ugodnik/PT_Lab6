namespace PT_Lab6
{
    /// <summary>
    /// ����� ������� �����
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// �������� �������� � ���� ������� ��������� ����� (����� ��� ������� ����� ��������������)
        /// </summary>
        internal ClockParams ClockParams
        {
            get { return clockParams; }
        }
        /// <summary>
        /// ��������� ����� �������������� ���������� �����
        /// </summary>
        EditClockForm form = new EditClockForm();

        private ClockParams clockParams = new ClockParams();

        public Form1()
        {
           
            InitializeComponent();
        }
        /// <summary>
        /// ����� �������� ����� - ��������� ������
        /// ���������� � ���������� ����� ��� ������ ��������� ����� ������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
           
            timer1.Start();
            ClockDrawer.MainForm = this;
        }
        /// <summary>
        /// ������� ��������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // ��������� ���������� �������: ����������� � ������������
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ClockDrawer.DrawClock(e.Graphics, clockParams);// ����� ������ ��������� ����� � ������������ ������ ClockDrawer
            
        }
        /// <summary>
        /// ������� ����������� ��������� ������� �� ������� - ���������� ����������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
        /// <summary>
        /// ������� ������ �� �������� ������������ ���� ����� - �������� ����� ��� �������������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editClockToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (form.ShowDialog() == DialogResult.OK)
            {
                clockParams = form.EditedClockParams;
            }
        }
        /// <summary>
        /// ������� ������ �� �������� ������������ ���� ����� - �������� ����� � ������� �� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorForm authorForm = new AuthorForm();
            authorForm.ShowDialog();
        }
    }
    
}