using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Globalization;

namespace GestLaboMach.Outils
{
    public class Fonctions_Numeriques
    {

        public static decimal str_to_decimal(string _str, int nbrDeciaml)
        {
            decimal chiffre = 0;
            if (_str == null || _str.Equals(null))
            {
                _str = "";
            }
            _str = _str.Replace(" ", "").Trim();
            _str = _str.Replace(",", ".").Trim();
            try
            {
                string s = _str;
                CultureInfo ci = new CultureInfo(1);
                NumberFormatInfo ni = new NumberFormatInfo();
                ni.NumberGroupSeparator = "";
                ni.NumberDecimalSeparator = ".";
                ni.NumberDecimalDigits =nbrDeciaml;
                ni.CurrencyDecimalDigits = nbrDeciaml;
                ci.NumberFormat = ni;
                decimal d = decimal.Parse(s, ci);
                chiffre = d;
            }
            catch (Exception xxxxx)
            {
            }

            return chiffre;
        }


        public static decimal str_to_decimal(string _str)
       {
           decimal chiffre = 0;

           if (_str == null || _str.Equals(null))
           {
               _str = "";
           }

           _str = _str.Replace(" ", "").Trim();
           _str = _str.Replace(",", ".").Trim();


           try
           {

               string s = _str;
               CultureInfo ci = new CultureInfo(1);
               NumberFormatInfo ni = new NumberFormatInfo();
               ni.NumberGroupSeparator = "";
               ni.NumberDecimalSeparator = ".";
               ci.NumberFormat = ni;
               decimal d = decimal.Parse(s, ci);

               chiffre = d;
           }
           catch (Exception xxxxx)
           {
           }
           return chiffre;
       }

        public static string decimal_to_str(decimal _chiffre)
        {
            string chiffre_str = _chiffre+"";

            chiffre_str = chiffre_str.Replace(" ", "").Trim();
            chiffre_str = chiffre_str.Replace(".", ",").Trim();
            decimal d = 0;
            try
            {
                string s = chiffre_str + "";
                CultureInfo ci = new CultureInfo(1);
                NumberFormatInfo ni = new NumberFormatInfo();
                ni.NumberGroupSeparator = " ";
                ni.NumberDecimalSeparator = ",";
                ci.NumberFormat = ni;
                d = decimal.Parse(s, ci);               
            }
            catch (Exception xxxxx)
            {
            }
            return d+"";
        }

    }
}