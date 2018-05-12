using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestLaboMach.labo.modele
{
    class Machine
    {
        public int id_machine = 0;
        public string machineName = "";
        public string ipAdresse="";
        public int portNumber = 0;

        public string userName = "";
        public string passWord = "";

        public string codeGroupeAnalyse = "";

        public Machine(int _id_machine)
        {
            this.id_machine = _id_machine;

            //id_machine_yumizenH500 ---------------------------------------------------------
            if (_id_machine == Constantes.id_machine_yumizenH500)
            {
                this.machineName = "Yumizen H500";
                this.ipAdresse = "127.0.0.1";
                this.portNumber = 4148;
                this.userName = "root";
                this.passWord = "123";
                this.codeGroupeAnalyse = "NFS";
            }

        }

    }
}
