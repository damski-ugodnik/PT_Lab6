using System.Text.Json;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
namespace PT_Lab6
{
    /// <summary>
    /// Стурктура, хранящая в себе параметры часов
    /// </summary>
    [DataContract]
    public struct ClockParams
    {
        /// <summary>
        /// Статический экземпляр класса сериализатора JSON для сохранения и открытия файлов
        /// </summary>
        private static DataContractJsonSerializer _dataContractJsonSerializer = new DataContractJsonSerializer(typeof(ClockParams));
        /// <summary>
        /// Цвет элемента часов
        /// </summary>
        [DataMember]
        public readonly Color primaryColor, contourColor, arrowsColor;
        /// <summary>
        /// Форма часов
        /// </summary>
        [DataMember]
        public readonly ClockForm clockForm;
        /// <summary>
        /// Тип циферблата
        /// </summary>
        [DataMember]
        public readonly ClockFace clockFace;
        /// <summary>
        /// Форма стрелок
        /// </summary>
        [DataMember]
        public readonly ArrowForm arrowForm;
        /// <summary>
        /// Длинна стрелки
        /// </summary>
        [DataMember]
        public readonly float secondArrowLength = 0, hourArrowLength = 0, minuteArrowLength = 0;
        /// <summary>
        /// Размер часов
        /// </summary>
        [DataMember]
        public readonly Size size;
        /// <summary>
        /// Шрифт текста на часах (не сериализуется)
        /// </summary>
        public readonly Font font;
        /// <summary>
        /// Базовый конструкор по умолчанию
        /// </summary>
        public ClockParams()
        {
            primaryColor = Color.White;
            contourColor = Color.Black;
            arrowsColor = Color.Black;
            clockForm = ClockForm.Ellipse;
            clockFace = ClockFace.Quarters;
            arrowForm = ArrowForm.Triangle;
            font = Form.DefaultFont;
            size = new Size(400, 400);
            if (size.Height <= size.Width)
            {
                secondArrowLength = size.Height / 2 - font.Height-10;
                minuteArrowLength = (secondArrowLength*2)/3;
                hourArrowLength = minuteArrowLength / 2;
            }
            else
            {
                secondArrowLength = size.Width / 2 - font.Height-10;
                minuteArrowLength = (secondArrowLength * 2) / 3;
                hourArrowLength = minuteArrowLength / 2;
            }
        }
        /// <summary>
        /// Конструктор с устанавливаемыми параметрами
        /// </summary>
        /// <param name="primaryColor">Основной цвет</param>
        /// <param name="arrowsColor">Цвет стрелок</param>
        /// <param name="clockForm">Форма часов</param>
        /// <param name="size">Размер часов</param>
        /// <param name="clockFace">Тип циферблата</param>
        /// <param name="arrowForm">Форма часов</param>
        /// <param name="font">Шрифт циферблата</param>
        /// <param name="countourColor">Цвет контура</param>
        public ClockParams(Color primaryColor, Color arrowsColor, ClockForm clockForm, Size size, ClockFace clockFace, ArrowForm arrowForm, Font font, Color countourColor):this()
        {
            this.primaryColor = primaryColor;
            this.arrowsColor = arrowsColor;
            this.contourColor = countourColor;
            this.clockForm = clockForm;
            this.size = size;
            this.clockFace = clockFace;
            this.arrowForm = arrowForm;
            this.font = font;
            // устновка длинны стрелок
            if (size.Height <= size.Width)
            {
                secondArrowLength = size.Height / 2 - font.Height - 10;
                minuteArrowLength = (secondArrowLength * 3) / 4;
                hourArrowLength = minuteArrowLength / 2;
            }
            else
            {
                secondArrowLength = size.Width / 2 - font.Height - 10;
                minuteArrowLength = (secondArrowLength * 3) / 4;
                hourArrowLength = minuteArrowLength / 2;
            }
        }
        /// <summary>
        /// Метод сохранения параметров часов
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="clockParams"></param>
        public static void SaveClockParams(string fileName, ClockParams clockParams)
        {
  
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)) {
                _dataContractJsonSerializer.WriteObject(fs,clockParams);
            }
            
        }
        /// <summary>
        /// Метод открытия парамеетров часов из файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static ClockParams ImportClockParams(string fileName)
        {

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                ClockParams? temp = (ClockParams?)_dataContractJsonSerializer.ReadObject(fs);
                if (temp != null)
                    return (ClockParams)temp;
                else return new ClockParams();
            }
        }
    }
}
