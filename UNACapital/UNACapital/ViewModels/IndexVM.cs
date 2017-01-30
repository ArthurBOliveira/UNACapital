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
        public List<CDI> CDIs;

        public IndexVM(CBLC cblc, List<CDI> cdis)
        {
            CBLC = cblc;
            CDIs = cdis;
        }
    }
}