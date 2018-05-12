using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;

namespace GestLaboMach.labo.modele
{
    public class SYS_LOG_Modele
    {

        // #################################################"
        public static void tracerMessage(string _msg)
        {
            /*
            try
            {

                string logFile = "~/App_Data/ErrorLog.txt";
                logFile = HttpContext.Current.Server.MapPath(logFile);
                StreamWriter sw = new StreamWriter(logFile, true);

                sw.WriteLine(" ******************** " + DateTime.Now);
                sw.WriteLine(" "  + _msg);

                try
                {
                    //sw.WriteLine("*** Request : " + HttpContext.Current.Request.Url.AbsoluteUri);
                }
                catch (Exception yyyyy)
                {

                }
                
                sw.Close();

            }
            catch (Exception xxxx)
            {

            } */
        }

        // #################################################"

        public static void tracerException(Exception _ex,string _msg)
        {
            string source = _ex.Source;
           
        }

        public static void tracerException(Exception _ex)
        {
            string source =_ex.Source; 
           
        }


  



    }
}