using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;

namespace GestLaboMach
{
    public class Constantes
    {

        public static string app_base_url_asp = "";
        public static string dossierSauvPicesJointesDossiers = "uploads";

        public static string app_base_url_php="http://localhost:8383/labo";

        // statuts des dossiers
        public static int app_dossier_accueil_statut = 1;
        public static int app_dossier_sais_rslt_statut = 2;
        public static int app_dossier_valid_doss_statut = 3;
        
            
                  

        // types de données

         public static int type_db_column_Chaine =10;
         public static int type_db_column_Entier = 20;
         public static int type_db_column_Float = 30;
         public static int type_db_column_DateTime = 40;
         public static int type_db_column_Date = 41;

           

        // statuts des mot de passes
        public static int user_statut_passwdUser_Created = 0;
        public static int user_statut_passwdUser_Attente_Resete = 101;
        public static int user_statut_passwdUser_Reseted = 102;
        public static int user_statut_passwdUser_Changed = 103;
        public static int user_statut_passwdUser_Deleted = 104;


        public static int actionId_Consult_Form = 10;
        public static int actionId_Consult_List = 20;
        public static int actionId_Create = 30;
        public static int actionId_Update = 40;
        public static int actionId_Delete = 50;

        public static int id_roleAdminSystem = 1000;
        public static int id_roleUtilisateur = 100;


        public static void init()
        {

        }
    }
}