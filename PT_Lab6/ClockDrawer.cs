using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace PT_Lab6
{
    /// <summary>
    /// Статический класс для рисования часов.
    /// Содержит методы для рисования стрелок циферблата и других элементов
    /// </summary>
    internal static class ClockDrawer
    {
        /// <summary>
        /// Свойство хранящее в себе переменную главной формы, чтобы брать данные о ней
        /// </summary>
        public static Form MainForm { get; set; }
        /// <summary>
        /// Метод рисования часов рисует часы полностью - их форму, циферблат и стрелки, а также время в цифровом формате
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clockParams">Параметры часов</param>
        public static void DrawClock(Graphics g, ClockParams clockParams)
        {
            Rectangle rec = new Rectangle(new Point(MainForm.Width / 2 - clockParams.size.Width / 2, MainForm.Height / 2 - clockParams.size.Height / 2), clockParams.size);// объявление прямоугольника в котором будут нарисованы часы (располагается посередине формы, размеры берутся из экземпляра структуры параметров часов)
            DateTime dateTime = DateTime.Now;// установка текущего времени
            Brush clockBrush = new SolidBrush(clockParams.primaryColor);// создание кисти для фона часов - primary color из параметров
            Pen contourPen = new Pen(clockParams.contourColor, 3);// создание ручки для рисования контуров установленным цветом из параметров
            switch (clockParams.clockForm)
            {
                // если форма круг или овал
                case ClockForm.Circle:
                case ClockForm.Ellipse:
                    {
                        g.ResetTransform();// сброс координатных параметров графики
                        g.FillEllipse(clockBrush, rec);// рисование заливки часов
                        g.DrawEllipse(contourPen, rec);// рисование контура часов
                        g.TranslateTransform(MainForm.Width / 2, MainForm.Height / 2);// перенос точки отсчёта в центр формы
                        DrawEllipseClockFace(g, clockParams);// вызов метода рисования круглого циферблата
                        // рисование прямоугольника и строки на нём в нижней половине часов для отображения цифрового времени
                        g.FillRectangle(Brushes.Black, -(int)g.MeasureString(dateTime.ToLongTimeString(), clockParams.font).Width / 2, rec.Height / 4, (int)g.MeasureString(dateTime.ToLongTimeString(), clockParams.font).Width, clockParams.font.Height);
                        g.DrawString(dateTime.ToLongTimeString(), clockParams.font, Brushes.White, -(int)g.MeasureString(dateTime.ToLongTimeString(), clockParams.font).Width / 2, +rec.Height / 4);
                    }
                    break;
                // если форма часов - квадрат или прямоугольник
                case ClockForm.Square:
                case ClockForm.Rectangle:
                    {
                        //аналогичо с круглыми часами, но рисуется прямоугольник
                        g.ResetTransform();
                        g.FillRectangle(clockBrush, rec);
                        g.DrawRectangle(contourPen, rec);
                        g.TranslateTransform(MainForm.Width / 2, MainForm.Height / 2);
                        DrawRectangleClockFace(g, clockParams);// вызов метода рисования квадратного циферблата
                        // рисование прямоугольника и строки на нём в нижней половине часов для отображения цифрового времени
                        g.FillRectangle(Brushes.Black, -(int)g.MeasureString(dateTime.ToLongTimeString(), clockParams.font).Width / 2, rec.Height / 4, (int)g.MeasureString(dateTime.ToLongTimeString(), clockParams.font).Width, clockParams.font.Height);
                        g.DrawString(dateTime.ToLongTimeString(), clockParams.font, Brushes.White,  - (int)g.MeasureString(dateTime.ToLongTimeString(), clockParams.font).Width / 2, + rec.Height / 4);
                    }
                    break;
            }
            DrawArrows(g, clockParams, dateTime);// вызов метода рисования стрелок - передаётся текущее время
        }
        /// <summary>
        /// Метод рисования овального циферблата
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clockParams"></param>
        private static void DrawEllipseClockFace(Graphics g, ClockParams clockParams)
        {
            Brush brush = new SolidBrush(clockParams.arrowsColor);// создание кисти цвета стрелок

            float x, y;// координаты для расположения деления циферблата

            int deg = 30;// угол смещения для деления

            // цикл от 1 до 12 (часы)
            for (int i = 1; i <= 12; i++)
            {
                x = GetCos(i * deg + 90) * ((clockParams.size.Width - 30) / 2);// вычисление координаты х по косинусу текущего угла (30*переменную цикла) и уменьшеному радиусу чтобы деления были внутри часов
                y = GetSin(i * deg + 90) * ((clockParams.size.Height - 30) / 2);// вычисление координаты у по синусу текущего угла (30*переменную цикла) и уменьшеному радиусу чтобы деления были внутри часов
                switch (clockParams.clockFace)// в зависимости от разметки циферблата цифрами рисуются только конктретные деления
                {
                    case ClockFace.All:// рисуются все цифры
                        {
                            StringFormat format = new StringFormat();
                            format.Alignment = StringAlignment.Center;
                            format.LineAlignment = StringAlignment.Center;

                            g.DrawString(i.ToString(), clockParams.font, brush, -x, -y, format);

                        }
                        break;
                    case ClockFace.Seconds:// рисуются только чётные цифры другие рисуются в виде линий
                        {
                            if (i % 2 == 0)
                            {
                                StringFormat format = new StringFormat();
                                format.Alignment = StringAlignment.Center;
                                format.LineAlignment = StringAlignment.Center;

                                g.DrawString(i.ToString(), clockParams.font, brush, -x, -y, format);
                            }
                            else
                            {
                                g.TranslateTransform(-x, -y);// установка точки отсчёта на координату деления 
                                g.RotateTransform(i * deg); // поворот угла отсчёта на текущий угол (30 * количество часов)
                                g.DrawLine(new Pen(brush), 0, 0, 0, clockParams.font.Height);// рисование вертикальной относительно установленных координат линии равной по длинне высоте шрифта
                                g.RotateTransform(-i * deg);// возврат поворота в 0 градусов
                                g.ResetTransform();// сброс точки отсчёта
                                g.TranslateTransform(MainForm.Width / 2, MainForm.Height / 2);// установка точки отсчёта в центр
                            }
                        }break;
                    case ClockFace.Quarters:// рисуются только четверти (12,3,6,9)
                        {
                            if (i % 3 == 0)
                            {
                                StringFormat format = new StringFormat();
                                format.Alignment = StringAlignment.Center;
                                format.LineAlignment = StringAlignment.Center;

                                g.DrawString(i.ToString(), clockParams.font, brush, -x, -y, format);
                            }
                            else
                            {
                                g.TranslateTransform(-x, -y);// установка точки отсчёта на координату деления 
                                g.RotateTransform(i * deg); // поворот угла отсчёта на текущий угол (30 * количество часов)
                                g.DrawLine(new Pen(brush), 0, 0, 0, clockParams.font.Height);// рисование вертикальной относительно установленных координат линии равной по длинне высоте шрифта
                                g.RotateTransform(-i * deg);// возврат поворота в 0 градусов
                                g.ResetTransform();// сброс точки отсчёта
                                g.TranslateTransform(MainForm.Width / 2, MainForm.Height / 2);// установка точки отсчёта в центр
                            }
                        }break;
                    case ClockFace.None:// везде рисуются линии
                        {
                            g.TranslateTransform(-x, -y);
                            g.RotateTransform(i * deg);
                            g.DrawLine(new Pen(brush), 0, 0, 0, clockParams.font.Height);
                            g.RotateTransform(-i * deg);
                            g.ResetTransform();
                            g.TranslateTransform(MainForm.Width / 2, MainForm.Height / 2);
                        }break;
                }
              
            }
        }
        /// <summary>
        ///  Метод рисования квадратного циферблата
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clockParams"></param>
        private static void DrawRectangleClockFace(Graphics g, ClockParams clockParams)
        {

            Brush brush = new SolidBrush(clockParams.arrowsColor);

            float x = 0, y = 0;

            int deg = 360 / 12;
            // рассчёт половин уменьшенной высоты и ширины прямоугольника
            float semiWidth = (clockParams.size.Width - 30) / 2;
            float semiHeight = (clockParams.size.Height - 30) / 2;
            // рассчёт вертикальных и горизонтальных катетов относительно  половин высоты и ширины
            float verticalCathetus = semiWidth * (GetSin(deg) / GetCos(deg));
            float horizontalCathetus = semiHeight * (GetSin(deg) / GetCos(deg));
            // установка формата строки
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            // цикл от 1 до 12
            for (int i = 1; i <= 12; i++)
            {


                if (i % 3 == 0)// если цифра это четверть - т.е делится на 3
                {
                    x = semiWidth * (i % 2);// х равен половине ширины умноженной на остаток от деления числа  на 2 - тем самым чётные числа (12 и 6) будут иметь нулевой х и будут посередине, а нечётные (3 и 9) будут по бокам
                    y = semiHeight * MathF.Abs((i % 2) - 1);// у равен половине высоты умноженной на модуль остатка от деления числа на 2 минус 1, тем самым нечётные будут вертикально посередине, а чётные сверху и снизу

                    if (i == 12)// если число = 12, то у умножается на -1 чтобы перемеситься вверха
                    {
                        y *= -1;
                    }
                    if (i == 9)// если число равно 9, то х умножается на -1 чтобы переместиться влево
                    {
                        x *= -1;
                    }

                }
                else if (i % 2 == 0)// если чётное число
                {
                    if (verticalCathetus > semiHeight)// если вертикальный катет больше половины высоты, т.е при проведении из центра к вертикальному катету гипотенузы их пересечение будет за вертикальным пределом прямоугольника
                    {
                        y = semiHeight;// у равен половине высоты
                        x = semiHeight * (GetCos(deg) / GetSin(deg));// х равен котангенсу угла на половину высоты в итоге число будет лежать на горизонтальной стороне прямоугольника

                    }
                    else// иначе число будет лежать в границах прямоугольника без сторонних маниипуляций
                    {
                        x = semiWidth;// х равен половине высоты
                        y = verticalCathetus;// у равен вертикальному катету
                    }
                    if (i == 2 || i == 10)// если число равно 2 или 10, то у умножатеся на -1 чтобы переместить их вверх
                    {
                        y *= -1;
                    }
                    if (i == 10 || i == 8)// если чсло равно 8 или 10, то х умножается на -1 чтобы перместить их влево
                    {
                        x *= -1;
                    }

                }
                else// в ином случае это числа 1 5 7 11 
                {
                    if (horizontalCathetus > semiWidth)// если горизонтальный катет больше половины ширины, т.е, координата лежала бы вне прямоугольника по горизонтали
                    {
                        x = semiWidth;// х = половине ширины, следовательно лежит на вертикальной стороне прямоугольника
                        y = semiWidth * (GetCos(deg) / GetSin(deg));// у равен котангенсу угла на половину ширины
                    }
                    else// иначе всё ложится без дополнительных вычислений
                    {
                        x = horizontalCathetus;// х равен горизонтальному катету
                        y = semiHeight;// у равен половине высоты
                    }
                    if (i == 1 || i == 11)// если число равно 1 или 11, то его надо переместить вверх умножая у на -1
                    {
                        y *= -1;
                    }
                    if (i == 11 || i == 7)// если число равно 7 или 11, то его надо переместить влево умножая х на -1
                    {
                        x *= -1;
                    }
                }
                // в зависимости от типа циферблата разметка происходит по разному ( выбор рисования происходит аналогично с круглым циферблатом)
                switch (clockParams.clockFace)
                {
                    case ClockFace.Quarters:
                        {
                            if (i % 3 == 0)
                            {
                                g.DrawString(i.ToString(), clockParams.font, brush, x, y, format);
                            }
                            else
                            {
                                g.TranslateTransform(x, y);
                                g.RotateTransform(i * deg);
                                g.DrawLine(new Pen(brush), 0, 0, 0, clockParams.font.Height);
                                g.RotateTransform(-i * deg);
                                g.ResetTransform();
                                g.TranslateTransform(MainForm.Width / 2, MainForm.Height / 2);
                            }
                        }
                        break;
                    case ClockFace.Seconds:
                        {
                            if (i % 2 == 0)
                            {
                                g.DrawString(i.ToString(), clockParams.font, brush, x, y, format);
                            }
                            else
                            {
                                g.TranslateTransform(x, y);
                                g.RotateTransform(i * deg);
                                g.DrawLine(new Pen(brush), 0, 0, 0, clockParams.font.Height);
                                g.RotateTransform(-i * deg);
                                g.ResetTransform();
                                g.TranslateTransform(MainForm.Width / 2, MainForm.Height / 2);
                            }
                        }
                        break;
                    case ClockFace.None:
                        {
                            g.TranslateTransform(x, y);
                            g.RotateTransform(i * deg);
                            g.DrawLine(new Pen(brush), 0, 0, 0, clockParams.font.Height);
                            g.RotateTransform(-i * deg);
                            g.ResetTransform();
                            g.TranslateTransform(MainForm.Width / 2, MainForm.Height / 2);
                        }
                        break;
                    case ClockFace.All:
                        {
                            g.DrawString(i.ToString(), clockParams.font, brush, x, y, format);
                        }
                        break;

                }

                
            }


        }
        /// <summary>
        ///  метод получения синуса
        /// </summary>
        /// <param name="degAngle"></param>
        /// <returns></returns>
        private static float GetSin(float degAngle)
        {
            return MathF.Sin(MathF.PI * degAngle / 180f);
        }
        /// <summary>
        /// метод получения косинуса
        /// </summary>
        /// <param name="degAngle"></param>
        /// <returns></returns>
        private static float GetCos(float degAngle)
        {
            return MathF.Cos(MathF.PI * degAngle / 180f);
        }

        /// <summary>
        /// Метод рисования стрелок по текущему времени
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clockParams"></param>
        /// <param name="time"></param>
        private static void DrawArrows(Graphics g, ClockParams clockParams, DateTime time)
        {

            DrawHour(g, clockParams, time);
            DrawMinutes(g,clockParams, time);
            DrawSeconds(g,clockParams, time);
        }
        /// <summary>
        /// Метод рисовани часовой стрелки
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clockParams"></param>
        /// <param name="time"></param>
        private static void DrawHour(Graphics g, ClockParams clockParams, DateTime time)
        {
            Point center = new Point(0, 0);// установка центральной точки
            Pen pen = new Pen(clockParams.arrowsColor, 5);// создание ручки для рисования стрелок цветом из параметров
            Brush brush = new SolidBrush(clockParams.arrowsColor);// создание кисти такого же цвета для заливки
            int Hours = time.Hour;// получение количества часов
            if (Hours >= 12)// если сейчас больше 12 часов включительно(12-23)
            {
                Hours -= 12;// вычитаем из переменной 12, чтобы были значения (0-11)
            }
            float angle = (float)(30 * time.Hour + 0.5 * time.Minute);// угол равен 30 умножить на количество часов + 0,5 градусов на количество минут (для точности и плавности перехода )
            g.RotateTransform(angle);// поворот точки отсчёта на высчитанный угол
            Point end = new Point(0, (int)-clockParams.hourArrowLength);// конец стрелки находится на высоте равной длинне стрелки 
            switch (clockParams.arrowForm)
            {
                case ArrowForm.Arrow:// если форма стрелок - стрела
                    { 
                        g.DrawLine(pen, center, end);// рисуется линия от центра до конца
                        g.DrawLine(pen, end, new Point(5, end.Y + 8));// рисуется два ответвления
                        g.DrawLine(pen, end, new Point(-5, end.Y + 8));
                    }
                    break;
                case ArrowForm.Triangle:// если треугольник
                    {
                        g.FillPolygon(brush, new Point[] { new Point(center.X - 4, center.Y), new Point(center.X + 4, center.Y), end });// заполняем сектор из трёх точек - внизу две точки левее и правее центра и вверху конец стрелки
                    }
                        break;
                case ArrowForm.Line:// если линия, рисуем линию от центра до конца
                    {
                        g.DrawLine(pen, center, end);
                    }
                    break;
            }
            g.RotateTransform(-angle);// возвращаем угол отсчёта на исходный
        }
        /// <summary>
        /// Метод рисования минутной стрелки
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clockParams"></param>
        /// <param name="time"></param>
        private static void DrawMinutes(Graphics g, ClockParams clockParams, DateTime time)
        {
            // аналогично с рисованием часовой, но длинна больше, и угол высчитывается по-другому
            Point center = new Point(0, 0);
            Pen pen = new Pen(clockParams.arrowsColor, 3);
            Brush brush = new SolidBrush(clockParams.arrowsColor);
            float angle = (float)(6 * time.Minute+0.1*time.Second);// угол равен количеству минут * 6 градусов + количество секунд * 0.1 градус
            g.RotateTransform(angle);
            Point end = new Point(0, (int)-clockParams.minuteArrowLength);
            switch (clockParams.arrowForm)
            {
                case ArrowForm.Arrow:
                    {
                        g.DrawLine(pen, center, end);
                        g.DrawLine(pen, end, new Point(5, end.Y + 8));
                        g.DrawLine(pen, end, new Point(-5, end.Y + 8));
                    }
                    break;
                case ArrowForm.Triangle:
                    {
                        g.FillPolygon(brush, new Point[] { new Point(center.X - 3, center.Y), new Point(center.X + 3, center.Y), end });
                    }
                    break;
                case ArrowForm.Line:
                    {
                        g.DrawLine(pen, center, end);
                    }
                    break;
            }
            g.RotateTransform(-angle);
        }
        /// <summary>
        /// Метод рисования секундной стрелки
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clockParams"></param>
        /// <param name="time"></param>
        private static void DrawSeconds(Graphics g, ClockParams clockParams, DateTime time)
        {
            //аналогично предыдущим методам для стрелок, но длинна больше и угол высчитиывается по другому
            Point center = new Point(0, 0);
            Pen pen = new Pen(clockParams.arrowsColor, 2);
            Brush brush = new SolidBrush(clockParams.arrowsColor);
            float angle = (float)(6 * time.Second);// угол равен 6 градусам * на количество секунд
            Point end = new Point(0, (int)-clockParams.secondArrowLength);
            g.RotateTransform(angle);
            switch (clockParams.arrowForm)
            {
                case ArrowForm.Arrow:
                    {
                        g.DrawLine(pen, center, end);
                        g.DrawLine(pen, end, new Point(5, end.Y + 8));
                        g.DrawLine(pen,end,new Point(-5, end.Y+8));
                    }
                    break;
                case ArrowForm.Triangle:
                    {
                        g.FillPolygon(brush, new Point[] { new Point(center.X - 2, center.Y), new Point(center.X + 2, center.Y), end });
                    }
                    break;
                case ArrowForm.Line:
                    {
                        g.DrawLine(pen, center, end);
                    }
                    break;
            }
            g.RotateTransform(-angle);
        }
    }
    /// <summary>
    /// Перечисление форм часов
    /// </summary>
   public enum ClockForm
    {
        Circle,
        Square,
        Ellipse,
        Rectangle
    }
    /// <summary>
    /// Перечисление типов циферблата
    /// </summary>
    public enum ClockFace
    {
        Quarters,
        Seconds,
        All,
        None
    }
    /// <summary>
    /// Перечисление форм стрелок
    /// </summary>
    public enum ArrowForm
    {
        Triangle,
        Arrow,
        Line
    }
}
