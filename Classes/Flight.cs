using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Aeroport.Classes
{

    public class Flight
    {
        public decimal Numfl { get; set; }
        /// <summary>
        /// Тип самолета
        /// </summary>
        public airplanes TypeAir { get; set; }
        /// <summary>
        /// Время прибытия
        /// </summary>
        public DateTime TimeIn { get; set; }
        /// <summary>
        /// Количество пассажиров
        /// </summary>
        public decimal ColPas { get; set; }
        /// <summary>
        /// Количество экипажа
        /// </summary>
        public decimal ColBuil { get; set; }
        /// <summary>
        /// Сбор на пассажира
        /// </summary>
        public decimal Pass { get; set; }
        /// <summary>
        /// Сбор на экипаж
        /// </summary>
        public decimal Build { get; set; }
        /// <summary>
        /// Процент надбавки за обслуживание
        /// </summary>
        public decimal Percent { get; set; }
        /// <summary>
        /// Процент надбавки за обслуживание
        /// </summary>
    }
}
