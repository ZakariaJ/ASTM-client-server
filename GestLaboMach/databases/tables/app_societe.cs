using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLabo.databases.tables
{
    public class app_societe
    {
        public static string getCreate(){

            string req = @"

   CREATE TABLE  app_societe  (
   id int(10) unsigned NOT NULL AUTO_INCREMENT,
   code_Societe  varchar(255) NOT  NULL UNIQUE ,
   raisonSocial  varchar(255) NOT  NULL UNIQUE ,
   titre_Logo  varchar(50)  NULL ,
   adresse  varchar(512)   NULL,
   ville  varchar(512)    NULL,
   code_postale  varchar(50)   NULL,
   pays  varchar(50)   NULL,
   tel_1  varchar(50)   NULL,
   tel_2  varchar(50)   NULL,
   email  varchar(255)   NULL,
   fax  varchar(255)   NULL,
   siteWeb  varchar(512)   NULL,
   dt_cre  datetime   NULL,
   dt_mod  datetime   NULL,
   id_usr_cre  int    NULL,
   id_usr_mod  int    NULL,
   statut  int    NULL,
   imgUrl  varchar(512)   NULL, 

  numberAleatoire bigint NULL,


  PRIMARY KEY ( id )

) 


";

            return req;

        }


        public static string getAlter()
        {

            string req = @"
;
ALTER TABLE app_societe add titre_Logo  varchar(50)  NULL ;

";

            return req;

        }
    }
}