using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UNACapital.Models
{
    public class Cotation
    {
        private DateTime date;
        private float number;

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

        public float Number
        {
            get
            {
                return Number1;
            }

            set
            {
                Number1 = value;
            }
        }

        public float Number1
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

        public Cotation(DateTime date, float number)
        {
            Date = date;
            Number = number;
        }
        #endregion
    }
}