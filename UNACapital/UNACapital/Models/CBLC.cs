using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace UNACapital.Models
{
    public class CBLC
    {
        private DateTime date; //06 - DATA DO MOVIMENTO FORMATO AAAAMMDD N(08) 33 40
        private int numberContracts; //04 – NÚMERO DE CONTRATOS - UM DIA QUANTIDADE DE CONTRATOS DE EMPRÉSTIMOS REGISTRADOS NO PERÍODO DE UM DIA ÚTIL N(10) 53 62
        private int amountActions; //QUANTIDADE DE AÇÕES - UM DIA QUANTIDADE DE AÇÕES ENVOLVIDAS NOS CONTRATOS REGISTRADOS NO PERÍODO DE UM DIA ÚTIL N(11) 63 73
        private float value; //06 – VALOR (R$) - UM DIA SOMATÓRIO DO VALOR, EM REAIS, DOS CONTRATOS REGISTRADOS NO PERÍODO DE UM DIA ÚTIL N(18)V(2) 74 93
        private float donator; //08 – TAXA MÉDIA – DOADOR – UM DIA TAXA MÉDIA, AO ANO, PRATICADA PELOS DOADORES DOS CONTRATOS REGISTRADOS NO PERÍODO DE UM DIA ÚTIL N(05)V(2) 101 107
        private float taker; // 11 – TAXA MÉDIA – TOMADOR – UM DIA TAXA MÉDIA, AO ANO, PRATICADA PELOS TOMADORES DOS CONTRATOS REGISTRADOS NO PERÍODO DE UM DIA ÚTIL N(05)V(2) 122 128
        private float cotation; // ?
        private float threeDays; // ?
        private int openPosition; // ?
        private string name; // NOME RESUMIDO DA EMPRESA X(30) 23 52

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

        public int NumberContracts
        {
            get
            {
                return numberContracts;
            }

            set
            {
                numberContracts = value;
            }
        }

        public int AmountActions
        {
            get
            {
                return amountActions;
            }

            set
            {
                amountActions = value;
            }
        }

        public float Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public float Donator
        {
            get
            {
                return donator;
            }

            set
            {
                donator = value;
            }
        }

        public float Taker
        {
            get
            {
                return taker;
            }

            set
            {
                taker = value;
            }
        }

        public float Cotation
        {
            get
            {
                return cotation;
            }

            set
            {
                cotation = value;
            }
        }

        public float ThreeDays
        {
            get
            {
                return threeDays;
            }

            set
            {
                threeDays = value;
            }
        }

        public int OpenPosition
        {
            get
            {
                return openPosition;
            }

            set
            {
                openPosition = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        #endregion

        #region Constructors
        public CBLC() { }

        public CBLC(string text, string actionId)
        {
            string actionLine = "";
            string[] lines = Regex.Split(text, "\r\n|\r|\n");

            date = DateTime.ParseExact(lines[0].Substring(32, 8), "yyyyMMdd", CultureInfo.InvariantCulture);

            for(int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(actionId))
                {
                    actionLine = lines[i];
                    break;
                }
            }

            name = actionLine.Substring(22, 30).Trim();
            numberContracts = int.Parse(actionLine.Substring(52, 10));
            amountActions = int.Parse(actionLine.Substring(62, 11));
            value = float.Parse(actionLine.Substring(73, 17) + "," + actionLine.Substring(91, 2));
            donator = float.Parse(actionLine.Substring(100, 04) + "," + actionLine.Substring(104, 2));
            taker = float.Parse(actionLine.Substring(124, 03) + "," + actionLine.Substring(127, 2));
        }
        #endregion
    }
}