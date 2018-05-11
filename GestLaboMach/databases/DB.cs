using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

using System.Data;

namespace GestLaboMach.databases
{
    public class DB
    {



        private static MySqlConnection con;
        string cmdSelect =
     @"   
";



        public  DataTable getResults(string _reqSelect, string _tableName, int _id_usr)
        {

            DataSet daSet1 = new DataSet();
            DataTable daTable1 = new DataTable();

            try
            {
                MySqlCommand cmd;
                con = SQLConnexion.getConnection();
                con.Open();
                cmd = new MySqlCommand(_reqSelect, con);
                //cmd.Parameters.AddWithValue("@dt_cre", dt_cre);
                //cmd.Parameters.AddWithValue("@id_societe", _id_societe);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(daSet1, _tableName);
                daTable1 = daSet1.Tables[_tableName];

            }
            catch (Exception ex)
            {
                labo.modele.SYS_LOG_Modele.tracerException(ex,  _reqSelect);
            }

            try
            {
                con.Close();
            }
            catch (Exception ex)
            {
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }
            return daTable1;

        }

        public DataTable getResults(string _reqSelect, string _tableName, Dictionary<int, DBParametre> _list_params, int _id_usr)
        {

            DataSet daSet1 = new DataSet();
            DataTable daTable1 = new DataTable();

            try
            {
                MySqlCommand cmd;
                con = SQLConnexion.getConnection();
                con.Open();
                cmd = new MySqlCommand(_reqSelect, con);

                if (_list_params != null && _list_params.Count > 0)
                {
                    foreach (int key in _list_params.Keys)
                    {
                        DBParametre param = (DBParametre)_list_params[key];
                        cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }
                }

                //cmd.Parameters.AddWithValue("@dt_cre", dt_cre);
                //cmd.Parameters.AddWithValue("@id_societe", _id_societe);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(daSet1, _tableName);
                daTable1 = daSet1.Tables[_tableName];

            }
            catch (Exception ex)
            {
                labo.modele.SYS_LOG_Modele.tracerException(ex,  _reqSelect);
            }
            finally
            {
                con.Close();
            }
            return daTable1;

        }

        public  DataSet getResults_DataSet(string _reqSelect, string _tableName,int _id_usr)
        {

            DataSet daSet1 = new DataSet();
            DataTable daTable1 = new DataTable();

            try
            {
                MySqlCommand cmd;
                con = SQLConnexion.getConnection();
                con.Open();
                cmd = new MySqlCommand(_reqSelect, con);


                //cmd.Parameters.AddWithValue("@dt_cre", dt_cre);
                //cmd.Parameters.AddWithValue("@id_societe", _id_societe);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(daSet1, _tableName);
                daTable1 = daSet1.Tables[_tableName];

            }
            catch (Exception ex)
            {
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }
            finally
            {
                con.Close();
            }
            return daSet1;

        }


        //#################################################################################################
        //#################################################################################################
        //#################################################################################################

        /*
          public  string insertOrUpdate(long _ident, DataSet _daSet,string cmdSelect, string _tableName, int _id_usr)
        {
            string test = "";


            if (_daSet != null)
            {
                // ouverture de la connexion
                try
                {
                    con = SQLConnexion.getConnection();
                    con.Open();

                }
                catch (Exception ex)
                {
                    test = ex.Message;
                    labo.modele.SYS_LOG_Modele.tracerException(ex);
                }

                    try
                    {

                        MySqlCommand cmd = new MySqlCommand(cmdSelect, con);
                        MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd);
                        MySqlCommandBuilder cmdbl = new MySqlCommandBuilder(adapter1);
                        adapter1.Update(_daSet, _tableName);                       
                       
                    }
                    catch (Exception ex)
                    {

                        test = ex.Message;
                        
                        labo.modele.SYS_LOG_Modele.tracerException(ex );
                    }

                // fermeture de la connexion
                try
                {
                    con.Close();
                }
                catch (Exception ex)
                {
                    test = ex.Message;
                    labo.modele.SYS_LOG_Modele.tracerException(ex);
                }


            }

            
            return test;
        }
        */

        //#################################################################################################
        //#################################################################################################
        //#################################################################################################




        public ActionModele update(long _ident, DataTable _dataTable, string _tableName, int _id_usr)
        {
            string test = "";
            
            ActionModele actionn = new ActionModele();           
            int actionId = Constantes.actionId_Update;
            GestLaboMach.labo.controle.Controle_Droits ctl_droits = new GestLaboMach.labo.controle.Controle_Droits();
            actionn = ctl_droits.controler(_tableName, actionId);
            test = actionn.alert_msg;

            if (actionn.isDroitsOk
                && _dataTable != null && _dataTable.Rows.Count > 0 && _dataTable.Columns.Count > 0)
            {
                // ouverture de la connexion
                try
                {
                    con = SQLConnexion.getConnection();
                    con.Open();

                }
                catch (Exception ex)
                {
                    test = ex.Message;
                    labo.modele.SYS_LOG_Modele.tracerException(ex);
                }


                for (int ln = 0; ln < _dataTable.Rows.Count; ln++)
                {
                    _dataTable.Rows[ln]["id_usr_mod"] = _id_usr;
                    _dataTable.Rows[ln]["dt_mod"] = DateTime.Now;
                   
                    MySqlCommand cmd = new MySqlCommand();                    

                    string list_val_update = "";
                    for (int c = 0; c < _dataTable.Columns.Count; c++)
                    {
                        string col = _dataTable.Columns[c].ColumnName + " ";
                        string val = "@" + col + "" ;

                        if (c == _dataTable.Columns.Count - 1 && !_dataTable.Columns[c].ColumnName.Trim().ToLower().Equals("id"))
                        {
                            list_val_update = list_val_update + col + "=" + val + " ";
                        }
                        else if (!_dataTable.Columns[c].ColumnName.Trim().ToLower().Equals("id"))
                        {
                            list_val_update = list_val_update + col + "=" + val + " , ";
                        }

                        cmd.Parameters.AddWithValue("@" + _dataTable.Columns[c].ColumnName + "", _dataTable.Rows[ln][_dataTable.Columns[c].ColumnName + ""]);

                    }// boucle sur les colonnes


                    string req_update = " UPDATE  " + _tableName   + " SET " + list_val_update  + " WHERE  id=" + _ident + " ";
                    try
                    {
                        System.Threading.Thread.Sleep(10);
                        cmd.Connection = con;
                        cmd.CommandText = req_update;
                                                            
                        //cmd.Parameters.AddWithValue("@ident", _ident);
                        cmd.ExecuteNonQuery();

                        
                    }
                    catch (Exception ex)
                    {

                        test = ex.Message;
                        
                        labo.modele.SYS_LOG_Modele.tracerException(ex );
                    }

                }// boucle sur les lignes


                // fermeture de la connexion
                try
                {
                    con.Close();
                }
                catch (Exception ex)
                {
                    test = ex.Message;
                    labo.modele.SYS_LOG_Modele.tracerException(ex);
                }


            }

             actionn.msg =  test ;
            return actionn;
        }


        //#################################################################################################
        //#################################################################################################
        //#################################################################################################
        public ActionModele insert(DataTable _dataTable, string _tableName, int _id_usr)
        {
            string test = "";

            //------------------------------
            ActionModele actionn = new ActionModele();
            int actionId = Constantes.actionId_Create;
            GestLaboMach.labo.controle.Controle_Droits ctl_droits = new GestLaboMach.labo.controle.Controle_Droits();
            actionn = ctl_droits.controler(_tableName, actionId);
            test = actionn.alert_msg;
            //-----------------------------

            if (actionn.isDroitsOk 
                && _dataTable != null && _dataTable.Rows.Count > 0 && _dataTable.Columns.Count > 0)
            {
                // ouverture de la connexion
                try
                {
                    con = SQLConnexion.getConnection();
                    con.Open();

                }
                catch (Exception ex)
                {
                    test = ex.Message;
                    labo.modele.SYS_LOG_Modele.tracerException(ex);
                }


                for (int ln = 0; ln < _dataTable.Rows.Count; ln++)
                {

                    _dataTable.Rows[ln]["id_usr_cre"] = _id_usr;
                    _dataTable.Rows[ln]["dt_cre"] = DateTime.Now;

                    MySqlCommand cmd = new MySqlCommand();
                    

                    string list_col = "";
                    string list_val = "";
                    for (int c = 0; c < _dataTable.Columns.Count; c++)
                    {
                        if (c == _dataTable.Columns.Count - 1 && !_dataTable.Columns[c].ColumnName.Trim().ToLower().Equals("id"))
                        {
                            list_col = list_col + " " + _dataTable.Columns[c].ColumnName + " ";
                            list_val = list_val + "@" + _dataTable.Columns[c].ColumnName + "" + " ";
                        }
                        else if (!_dataTable.Columns[c].ColumnName.Trim().ToLower().Equals("id"))
                        {
                            list_col = list_col + " " + _dataTable.Columns[c].ColumnName + " , ";
                            list_val = list_val + "@" + _dataTable.Columns[c].ColumnName + "" + " , ";
                        }

                        cmd.Parameters.AddWithValue("@" + _dataTable.Columns[c].ColumnName + "", _dataTable.Rows[ln][_dataTable.Columns[c].ColumnName + ""]);

                    }// boucle sur les colonnes

                  
                    string req_insert_part_1 = @" INSERT INTO  " + _tableName + " ( " + list_col + "  ) ";
                    string req_insert_part_2 = @" VALUES (  " + list_val + "  ) ";

                    string req_insert = req_insert_part_1 + " " + req_insert_part_2;
                   
                    try
                    {
                        
                        System.Threading.Thread.Sleep(10);

                        cmd.Connection = con;
                        cmd.CommandText = req_insert;                       
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        test = ex.Message;
                        labo.modele.SYS_LOG_Modele.tracerException(ex, " DB.insert() :: " + req_insert);
                    }

                }// boucle sur les lignes


                // fermeture de la connexion
                try
                {
                    con.Close();
                }
                catch (Exception ex)
                {
                    test = ex.Message;
                    labo.modele.SYS_LOG_Modele.tracerException(ex);
                }


            }

            
            actionn.msg = test;


            return actionn;
        }

        //#################################################################################################
        //#################################################################################################
        //#################################################################################################


        public  string delete(string _reqDelete, string _tableName, int _id_usr)
        {
            string test = "";
            int nbrLigneDeleted = 0;
            try
            {
                con = SQLConnexion.getConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand(_reqDelete, con);
                //cmd.Parameters.AddWithValue("@ident", _ident);             
                cmd.Parameters.AddWithValue("@id_usr", _id_usr);

               nbrLigneDeleted = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                test = ex.Message;
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }

            // fermeture de la connexion
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {
                test = ex.Message;
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }

            if (Outils.Fonctions_String.getString_toCompare(test).Equals("")
               && nbrLigneDeleted <= 0)
            {
                test = "Suppression impossible";
            }

            return test;
        }

        // ##################################################################################""
        public  string delete(long _ident, string _tableName, int _id_usr)
        {
            string test = "";
            int nbrLigneDeleted = 0;

            string cmdDeleteCommand = @" 

              DELETE FROM " + _tableName + " WHERE ident = @ident ";

            try
            {
                con = SQLConnexion.getConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmdDeleteCommand, con);
                cmd.Parameters.AddWithValue("@ident", _ident);
                cmd.Parameters.AddWithValue("@id_usr", _id_usr);

               nbrLigneDeleted = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                test = ex.Message;
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }

            // fermeture de la connexion
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {
                test = ex.Message;
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }


            if (Outils.Fonctions_String.getString_toCompare(test).Equals("")
               && nbrLigneDeleted <= 0)
            {
                test = "Suppression impossible";
            }

            return test;
        }

        public string delete(string _reqDelete, string _tableName, Dictionary<int, DBParametre> _list_params, int _id_usr)
        {
            string test = "";

            int nbrLigneDeleted = 0;
            try
            {
                con = SQLConnexion.getConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand(_reqDelete, con);

                if (_list_params != null && _list_params.Count > 0)
                {
                    foreach (int key in _list_params.Keys)
                    {
                        DBParametre param = (DBParametre)_list_params[key];
                        cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }
                }

               nbrLigneDeleted = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                test = ex.Message;
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }

            // fermeture de la connexion
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {
                test = ex.Message;
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }

            if (Outils.Fonctions_String.getString_toCompare(test).Equals("")
                && nbrLigneDeleted<=0)
            {
                test = "Suppression impossible";
            }

            return test;
        }


        // ####################################################################################"""


        public int getLas_id_Inserted(long _numberAleatoire, int _id_usr)
        {

            DataSet daSet1 = new DataSet();
            DataTable daTable1 = new DataTable();
            int i = 0;

            string reqSelectx =
           " SELECT MAX(ident) as last_id  FROM ar_entite WHERE numberAleatoire=@numberAleatoire ";

            try
            {

                MySqlCommand cmd;
                con = SQLConnexion.getConnection();
                con.Open();
                cmd = new MySqlCommand(reqSelectx, con);
                cmd.Parameters.AddWithValue("@numberAleatoire", _numberAleatoire);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(daSet1, "ar_entite");
                daTable1 = daSet1.Tables["ar_entite"];
            }
            catch (Exception ex)
            {

                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }

            // fermeture de la connexion
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {
                
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }

            try
            {

                i = Int32.Parse(daTable1.Rows[0]["last_id"] + "");

            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message);
            }


            return i;
        }




        public string executeNonQuery(string _req, Dictionary<int, DBParametre> _list_params, int _id_usr)
        {
            string test = "";          

            try
            {
                con = SQLConnexion.getConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand(_req, con);
              
                if (_list_params != null && _list_params.Count > 0)
                {
                    foreach (int key in _list_params.Keys)
                    {
                        DBParametre param = (DBParametre)_list_params[key];
                        cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }
                }


                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                test = ex.Message;
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }

            // fermeture de la connexion
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {
                test = ex.Message;
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }

            return test;
        }


        public  string executeNonQuery(string _req, int _id_usr)
        {
            string test = "";

            try
            {
                con = SQLConnexion.getConnection();
                con.Open();
                MySqlCommand cmd = new MySqlCommand(_req, con);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                test = ex.Message;
                labo.modele.SYS_LOG_Modele.tracerException(ex);
                labo.modele.SYS_LOG_Modele.tracerMessage(_req);
            }

            // fermeture de la connexion
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {
                test = ex.Message;
                labo.modele.SYS_LOG_Modele.tracerException(ex);
            }

            return test;
        }



    }



}
