using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Jeu2Des
{
    
    public abstract class Classement  
    {
        protected Dictionary<string, int > HighScore;
        
         
        protected Classement()
        {
           HighScore = new Dictionary<string, int>();
        }

        public void AjouterAuHighScore(string nom ,int score)
        {
            if (HighScore.ContainsKey(nom) && HighScore[nom]< score)
            {
                
                HighScore[nom] = score;
            }
            else if (HighScore.ContainsKey(nom) && HighScore[nom] > score)
            {
                HighScore[nom] = HighScore[nom];
            }
            else if (HighScore.ContainsKey(nom) && HighScore[nom] == score)
            {
                HighScore[nom] = score;
            }
            else
            {
                HighScore.Add(nom, score);
            }  
            
            
                     
        }        

        public void TopN()
        {

           Dictionary<string, int> Doctrier = HighScore.OrderByDescending(e => e.Value).ToDictionary(e => e.Key, e => e.Value);

            foreach (var scorejoueur in Doctrier)
            {
                Console.WriteLine(scorejoueur.Key +" " + scorejoueur.Value);
            }
        }


        public abstract void Save();

        public abstract void Load();


        

        #region savexml qui marche pas encore
        //public void SaveHighScoreXml()
        //{
        //    using (Stream fichier = File.Create("savxml.xml"))
        //    {
        //        XmlSerializer serializer = new XmlSerializer(HighScore.GetType());
        //        serializer.Serialize(fichier, HighScore);
        //        fichier.Close();
        //    }
        //}

        //public void LoadHighScoreXml()
        //{
        //    if (File.Exists("savxml.xml"))
        //    {
        //        using (Stream fichier = File.OpenRead("savxml.xml"))
        //        {
        //            XmlSerializer serializer = new XmlSerializer(typeof(Classement));
        //            Object obj = serializer.Deserialize(fichier);

        //            HighScore = (SerializableDictionary<string, int>)obj;
        //            fichier.Close();
        //        }
        //    }

        //}
        #endregion

       
    }
}
