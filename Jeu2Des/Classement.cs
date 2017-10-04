using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu2Des
{
    class Classement  
    {
        SortedDictionary<string, int > HighScore;
        
         
        public Classement()
        {
           HighScore = new SortedDictionary<string, int>();
        }

        public void AjouterAuHighScore(string nom ,int score)
        {
            HighScore.Add(nom, score);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
