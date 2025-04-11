using BanqueLib;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

//deserialize
string dataFile = "Compte.json";

Compte compte = LoadCompte(dataFile);

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
     r - Reset

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

            SaveCompte(compte, dataFile);

            Environment.Exit(0);
            break;
        case 'r':
            compte = new Compte(new Random().Next(100, 1000), "Rémi Labelle");
            Console.WriteLine(" Un nouveau compte a été créé.");
            break;
        default:
            Console.WriteLine(" Mauvais choix.");
            break;
    }
    Console.WriteLine("\n Appuyer sur ENTER pour continuer...");
    Console.ReadLine();
}
;

void SaveCompte(Compte compte, string data)
{
    File.WriteAllText(data, JsonSerializer.Serialize(compte, new JsonSerializerOptions { WriteIndented = true }));
}

Compte LoadCompte(string data)
{
    if (File.Exists(data))
    {
        string rawData = File.ReadAllText(data);

        if (!string.IsNullOrWhiteSpace(rawData))
        {
            return JsonSerializer.Deserialize<Compte>(rawData);
        }
        else
        {
            return new Compte(new Random().Next(100, 1000), "Rémi Labelle");
        }
    }
    else
    {
        return new Compte(new Random().Next(100, 1000), "Rémi Labelle");
    }
}