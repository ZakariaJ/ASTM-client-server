using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestLaboMach.personnalisation
{
    class PersonnaliserDATAGRIDVIEW
    {



        public static void personnaliser(DataGridView _dataGridView)
        {
           
            personnaliser_Ligne(_dataGridView);
            personnaliser_Colonne(_dataGridView);
        }


        private static void personnaliser_Ligne(DataGridView _dataGridView)
        {
            _dataGridView.MultiSelect = false;
            _dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private static void personnaliser_Colonne(DataGridView _dataGridView)
        {
            
        }
    }
}
