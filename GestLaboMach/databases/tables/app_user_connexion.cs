using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLabo.databases.tables
{
    public class app_user_connexion
    {
        public static string getCreate(){

            string req = @"


CREATE TABLE  app_user_connexion  (
   id int(10) unsigned NOT NULL AUTO_INCREMENT,
   id_utilisateur  int DEFAULT NULL,
   dt_connexion  datetime DEFAULT NULL,
   SESSION_ID_DB  int DEFAULT NULL,
   RemoteUser  varchar(255)   DEFAULT NULL,
   REMOTE_ADDR  varchar(255)   DEFAULT NULL,
   Platform  varchar(255)   DEFAULT NULL,
   UrlHost  varchar(255)   DEFAULT NULL,
   BrowserName  varchar(255)   DEFAULT NULL,
   id_session_client  varchar(255)   DEFAULT NULL,
  PRIMARY KEY ( id )
)


";

            return req;

        }


        public static string getAlter()
        {

            string req = @"

   

";

            return req;

        }
    }
}