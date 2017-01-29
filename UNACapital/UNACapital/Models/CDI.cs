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
        #endregion

        #region Constructors
        public CDI() { }

        public CDI(DateTime date, int number)
        {
            Date = date;
            Number = number;
        }
        #endregion
    }
}