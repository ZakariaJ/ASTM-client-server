using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLabo.databases.tables
{
    public class app_dual
    {
        public static string getCreate(){

            string req = @"

CREATE TABLE  app_dual (
	 id int(10) unsigned NOT NULL AUTO_INCREMENT,	
     c   int(10) NULL 
     PRIMARY KEY ( id ) 
) 


";

            return req;

        }


        public static string getAlter()
        {

            string req = @"

;

DELETE FROM app_dual WHERE IFNULL(c,0) <>1 ;

INSERT INTO app_dual (  c )
SELECT  1 as c
WHERE 1 NOT IN ( SELECT IFNULL(c,0) FROM  app_dual ) 

;


";

            return req;

        }

    }
}