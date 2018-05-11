using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

using System.Data;
using GestLaboMach.databases;

namespace GestLaboMach.labo.dao
{
    public class App_dossier_dtDAO
    {
        GestLaboMach.databases.DB db = new GestLaboMach.databases.DB();
        
        public DataTable ListByListIdDossierForListDossier(int _id_usr, ArrayList _listid_dossiers)
        {
            string list_id_str = "(-1000";
            for (int i = 0; i < _listid_dossiers.Count; i++)
            {
                list_id_str = list_id_str + "," + _listid_dossiers[i];
            }
            list_id_str = list_id_str + ")";

            string req = @" 
SELECT app_dossier_dt.id_dossier ,
case when ifnull(app_dossier_dt.id_analyse,0)>0 then app_analyse.code else  app_analyse_grp.code           
end as code_analyse,            
( SELECT  count(dtxxx.resultat) FROM app_dossier_dt dtxxx 
    WHERE dtxxx.id_dossier=app_dossier_dt.id_dossier
    AND dtxxx.id_analyse_grp =app_dossier_dt.id_analyse_grp
    AND ifnull(dtxxx.id_analyse,0)>0
    AND TRIM(  CONCAT(ifnull(dtxxx.resultat,''),ifnull(dtxxx.resultat_n,''))  )=''  )                        
                       
as resultatGrpSaisie ,	   
		 
TRIM(  CONCAT(ifnull(app_dossier_dt.resultat,''),ifnull(app_dossier_dt.resultat_n,''))  ) as resultatTest
			
FROM app_dossier_dt  
LEFT JOIN app_analyse ON app_analyse.id = app_dossier_dt.id_analyse			
LEFT JOIN app_analyse_grp on app_analyse_grp.id=app_dossier_dt.id_analyse_grp	
			
WHERE IFNULL(is_analyse,0)=1 and app_dossier_dt.id_dossier IN " + list_id_str + " and app_dossier_dt.id_bilan = 0";
            string tableName = "app_dossier_dt";
            DataTable daTable = db.getResults(req, tableName, _id_usr);
            return daTable;
        }

           

       

        //----------------------------------------------------------------------------
        public DataTable ListByIdDossier(long _id, int _id_usr)
        {
            string req = @" 

            SELECT 
             case when ifnull(app_dossier_dt.id_analyse,0)>0 then app_analyse.code else  app_analyse_grp.code           
           end as code_analyse, 
           case when ifnull(app_dossier_dt.id_analyse,0)>0 then app_analyse.libelle else  app_analyse_grp.libelle           
           end as libelle_analyse,       
           
        ( SELECT  count(dtxxx.resultat) FROM app_dossier_dt dtxxx 
                        WHERE dtxxx.id_dossier=app_dossier_dt.id_dossier
                        AND dtxxx.id_analyse_grp =app_dossier_dt.id_analyse_grp
                        AND ifnull(dtxxx.id_analyse,0)>0
                        AND TRIM(  CONCAT(ifnull(dtxxx.resultat,''),ifnull(dtxxx.resultat_n,''))  )=''  )                        
                       
           as resultatGrpSaisie ,	   
		 
         TRIM(  CONCAT(ifnull(app_dossier_dt.resultat,''),ifnull(app_dossier_dt.resultat_n,''))  ) as resultatTest,
         
           
            app_dossier_dt.* ,app_analyse.*, 
		app_analyse_grp.code as code_grp,
	     app_analyse_grp.libelle as libelle_grp,
      	app_analyse_ssgrp.code as code_ssgrp,
     	app_analyse_ssgrp.libelle as libelle_ssgrp,
	   app_discipline.code as code_discipline,
	  app_discipline.libelle as libelle_discipline
			
			FROM app_dossier_dt  
			LEFT JOIN app_analyse ON app_analyse.id = app_dossier_dt.id_analyse			
			LEFT JOIN app_analyse_grp on app_analyse_grp.id=app_dossier_dt.id_analyse_grp
			LEFT JOIN app_analyse_ssgrp on app_analyse_ssgrp.id=app_analyse.id_analyse_ssgrp
			LEFT JOIN app_discipline on app_discipline.id=app_analyse.id_discipline			
			
			WHERE IFNULL(is_analyse,0)=1 and app_dossier_dt.id_dossier = " + _id + " and app_dossier_dt.id_bilan = 0 ";

            string tableName = "app_dossier_dt";

            DataTable daTable = db.getResults(req, tableName, _id_usr);
            return daTable;
        }


        public DataTable ListByIdDossierRslt(long _id, int _id_usr)
        {



            string req = @" 
			
            SELECT 
            
           case when ifnull(app_dossier_dt.id_analyse,0)>0 then app_analyse.code else  app_analyse_grp.code           
           end as code_analyse, 
           IFNULL(app_analyse.calculable,0) calculable,
           IFNULL(app_analyse.formule,'') formule,
           IFNULL(app_analyse.code_formule,'') code_formule,
           
           case when ifnull(app_dossier_dt.id_analyse,0)>0 then app_analyse.libelle else  app_analyse_grp.libelle           
           end as libelle_analyse, 
           IFNULL(app_analyse.type_valeur,'n') as typeVal,
            
            app_dossier_dt.* ,app_analyse.*, 
            app_dossier_dt.id as id_row,
		    app_analyse_grp.code as code_grp,
	        app_analyse_grp.libelle as libelle_grp,
      	    app_analyse_ssgrp.code as code_ssgrp,
            app_analyse_ssgrp.libelle as libelle_ssgrp,
            app_discipline.code as code_discipline,
            app_discipline.libelle as libelle_discipline,
            app_unite1.code as code_unite1,
            app_unite2.code as code_unite2,
            TIMESTAMPDIFF(YEAR, app_patient.date_naiss, CURDATE()) AS age_patient,
            
            ((app_dossier_dt.resultat) * (app_analyse.facteur_conv)) as soit,
            
            app_dossier.date_accueil as date_accueil,
            app_dossier.id_patient as id_patient,
            
            app_dossier_dt.id_dossier as id_dossier,
            app_dossier_dt.id_analyse as id_analyse,
            
            IFNULL(app_dossier_dt.id_val_normal,0) as id_val_normal,
            IFNULL(app_analyse_normal.normale_1,'') as normale_1,
            IFNULL(app_analyse_normal.normale_2,'') as normale_2,
            IFNULL(app_patient.sexe,'') as pat_sexe,
            
            CASE  
            WHEN timestampdiff(DAY,app_patient.date_naiss,NOW()) < 30 THEN 'j'
            WHEN timestampdiff(MONTH,app_patient.date_naiss,NOW()) BETWEEN 1 AND 12 THEN 'm'
            WHEN timestampdiff(YEAR,app_patient.date_naiss,NOW()) > 1 THEN 'a' END as unite_age
            
			
			FROM app_dossier_dt 
			LEFT JOIN app_analyse  ON app_analyse.id = app_dossier_dt.id_analyse			
			LEFT JOIN app_analyse_grp on app_analyse_grp.id=app_dossier_dt.id_analyse_grp
			LEFT JOIN app_analyse_ssgrp on app_analyse_ssgrp.id=app_analyse.id_analyse_ssgrp
			LEFT JOIN app_discipline on app_discipline.id=app_analyse.id_discipline		
            LEFT JOIN app_unite as app_unite1 ON app_unite1.id = app_analyse.id_unite1
            LEFT JOIN app_unite as app_unite2 ON app_unite2.id = app_analyse.id_unite2
            LEFT JOIN app_dossier ON app_dossier.id = app_dossier_dt.id_dossier
            LEFT JOIN app_patient ON app_patient.id = app_dossier.id_patient
            LEFT JOIN app_analyse_normal ON app_analyse_normal.id = app_dossier_dt.id_val_normal
			
			WHERE    IFNULL(app_dossier_dt.id_analyse,0)>0 and app_dossier_dt.id_dossier = " + _id + " ";
            
            string tableName = "app_dossier_dt";
            DataTable daTable = db.getResults(req, tableName, _id_usr);
            return daTable;
        }
          
   

        public DataTable FindById_ForInsertOrUpdate(long _id, int _id_usr)
        {


            string req = " SELECT * FROM app_dossier_dt WHERE id = " + _id;
            string tableName = "app_dossier_dt";
            DataTable daTable = db.getResults(req, tableName, _id_usr);

            return daTable;
        }

        public DataTable FindById(long _id, int _id_usr)
        {

            string req = @" SELECT * , 
                    CONCAT( IFNULL('',''),' ' )  titreFormEdit, 
                    CONCAT( IFNULL('',''),' ' )  infoLigneFormDelete 
                    FROM app_dossier_dt WHERE id = " + _id;

            string tableName = "app_dossier_dt";
            DataTable daTable = db.getResults(req, tableName, _id_usr);

            return daTable;
        }

        // ---------------------------------------------------------------------

        public DataTable FindByIdDossier(long _idd, int _id_usr)
        {

            string req = @" SELECT  app_dossier_dt.id as idd_dt, 
            app_dossier_dt.id_dossier,
             case when ifnull(app_dossier_dt.id_analyse,0)>0 then app_analyse.code else  app_analyse_grp.code           
           end as code_analyse, 
           case when ifnull(app_dossier_dt.id_analyse,0)>0 then app_analyse.libelle else  app_analyse_grp.libelle           
           end as libelle_analyse, 
           
           
          app_dossier_dt.id_analyse_grp as id_grp,          
                    
          
           case when ifnull(app_dossier_dt.id_analyse,0)>0 then IFNULL(app_dossier_dt.prix,0)
            else  (SELECT SUM(IFNULL( d_dt_grpx.prix,0 )) 
				FROM app_dossier_dt d_dt_grpx WHERE d_dt_grpx.id_analyse_grp=app_dossier_dt.id_analyse_grp
													AND d_dt_grpx.id_dossier =app_dossier_dt.id_dossier )             
           end as  d_dt_prix_analyse ,
           
           IFNULL(app_dossier_dt.prix,0) as d_dt_prix,
            
            app_dossier_dt.* ,app_analyse.*, 
			  app_dossier_dt.id as id_analyse,
		      app_analyse_grp.code as code_grp,
              
	           app_analyse_grp.libelle as libelle_grp,
               
               IFNULL(app_analyse.nbr_b,0) as nbr_b,
               
               
               
      	     app_analyse_ssgrp.code as code_ssgrp,
     	      app_analyse_ssgrp.libelle as libelle_ssgrp,
	           app_discipline.code as code_discipline,
	           app_discipline.libelle as libelle_discipline
               
               
			
			FROM app_dossier_dt  
			LEFT JOIN app_analyse  ON app_analyse.id = app_dossier_dt.id_analyse			
			LEFT JOIN app_analyse_grp on app_analyse_grp.id=app_dossier_dt.id_analyse_grp
			LEFT JOIN app_analyse_ssgrp on app_analyse_ssgrp.id=app_analyse.id_analyse_ssgrp
			LEFT JOIN app_discipline on app_discipline.id=app_analyse.id_discipline
			
			
			WHERE IFNULL(is_analyse,0)=1 and app_dossier_dt.id_dossier = " + _idd + " and app_dossier_dt.id_bilan = 0 ";

            string tableName = "app_dossier_dt";
            DataTable daTable = db.getResults(req, tableName, _id_usr);

            return daTable;
        }
                   


        public ActionModele UpdateForm(long _id, DataTable _daTable, int _id_usr)
        {
            string tableName = "app_dossier_dt";
            ActionModele actionn = db.update(_id, _daTable, tableName, _id_usr);
            return actionn;

        }

        public string DeleteRow(long _id, int _id_usr)
        {
            string req = @" 
            DELETE FROM app_dossier_dt WHERE id =" + _id + @" 
            and id not in ( SELECT distinct id_civilite FROM app_patient WHERE id_civilite=" + _id + @"  ) 
             ";
            string tableName = "app_dossier_dt";
            string test = db.delete(req, tableName, _id_usr);
            return test;

        }


        // ########################################################
             
        //-----------------------------------------

        public decimal calcResult(long _id_dossier, int _id_analyse, int _id_usr)
        {
            string formule = "";
            string code_formule = "";
            int calculable = 0;
            DataTable daTable_listResult = this.ListByIdDossierRslt(_id_dossier, _id_usr);

            if (daTable_listResult != null && daTable_listResult.Rows.Count > 0)
            {
                for (int i = 0; i < daTable_listResult.Rows.Count; i++)
                {
                    int id_analysexxx = -1080;
                    try
                    {
                        id_analysexxx = Int32.Parse(daTable_listResult.Rows[i]["id_analyse"] + "");
                    }
                    catch (Exception ex)
                    {
                        // labo.modele.SYS_LOG_Modele.tracerException(ex);
                    }

                    if (id_analysexxx == _id_analyse)
                    {
                        formule = daTable_listResult.Rows[i]["formule"] + "";
                        code_formule = daTable_listResult.Rows[i]["code_formule"] + "";

                        try
                        {
                            calculable = Int32.Parse(daTable_listResult.Rows[i]["calculable"] + "");
                        }
                        catch (Exception ex)
                        {
                            // labo.modele.SYS_LOG_Modele.tracerException(ex);
                        }


                    }// fin if (id_analysexxx == _id_analyse)


                }// fin for (int i = 0; i < daTable_listResult.Rows.Count; i++)
                //----------------------------------------------------------------------------


                // replacement des code_formules par ces valeur dans la formule
                int id_analyseyyy = -2523;
                for (int i2 = 0; i2 < daTable_listResult.Rows.Count; i2++)
                {
                    try
                    {
                        id_analyseyyy = Int32.Parse(daTable_listResult.Rows[i2]["id_analyse"] + "");
                    }
                    catch (Exception ex)
                    {
                        // labo.modele.SYS_LOG_Modele.tracerException(ex);
                    }
                    if (id_analyseyyy != _id_analyse)
                    {

                        decimal resultat_n = 0;
                        try
                        {
                            resultat_n = Outils.Fonctions_Numeriques
                                .str_to_decimal(daTable_listResult.Rows[i2]["resultat_n"] + "");
                        }
                        catch (Exception ex)
                        {
                            // labo.modele.SYS_LOG_Modele.tracerException(ex);
                        }

                        string code_formule222 = daTable_listResult.Rows[i2]["code_formule"] + "";
                        formule = formule.Replace(code_formule222, resultat_n + "");
                    } // fin if (id_analyseyyy != _id_analyse)
                }



            } // fin if if (daTable_listResult!=null && daTable_listResult.Rows.Count>0)



            /*
              $formule=str_replace("+",",",$formule);
              $formule=str_replace("-",",",$formule);
              $formule=str_replace("*",",",$formule);
              $formule=str_replace("/",",",$formule);
              $formule=str_replace("/",",",$formule);
             */

            string req = " SELECT " + formule + " as resltCalc FROM app_dual LIMIT 1 ";

            decimal resltCalc = 0;
            if (calculable == 1)
            {

                try
                {
                    string tableName = "app_dossier_dt";
                    DataTable daTablexx = db.getResults(req, tableName, _id_usr);
                    // 
                    if (daTablexx != null && daTablexx.Rows.Count > 0)
                    {
                        try
                        {
                            resltCalc = Outils.Fonctions_Numeriques
                                .str_to_decimal(daTablexx.Rows[0]["resltCalc"] + "");
                        }
                        catch (Exception ex)
                        {
                            // labo.modele.SYS_LOG_Modele.tracerException(ex);
                        }
                        db.executeNonQuery(" UPDATE app_dossier_dt SET resultat_n=$resltCalc WHERE id_dossier = "
                            + _id_dossier + " and id_analyse = " + _id_analyse, _id_usr);

                    }
                }
                catch (Exception exxx)
                {
                    // labo.modele.SYS_LOG_Modele.tracerException(ex);
                }
            }

            return resltCalc;
        }

        //###############################################################################
        
        public string UpdateResultatDossier(int ida, long idd, string resultat, int _id_usr)
        {
            string test = "";

            {
                string req1 = @" UPDATE app_dossier_dt
						SET resultat = @resultat ,
						id_usr_mod =  " + _id_usr + @" ,
						dt_mod = @dt_mod
						WHERE id_analyse =" + ida + @"
						AND id_dossier =" + idd + " ";

                Dictionary<int, DBParametre> list_params = new Dictionary<int, DBParametre>();
                list_params.Add(1, new DBParametre("@resultat", resultat));
                list_params.Add(2, new DBParametre("@dt_mod", Outils.Fonctions_Date.getDateTime_NOW_Maroc()));
                string tableName = "app_dossier_dt";
                test = db.executeNonQuery(req1, list_params, _id_usr);
            }

            {
                /*
                string req2 = @" UPDATE app_dossier_dt
						SET soit = Round((SELECT  IFNULL(app_analyse.normale_2_soit,0) * (IFNULL(app_dossier_dt.resultat,0) / IFNULL(app_analyse.normale_2,0)) 
                        FROM app_analyse where app_analyse.id = app_dossier_dt.id_analyse),2)
						WHERE app_dossier_dt.id_analyse = @ida
						AND app_dossier_dt.id_dossier = @idd 
                        AND IFNULL(app_analyse.normale_2,0)<>0 ";

                Dictionary<int, DBParametre> list_params = new Dictionary<int, DBParametre>();
                list_params.Add(1, new DBParametre("@ida", ida));
                list_params.Add(2, new DBParametre("@idd", idd));

                string tableName = "app_dossier_dt";
                test = db.executeNonQuery(req2, list_params, _id_usr);*/
            }

            return test;
        }


        // -----------------------------------------------------------------
        public string UpdateNote(int ida, long idd, string notes, int _id_usr)
        {

            string test = "";

            string req = @"  UPDATE app_dossier_dt
						SET notes =  @notes ,
						id_usr_mod =  " + _id_usr + @" ,
						dt_mod =  @dt_mod
						WHERE id_analyse = @ida
						AND id_dossier = @idd ";


            Dictionary<int, DBParametre> list_params = new Dictionary<int, DBParametre>();
            list_params.Add(1, new DBParametre("@ida", ida));
            list_params.Add(2, new DBParametre("@idd", idd));
            list_params.Add(3, new DBParametre("@notes", notes));
            list_params.Add(4, new DBParametre("@dt_mod", Outils.Fonctions_Date.getDateTime_NOW_Maroc()));
            string tableName = "app_dossier_dt";
            test = db.executeNonQuery(req, list_params, _id_usr);

            return test;
        }

        // -----------------------------------------------------------------
        public string UpdateResultatDossierNum(int ida, long idd, decimal resultat_n, int _id_usr, string symbole)
        {
            string test = "";
            {
                string req = @" UPDATE app_dossier_dt
						SET resultat_n = @resultat_n ,
                        symbole = @symbole ,
						id_usr_mod = " + _id_usr + @" ,
						dt_mod =  @dt_mod
						WHERE id_analyse = @ida
						AND id_dossier = @idd ";

                Dictionary<int, DBParametre> list_params = new Dictionary<int, DBParametre>();
                list_params.Add(1, new DBParametre("@ida", ida));
                list_params.Add(2, new DBParametre("@idd", idd));
                list_params.Add(3, new DBParametre("@resultat_n", resultat_n));
                list_params.Add(4, new DBParametre("@symbole", symbole));
                list_params.Add(5, new DBParametre("@dt_mod", Outils.Fonctions_Date.getDateTime_NOW_Maroc()));
                string tableName = "app_dossier_dt";
                test = db.executeNonQuery(req, list_params, _id_usr);

            }

            {
                string req = @" UPDATE app_dossier_dt
						SET soit = Round((SELECT IFNULL(app_analyse.normale_2_soit,0) * (IFNULL(app_dossier_dt.resultat,0) / IFNULL(app_analyse.normale_2,0)) FROM app_analyse where app_analyse.id = app_dossier_dt.id_analyse),2)
						WHERE app_dossier_dt.id_analyse = @ida
						AND app_dossier_dt.id_dossier = @idd 
                      AND IFNULL(app_analyse.normale_2,0)<>0 ";


                Dictionary<int, DBParametre> list_params = new Dictionary<int, DBParametre>();
                list_params.Add(1, new DBParametre("@ida", ida));
                list_params.Add(2, new DBParametre("@idd", idd));
                list_params.Add(3, new DBParametre("@resultat_n", resultat_n));
                list_params.Add(4, new DBParametre("@symbole", symbole));
                list_params.Add(5, new DBParametre("@dt_mod", Outils.Fonctions_Date.getDateTime_NOW_Maroc()));
                string tableName = "app_dossier_dt";
                test = db.executeNonQuery(req, list_params, _id_usr);

            }


            return test;
        }



    }
}