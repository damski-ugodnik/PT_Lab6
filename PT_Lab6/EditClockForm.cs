using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PT_Lab6
{
    /// <summary>
    /// Класс формы для редактированяия параметров часов
    /// </summary>
    public partial class EditClockForm : Form
    { 
        /// <summary>
        /// Экземпляр структуры, хранящей в себе параметры часов
        /// </summary>
        internal ClockParams EditedClockParams
        {
            get;
            set;
        }
        /// <summary>
        /// Делегат для события изменения параметров с помощью файла
        /// </summary>
        private delegate void ClockParamsHandler();
        /// <summary>
        /// Событие изменения параметров через файл
        /// </summary>
        private event ClockParamsHandler EditedClockParamsChanged;
        /// <summary>
        /// Метка указывающая на то, была ли уже показана эта форма в этой сессии
        /// (сделано для того, чтобы поля Combo box не дополнялись ещё раз)
        /// </summary>
        bool beenShown = false;
        /// <summary>
        /// Конструктор класса формы
        /// </summary>
        public EditClockForm()
        {
            EditedClockParamsChanged += new ClockParamsHandler(EditedClockParams_Changed);//подписка обработчика на событие изменения параметров формы
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик нажатия кнопки изменения цвета -  устанавливает необходимый цвет и кнопка меняет цвет, цвет текста противоположен цвету кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorBox_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                (sender as Button).BackColor = colorDialog1.Color;
                (sender as Button).ForeColor = Color.FromArgb(255 - colorDialog1.Color.R, 255 - colorDialog1.Color.G, 255 - colorDialog1.Color.B);
            }
        }
        /// <summary>
        /// Загрузка формы: установка свойств каждого элемента в соответствии со значением параметра который он редактрует
        /// добавление вариантов в поля Combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditClockForm_Load(object sender, EventArgs e)
        {
            widthBox.Maximum = heightBox.Maximum = Singleton.Instance.Width;// установка максимального значения для размеров часов в соответсвии с размером главной формы
            widthBox.Value = Singleton.Instance.ClockParams.size.Width;// установка значений размеров часов
            heightBox.Value = Singleton.Instance.ClockParams.size.Height;
            if (!beenShown)// если ещё не была показана форма - в поля Combo box добавляются элементы из перечислений для соответсвующего параметра
            {
                beenShown = true;
                foreach (string clockForm in Enum.GetNames(typeof(ClockForm)))
                {
                    formBox.Items.Add(clockForm);
                }
                formBox.SelectedIndex = (int)Singleton.Instance.ClockParams.clockForm;
                foreach (string clockFace in Enum.GetNames(typeof(ClockFace)))
                {
                    clockFaceComboBox.Items.Add(clockFace);
                }
                clockFaceComboBox.SelectedIndex = (int)Singleton.Instance.ClockParams.clockFace;
                foreach (string arrowForm in Enum.GetNames(typeof(ArrowForm)))
                {
                    arrowFormComboBox.Items.Add(arrowForm);
                }
            }
            formBox.SelectedIndex = (int)Singleton.Instance.ClockParams.clockForm;// установка индекса выбора для формы часов в соответсвии с текущими параметрами
            clockFaceComboBox.SelectedIndex = (int)Singleton.Instance.ClockParams.clockFace;// установка индекса выбора для разметки циферблата в соответсвии с текущими параметрами
            arrowFormComboBox.SelectedIndex = (int)Singleton.Instance.ClockParams.arrowForm;// установка индекса выбора для формы стрелок в соответсвии с текущими параметрами
            Color color;// переменная цвета для инвертирования его
            color = arrowColorBox.BackColor = Singleton.Instance.ClockParams.arrowsColor;// цвет кнопки выбора цвета стрелок равен цвету стрелок в парметрах (также записывается в переменную color)
            arrowColorBox.ForeColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);// цвет текста в кнопке инвертируется относительно цвета кнопки
            color = primaryColorBox.BackColor = Singleton.Instance.ClockParams.primaryColor;// цвет кнопки выбора цвета часов равен цвету стрелок в парметрах (также записывается в переменную color)
            primaryColorBox.ForeColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);// цвет текста в кнопке инвертируется относительно цвета кнопки
            color = secondaryColorBox.BackColor = Singleton.Instance.ClockParams.contourColor;// цвет кнопки выбора цвета контура равен цвету стрелок в парметрах (также записывается в переменную color)
            secondaryColorBox.ForeColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);// цвет текста в кнопке инвертируется относительно цвета кнопки
            fontButton.Text = Singleton.Instance.ClockParams.font.Name;// текст в кнопке выбора шрифта равен названию шрифта в параметрах
            fontButton.Font = Singleton.Instance.ClockParams.font;// шрифт текста в в кнопке выбора шрифта равен шрифту в параметрах

        }
        /// <summary>
        /// Обработчик изменения свойства новых параметров - аналогичен процессу загрузки окна, но параметры берутся уже из свойства EditedClockParams, поскольку в него происходит запись из файла\
        /// ! - изменения шрифта не происходит, потому что класс Font не сериализуется
        /// </summary>
        private void EditedClockParams_Changed()
        {
            widthBox.Maximum = heightBox.Maximum = Singleton.Instance.Width;
            widthBox.Value = EditedClockParams.size.Width;
            heightBox.Value = EditedClockParams.size.Height;
            arrowFormComboBox.SelectedIndex = (int)EditedClockParams.arrowForm;
            formBox.SelectedIndex = (int)EditedClockParams.clockForm;
            clockFaceComboBox.SelectedIndex = (int)EditedClockParams.clockFace;
            Color color;
            color = arrowColorBox.BackColor = EditedClockParams.arrowsColor;
            arrowColorBox.ForeColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
            color = primaryColorBox.BackColor = EditedClockParams.primaryColor;
            primaryColorBox.ForeColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
            color = secondaryColorBox.BackColor = EditedClockParams.contourColor;
            secondaryColorBox.ForeColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }
        /// <summary>
        /// Обработчик нажатия кнопки изменения шрифта: открывается диалог изменения шрифта и после установки параметров, эти значения устанавливаются как шрифт кнопки, а текст отображает название шрф=ифта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontButton_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                fontButton.Text = fontDialog1.Font.Name;// установкаа названия шрифта
                fontButton.Font = fontDialog1.Font;// установка шрифта
            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки - создаёт экземпляр структуры параметров часов и записывает его в свойство
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            ClockParams clockParams = new ClockParams(primaryColorBox.BackColor, arrowColorBox.BackColor, (ClockForm)formBox.SelectedIndex, new Size((int)widthBox.Value, (int)heightBox.Value), (ClockFace)clockFaceComboBox.SelectedIndex, (ArrowForm)arrowFormComboBox.SelectedIndex,fontDialog1.Font, secondaryColorBox.BackColor);
            EditedClockParams = clockParams;
        }
        /// <summary>
        /// Обработчик нажатия кнопки импортирования параметров - открывает диалог для открытия файлов,вызывает метод структуры ClockParams для вытягивания парамтеров из файла
        /// затем записывает их в свойство и вызывает событие изменения свойства параметров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ClockParams clockParams = ClockParams.ImportClockParams(openFileDialog.FileName);
                EditedClockParams = clockParams;
                EditedClockParamsChanged();
            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки сохраниния файлов в файл -  открывает диалог и по указанному пути сохраняет передавая методу структуры ClockParams путь и экземпляр структуры с параметрами указанными в форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ClockParams.SaveClockParams(saveFileDialog.FileName, new ClockParams(primaryColorBox.BackColor, arrowColorBox.BackColor, (ClockForm)formBox.SelectedIndex, new Size((int)widthBox.Value, (int)heightBox.Value), (ClockFace)clockFaceComboBox.SelectedIndex, (ArrowForm)arrowFormComboBox.SelectedIndex, fontDialog1.Font, secondaryColorBox.BackColor));
            }
        }
        /// <summary>
        /// При изменении значения высоты или ширины, если в качестве формы указан квадрат или круг, оба параметра равны
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sizeBox_ValueChanged(object sender, EventArgs e)
        {
            if(formBox.SelectedIndex<=1)
            {
                if(sender==widthBox)
                {
                    heightBox.Value = widthBox.Value;
                }
                else { widthBox.Value = heightBox.Value; }
            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки сброса к параметрам по умлочанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toDefaultButton_Click(object sender, EventArgs e)
        {
            EditedClockParams = new ClockParams();
            EditedClockParamsChanged();
        }
    }
}
