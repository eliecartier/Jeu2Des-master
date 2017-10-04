using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Jeu2Des
{
    [Serializable]
    public class Classement  
    {
        SortedDictionary<string, int > HighScore;
        
         
        public Classement()
        {
           HighScore = new SortedDictionary<string, int>();
        }

        public void AjouterAuHighScore(string nom ,int score)
        {
            if (HighScore.ContainsKey(nom) && HighScore[nom]< score)
            {
                //HighScore.Remove(nom);
                //HighScore.Add(nom, score);
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

        public override string ToString()
        {
            return base.ToString();
        }

        public void TopN()
        {

           Dictionary<string, int> Doctrier = HighScore.OrderByDescending(e => e.Value).ToDictionary(e => e.Key, e => e.Value);

            foreach (var scorejoueur in Doctrier)
            {
                Console.WriteLine(scorejoueur.Key +" " + scorejoueur.Value);
            }
        }

        public void SaveHighscore()
        {

            using (Stream fichier = File.Create("sav.txt"))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(fichier, HighScore);
                fichier.Close();
            }
        }

        public void LoadHighScore()
        {
            if (File.Exists("sav.txt"))
            {
                using (Stream fichier = File.OpenRead("sav.txt"))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    Object obj = serializer.Deserialize(fichier);

                    HighScore = (SortedDictionary<string, int>)obj;
                    fichier.Close();
                }
            }
        }


    }
}
