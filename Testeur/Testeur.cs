using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Jeu2Des;


namespace Testeur
{
    class Testeur
    {
        
        public static void Main(string[] args)
        {
            //choix du type de save binaire ou json
            int choixsave = 0;

            Console.WriteLine("Vous pouvez choisir de sauvergarder votre classement en format binaire ou en format json ");
            Console.WriteLine("Pour le format binaire taper 1");
            Console.WriteLine("Pour le format json taper 2");
            choixsave = Convert.ToInt32( Console.ReadLine());
            
            
                       
            //Le jeu est crée (avec ses 2 des et son classement)
            Jeu MonJeu = new Jeu(choixsave);

            //Jouons quelques parties....
            MonJeu.JouerPartie(); //1ere partie avec un joueur par défaut            
            MonJeu.JouerPartie(); //2eme partie avec un joueur par défaut
            MonJeu.JouerPartie("David"); //3eme partie
            MonJeu.JouerPartie("David"); //Encore une partie  
            MonJeu.JouerPartie("Sarah"); //Encore une partie 
            MonJeu.JouerPartie("Lucie"); //Encore une partie
            MonJeu.JouerPartie(); //Encore une partie 


            Console.WriteLine("Le classement des score : ");
            MonJeu.AfficheHighScore();

            MonJeu.SaveClassement();
            Console.ReadKey();            
        }
    }
}
