using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;


namespace GestLaboMach.databases
{
    class SQL_CONTROLDATABASE_ALTER
    {
        
        private static MySqlConnection con;                
        public static void alter_DatabaseDefenition()
        {
           // RENAME TABLE art_Artisant_CatalogueDt TO art_product_Catalogue
           // ALTER TABLE art_crm_contact MODIFY tel_1 varchar(100)
            //   ALTER TABLE art_crm_dde_devis_info MODIFY tel varchar(100) ;

            /*
          unique  ar_dossiermodele_dt id_dossiermodele
          id_typedocument
            */
            
            // *** Tables *****************************************************
          //  controle_SplitString(tables.table_sg_entite.getScriptCreate());
            /*
            controle(tables.app_dual.getCreate());
           
            controle_SplitString(tables.app_societe.getAlter());

            controle_SplitString(tables.alter_all_tables.getAlter());
         
            */
        }
               
        
        public static void controle_SplitString(string _req)
        {
            string str = null;
            string[] strArr = null;
            int count = 0;
            str = _req;
            char[] splitchar = { ';' };
            strArr = str.Split(splitchar);
            for (count = 0; count <= strArr.Length - 1; count++)
            {
                //MessageBox.Show(strArr[count]);
                controle(strArr[count]);
            }

        }

        public static void controle(string _req)
        {
            System.Threading.Thread.Sleep(5);
           
            //******************************************************************************
                try
                {

                    MySqlCommand cmd;
                    con = SQLConnexion.getConnection();
                    con.Open();

                    cmd = new MySqlCommand(_req, con);
                    //cmd.Parameters.Add(new MyMySqlParameter("@_loginUser", _loginUser));
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                }
                finally
                {
                    con.Close();
                }
            
        }

        

        }

    
}
