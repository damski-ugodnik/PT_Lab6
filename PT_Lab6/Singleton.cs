using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_Lab6
{
    /// <summary>
    /// Класс, с которого начинается выполнение программы 
    /// </summary>
    internal class Singleton
    {
        /// <summary>
        /// Статическая переменная формы, хранящая в себе главную форму
        /// </summary>
        private static Form1? instance;
        /// <summary>
        /// Экземпляр главной формы
        /// </summary>
        public static Form1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance= new Form1();
                }
                return instance;
            }
        }

        private Singleton()
        {

        }
    }
}
