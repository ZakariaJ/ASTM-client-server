using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GestLaboMach.labo.modele;

namespace GestLaboMach.labo.controle
{
    public class Controle_Droits
    {

        public ActionModele controler(string _db_tablename, int _actionId)
        {
           
            _db_tablename = getString_toCompare(_db_tablename);

            ActionModele actionModel = new ActionModele();
            /*
           dao.Module_DAO modDAO =new dao.Module_DAO();
           int id_module = modDAO.getIdModule_By_db_tablename(_db_tablename);

           string id_session_client = HttpContext.Current.Session.SessionID;
           string ip_adress_client = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
           GestionLabo.labo.modele.SessionModele sessionObj = new GestionLabo.labo.modele.SessionModele();

           if (GestionLabo.GlobalLabo.list_Sessions.ContainsKey(id_session_client))
           {
               sessionObj = GestionLabo.GlobalLabo.list_Sessions[id_session_client];
           }

           int id_role = 0;
           int ident_user = 0;
           string loginUser = "";
           int societe_ident = 0;
            List<Droit> list_droits = new List<Droit>();
           if (sessionObj != null)
           {
               ident_user = sessionObj.user_ident;
               id_role = sessionObj.user_id_role;
               loginUser = sessionObj.user_loginn;
               societe_ident = sessionObj.societe_ident;
               list_droits = sessionObj.list_droits;
           }
            
           // controle des droits
            
           int id_groupe = 0;
           int id_societe = 0;
           int isConsult = 0;
           int isCreate = 0;
           int isUpdate = 0;
           int isDelete = 0;
            
           // -------------------------------------------------------------------------------

           if (list_droits != null)
           {
               for (int i = 0; i < list_droits.Count; i++)
               {

                   Droit drt = list_droits[i];
                   if (
                       drt.id_user==ident_user
                      && drt.id_module == id_module)
                   {
                       isConsult = drt.isConsult;
                       isCreate = drt.isCreate;
                       isUpdate = drt.isUpdate;
                       isDelete = drt.isDelete;
                   }
                    
                   
  
               }// fin for (int i = 0; i < list_droits.Count; i++)


           } // fin if (list_droits != null)
            
           bool isAuthorizeddd = false;
           //--------------------------------------------------------
           if (_actionId == Constantes.actionId_Consult_List)
           {
               if (isConsult > 0)
               {
                   isAuthorizeddd = true;
                   actionModel.alert_msg = "";
                   actionModel.msg = "";
               }
               else
               {
                   actionModel.alert_msg = Outils.FonctionsHTML.getHTML_alert_alert_danger_droits_nok();
                   actionModel.msg = "Vous n'êtes pas autorisé à effectuer cette opération";
               }

           }//--------------------------------------------------------
           else if (_actionId == Constantes.actionId_Consult_Form )
           {
               if (isConsult > 0)
               {
                   isAuthorizeddd = true;
                   actionModel.alert_msg = "";
                   actionModel.msg = "";
               }
               else
               {
                   actionModel.alert_msg = Outils.FonctionsHTML.getHTML_alert_alert_danger_droits_nok();
                   actionModel.msg = "Vous n'êtes pas autorisé à effectuer cette opération";
               }
           }//--------------------------------------------------------
           else if (_actionId == Constantes.actionId_Create )
           {
               if (isCreate > 0)
               {
                   isAuthorizeddd = true;
                   actionModel.alert_msg = "";
                   actionModel.msg = "";
               }
               else
               {
                   actionModel.alert_msg = Outils.FonctionsHTML.getHTML_alert_alert_danger_droits_nok();
                   actionModel.msg = "Vous n'êtes pas autorisé à effectuer cette opération";
               }
           }//--------------------------------------------------------
           else if (_actionId == Constantes.actionId_Update )
           {
               if (isUpdate > 0)
               {
                   isAuthorizeddd = true;
                   actionModel.alert_msg = "";
                   actionModel.msg = "";
               }
               else
               {
                   actionModel.alert_msg = Outils.FonctionsHTML.getHTML_alert_alert_danger_droits_nok();
                   actionModel.msg = "Vous n'êtes pas autorisé à effectuer cette opération";
               }
           }//--------------------------------------------------------
           else if (_actionId == Constantes.actionId_Delete )
           {
               if (isDelete > 0)
               {
                   isAuthorizeddd = true;
                   actionModel.alert_msg = "";
                   actionModel.msg = "";
               }
               else
               {
                   actionModel.alert_msg = Outils.FonctionsHTML.getHTML_alert_alert_danger_droits_nok();
                   actionModel.msg = "Vous n'êtes pas autorisé à effectuer cette opération";
               }
           }
                     
           actionModel.isDroitsOk = isAuthorizeddd;

          // tables exlus


           if (id_role==Constantes.id_roleAdminSystem
               || _db_tablename.Equals("app_session")
               || _db_tablename.Equals("app_user_connexion")
               || _db_tablename.Equals("app_sys_global")
               || _db_tablename.Equals("app_dual")
              )
           {
               actionModel.isDroitsOk = true;
               actionModel.msg = "";
               actionModel.alert_msg = "";
           }
           */

            actionModel.isDroitsOk = true;
            actionModel.msg = "";
            actionModel.alert_msg = "";

            return actionModel;

        }

        // #################################################################
        // #################################################################
        // #################################################################
        // #################################################################
        // #################################################################
        private string getString_toCompare(string _chaine)
        {

            if (_chaine == null || _chaine.Equals(null))
            {
                _chaine = "";
            }

            string chaine1 = _chaine;
            chaine1 = chaine1.Trim().ToLower().Replace(" ", "");
            return chaine1;
        }

    }
}