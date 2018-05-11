using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLabo.databases.tables
{
    public class app_sys_log
    {
        public static string getCreate(){

            string req = @"

   CREATE TABLE  app_sys_log (	
     titre   varchar (512) NOT NULL ,
     msg   varchar (3000) NULL  ,     
	 dt_cre   datetime  NULL
) 
";

            return req;

        }


        public static string getAlter()
        {

            string req = @"
;



";

            /*
ALTER TABLE ar_entite
ADD FOREIGN KEY (id_dossiermodele_parente) REFERENCES ar_entite(ident);

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