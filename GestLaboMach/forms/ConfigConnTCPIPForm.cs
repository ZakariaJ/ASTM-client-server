using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestLaboMach.forms
{
    public partial class ConfigConnTCPIPForm : Form
    {

        private labo.modele.Machine  mach ; 
        public ConfigConnTCPIPForm(int _id_machine)
        {
            this.mach = new labo.modele.Machine(_id_machine);
            InitializeComponent();
            
            this.Text = "Configuration TCP IP - " + this.mach.machineName;
        }
    }
}
