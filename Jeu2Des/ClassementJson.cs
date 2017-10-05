using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Runtime.Serialization;

namespace Jeu2Des
{
    
    class ClassementJson : Classement
    {

        public ClassementJson(): base ()
        {
            
        }


        public override void Load()
        {
            if (File.Exists("savJson.json"))
            {
                using (Stream fichier = File.OpenRead("savJson.json"))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(HighScore.GetType());
                    HighScore = (Dictionary<string, int>)serializer.ReadObject(fichier);

                    fichier.Close();
                }
            }
        }

        public override void Save()
        {
            using (Stream fichier = File.Create("savJson.json"))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(HighScore.GetType());
                serializer.WriteObject(fichier, HighScore);
                fichier.Close();
            }
        }
    }
}
