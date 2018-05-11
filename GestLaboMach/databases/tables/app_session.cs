using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLabo.databases.tables
{
    public class app_session
    {
        public static string getCreate(){

            string req = @"

CREATE TABLE app_session  (

 id int(10) unsigned NOT NULL AUTO_INCREMENT,
  id_user int(10) NULL ,
  id_session  varchar(512) NULL,  
  dt_cre  datetime DEFAULT NULL,
  dt_mod  datetime DEFAULT NULL,
  id_usr_cre  int DEFAULT NULL,
  id_usr_mod  int DEFAULT NULL,

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