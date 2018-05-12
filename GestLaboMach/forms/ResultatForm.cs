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

namespace GestLaboMach.forms
{
    public partial class ResultatForm : Form
    {

        TcpIpClient tcpipCliObj = new TcpIpClient();

        App_dossierDAO dosDAO = new App_dossierDAO();
        App_dossier_dtDAO dos_dt = new App_dossier_dtDAO();

        // DataSet daSetResult = new System.Data.DataSet();
        DataTable daTableDossiers = new System.Data.DataTable();
        DataTable daTableDosDT = new System.Data.DataTable();

        private long selected_id_dossier = 0;
        private labo.modele.Machine mach;
        public ResultatForm(int _id_machine)
        {
            this.mach = new labo.modele.Machine(_id_machine);
            InitializeComponent();
                       

            dataGridViewDossiers.SelectionChanged += new EventHandler(
            dataGridViewDossiers_SelectionChanged);

            this.init_dataGridViewListDossiers();                       

            this.Text = "Contrôle des résultats - " + this.mach.machineName;
            tcpipCliObj.rslform = this;
            
        }

        public void init_dataGridViewListDossiers()
        {
           // this.daSet1 = fdao.getAllDataSet();
            try
            {
                this.daTableDossiers = dosDAO.ListAll_For_List_DataTable(Constantes.app_dossier_sais_rslt_statut);
                this.bindingSourceDossiers.DataSource = this.daTableDossiers;
                this.dataGridViewDossiers.DataSource = this.bindingSourceDossiers;
                this.bindingNavigatorDossiers.BindingSource = this.bindingSourceDossiers;
                dataGridViewDossiers.Columns["id_dossier"].Visible = false;
                dataGridViewDossiers.Columns["num_dossier"].Visible = true;
                dataGridViewDossiers.Columns["patient"].Visible = true;
                dataGridViewDossiers.Columns["num_dossier"].HeaderText = "Dossier";
                dataGridViewDossiers.Columns["patient"].HeaderText = "Patient";
                GestLaboMach.personnalisation.PersonnaliserDATAGRIDVIEW
                    .personnaliser(this.dataGridViewDossiers);

                this.dataGridViewDossiers.Columns["patient"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception xxxxx)
            {
                MessageBox.Show(xxxxx.Message);
            }

        }

        //##################################################################
        private void dataGridViewDossiers_SelectionChanged(object sender, EventArgs e)
        {
            // Update the labels to reflect changes to the selection.
            //UpdateLabelText();
            foreach (DataGridViewRow row in dataGridViewDossiers.SelectedRows)
            {
                this.selected_id_dossier = 0;
                try {
                    this.selected_id_dossier = Int64.Parse(row.Cells["id_dossier"].Value.ToString());
                }
                catch(Exception xxx)
                {
                   // MessageBox.Show(xxx.Message);
                }
                
                this.affiche_DossDet(this.selected_id_dossier);
            }
        }

        //##################################################################

        private void affiche_DossDet(long _id_dossier)
        {
            this.init_dataGridViewListDosDT(_id_dossier);
        }

        //#######################################################################
        private void init_dataGridViewListDosDT(long _id_dossier)
        {
            // this.daSet1 = fdao.getAllDataSet();
            try
            {
                this.daTableDosDT = dos_dt.ListByIdDossier(_id_dossier,this.mach.codeGroupeAnalyse);
                this.bindingSourceDossiersDt.DataSource = this.daTableDosDT;
                this.dataGridViewDosDT.DataSource = this.bindingSourceDossiersDt;
                //this.bindingNavigatorDossiers.BindingSource = this.bindingSourceDossiersDt;

                //  dataGridViewDossiers.Columns["patient"].Width = 250;                 
                dataGridViewDosDT.Columns["id_dossier_dt"].Visible = false;
                dataGridViewDosDT.Columns["code_analyse"].Visible = true;             

                dataGridViewDosDT.Columns["libelle_analyse"].Visible = true;
                dataGridViewDosDT.Columns["resultat"].Visible = true;

                dataGridViewDosDT.Columns["code_analyse"].HeaderText = "Examen";
                dataGridViewDosDT.Columns["libelle_analyse"].HeaderText = "Libellé";
                dataGridViewDosDT.Columns["resultat"].HeaderText = "Résultat";

                GestLaboMach.personnalisation.PersonnaliserDATAGRIDVIEW
                    .personnaliser(this.dataGridViewDosDT);

                this.dataGridViewDosDT.Columns["libelle_analyse"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception xxxxx)
            {
                MessageBox.Show(xxxxx.Message);
            }

        }

        private void btn_Seconnecter_Click(object sender, EventArgs e)
        {
            tcpipCliObj.seConecter(this.mach.id_machine);
        }
    }
}
