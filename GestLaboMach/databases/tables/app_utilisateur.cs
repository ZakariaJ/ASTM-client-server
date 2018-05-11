using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLabo.databases.tables
{
    public class app_utilisateur
    {
        public static string getCreate(){

            string req = @"


";

            return req;

        }


        public static string getAlter()
        {

            string req = @"
;


ALTER TABLE app_utilisateur ADD  id_groupe  int NULL ;
ALTER TABLE app_utilisateur ADD  nom  varchar(255) DEFAULT NULL;
  ALTER TABLE app_utilisateur ADD  prenom  varchar(255) DEFAULT NULL;
  ALTER TABLE app_utilisateur ADD  email  varchar(255) DEFAULT NULL;
  ALTER TABLE app_utilisateur ADD  tel  varchar(255) DEFAULT NULL;
  ALTER TABLE app_utilisateur ADD  imgUrl  varchar(255) DEFAULT NULL;
  ALTER TABLE app_utilisateur ADD  statut  int DEFAULT NULL;
  ALTER TABLE app_utilisateur ADD  loginn  varchar(255) NOT NULL UNIQUE;
  ALTER TABLE app_utilisateur ADD  passwordd  varchar(255) DEFAULT NULL;

  ALTER TABLE app_utilisateur ADD  id_role  int DEFAULT NULL;
  ALTER TABLE app_utilisateur ADD  isUserInactif  int DEFAULT NULL;
 
  ALTER TABLE app_utilisateur ADD  numberAleatoire bigint NULL;


  ALTER TABLE app_utilisateur ADD  statut_passwdUser int NULL;
  ALTER TABLE app_utilisateur ADD  code_securite_aleatoire  bigint NULL;
  



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