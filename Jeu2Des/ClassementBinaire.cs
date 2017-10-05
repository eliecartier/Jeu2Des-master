using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Jeu2Des
{
    [Serializable]
    class ClassementBinaire : Classement
    {

        public ClassementBinaire() : base()
        {
           
        }





        public override void Load()
        {
            if (File.Exists("savbinaire.txt"))
            {
                using (Stream fichier = File.OpenRead("savbinaire.txt"))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    Object obj = serializer.Deserialize(fichier);

                    HighScore = (Dictionary<string, int>)obj;
                    fichier.Close();
                }
            }
        }

        public override void Save()
        {
            using (Stream fichier = File.Create("savbinaire.txt"))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(fichier, HighScore);
                fichier.Close();
            }
        }
    }
}
