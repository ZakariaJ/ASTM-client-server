using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLabo.databases.tables
{
    public class alter_all_tables
    {


        public static string getAlter()
        {

            /*
            voir à supprimer de la tables app_analyse
                `id_type_analyse` int(10) DEFAULT NULL,
                  `soustraitance` varchar(512) DEFAULT NULL,
                  `val_b` double DEFAULT NULL,
                   tmp_code
                   `sensibil_Ana` double DEFAULT NULL,
              */


           

            string req = @"
          
;

UPDATE app_questions_reponses SET dt_mod = NOW();
UPDATE app_questions_reponses SET dt_cre = NOW();
ALTER TABLE  app_questions_reponses MODIFY id_usr_cre int(10) NULL;
ALTER TABLE  app_questions_reponses MODIFY id_usr_mod int(10) NULL;
ALTER TABLE  app_questions_reponses MODIFY dt_cre datetime NULL;
ALTER TABLE  app_questions_reponses MODIFY dt_mod datetime NULL;

ALTER TABLE  app_dossier_pj ADD isDeleted int(2) NULL;

ALTER TABLE  app_dossier_pj ADD id_dossier int(10) NULL; 
ALTER TABLE  app_dossier_pj ADD file_url varchar(512) NULL; 
ALTER TABLE  app_dossier_pj ADD numberAleatoire int(10) NULL; 


UPDATE app_dossier_pj SET dt_mod = NOW();
UPDATE app_dossier_pj SET dt_cre = NOW();
ALTER TABLE  app_dossier_pj ADD id_usr_cre int(10) NULL;
ALTER TABLE  app_dossier_pj ADD id_usr_mod int(10) NULL;
ALTER TABLE  app_dossier_pj ADD dt_cre datetime NULL;
ALTER TABLE  app_dossier_pj ADD dt_mod datetime NULL;

ALTER TABLE  app_dossier_pj MODIFY id_user_cre int(10) NULL;
ALTER TABLE  app_dossier_pj MODIFY id_user_mod int(10) NULL;
ALTER TABLE  app_dossier_pj MODIFY date_cre datetime NULL;
ALTER TABLE  app_dossier_pj MODIFY date_mod datetime NULL;

ALTER TABLE  app_dossier_pj MODIFY num_dossier varchar(100) NULL;  
ALTER TABLE  app_dossier_pj MODIFY filename varchar(255) NULL;


ALTER TABLE  app_dossier MODIFY total_imprime double NULL; 

ALTER TABLE  app_dossier ADD compteur int(10) NULL; 

ALTER TABLE  app_dossier MODIFY urgence int(4) NULL; 
ALTER TABLE  app_dossier MODIFY id_mutuelle int(10) NULL; 
ALTER TABLE  app_dossier MODIFY id_prescripteur int(10) NULL;
ALTER TABLE  app_dossier MODIFY id_type_prelevement int(10) NULL;
ALTER TABLE  app_dossier MODIFY modalite int(10) NULL;
ALTER TABLE  app_dossier MODIFY is_devis int(4) NULL;
ALTER TABLE  app_dossier MODIFY groupage_sanguin int(10) NULL;
UPDATE app_dossier SET dt_mod = NOW();

ALTER TABLE  app_analyse ADD id_sous_traitant int(10) NULL; 

ALTER TABLE  app_analyse MODIFY facteur_conv double NULL; 


UPDATE app_questionnaire SET dt_mod = NOW();
ALTER TABLE  app_questionnaire MODIFY id_usr_cre int(10) NULL;
ALTER TABLE  app_questionnaire MODIFY id_usr_mod int(10) NULL;
ALTER TABLE  app_questionnaire MODIFY dt_cre datetime NULL;
ALTER TABLE  app_questionnaire MODIFY dt_mod datetime NULL;

UPDATE app_analyse SET dt_mod = NOW();
ALTER TABLE  app_analyse MODIFY id_usr_cre int(10) NULL;
ALTER TABLE  app_analyse MODIFY id_usr_mod int(10) NULL;
ALTER TABLE  app_analyse MODIFY dt_cre datetime NULL;
ALTER TABLE  app_analyse MODIFY dt_mod datetime NULL;

UPDATE app_type_prelevement SET dt_mod = NOW();
ALTER TABLE  app_type_prelevement MODIFY id_usr_cre int(10) NULL;
ALTER TABLE  app_type_prelevement MODIFY id_usr_mod int(10) NULL;
ALTER TABLE  app_type_prelevement MODIFY dt_cre datetime NULL;
ALTER TABLE  app_type_prelevement MODIFY dt_mod datetime NULL;

UPDATE app_modalite SET dt_mod = NOW();
ALTER TABLE  app_modalite MODIFY id_usr_cre int(10) NULL;
ALTER TABLE  app_modalite MODIFY id_usr_mod int(10) NULL;
ALTER TABLE  app_modalite MODIFY dt_cre datetime NULL;
ALTER TABLE  app_modalite MODIFY dt_mod datetime NULL;

ALTER TABLE  app_analyse ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_analyse_grp ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_analyse_normal ADD numberAleatoire int(10) NULL;

ALTER TABLE  app_analyse_ssgrp ADD numberAleatoire int(10) NULL;

ALTER TABLE  app_civilite ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_discipline ADD numberAleatoire int(10) NULL;

ALTER TABLE  app_dossier ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_medecin ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_methode ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_modalite ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_mutuelle ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_patient ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_prelevement ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_preleveur ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_prescripteur ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_questionnaire ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_questions_reponses ADD numberAleatoire int(10) NULL;

ALTER TABLE  app_tube ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_type_analyse ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_type_prelevement ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_unite ADD numberAleatoire int(10) NULL;

ALTER TABLE  app_user_groups_droits ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_utilisateur ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_user_groups ADD numberAleatoire int(10) NULL;


ALTER TABLE  app_patient ADD numberAleatoire int(10) NULL;
ALTER TABLE  app_patient ADD date_naiss_2 date NULL;


ALTER TABLE  app_analyse ADD id_societe int (10) NULL;
ALTER TABLE  app_analyse_grp ADD id_societe int (10) NULL;

ALTER TABLE  app_analyse_ssgrp ADD id_societe int (10) NULL;
ALTER TABLE  app_bilan ADD id_societe int (10) NULL;
ALTER TABLE  app_bilan_examens ADD id_societe int (10) NULL;
ALTER TABLE  app_civilite ADD id_societe int (10) NULL;
ALTER TABLE  app_discipline ADD id_societe int (10) NULL;
ALTER TABLE  app_dossier ADD id_societe int (10) NULL;

ALTER TABLE  app_examen ADD id_societe int (10) NULL;
ALTER TABLE  app_groupage ADD id_societe int (10) NULL;
ALTER TABLE  app_medecin ADD id_societe int (10) NULL;
ALTER TABLE  app_methode ADD id_societe int (10) NULL;
ALTER TABLE  app_modalite ADD id_societe int (10) NULL;
ALTER TABLE  app_mutuelle ADD id_societe int (10) NULL;
ALTER TABLE  app_patient ADD id_societe int (10) NULL;
ALTER TABLE  app_prelevement ADD id_societe int (10) NULL;
ALTER TABLE  app_preleveur ADD id_societe int (10) NULL;
ALTER TABLE  app_prescripteur ADD id_societe int (10) NULL;
ALTER TABLE  app_questionnaire ADD id_societe int (10) NULL;
ALTER TABLE  app_questions_reponses ADD id_societe int (10) NULL;
ALTER TABLE  app_session ADD id_societe int (10) NULL;
ALTER TABLE  app_tube ADD id_societe int (10) NULL;
ALTER TABLE  app_type_analyse ADD id_societe int (10) NULL;
ALTER TABLE  app_type_prelevement ADD id_societe int (10) NULL;
ALTER TABLE  app_unite ADD id_societe int (10) NULL;
ALTER TABLE  app_user_connexion ADD id_societe int (10) NULL;
ALTER TABLE  app_user_groups_droits ADD id_societe int (10) NULL;
ALTER TABLE  app_utilisateur ADD id_societe int (10) NULL;


";

            return req;

        }

    }
}