using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UNACapital.Models
{
    public class Cotation
    {
        private DateTime date;
        private decimal number;

        #region Properties
        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public decimal Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }
        #endregion

        #region Contructors
        public Cotation() { }

        public Cotation(DateTime date, decimal number)
        {
            Date = date;
            Number = number;
        }
        #endregion
    }
}