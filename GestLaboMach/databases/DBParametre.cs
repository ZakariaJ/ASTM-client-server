using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestLaboMach.databases
{
    public class DBParametre
    {
        public string ParameterName = "";
        public Object Value = "";

        public DBParametre(string _ParameterName, Object _Value)
        {
            this.ParameterName = _ParameterName;
            this.Value = _Value;
        }
    }
}
