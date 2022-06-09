namespace PT_Lab6
{
    /// <summary>
    ///  ласс главной формы
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// —войство хран€щее в себе текущие параметры часов (нужна дл€ доступа формы редактировани€)
        /// </summary>
        internal ClockParams ClockParams
        {
            get { return clockParams; }
        }
        /// <summary>
        /// Ёкземпл€р формы редактировани€ параметров часов
        /// </summary>
        EditClockForm form = new EditClockForm();

        private ClockParams clockParams = new ClockParams();

        public Form1()
        {
           
            InitializeComponent();
        }
        /// <summary>
        /// ћетод загрузки формы - запускает таймер
        /// записывает в переменную формы дл€ класса рисовани€ часов текущую форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
           
            timer1.Start();
            ClockDrawer.MainForm = this;
        }
        /// <summary>
        /// —обытие рисовани€ формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // установка параметров графики: сглаживани€ и интерпол€ции
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ClockDrawer.DrawClock(e.Graphics, clockParams);// вызов метода рисовани€ часов и статического класса ClockDrawer
            
        }
        /// <summary>
        /// —обытие прохождени€ интервала времени на таймере - происходит перерисовка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
        /// <summary>
        /// —обытие щелчка по элементу контекстного меню формы - вызывает форму дл€ редактировани€ часов
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
        /// —обытие щелчка по элементу контекстного меню формы - вызывает форму с данными об авторе
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