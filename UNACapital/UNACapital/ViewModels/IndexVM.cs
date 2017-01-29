using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UNACapital.Models;

namespace UNACapital.ViewModels
{
    public class IndexVM
    {
        public CBLC CBLC;

        public IndexVM(CBLC cblc)
        {
            CBLC = cblc;
        }
    }
}