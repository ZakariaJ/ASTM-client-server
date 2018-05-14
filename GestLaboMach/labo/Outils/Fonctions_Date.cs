using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestLaboMach.Outils
{
    public class Fonctions_Date
    {
        
        public static DateTime getDateTime_NOW_Maroc()
        {
            DateTime dt = DateTime.Now;
            dt = dt.AddHours(-1);
            return dt;

        }


        public static DateTime convert_DateTime_ToDateTime_avec_First_SecondDuJour(DateTime _dt)
        {
            DateTime dt = _dt;
            int anneeeeee = dt.Year;
            int moisss = dt.Month;
            int jourrrr = dt.Day;

            int heuree = 0;
            int minuteee = 0;
            int secondee = 0;
            dt = new DateTime(anneeeeee, moisss, jourrrr, heuree, minuteee, secondee);
            return dt;

        }


        public static DateTime convert_DateTime_ToDateTime_avec_Last_SecondDuJour(DateTime _dt)
        {
            DateTime dt = _dt;
            int anneeeeee = dt.Year;
            int moisss = dt.Month;
            int jourrrr = dt.Day;

            int heuree = 23;
            int minuteee = 59;
            int secondee = 59;
            dt = new DateTime(anneeeeee, moisss, jourrrr, heuree, minuteee, secondee);
            return dt;

        }


        public static string convert_Date_ToString(DateTime _dt)
        {
            string dt_string = "";
            try
            {
                dt_string = _dt.ToString("dd/MM/yyyy");
                if (dt_string.Replace(" ", "").Equals("01/01/1900"))
                {
                    dt_string = "";
                }

            }
            catch (Exception xxx)
            {
            }
            return dt_string;
        }


        public static string displayShortDate(DateTime _dt)
        {
            string dt_string = "";
            try
            {
                dt_string = _dt.ToString("dd/MM/yyyy");
                if (dt_string.Replace(" ", "").Equals("01/01/1900"))
                {
                    dt_string = "";
                }

            }
            catch (Exception xxx)
            {
            }
            return dt_string;
        }

        public static string convert_Date_ToString_As_Id(DateTime _dt)
        {
            string dt_string = "";


            try
            {

                dt_string = _dt.ToString("yyyy-MM-dd");
                if (dt_string.Replace(" ", "").Equals("1900-01-01"))
                {
                    dt_string = "";
                }

            }
            catch (Exception xxx)
            {
            }

            dt_string = dt_string.Replace("-", "");

            return dt_string;

        }

        public static string convert_DateTime_ToString_As_Id(DateTime _dt)
        {
            string dt_string = "";


            try
            {

                dt_string = _dt.ToString("yyyy-MM-dd HH:mm:ss");
                if (dt_string.Replace(" ", "").Equals("1900-01-01"))
                {
                    dt_string = "";
                }

            }
            catch (Exception xxx)
            {
            }

            dt_string = dt_string.Replace("-", "");
            dt_string = dt_string.Replace(" ", "");
            dt_string = dt_string.Replace(":", "");

            return dt_string;

        }



        public static DateTime convert_String_ToDate(string _dt_string)
        {
            DateTime dt = new DateTime(1900, 01, 01);
            string dt_string = "";

            try
            {
                dt_string = _dt_string.Replace(" ", "").Trim();
            }
            catch (Exception xxxgg)
            {

            }

            if (!dt_string.Equals(""))
            {

                try
                {

                    dt = DateTime.Parse(dt_string + "");
                }
                catch (Exception xxx)
                {
                }
            }


            return dt;

        }


        public static string getCode_Mois(int _num)
        {
            string code = "";
            if (_num < 10)
            {
                code = "0" + _num;
            }
            else
            {
                code = _num+"";
            }
            return code;

        }



        public static string getDesign_Mois(int _num)
        {
            string design = "";


            if (_num == 1)
            {
                design = "Janvier";

            }
            else if (_num == 2)
            {
                design = "Février";

            }
            else if (_num == 3)
            {
                design = "Mars";

            }
            else if (_num == 4)
            {

                design = "Avril";
            }
            else if (_num == 5)
            {

                design = "Mai";
            }
            else if (_num == 6)
            {

                design = "Juin";
            }
            else if (_num == 7)
            {

                design = "Juillet";
            }
            else if (_num == 8)
            {

                design = "Août";
            }
            else if (_num == 9)
            {

                design = "Septembre";
            }
            else if (_num == 10)
            {

                design = "Octobre";
            }
            else if (_num == 11)
            {

                design = "Novembre";
            }
            else if (_num == 12)
            {

                design = "Décembre";
            }
            else
            {
                design = "Autre";
            }



            return design;

        }

        public static string getCode_Jour(int _num)
        {
            string code = "";
            if (_num < 10)
            {
                code = "0" + _num;
            }
            else
            {
                code = _num + "";
            }
            return code;

        }


        public static string getDesign_Jour(int _num)
        {
            string design = "";
            if (_num==1)
            {
                design = "Dimanche";

            }
            else if (_num == 2)
            {
                design = "Lundi";

            }
            else if (_num == 3)
            {
                design = "Mardi";

            }
            else if (_num == 4)
            {
                design = "Mercredi";

            }
            else if (_num == 5)
            {

                design = "Jeudi";
            }
            else if (_num == 6)
            {

                design = "Vendredi";
            }
            else if (_num == 7)
            {

                design = "Samedi";
            }
           
            else
            {
                design = ""+_num;
            }


            return design;

        }



        public static string getDesign_Jour_English_ToFrensh(string _day)
        {
            string design = "";

            _day = _day.ToLower().Trim();

            if (_day.Equals("monday"))
            {
                design = "Lundi";

            }
            else if (_day.Equals("tuesday"))
            {
                design = "Mardi";

            }
            else if (_day.Equals("wednesday"))
            {
                design = "Mercredi";

            }
            else if (_day.Equals("thursday"))
            {

                design = "Jeudi";
            }
            else if (_day.Equals("friday"))
            {

                design = "Vendredi";
            }
            else if (_day.Equals("saturday"))
            {

                design = "Samedi";
            }
            else if (_day.Equals("sunday"))
            {

                design = "Dimanche";
            }
            else
            {
                design = _day;
            }


            return design;

        }

        public static string add0ToStrDate_MJHMS_MILI(int _nbr)
        {
            string chaine = _nbr + "";

            if (_nbr <= 9)
            {
                chaine = "0" + _nbr;
            }

            return chaine;
        }

    }
}