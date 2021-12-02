using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//DebutNameSpaceConsoleAPP1
namespace ConsoleApp1
{
    class Black_Jack
    {
        //debut static void Main
        static void Main(string[] args)
        {

            // Initialisation du dictionnaire contenant en clé les noms des cartes en string, et en int
            // les valeurs des cartes, qui est aussi la valeur de la clé

            Dictionary<string, int> ValeursCartes = new Dictionary<string, int> { };
            List<string> JoueurHumain = new List<string>();
            List<string> JoueurOrdinateur = new List<string>();
            List<string> Paquet = new List<string>();
            List<int> listeCartePourObtenirBlackJack = new List<int>();
            List<int> compteurSoustractionValeurASJoueur = new List<int>();
            List<string> receptionCarteASJoueur = new List<string>();
            List<int> receptioncarteAsJoueurOrdinateur = new List<int>();
            List<string> receptionCarteAsOrdinateur = new List<string>();
            List<int> compteurDeSoustractionParAsOrdinateur = new List<int>();
            List<int> compteurASDansJeuHumainAChangeDeValeur = new List<int>();
            List<string> compteurASJeuOrdinateur = new List<string>();
            List<string> compteurASDansJeuOrdinateurAChangeDeValeur = new List<string>();
            List<string> compteurJoueurOrdinateurATriche = new List<string>();
            List<string> SoustractionAEteEffectuee = new List<string>();
            Random Melangeur = new Random();


            int ScoreHumain;
            int ScoreOrdinateur;
            int NombreDePaquets = 4;
            int CarteduJeu;
            int choixnombrepaquetcartes;


            string ChoixJoueur;
            string PossibilitéChoixPaquetCartes;



            bool stopJoueurHumain = false;
            bool stopOrdinateur = false;
            bool finDePartie = false;
            bool scoreMaxAutoriseAtteint = false;
            bool joueurPeutCommencerTour = false;
            bool joeurATireAS = false;
            bool OrdinateurATireAs = false;
            bool joueurAccordeTricheAOrdinateur = false;
            bool victoireOrdinateur = false;
            bool victoireJoueur = false;
            bool BLACKJACKJOUEURHUMAIN = false;
            bool BLACKJACKJOUEURORDINATEUR = false;

            Console.WriteLine("\n Bonjour ... Quel est votre prénom ? ");
            Console.WriteLine(" \n Le programme ne s'activera que si vous écrivez quelque chose sur le clavier :) ");

            var prenomJoueur = Console.ReadLine();

            do
            {

                prenomJoueur = Console.ReadLine();
            }

            while (string.IsNullOrEmpty(prenomJoueur));



            Console.WriteLine("\n Bienvenue dans ce programme de Black Jack " + prenomJoueur);
            Console.WriteLine(" Le but de ce jeu est de vaincre le croupier joué par l'ordinateur en tirant des cartes " +
                "sans atteindre la somme de 21 ");
            Console.WriteLine(" Attention cependant l'ordinateur n'est pas réputé pour être un joueur honnête et il a pour objectif de toujours faire gagner la maison !");
            Console.WriteLine("\n Arriverez-vous à le vaincre ? ");


            Console.WriteLine("\n Ce jeu de Black Jack est un peu special ... Mais il est rudimentaire. \n Voulez-vous accorder à l'ordinateur le droit de tricher pour pimenter" +
                "la partie ? \n Selon certains paramètres précis et selon le score de l'Ordinateur, l'Ordinateur peut choisir de changer Une carte du Jeu, pour le rapprocher le plus \n" +
                "possible de 21 (notez au passage que dans certains casinos, le croupier n'est pas du tout réputé pour être honnête ...  Notez aussi qu'en acceptant cette option, l'ordinateur" +
                "trichera en fonction de si cela l'avantage lui oui non ");



            Console.WriteLine(" \n  Voulez accorder à l'Ordinateur le droit de tricher ? \n ");

            Console.WriteLine(" O - Oui ");
            Console.WriteLine(" N - Non ");


            do
            {

                Console.WriteLine(" \n Veuillez choisir l'un des deux caractères demandés O - Oui, N - Non ");
                ChoixJoueur = Console.ReadLine();
            }
            while (ChoixJoueur != "O" && ChoixJoueur != "N");

            if (ChoixJoueur == "O")
            {
                joueurAccordeTricheAOrdinateur = true;
                Console.WriteLine(" \n Vous avez accordé à l'Ordinateur le droit de tricher ! ");
            }


            //debut initiations des cartes i à 14, avec valeur 10 pour 10, V, D, K et AS
            for (int i = 1; i <= 15; i++)
            {

                if (i > 9)
                {
                    switch (i)
                    {
                        case 10: ValeursCartes.Add("10", 10); break;
                        case 11: ValeursCartes.Add("V", 10); break;
                        case 12: ValeursCartes.Add("D", 10); break;
                        case 13: ValeursCartes.Add("K", 10); break;
                        case 14: ValeursCartes.Add("AS", 11); break;
                    }
                }
                else
                {
                    ValeursCartes.Add(i.ToString(), i);
                }

            }
            ValeursCartes.Remove(ValeursCartes.Keys.First());
            //On retire la première valeur du dictionnaire, en effet on a pas besoin de la Carte 1
            // Il y en a pas dans le BlackJack, et on a rajouté l'AS qui vaut 11;

            List<int> listeValeursCartes = ValeursCartes.Values.ToList();
            listeCartePourObtenirBlackJack = ValeursCartes.Values.ToList();

            Console.WriteLine("\n Initialisation des valeurs des cartes : \n ");
            Console.WriteLine("");
            for (int item = 0; item < listeValeursCartes.Count; item++)
            {
                Console.Write(" " + listeValeursCartes[item]);
            }


            Console.WriteLine("");
            Console.WriteLine("\n Les cartes sont : \n ");
            foreach (string key in ValeursCartes.Keys)
            {
                Console.Write(" " + key);
            }
            Console.WriteLine("");

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\n Les cartes du jeu ont été initialisé \n");

            Console.WriteLine("\n Par défaut le nombre de paquets de cartes est initialisé à 4");
            Console.WriteLine("\n Voulez vous choisir un nombre de paquets de cartes ? ");

            //Debut choix paquet de carte
            do
            {

                Console.WriteLine(" \n Veuillez répondre en choissant l'un des deux caractères demandés ");
                Console.WriteLine(" \n O - Oui, N - non");
                PossibilitéChoixPaquetCartes = Console.ReadLine();
            }
            while (PossibilitéChoixPaquetCartes != "O" && PossibilitéChoixPaquetCartes != "N");

            if (PossibilitéChoixPaquetCartes == "O")
            {

                Console.WriteLine(" \n Vous avez choisi Oui, veuillez entrer un nombre de paquets de cartes : ");
                while (!int.TryParse(Console.ReadLine(), out NombreDePaquets))
                {

                    Console.WriteLine("\n Veuillez entrer un nombre valide ");
                }

                NombreDePaquets = choixnombrepaquetcartes = Convert.ToInt32(NombreDePaquets);

                //on continue de demander jusqu'à ce que l'utilisateur entre un int

            }

            else
            {
                Console.WriteLine(" \n Vous n'avez pas choisi de nombre de paquets de carte");
            }
            //Fin Choixpaquet de carte

            Console.WriteLine(" \n Le nombre de paquets de carte est de " + NombreDePaquets);

            System.Threading.Thread.Sleep(1000);

            //Debut affichage paquet de carte
            foreach (string key in ValeursCartes.Keys)
            {
                for (int i = 0; i < NombreDePaquets; i++)
                {
                    Paquet.Add(key);

                }
            }
            //Fin affichage paquet de carte

            System.Threading.Thread.Sleep(1000);

            //Appel de la fonction score
            ScoreHumain = score(JoueurHumain, ValeursCartes);
            ScoreOrdinateur = score(JoueurOrdinateur, ValeursCartes);
            //fin appel de la fonction score

            Console.WriteLine(" \n Le paquet de cartes a été mélangé ");
            System.Threading.Thread.Sleep(1000);

            //Melangeur du Paquet
            Paquet = Paquet.OrderBy(item => Melangeur.Next()).ToList();

            

            //boucle de la partie
            if (finDePartie == false)
            {
                Console.WriteLine(" \n Que la partie commence ... ");

                // Debut boucle for permettant d'ajouter la dernière carte du paquet 
                for (int j = 0; j < 2; j++)
                {
                    JoueurHumain.Add(Paquet.Last());
                    Paquet.RemoveAt(Paquet.Count - 1);

                    JoueurOrdinateur.Add(Paquet.Last());
                    Paquet.RemoveAt(Paquet.Count - 1);
                }

                //fin boucle for permettant d'ajouter la dernière carte du paquet

                //Debut Affichage jeu humain
                for (CarteduJeu = 0; CarteduJeu < JoueurHumain.Count - 1; CarteduJeu++)
                {
                    Console.WriteLine($"\r--------" + " ---------");
                    Console.WriteLine($"\r|      |" + " |       |");
                    Console.WriteLine($"\r   {JoueurHumain[CarteduJeu]}   " + $"     {JoueurHumain.Last()}   ");
                    Console.WriteLine($"\r|      |" + " |       |");
                    Console.WriteLine($"\r--------" + "  -------");

                }
                ScoreHumain = score(JoueurHumain, ValeursCartes);
                Console.WriteLine(" Vous avez tiré une nouvelle carte, la valeur totale de la main de " + prenomJoueur + " est de " + ScoreHumain);
                //Fin Affcihage jeu humain


                Console.WriteLine($" \n Le Score de la main du Joueur Humain est : {ScoreHumain} ");
                if (ScoreHumain == 21)
                {
                    BLACKJACKJOUEURHUMAIN = true;
                    {
                        if (BLACKJACKJOUEURHUMAIN == true)
                        {
                            Console.WriteLine(" Vous avez fait un BLACK JACK ! ");
                            stopJoueurHumain = true;
                        }
                    }
                }

                //Boucle for Affichage jeu ordinateur
                for (CarteduJeu = 0; CarteduJeu < JoueurOrdinateur.Count - 1; CarteduJeu++)
                {
                    Console.WriteLine("--------" + " ---------");
                    Console.WriteLine("|      |" + " |       |");
                    Console.WriteLine($"   ?  " + $"       {JoueurOrdinateur.Last()}   ");
                    Console.WriteLine("|      |" + " |       |");
                    Console.WriteLine("--------" + "  -------");
                }
                ScoreOrdinateur = score(JoueurOrdinateur, ValeursCartes);
                if (ScoreOrdinateur == 21)
                {
                    BLACKJACKJOUEURORDINATEUR = true;
                    stopOrdinateur = true;
                }

                System.Threading.Thread.Sleep(2000);
                Console.WriteLine(" \n L'ordinateur vous regarde d'une manière suspicieuse ... Va-t-il tricher ? ");
                System.Threading.Thread.Sleep(2000);
                //Fin Affichage ordinateur

                //Debut triche ordinateur
                if (joueurAccordeTricheAOrdinateur == true && ScoreOrdinateur < 21)
                {

                    Console.WriteLine("\n L'ordinateur détourne votre attention en pointant quelque chose du doigt ... Vous avez regardé et n'avez pas vu ce qu'il a fait ! " +
                            "\n Diantre !");
                    JoueurOrdinateur.RemoveAt(0);
                    JoueurOrdinateur.Insert(0, "K");
                    ScoreOrdinateur = score(JoueurOrdinateur, ValeursCartes);
                    Console.WriteLine(" Le score ordinateur est de " + ScoreOrdinateur);
                    System.Threading.Thread.Sleep(2000);

                }
                else
                {
                    Console.WriteLine(" L'Ordinateur semble satisfait ... ");
                    System.Threading.Thread.Sleep(2000);
                }
                joueurAccordeTricheAOrdinateur = false;

                //fin triche ordinateur


                // Debut boucle if else du jour Humain si score humain est inférieur à 21
                if (ScoreHumain < 21 && stopJoueurHumain == false)
                {
                    

                    if (stopJoueurHumain == false)
                    {
                        Console.WriteLine(" \n Voulez-vous piocher une nouvelle carte ? \n ");

                        Console.WriteLine(" O - Oui ");
                        Console.WriteLine(" N - Non ");

                        do
                        {
                            Console.WriteLine(" \n C'est à votre tour de jouer ");
                            Console.WriteLine(" \n Veuillez choisir l'un des deux caractères demandés - O - oui, N - non ");
                            ChoixJoueur = Console.ReadLine();
                        }
                        while (ChoixJoueur != "O" && ChoixJoueur != "N");
                        if (ChoixJoueur == "O")
                        {
                            Console.WriteLine(prenomJoueur + " est en train de piocher ");

                            JoueurHumain.Add(Paquet.Last());
                            Paquet.RemoveAt(Paquet.Count - 1);

                            for (CarteduJeu = 0; CarteduJeu < JoueurHumain.Count; CarteduJeu++)
                            {
                                Console.WriteLine($"\r--------");
                                Console.WriteLine($"\r|      |");
                                Console.WriteLine($"\r   {JoueurHumain[CarteduJeu]}");
                                Console.WriteLine($"\r|      |");
                                Console.WriteLine($"\r--------");

                            }

                            ScoreHumain = score(JoueurHumain, ValeursCartes);
                            Console.WriteLine(" Vous avez tiré une nouvelle carte, la valeur totale de la main de " + prenomJoueur + " est de " + ScoreHumain); ;

                        }
                        else
                        {
                            stopJoueurHumain = true;
                        }
                    }
                    else
                    {
                        stopJoueurHumain = true;
                        Console.WriteLine(" Vous avez dépassé ou atteint le nombre 21, ou avez décidé de ne pas jouer, vous ne pouvez donc pas jouer");
                    }

                    if (ScoreOrdinateur >= 15)
                    {
                        if (scoreMaxAutoriseAtteint == false)
                        {
                            joueurPeutCommencerTour = true;
                            if (joueurPeutCommencerTour == true)
                            {
                                Console.WriteLine(" Ordinateur a décidé de jouer ");

                                JoueurOrdinateur.Add(Paquet.Last());
                                Paquet.RemoveAt(Paquet.Count - 1);

                                Console.WriteLine(" L'ordinateur a pioché  : ");


                                for (CarteduJeu = 0; CarteduJeu < JoueurOrdinateur.Count - 1; CarteduJeu++)
                                {
                                    Console.WriteLine("-------");
                                    Console.WriteLine("|      |");
                                    Console.WriteLine($"  ?   ");
                                    Console.WriteLine("|      |");
                                    Console.WriteLine("-------");
                                }

                                Console.WriteLine("  -------");
                                Console.WriteLine(" |      |");
                                Console.WriteLine($"    {JoueurOrdinateur.Last()}   ");
                                Console.WriteLine(" |      |");
                                Console.WriteLine("  -------");

                                Console.WriteLine(" \n L'ordinateur a fini de piocher");
                                System.Threading.Thread.Sleep(2000);

                                //fin boucle00 si la dernière carte de l'Ordinateur est un AS

                                // boucle if si Score Humain est inférieur à 21 ligne 418

                                if (ScoreHumain <= 21 && stopJoueurHumain == false)
                                {

                                    Console.WriteLine(" \n  Voulez-vous piocher une nouvelle carte ? \n ");

                                    Console.WriteLine(" O - Oui ");
                                    Console.WriteLine(" N - Non ");


                                    do
                                    {
                                        Console.WriteLine(" \n C'est à votre tour de jouer ");
                                        Console.WriteLine(" \n Veuillez choisir l'un des deux caractères demandés O - Oui, N - Non ");
                                        ChoixJoueur = Console.ReadLine();
                                    }
                                    while (ChoixJoueur != "O" && ChoixJoueur != "N");

                                    if (ChoixJoueur == "O" && stopJoueurHumain == false)
                                    {
                                        Console.WriteLine(prenomJoueur + " est en train de piocher Ligne");

                                        JoueurHumain.Add(Paquet.Last());
                                        Paquet.RemoveAt(Paquet.Count - 1);

                                        for (CarteduJeu = 0; CarteduJeu < JoueurHumain.Count; CarteduJeu++)
                                        {
                                            Console.WriteLine($"\r--------");
                                            Console.WriteLine($"\r|      |");
                                            Console.WriteLine($"\r   {JoueurHumain[CarteduJeu]}");
                                            Console.WriteLine($"\r|      |");
                                            Console.WriteLine($"\r--------");

                                        }
                                        ScoreHumain = score(JoueurHumain, ValeursCartes);




                                        // On ajoute de nouveau une carte dans la liste Joueur Humain
                                        // pour chaque élément carte dans la liste joueur humain
                                        // On affiche donc carte et on ajoute une virgule entre guillemets 

                                        Console.WriteLine();
                                        Console.WriteLine(" Vous avez tiré une nouvelle carte, la valeur totale de la main de " + prenomJoueur + " est de " + ScoreHumain);
                                        System.Threading.Thread.Sleep(2000);


                                    }

                                    else
                                    {
                                        Console.Write(" \n " + prenomJoueur + "  a choisi de s'arrêter ");
                                        System.Threading.Thread.Sleep(2000);
                                        stopJoueurHumain = true;

                                    }
                                    //fin boucle if Tour si Score humain est inférieur à 21

                                }
                                else
                                {
                                    stopJoueurHumain = true;
                                    Console.WriteLine(" Vous avez dépassé ou atteint le nombre 21, ou avez décidé de ne pas jouer au tour précédent, vous ne pouvez pas jouer");
                                    Console.ReadKey();
                                }

                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine(" L'ordinateur a décidé de ne pas continuer à jouer ");
                            stopOrdinateur = true;
                        }
                    }

                }
                else
                {
                    stopJoueurHumain = true;
                }
                //fin boucle premier tour if else,
                System.Threading.Thread.Sleep(1000);


                //Debut tour  ordinateur
                if (ScoreOrdinateur <= 15 && stopOrdinateur == false || ScoreOrdinateur < ScoreHumain || stopJoueurHumain == true)
                {


                    if (ScoreOrdinateur >= ScoreHumain || ScoreHumain >= 21
                        || ScoreOrdinateur >= 20 || ScoreOrdinateur >= 19)
                    {
                        scoreMaxAutoriseAtteint = true;
                        stopOrdinateur = true;
                        Console.WriteLine(" \n L'ordinateur a décidé de ne pas jouer");
                        System.Threading.Thread.Sleep(2000);
                    }

                    else
                    {
                        //debut boucle Ordinateur si son score est inférieur à 15
                        if (ScoreOrdinateur <= 15 && stopOrdinateur == false)
                        {
                            if (scoreMaxAutoriseAtteint == false)
                            {
                                joueurPeutCommencerTour = true;
                                if (joueurPeutCommencerTour == true)
                                {
                                    Console.WriteLine(" Ordinateur a décidé de jouer ");

                                    JoueurOrdinateur.Add(Paquet.Last());
                                    Paquet.RemoveAt(Paquet.Count - 1);

                                    Console.WriteLine(" L'ordinateur a pioché  : ");

                                    for (CarteduJeu = 0; CarteduJeu < JoueurOrdinateur.Count - 1; CarteduJeu++)
                                    {
                                        Console.WriteLine("-------");
                                        Console.WriteLine("|      |");
                                        Console.WriteLine($"  ?   ");
                                        Console.WriteLine("|      |");
                                        Console.WriteLine("-------");
                                    }

                                    Console.WriteLine("  -------");
                                    Console.WriteLine(" |      |");
                                    Console.WriteLine($"    {JoueurOrdinateur.Last()}   ");
                                    Console.WriteLine(" |      |");
                                    Console.WriteLine("  -------");

                                    System.Threading.Thread.Sleep(2000);

                                    // boucle if si Score Humain est inférieur à 21 ligne 418

                                    if (ScoreHumain < 21 && stopJoueurHumain == false)
                                    {

                                        Console.WriteLine(" \n  Voulez-vous piocher une nouvelle carte ? \n ");
                                        Console.WriteLine(" O - Oui ");
                                        Console.WriteLine(" N - Non ");

                                        do
                                        {
                                            Console.WriteLine(" \n C'est à votre tour de jouer ");
                                            Console.WriteLine(" \n Veuillez choisir l'un des deux caractères demandés O - Oui, N - Non ");
                                            ChoixJoueur = Console.ReadLine();
                                        }
                                        while (ChoixJoueur != "O" && ChoixJoueur != "N");

                                        if (ChoixJoueur == "O" && stopJoueurHumain == false)
                                        {
                                            Console.WriteLine(prenomJoueur + " est en train de piocher ");

                                            JoueurHumain.Add(Paquet.Last());
                                            Paquet.RemoveAt(Paquet.Count - 1);

                                            for (CarteduJeu = 0; CarteduJeu < JoueurHumain.Count; CarteduJeu++)
                                            {
                                                Console.WriteLine($"\r--------");
                                                Console.WriteLine($"\r|      |");
                                                Console.WriteLine($"\r   {JoueurHumain[CarteduJeu]}");
                                                Console.WriteLine($"\r|      |");
                                                Console.WriteLine($"\r--------");

                                            }
                                            ScoreHumain = score(JoueurHumain, ValeursCartes);

                                            Console.WriteLine(" Vous avez tiré une nouvelle carte, la valeur totale de la main de " + prenomJoueur + " est de " + ScoreHumain);


                                            // On ajoute de nouveau une carte dans la liste Joueur Humain
                                            // pour chaque élément carte dans la liste joueur humain
                                            // On affiche donc carte et on ajoute une virgule entre guillemets 
                                            Console.WriteLine();
                                        }

                                        else
                                        {
                                            Console.WriteLine(" \n Joueur Humain a choisi de s'arrêter ");
                                            System.Threading.Thread.Sleep(2000);
                                            stopJoueurHumain = true;
                                        }
                                        //fin boucle if Tour si Score humain est inférieur à 21
                                    }
                                    else
                                    {
                                        stopJoueurHumain = true;
                                        Console.WriteLine(" Vous avez dépassé ou atteint le nombre 21, ou avez décidé de ne pas jouer au tour précédent, vous ne pouvez pas jouer");
                                        Console.ReadKey();
                                    }

                                    Console.ReadKey();
                                }
                            }
                            else
                            {

                                stopOrdinateur = true;
                            }
                        }
                    }

                    //debut boucle ordinateur
                    if (scoreMaxAutoriseAtteint == true)
                    {
                        stopOrdinateur = true;
                        Console.WriteLine(" L'ordinateur a décidé de ne pas continuer à jouer");


                        //debut boucle if Scorehumain inférieur ou égal à 21 
                        if (ScoreHumain < 21)
                        {
                            if (stopJoueurHumain == false)
                            {
                                do
                                {
                                    Console.WriteLine(" \n C'est à votre tour de jouer ");
                                    Console.WriteLine(" \n Veuillez choisir l'un des deux caractères demandés O - Oui, N - non ");
                                    ChoixJoueur = Console.ReadLine();
                                }
                                while (ChoixJoueur != "O" && ChoixJoueur != "N");

                                if (ChoixJoueur == "O" && stopJoueurHumain == false)
                                {
                                    Console.WriteLine(prenomJoueur + " est en train de piocher ");

                                    JoueurHumain.Add(Paquet.Last());
                                    Paquet.RemoveAt(Paquet.Count - 1);

                                    for (CarteduJeu = 0; CarteduJeu < JoueurHumain.Count; CarteduJeu++)
                                    {
                                        Console.WriteLine($"\r--------");
                                        Console.WriteLine($"\r|      |");
                                        Console.WriteLine($"\r   {JoueurHumain[CarteduJeu]}");
                                        Console.WriteLine($"\r|      |");
                                        Console.WriteLine($"\r--------");

                                    }

                                }
                            }
                            else
                            {
                                stopJoueurHumain = true;
                            }
                        }
                        else
                        {
                            stopJoueurHumain = true;
                        }
                    }
                    else
                    {
                        finDePartie = true;
                    }
                    //fin boucle ordinateur

                    //Debut Affichage conditions des fin de partie
                    if (stopJoueurHumain == true || stopOrdinateur == true)
                    {
                        Console.WriteLine("\n - Joueur humain a atteint ou dépassé 21, ou choisi de s'arrêter, et ne peut donc plus jouer");
                        Console.WriteLine(" \n - Ordinateur a atteint ou dépassé 21, ou choisi de s'arrêter et ne peut donc plus jouer ");
                        Console.WriteLine(" \n - Les deux joueurs ont arrêté la partie ");
                        Console.ReadKey();
                        System.Threading.Thread.Sleep(1000);
                        finDePartie = true;
                        Console.WriteLine("\n Les conditions de fin de la partie ont été réunies \n ");
                    }
                    //Fin Affichage conditions des fins de partie

                    //Condition speciale fin de partie 

                    // Fin condition speciale fin de partie

                    //Debut Detail des conditions de fins de partie
                    if (finDePartie == true)
                    {

                        Console.WriteLine("\n Les conditions nécessaire pour terminer la partie ont été réunie : ");
                        System.Threading.Thread.Sleep(1000);

                        //debut boucle évènement Joueur a un AS dans son premier tour EVENTSPECIAL00
                        if (JoueurHumain.Contains("AS"))
                        {
                            Console.WriteLine(" \n Il y a un AS DANS VOTRE JEU ! DES CONDITIONS SPECIALES VIENNENT DE S'ENCLENCHER ! ");
                            Console.WriteLine(" Si votre score est supérieur à 21, et selon votre décision, La valeur de votre AS passera de 1 à 10");
                            joeurATireAS = true;

                            //On propose au joueur s'il veut changer la valeur de son as
                            Console.WriteLine(" Votre Score est de " + ScoreHumain);
                            Console.WriteLine(" \n Voulez-vous changer la valeur de votre as ? \n ");

                            Console.WriteLine(" O - Oui ");
                            Console.WriteLine(" N - Non ");

                            do
                            {

                                Console.WriteLine(" \n Veuillez choisir l'un des deux caractères demandés - O - oui, N - non ");
                                ChoixJoueur = Console.ReadLine();
                            }
                            while (ChoixJoueur != "O" && ChoixJoueur != "N");

                            if (ChoixJoueur == "O" && stopJoueurHumain == false)
                            {

                                Console.WriteLine(" \n Vous avez choisi Oui ! ");

                                if (joeurATireAS == true)
                                {

                                    if (ScoreHumain > 21)
                                    {
                                        ScoreHumain = score(JoueurHumain,ValeursCartes);
                                        ScoreHumain += -10;
                                        Console.WriteLine(" La soustraction a été effectuée ! ");

                                    }
                                    else
                                    {
                                        Console.WriteLine(" \n Votre score n'est pas supérieur à 21, la soustraction n'a pas pu se faire");
                                    }
                                }

                                compteurSoustractionValeurASJoueur.Clear();
                                joeurATireAS = false;
                            }

                            //fin boucle if évènement Joueur a tiré AS dans son premier tour EVENTSPECIAL00
                            // Fin condition speciale fin de parti


                        }
                        // fin boucle



                        //Si ordinateur tire un AS dès sa première main et que son score est supérieur à 21
                        ScoreOrdinateur = score(JoueurOrdinateur, ValeursCartes);
                        if (JoueurOrdinateur.Contains("AS"))
                        {
                            ScoreOrdinateur = score(JoueurOrdinateur, ValeursCartes);
                            Console.WriteLine(" L'ordinateur a tiré un AS ! Son score est de " + ScoreOrdinateur);
                            OrdinateurATireAs = true;
                            if (OrdinateurATireAs == true)
                            {

                                if (ScoreOrdinateur > 21)
                                {
                                    Console.WriteLine(" Le Score de l'ordinateur est supérieur à 21, L'ordinateur a donc choisi que son AS passe de 11 à 1");
                                    Console.ReadKey();
                                    ScoreOrdinateur += -10;
                                }
                                else
                                {

                                }
                            }

                        }
                        OrdinateurATireAs = false;
                        //Fin Detail des conditions de fin de partie
                        //fin boucle Ordinateur a tiré un AS lors de son premier tour

                        // debut conditions de fin de partie


                        {
                            if (BLACKJACKJOUEURHUMAIN == true)
                            {

                                Console.WriteLine(" \n " + prenomJoueur + " A REMPORTÉ LA PARTIE GRACE A UN BLACK JACK !!!! \n VOUS ÊTES GRAND AUJOURD'HUI !!!!! \n OUAIS !!!!!! OUAIS !!!!! OUUUUUUUUAAAAAIS !!!!! ");
                                victoireJoueur = true;
                            }
                            if (BLACKJACKJOUEURORDINATEUR == true)
                            {
                                Console.WriteLine(" L'Ordinateur a obtenu à un Black Jack ... Et il vous affiche son petit sourire malicieux ... ");
                            }

                            if (ScoreHumain <= 21 && ScoreHumain > ScoreOrdinateur)
                            {
                                Console.WriteLine("\n Félicitations, vous avez vaincu un ordinateur tricheur ! Admirez-le, s'étouffant dans rage ! Hmmmm Délicieux !");
                                victoireJoueur = true;
                                victoireOrdinateur = false;

                            }

                            if (ScoreOrdinateur == ScoreHumain)
                            {
                                Console.WriteLine("\n Votre score est le même que celui de l'ordinateur," +
                                    " Vous avez fait un match nul, l'ordinateur n'a pas gagné, mais vous non plus ... ");
                                victoireJoueur = false;
                                victoireOrdinateur = false;

                            }

                            if (ScoreOrdinateur >= 21 && ScoreHumain >= 21)
                            {
                                Console.WriteLine("\n Les deux joueurs ont dépassé 21, c'est un match nul, l'ordinateur n'a pas gagné, mais vous non plus ...");
                                Console.ReadKey();
                                victoireJoueur = false;
                                victoireOrdinateur = false;

                            }

                            if (ScoreHumain > 21 && ScoreOrdinateur <= ScoreHumain && ScoreOrdinateur <= 21)
                            {
                                Console.WriteLine("\n Vous avez dépassé 21, ce qui n'est pas le cas de l'Ordinateur, Vous avez perdu !");
                                Console.WriteLine("\n L'ordinateur est fier de sa réussite");
                                victoireJoueur = false;
                                victoireOrdinateur = true;

                            }
                            if (ScoreOrdinateur > 21)
                            {
                                Console.WriteLine("\n Ordinateur a dépassé 21 et a donc perdu !");
                                Console.WriteLine("\n Felicitations pour votre Victoire ! ");
                                Console.ReadKey();
                                victoireJoueur = true;
                                victoireOrdinateur = false;

                            }
                            if (ScoreHumain > ScoreOrdinateur && ScoreHumain <= 21)
                            {
                                Console.WriteLine("\n Joueur Humain a fait un score supérieur à l'ordinateur sans atteindre 21");
                                Console.WriteLine(" \n Franchement GG, profitez de votre victoire mérité !");
                                victoireJoueur = true;
                                victoireOrdinateur = false;


                            }


                            if (ScoreOrdinateur > ScoreHumain && ScoreOrdinateur <= 21)
                            {
                                Console.WriteLine("\n Le Score de l'ordinateur est supérieur au score humain, et est inférieur ou égal à 21 ");
                                Console.WriteLine(" \n L'ordinateur profite de sa victoire en vous regardant d'un sourire narquois, téma la taille du rat ... ");
                                Console.ReadKey();
                                victoireJoueur = false;
                                victoireOrdinateur = true;

                            }

                            if (ScoreOrdinateur > 21 && ScoreHumain > ScoreOrdinateur)
                            {
                                Console.WriteLine(" \n " + prenomJoueur + " a gagné la partie en n'atteignant pas 21 et en battant le score de l'ordinateur !!! BRAVO !!! ");
                                Console.WriteLine("");
                                Console.ReadKey();
                                victoireJoueur = true;
                                victoireOrdinateur = true;

                            }
                            if (ScoreOrdinateur > 21 && ScoreOrdinateur <= ScoreHumain)
                            {
                                Console.WriteLine(" \n Joeur humain a gagné contre l'ordinateur, Franchement bravo !");
                                Console.ReadKey();
                                Console.ReadKey();
                                victoireOrdinateur = true;
                                victoireJoueur = true;

                            }

                        }
                        //fin conditions de fin de partie

                        if (victoireJoueur == true)
                        {
                            Console.WriteLine(prenomJoueur + "\n A GAGNÉ LA PARTIE ! FÉLICITATIONS !!!!! ");
                        }
                        else
                        {
                            Console.Write(" \n " + prenomJoueur + " a perdu la partie ...");
                        }
                        if (victoireOrdinateur == true)
                        {
                            Console.WriteLine("\n L'ordinateur a gagné la partie ... Mais vous aurez votre revanche ! ");
                        }
                        if (victoireOrdinateur == false && victoireJoueur == false)
                        {
                            Console.WriteLine("\n Les 2 joueurs ont fait un match nul ... ");
                        }

                    }


                    // Debut boucle pour quitter le programme si la partie est finie
                    if (finDePartie == true)
                    {

                        Console.WriteLine("\n L'Ordinateur est en train de poser sa main sur la table : ");
                        System.Threading.Thread.Sleep(1000);

                        for (CarteduJeu = 0; CarteduJeu < JoueurOrdinateur.Count; CarteduJeu++)
                        {


                            Console.WriteLine($"\r--------");
                            Console.WriteLine($"\r|      |");
                            Console.WriteLine($"\r   {JoueurOrdinateur[CarteduJeu]}");
                            Console.WriteLine($"\r|      |");
                            Console.WriteLine($"\r--------");

                        }

                        Console.WriteLine("\n Le score du joueur Ordinateur est de " + ScoreOrdinateur);


                        Console.WriteLine(" \n Vous posez à votre vos mains sur la table ");
                        System.Threading.Thread.Sleep(1000);

                        Console.WriteLine(" \n ");
                        for (CarteduJeu = 0; CarteduJeu < JoueurHumain.Count; CarteduJeu++)
                        {
                            Console.WriteLine($"\r--------");
                            Console.WriteLine($"\r|      |");
                            Console.WriteLine($"\r   {JoueurHumain[CarteduJeu]}");
                            Console.WriteLine($"\r|      |");
                            Console.WriteLine($"\r--------");
                        }


                        Console.WriteLine("\n Le score de " + prenomJoueur + " est de " + ScoreHumain);


                        Console.WriteLine(" \n Le jeu est terminé");
                        Console.WriteLine(" \n Merci à vous, nous nous sommes bien amusés ! Au plaisir de vous renvoir dans une nouvelle partie ... ");
                        Console.WriteLine("  Veuillez appuyer sur une touche pour quitter le jeu");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                    }
                    // Fin boucle pour quitter le programme si la partie est finie

                }

            }
            // fin static void Main


        }

        // fin static void main
        //debut static int score
        static int score(List<string> MainDuJoueur, Dictionary<string, int> ValeursDesCartes)
        {
            int Score = 0;

            foreach (string item in MainDuJoueur)
            {
                Score += ValeursDesCartes[item];
            }

            return Score;
        }
        //fin static int score

        //fin class
    }
    //fin NameSpace ConsoleApp1
}

