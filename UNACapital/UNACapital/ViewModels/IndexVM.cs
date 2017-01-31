using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UNACapital.Models;

namespace UNACapital.ViewModels
{
    public class IndexVM
    {
        public string Action;
        public CBLC CBLC;
        public List<CDI> CDIs;
        public List<Cotation> Cotations;

        public IndexVM() { }

        public IndexVM(string action, CBLC cblc, List<CDI> cdis, List<Cotation> cotations)
        {
            Action = action;
            CBLC = cblc;
            CDIs = cdis;
            Cotations = cotations;
        }
    }
}