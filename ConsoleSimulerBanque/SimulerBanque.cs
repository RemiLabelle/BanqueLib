using BanqueLib;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json;

string dataFile = "Banque.json";

Banque banque = LoadBanque(dataFile);

while (true)
{
    Console.Clear();
    Console.WriteLine(banque.DescriptionSommaire());
    Console.WriteLine(banque.DescriptionDesComptes());
    Console.WriteLine("""
    
     1..9 - Selectionner le compte
     c    - Créer nouveau compte
     q    - Quitter
     r    - Reset
     s    - Supprimer le dernier compte

     Votre choix, Rémi Labelle ?

    """);

    switch (Console.ReadKey(true).KeyChar)
    {
        case '1':
            try
            {
                Compte selectCompte = banque.ChercherCompte(1);
                ArgumentNullException.ThrowIfNull(selectCompte);

                SimulerCompte(ref selectCompte);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ** Aucun compte ne porte le numéro 1 ** ");
            }
            break;
        case '2':
            try
            {
                Compte selectCompte = banque.ChercherCompte(2);
                ArgumentNullException.ThrowIfNull(selectCompte);

                SimulerCompte(ref selectCompte);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ** Aucun compte ne porte le numéro 2 ** ");
            }
            break;
        case '3':
            try
            {
                Compte selectCompte = banque.ChercherCompte(3);
                ArgumentNullException.ThrowIfNull(selectCompte);

                SimulerCompte(ref selectCompte);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ** Aucun compte ne porte le numéro 3 ** ");
            }
            break;
        case '4':
            try
            {
                Compte selectCompte = banque.ChercherCompte(4);
                ArgumentNullException.ThrowIfNull(selectCompte);

                SimulerCompte(ref selectCompte);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ** Aucun compte ne porte le numéro 4 ** ");
            }
            break;
        case '5':
            try
            {
                Compte selectCompte = banque.ChercherCompte(5);
                ArgumentNullException.ThrowIfNull(selectCompte);

                SimulerCompte(ref selectCompte);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ** Aucun compte ne porte le numéro 5 ** ");
            }
            break;
        case '6':
            try
            {
                Compte selectCompte = banque.ChercherCompte(6);
                ArgumentNullException.ThrowIfNull(selectCompte);

                SimulerCompte(ref selectCompte);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ** Aucun compte ne porte le numéro 6 ** ");
            }
            break;
        case '7':
            try
            {
                Compte selectCompte = banque.ChercherCompte(7);
                ArgumentNullException.ThrowIfNull(selectCompte);

                SimulerCompte(ref selectCompte);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ** Aucun compte ne porte le numéro 7 ** ");
            }
            break;
        case '8':
            try
            {
                Compte selectCompte = banque.ChercherCompte(8);
                ArgumentNullException.ThrowIfNull(selectCompte);

                SimulerCompte(ref selectCompte);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ** Aucun compte ne porte le numéro 8 ** ");
            }
            break;
        case '9':
            try
            {
                Compte selectCompte = banque.ChercherCompte(9);
                ArgumentNullException.ThrowIfNull(selectCompte);

                SimulerCompte(ref selectCompte);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ** Aucun compte ne porte le numéro 9 ** ");
            }
            break;
        case 'c':
            banque.CréerCompte("Remi Labelle " + new Random().Next(100,1000));

            Console.WriteLine(" ** Nouveau compte ajouté ** ");
            break;
        case 'q':
            SaveBanque(banque, dataFile);

            Environment.Exit(0);
            break;
        case 's':
            if (banque.Comptes != null && banque.Comptes.Count > 0)
            {
                Compte supprCompte = banque.Comptes[banque.NombreDeComptes() - 1];

                try
                {
                    banque.SupprimerCompte(supprCompte);
                    Console.WriteLine($" ** Le compte de {supprCompte.Détenteur} (compte #{supprCompte.Numéro}) a été supprimé. ** ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" ** Le compte de {supprCompte.Détenteur} (compte #{supprCompte.Numéro}) est gelé ou non vide : Impossible de le supprimer. **");
                }
            }
            else 
            {
                Console.WriteLine(" ** Aucun compte à supprimer. ** ");
            }
            break;
        case 'r':
            banque = new Banque("Remi Labelle Banking Co.");

            Console.WriteLine(" ** Banque réinitialisée avec succès. ** ");
            break;
        default:
                Console.WriteLine(" Mauvais choix.");
            break;
    }
    Console.WriteLine("\n Appuyer sur ENTER pour continuer...");
    Console.ReadLine();
};

void SimulerCompte(ref Compte compte) 
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine(compte.Description());
        Console.WriteLine("""
    
     1 - Modifier Détenteur
     2 - Peut Déposer
     3 - Peut retirer
     4 - Peut retirer (montant)
     5 - Déposer (montant)
     6 - Retirer (montant)
     7 - Vider
     8 - Geler
     9 - Dégeler
     q - Quitter
     r - Supprimer

     Votre choix, Rémi Labelle ?

    """);

        switch (Console.ReadKey(true).KeyChar)
        {
            case '1':
                compte.SetDétenteur("Rémi Labelle " + new Random().Next(1, 100));
                Console.WriteLine($"** Détenteur modifié pour : {compte.Détenteur}.");
                break;
            case '2':
                try
                {
                    Console.WriteLine("** Peut déposer ? " + (compte.PeutDéposer() ? "Oui." : "Non."));
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("** Peut déposer ? Non.");
                }

                break;
            case '3':
                try
                {
                    Console.WriteLine("** Peut retirer ? " + (compte.PeutRetirer() ? "Oui." : "Non."));
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("** Peut retirer ? Non.");
                }

                break;
            case '4':

                decimal _ = Math.Round(Convert.ToDecimal(new Random().Next(0, 100) + new Random().NextDouble()), 2);

                try
                {
                    Console.WriteLine($"** Peut retirer {_:C2}? " + (compte.PeutRetirer(_) ? "Oui." : "Non."));
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"** Peut retirer {_:C2} ? Non.");
                }

                break;
            case '5':

                _ = Math.Round(Convert.ToDecimal(new Random().Next(0, 100) + new Random().NextDouble()), 2);

                try
                {
                    compte.Déposer(_);
                    Console.WriteLine($"** Dépôt de {_:C2}.");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine($"** Impossible de déposer {_:C2}.");
                }

                break;
            case '6':

                _ = Math.Round(Convert.ToDecimal(new Random().Next(0, 100) + new Random().NextDouble()), 2);

                try
                {
                    compte.Retirer(_);
                    Console.WriteLine($"** Retrait de {_:C2}.");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine($"** Impossible de retirer {_:C2}.");
                }

                break;
            case '7':
                try
                {
                    Console.WriteLine($"** Retrait complet de {compte.Vider():C2}.");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("** Impossible de vider un compte vide ou gelé.");
                }

                break;
            case '8':
                if (compte.EstGelé)
                {
                    Console.WriteLine("** Impossible de geler un compte déjà gelé.");
                }
                else
                {
                    compte.Geler();
                    Console.WriteLine("** Le compte a été gelé.");
                }
                break;
            case '9':
                if (!compte.EstGelé)
                {
                    Console.WriteLine("** Impossible de dégeler un compte non gelé.");
                }
                else
                {
                    compte.Dégeler();
                    Console.WriteLine("** Le compte a été dégelé.");
                }
                break;
            case 'q':
                return;
            case 'r':
                banque.SupprimerCompte(compte);
                Console.WriteLine(" ** Le compte a été supprimé. **");
                return;
            default:
                Console.WriteLine(" Mauvais choix.");
                break;
        }
        Console.WriteLine("\n Appuyer sur ENTER pour continuer...");
        Console.ReadLine();
    };
}

void SaveBanque(Banque banque, string data)
{
    File.WriteAllText(data, JsonSerializer.Serialize(banque, new JsonSerializerOptions { WriteIndented = true }));
}

Banque LoadBanque(string data)
{
    if (File.Exists(data))
    {
        string rawData = File.ReadAllText(data);

        if (!string.IsNullOrWhiteSpace(rawData))
        {
            return JsonSerializer.Deserialize<Banque>(rawData);
        }
    }
    
    return new Banque("Remi Labelle Banking Co.");
}
