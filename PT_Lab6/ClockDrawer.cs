using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PT_Lab6
{
    internal static class ClockDrawer
    {
    }

    internal struct ClockParams
    {
        public readonly Color primaryColor, secondaryColor, arrowsColor;
        public readonly ClockForm clockForm;
        public readonly ClockFace clockFace;
        public readonly ArrowForm arrowForm;
        public readonly Font font;
        public readonly TimeZoneInfo timeZone;
        public readonly bool romanianDigits, visualiseGigital;
        public readonly Size size;

        public ClockParams()
        {
            primaryColor = Color.White;
            secondaryColor = Color.White;
            arrowsColor = Color.Black;
            clockForm = ClockForm.Circle;
            clockFace = ClockFace.Quarters;
            arrowForm = ArrowForm.Line;
            font = Form.DefaultFont;
            timeZone = TimeZoneInfo.Local;
            romanianDigits = false;
            visualiseGigital = false;
            size = new Size(200, 200);
        }

        public ClockParams(Color primaryColor, Color arrowsColor) : this()
        {
            this.primaryColor = primaryColor;
            this.arrowsColor = arrowsColor;
        }

        public ClockParams(Color primaryColor, Color arrowsColor, ClockForm clockForm, Size size) : this(primaryColor, arrowsColor)
        {
            this.clockForm = clockForm;
            this.size = size;
        }
        public ClockParams(Color primaryColor, Color arrowsColor, ClockForm clockForm, Size size, ClockFace clockFace): this(primaryColor, arrowsColor, clockForm, size)
        {
            this.clockFace = clockFace;
        }
        public ClockParams(Color primaryColor, Color arrowsColor, ClockForm clockForm, Size size, ClockFace clockFace,ArrowForm arrowForm): this(primaryColor, arrowsColor, clockForm,size, clockFace)
        {
            this.arrowForm = arrowForm;
        }
        public ClockParams(Color primaryColor, Color arrowsColor, ClockForm clockForm, Size size, ClockFace clockFace, ArrowForm arrowForm, bool visualiseDigital): this(primaryColor, arrowsColor, clockForm, size,clockFace, arrowForm)
        {
            visualiseGigital = visualiseDigital;
        }
        public ClockParams(Color primaryColor, Color arrowsColor, ClockForm clockForm, Size size, ClockFace clockFace, ArrowForm arrowForm, bool visualiseDigital,Font font, bool romanianDigits): this(primaryColor, arrowsColor, clockForm,size, clockFace, arrowForm, visualiseDigital)
        {
            this.font = font;
            this.romanianDigits = romanianDigits;
        }
        public ClockParams(Color primaryColor, Color arrowsColor, ClockForm clockForm, Size size, ClockFace clockFace, ArrowForm arrowForm, bool visualiseDigital, Font font, bool romanianDigits, TimeZoneInfo timeZone) : this(primaryColor, arrowsColor, clockForm,size, clockFace, arrowForm, visualiseDigital, font, romanianDigits)
        {
            this.timeZone = timeZone;
        }
        public ClockParams(Color primaryColor, Color arrowsColor, ClockForm clockForm, Size size, ClockFace clockFace, ArrowForm arrowForm, bool visualiseDigital, Font font, bool romanianDigits, TimeZoneInfo timeZone, Color secondaryColor) : this(primaryColor, arrowsColor, clockForm, size, clockFace, arrowForm, visualiseDigital, font, romanianDigits, timeZone)
        {
            this.secondaryColor = secondaryColor; 
        }
    }
    internal enum ClockForm
    {
        Circle,
        Square,
        Ellipse,
        Rectangle,
        Rhombus
    }
    internal enum ClockFace
    {
        Quarters,
        Seconds,
        All
    }
    internal enum ArrowForm
    {
        Triangle,
        Arrow,
        Line
    }
}
