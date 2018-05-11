using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLabo.databases.tables
{
    public class app_sous_traitant
    {
        public static string getCreate(){

            string req = @"

CREATE TABLE IF NOT EXISTS  app_sous_traitant  (
   id  int(10) unsigned NOT NULL AUTO_INCREMENT,
   num_prescripteur  varchar(255) DEFAULT NULL,
   nom  varchar(255) DEFAULT NULL,
   prenom  varchar(255) DEFAULT NULL,
   adr  varchar(512) DEFAULT NULL,
   ville  varchar(255) DEFAULT NULL,
   specialite  varchar(512) DEFAULT NULL,
   id_usr_cre  int(10) DEFAULT NULL,
   id_usr_mod  int(10) DEFAULT NULL,
   dt_cre  datetime DEFAULT NULL,
   dt_mod  datetime DEFAULT NULL,
   tel_1  varchar(255) DEFAULT NULL,
   tel_2  varchar(255) DEFAULT NULL,
   email  varchar(255) DEFAULT NULL,
   cin  varchar(50) DEFAULT NULL,
   id_societe  int(10) DEFAULT NULL,
   numberAleatoire  int(10) DEFAULT NULL,
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