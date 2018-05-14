using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

using System.Data;
using System.Configuration;

namespace GestLaboMach.databases
{
    class SQLConnexion
    {

       private static MySqlConnection con;

       public static string sevrer;
       public static string dataBase;
       public static string user;
       public static string password;

       public static void init()
       {
           try
           {
               sevrer = ConfigurationManager.AppSettings["sevrer"];
               dataBase = ConfigurationManager.AppSettings["dataBase"];
               user = ConfigurationManager.AppSettings["user"];
               password = ConfigurationManager.AppSettings["password"];
           }
           catch (Exception ex)
           {
               labo.modele.SYS_LOG_Modele.tracerException(ex);
           }
          
       }

        public static MySqlConnection getConnection()
        {
            try
            {
                sevrer = ConfigurationManager.AppSettings["sevrer"];
                dataBase = ConfigurationManager.AppSettings["dataBase"];
                user = ConfigurationManager.AppSettings["user"];
                password = ConfigurationManager.AppSettings["password"];

                //string stringConn = "Provider = MySQLProv; Data Source = " + dataBase + "; User Id =" + user + "; Password =" + password + ";";

                string stringConn = "server=" + @sevrer + @";database=" + @dataBase + @";uid=" + @user + @";pwd=" + @password + @";";
                
                /* 
                string stringConn ="Provider=sqloledb;Data Source="+sevrer+";"
                   + "Initial Catalog=" + dataBase + ";User ID=" + user + ";Password=" + password;
                 */


                /*

                "Provider=MSDAORA; Data Source=ORACLE8i7;Persist Security Info=False;Integrated Security=Yes"
                "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\bin\LocalAccess40.mdb"
                "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI"                 
                 Provider=sqloledb;Data Source=190.190.200.100,1433;Network Library=DBMSSOCN;
                 Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;

                */


                con = new MySqlConnection(stringConn);
            }
            catch (Exception ex)
            {
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }            
            return con;

        }
     
       

    }
}
