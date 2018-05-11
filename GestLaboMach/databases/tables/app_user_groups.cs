using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLabo.databases.tables
{
    public class app_user_groups
    {
        public static string getCreate(){

            string req = @"

CREATE TABLE app_user_groups  (
 id int(10) unsigned NOT NULL AUTO_INCREMENT,
  code  varchar(255) NULL,
  designation  varchar(255) NOT NULL UNIQUE,  
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