using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UNACapital.Models
{
    public class CDI
    {
        private DateTime date;
        private int number;
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

        public int Number
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

        #region Constructors
        public CDI() { }

        public CDI(DateTime date, int number, float percentage)
        {
            Date = date;
            Number = number;
            Percentage = percentage;
        }
        #endregion
    }
}