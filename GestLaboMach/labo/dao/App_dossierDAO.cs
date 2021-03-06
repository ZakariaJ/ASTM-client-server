﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

using System.Data;
using GestLaboMach.databases;

namespace GestLaboMach.labo.dao
{
    public class App_dossierDAO
    {
        GestLaboMach.databases.DB db = new GestLaboMach.databases.DB();

        

        public DataTable ListAll_For_List_DataTable(int _statut_mach  )
        {

            

string req = @" SELECT d.id as id_dossier,
d.num_dossier,
CONCAT( IFNULL(p.num_patient,''),' - ',IFNULL(p.nom,''),' ' , IFNULL(p.prenom,'') ) as patient 
              
              
FROM app_dossier d  
LEFT JOIN app_patient p ON d.id_patient = p.id 
WHERE d.statut=" + _statut_mach  + @"
ORDER BY  d.urgence DESC, d.date_accueil , d.id  " ;
string tableName = "app_dossier";
            
            
            DataTable daTable = db.getResults(req, tableName);

     
            return daTable;
        }

        public long getNbrLignes_For_List_DataTable(int _statut )
        {

            long nbr = 0;
            string req = " SELECT count(id) as nbr  FROM app_dossier "
                 + " WHERE app_dossier.statut=" + _statut + " ";
            string tableName = "app_dossier";
            DataTable daTable = db.getResults(req, tableName);

            try
            {
                nbr = Int64.Parse(daTable.Rows[0]["nbr"] + "");
            }
            catch (Exception ex)
            {
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }
            return nbr;

        }

            

        public DataTable ListAll()
        {
            string req = "SELECT * FROM app_dossier";
            string tableName = "app_dossier";
            DataTable daTable = db.getResults(req, tableName);
            return daTable;
        }

            public DataTable FindById_ForInsertOrUpdate(long _id)
        {
            string req = " SELECT * FROM app_dossier WHERE id = " + _id;
            string tableName = "app_dossier";
            DataTable daTable = db.getResults(req, tableName);

            return daTable;
        }

        public DataTable FindById(long _id, int _id_usr)
        {

            string req = @" SELECT * , 
                    CONCAT( IFNULL(num_dossier,''),' ' )  titreFormEdit, 
                    CONCAT( IFNULL(num_dossier,''),' ' )  infoLigneFormDelete 
                    FROM app_dossier WHERE id = " + _id;

            string tableName = "app_dossier";
            DataTable daTable = db.getResults(req, tableName);

            return daTable;
        }

  
        public ActionModele UpdateForm(long _id, DataTable _daTable)
        {
            string tableName = "app_dossier";
            ActionModele actionn = db.update(_id, _daTable, tableName);
            return actionn;

        }

      
        //###############################################################################


      

    }
}