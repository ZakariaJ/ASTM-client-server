using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLabo.databases.tables
{
    public class alter_all_tables
    {        
        public static string getAlter()
        {
            /*
            voir à supprimer de la tables app_analyse
                `id_type_analyse` int(10) DEFAULT NULL,
                  `soustraitance` varchar(512) DEFAULT NULL,
                  `val_b` double DEFAULT NULL,
                   tmp_code
                   `sensibil_Ana` double DEFAULT NULL,
              */

                      
            string req = @"
          
;

UPDATE app_questions_reponses SET dt_mod = NOW();
UPDATE app_questions_reponses SET dt_cre = NOW();
ALTER TABLE  app_questions_reponses MODIFY id_usr_cre int(10) NULL;
ALTER TABLE  app_analyse MODIFY facteur_conv double NULL; 

";

            return req;

        }

    }
}