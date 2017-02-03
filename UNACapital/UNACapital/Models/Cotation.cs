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
        private float percentage;

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
                return number;
            }

            set
            {
                number = value;
            }
        }

        public float Percentage
        {
            get
            {
                return percentage;
            }

            set
            {
                percentage = value;
            }
        }
        #endregion

        #region Contructors
        public Cotation() { }

        public Cotation(DateTime date, float number, float percentage)
        {
            Date = date;
            Number = number;
            Percentage = percentage;
        }
        #endregion
    }
}