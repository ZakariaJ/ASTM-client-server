using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLabo.databases.tables
{
    public class app_user_groups_droits
    {
        public static string getCreate(){

            string req = @"

CREATE TABLE  app_user_groups_droits (

id int(10) unsigned NOT NULL AUTO_INCREMENT,
 
id_groupe  int NULL,
id_module int NULL,

isConsult  int NULL,
isCreate  int NULL,
isUpdate  int NULL,
isDelete  int NULL,	

numberAleatoire bigint   NULL,

dt_cre   datetime  NULL,
dt_mod   datetime  NULL,
id_usr_cre   int  NULL,
id_usr_mod   int  NULL,

PRIMARY KEY ( id ) 
) 


";

            return req;

}


        public static string getAlter()
        {

            string req = @"
;

ALTER TABLE app_user_groups_droits ADD id_module int NULL;


";

            /*
ALTER TABLE ar_entite
ADD FOREIGN KEY (id_entite_parente) REFERENCES ar_entite(ident);

ALTER TABLE ar_entite
ADD FOREIGN KEY (id_societe) REFERENCES ar_societe(ident);

ALTER TABLE ar_entite
ADD FOREIGN KEY (id_usr_cre) REFERENCES ar_user(ident);

ALTER TABLE ar_entite
ADD FOREIGN KEY (id_usr_mod) REFERENCES ar_user(ident);
*/


            return req;

        }
    }
}