using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data;
using GestLaboMach.labo.dao;
using GestLaboMach.labo.modele;

namespace GestLaboMach
{
    public partial class ResultatForm : Form
    {

        App_dossierDAO dosDAO = new App_dossierDAO();
        App_dossier_dtDAO dos_dt = new App_dossier_dtDAO();

        // DataSet daSetResult = new System.Data.DataSet();
        DataTable daTableDossiers = new System.Data.DataTable();

        public ResultatForm()
        {
            InitializeComponent();


            this.init_dataGridViewResult();
        }

        public void init_dataGridViewResult()
        {
           // this.daSet1 = fdao.getAllDataSet();
            try
            {
                this.daTableDossiers = dosDAO.ListAll_For_List_DataTable(Constantes.app_dossier_sais_rslt_statut);
                this.bindingSourceDossiers.DataSource = this.daTableDossiers;
                this.dataGridViewDossiers.DataSource = this.bindingSourceDossiers;
                this.bindingNavigatorDossiers.BindingSource = this.bindingSourceDossiers;

               //  dataGridViewDossiers.Columns["patient"].Width = 250;                 
                dataGridViewDossiers.Columns["num_dossier"].Visible = true;
                dataGridViewDossiers.Columns["patient"].Visible = true;               
         

                GestLaboMach.personnalisation.PersonnaliserDATAGRIDVIEW.personnaliser(this.dataGridViewDossiers);

            }
            catch (Exception xxxxx)
            {
                MessageBox.Show(xxxxx.Message);
            }

        }





    }
}
