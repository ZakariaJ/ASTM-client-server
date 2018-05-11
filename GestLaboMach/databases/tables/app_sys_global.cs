using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLabo.databases.tables
{
    public class app_sys_global
    {
        public static string getCreate(){

            string req = @"

CREATE TABLE  app_sys_global  (
   id int(10) unsigned NOT NULL AUTO_INCREMENT,
   activation_key  varchar(512) NULL ,
   param_1  varchar(512) NULL ,
   param_2  varchar(512) NULL ,
   param_3  varchar(512) NULL ,
   param_4  varchar(512) NULL ,
   param_5  varchar(512) NULL ,
   param_6  varchar(512) NULL ,
   param_7  varchar(512) NULL ,
  
   dt_cre  datetime   NULL,
   dt_mod  datetime   NULL,
   id_usr_cre  int    NULL,
   id_usr_mod  int    NULL,
 
  PRIMARY KEY ( id )

) 


";

            return req;

        }


        public static string getAlter()
        {

            string req = @"
;

";

            return req;

        }
    }
}