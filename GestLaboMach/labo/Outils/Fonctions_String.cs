using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestLaboMach.Outils
{
    public class Fonctions_String
    {

        public static string getString_Sans_Accents (string _chaine){

            if (_chaine == null)
            {
                _chaine = "";
            }

            string chaine1 = _chaine;

        chaine1 = chaine1.Replace("à", "a");
        chaine1 = chaine1.Replace("à".ToUpper(), "a".ToUpper());

        chaine1 = chaine1.Replace("â", "a");        
        chaine1 = chaine1.Replace("â".ToUpper(), "a".ToUpper());

        chaine1 = chaine1.Replace("é", "e");
        chaine1 = chaine1.Replace("é".ToUpper(), "e".ToUpper());

        chaine1 = chaine1.Replace("è", "e");
        chaine1 = chaine1.Replace("è".ToUpper(), "e".ToUpper());
     
        chaine1 = chaine1.Replace("ê", "e");
        chaine1 = chaine1.Replace("ê".ToUpper(), "e".ToUpper());

        chaine1 = chaine1.Replace("î", "i");
        chaine1 = chaine1.Replace("î".ToUpper(), "i".ToUpper());

        chaine1 = chaine1.Replace("ù", "u");
        chaine1 = chaine1.Replace("ù".ToUpper(), "u".ToUpper());

        chaine1 = chaine1.Replace("û", "u");
        chaine1 = chaine1.Replace("û".ToUpper(), "u".ToUpper());

        chaine1 = chaine1.Replace("ô", "o");
        chaine1 = chaine1.Replace("ô".ToUpper(), "o".ToUpper());

        chaine1 = chaine1.Replace("ç", "c");
        chaine1 = chaine1.Replace("ç".ToUpper(), "c".ToUpper());

        return chaine1;

    }


     
        public static string getString_For_FileName(string _chaine)
        {

            if (_chaine == null)
            {
                _chaine = "";
            }

            string chaine1 = Outils.Fonctions_String.getString_Sans_Accents(_chaine);
            
            chaine1 = chaine1.Trim();
            chaine1 = chaine1.ToLower();
            chaine1 = chaine1.Replace(" ", "-");            
            chaine1 = getString_Sans_Caract_Speciaux(chaine1, "-");
            chaine1 = chaine1.Replace(" ", "-");
            chaine1 = chaine1.Replace("--", "-");
            chaine1 = chaine1.Trim();

            
            return chaine1;


        }

        public static string getString_For_referencement_url(string _chaine)
        {

            if (_chaine == null)
            {
                _chaine = "";
            }


            string chaine1 = Outils.Fonctions_String.getString_Sans_Accents(_chaine);
            chaine1 = chaine1.Trim();
            chaine1 = chaine1.ToLower();

            chaine1 = chaine1.Replace(" ", "-");
            chaine1 = getString_Sans_Caract_Speciaux(chaine1, "-");
            chaine1 = chaine1.Replace("--", "-");
            
           // N'utilisez surtout pas les caractères spéciaux 
           // (parenthèses, accolades, apostrophe, guillemets, etc.) 
           //     ainsi que l'espace et les lettres diacritiques (accents).

            return chaine1;


        }




        public static string getString_Sans_Caract_Speciaux(string _chaine, string _caract_de_remplacement)
        {
            if (_chaine == null)
            {
                _chaine = "";
            }

            string chaine1 = _chaine;


            chaine1 = chaine1.Replace("°", _caract_de_remplacement);
            chaine1 = chaine1.Replace("%", _caract_de_remplacement);
            chaine1 = chaine1.Replace("*", _caract_de_remplacement);
            chaine1 = chaine1.Replace("+", _caract_de_remplacement);
            chaine1 = chaine1.Replace("@", _caract_de_remplacement);
            chaine1 = chaine1.Replace("/", _caract_de_remplacement);
            chaine1 = chaine1.Replace("\\", _caract_de_remplacement);
            chaine1 = chaine1.Replace("|", _caract_de_remplacement);

            chaine1 = chaine1.Replace(".", _caract_de_remplacement);
            chaine1 = chaine1.Replace(";", _caract_de_remplacement);
            chaine1 = chaine1.Replace(":", _caract_de_remplacement);
            chaine1 = chaine1.Replace(",", _caract_de_remplacement);

            chaine1 = chaine1.Replace("=", _caract_de_remplacement);
            chaine1 = chaine1.Replace("&", _caract_de_remplacement);
            chaine1 = chaine1.Replace("?", _caract_de_remplacement);
            chaine1 = chaine1.Replace("!", _caract_de_remplacement);

            chaine1 = chaine1.Replace("'", _caract_de_remplacement);
            chaine1 = chaine1.Replace("\"", _caract_de_remplacement);

            chaine1 = chaine1.Replace("(", _caract_de_remplacement);
            chaine1 = chaine1.Replace(")", _caract_de_remplacement);
            chaine1 = chaine1.Replace("{", _caract_de_remplacement);
            chaine1 = chaine1.Replace("}", _caract_de_remplacement);
            chaine1 = chaine1.Replace("[", _caract_de_remplacement);
            chaine1 = chaine1.Replace("]", _caract_de_remplacement);
            chaine1 = chaine1.Replace("<", _caract_de_remplacement);
            chaine1 = chaine1.Replace(">", _caract_de_remplacement);

            chaine1 = chaine1.Replace("#", _caract_de_remplacement);
            chaine1 = chaine1.Replace("~", _caract_de_remplacement);
            chaine1 = chaine1.Replace("`", _caract_de_remplacement);
            chaine1 = chaine1.Replace("$", _caract_de_remplacement);

            if (!_caract_de_remplacement.Equals(""))
            {
                try
                {
                    chaine1 = chaine1.Replace(_caract_de_remplacement + "" + _caract_de_remplacement, _caract_de_remplacement);
                    chaine1 = chaine1.Replace(_caract_de_remplacement + "" + _caract_de_remplacement, _caract_de_remplacement);
                    chaine1 = chaine1.Replace(_caract_de_remplacement + "" + _caract_de_remplacement, _caract_de_remplacement);
                    chaine1 = chaine1.Replace(_caract_de_remplacement + "" + _caract_de_remplacement, _caract_de_remplacement);
                }
                catch (Exception ffffff)
                {

                }
            }

            

            return chaine1;
        }


        public static string getString_toCompare(string _chaine)
        {

            if (_chaine == null || _chaine.Equals(null))
            {
                _chaine = "";
            }

            string chaine1 = _chaine;
            chaine1 = chaine1.Trim().ToLower().Replace(" ", "");
            return chaine1;
        }
    
    }
}