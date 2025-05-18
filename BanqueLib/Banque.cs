using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BanqueLib
{
    public class Banque
    {
        #region champs

        private string _nom;
        private IReadOnlyList<Compte>? _comptes = null;
        private int _prochainNumero = 1;

        #endregion
        #region constructeurs

        
        public Banque(string nom, int prochainNumero, IReadOnlyList<Compte>? comptes = null) 
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nom);
            this._nom = nom;
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(prochainNumero);
            if (comptes == null) 
            {
                this._prochainNumero = prochainNumero;
            }
            else
            {
                for (int i = 0; i < comptes.Count; i++)
                {
                    ArgumentNullException.ThrowIfNull(comptes[i]);

                    for (int j = 0; j < comptes.Count; j++)
                    {
                        if (comptes[j] != null)
                        {
                            if (comptes[i].Numéro == comptes[j].Numéro && i != j)
                                throw new ArgumentException();

                            if ((comptes[i].Numéro < comptes[j].Numéro && i > j) || (comptes[i].Numéro > comptes[j].Numéro && i < j))
                            {
                                Compte[] tempComptes = comptes.ToArray();
                                Compte tempCompte = comptes[i];

                                tempComptes[i] = comptes[j];
                                tempComptes[j] = tempCompte;

                                comptes = tempComptes;
                            }
                        }
                    }
                }

                this._comptes = comptes;

                this._prochainNumero = Comptes[Comptes.Count - 1].Numéro + 1;
                ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(ProchainNuméro, prochainNumero);
            }
        }

        [JsonConstructor]
        public Banque(string nom, IReadOnlyList<Compte>? comptes = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nom);
            this._nom = nom;

            if (comptes != null)
            {
                for (int i = 0; i < comptes.Count; i++)
                {
                    ArgumentNullException.ThrowIfNull(comptes[i]);

                    for (int j = 0; j < comptes.Count; j++)
                    {
                        if (comptes[j] != null) 
                        {
                            if (comptes[i].Numéro == comptes[j].Numéro && i != j)
                                throw new ArgumentException();

                            if ((comptes[i].Numéro < comptes[j].Numéro && i > j) || (comptes[i].Numéro > comptes[j].Numéro && i < j))
                            {
                                Compte[] tempComptes = comptes.ToArray();
                                Compte tempCompte = comptes[i];

                                tempComptes[i] = comptes[j];
                                tempComptes[j] = tempCompte;

                                comptes = tempComptes;
                            }
                        }
                    }
                }

                this._comptes = comptes;

                this._prochainNumero = Comptes[Comptes.Count - 1].Numéro + 1;
            }
            else
            {
                this._prochainNumero = ProchainNuméro;
            }
        }

        #endregion
        #region getters

        public string Nom => this._nom;
        public IReadOnlyList<Compte> Comptes => this._comptes;
        public int ProchainNuméro => this._prochainNumero;

        #endregion
        #region méthodes calculantes

        public int NombreDeComptes() 
        {
            if (Comptes != null)
            {
                return Comptes.Count;
            }
            else 
            {
                return 0;
            }
        }

        public decimal TotalDesDépôts() 
        {
            if (Comptes != null)
            {
                decimal total = 0;

                foreach (Compte compte in Comptes)
                {
                    total += compte.Solde;
                }

                return total;
            }
            else 
            {
                return 0;
            }
        }

        public string DescriptionSommaire()
        {
            string output = "";

            for (int i = 0; i < 9; i++)
            {
                output += "[RL] ";

                for (int j = 0; j < 55; j++)
                {
                    if (i == 0 || i == 8)
                    {
                        output += "=";
                    }
                    else if (i == 2 && j == 7)
                    {
                        output += Nom;
                        j += Nom.Length - 1;
                    }
                    else if (i == 4 && j == 5)
                    {
                        string txt = $"Prochain Numéro:  {ProchainNuméro}";
                        output += txt;
                        j += (txt.Length - 1);
                    }
                    else if (i == 5 && j == 3)
                    {
                        string txt = $"Nombre de Comptes:  {NombreDeComptes()}";
                        output += txt;
                        j += (txt.Length - 1);
                    }
                    else if (i == 6 && j == 4)
                    {
                        string txt = $"Total des Dépôts:  {TotalDesDépôts():C2}";
                        output += txt;
                        j += (txt.Length - 1);
                    }
                    else 
                    {
                        if (j == 0 || j == 54)
                        {
                            output += "|";
                        }
                        else 
                        {
                            output += " ";
                        } 
                    }
                }

                output += "\n";
            }

            return output;
        }

        public string DescriptionDesComptes()
        {
            string output = "";

            if (Comptes != null)
            {
                for (int i = 0; i < Comptes.Count; i++)
                {
                    output += "[RL]  ";

                    output += $"#{Comptes[i].Numéro}";
                    for (int j = 0; j < 16 - Comptes[i].Numéro.ToString().Length; j++) 
                    {
                        output += " ";
                    }

                    output += Comptes[i].Détenteur;
                    for (int j = 0; j < 30 - Comptes[i].Solde.ToString("C2").Length - Comptes[i].Détenteur.Length; j++)
                    {
                        output += " ";
                    }

                    output += $"{Comptes[i].Solde:C2}";
                    for (int j = 0; j < 3; j++)
                    {
                        output += " ";
                    }

                    output += Comptes[i].Statut.ToString();

                    output += "\n\n";
                }
            }

            return output;
        }

        public string DescriptionComplète()
        {
            return DescriptionSommaire() + "\n\n" + DescriptionDesComptes();
        }

        public Compte? ChercherCompte(int numeroCompte)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numeroCompte);

            foreach (Compte compte in Comptes) 
            {
                if (compte.Numéro == numeroCompte)
                {
                    return compte;
                }
            }

            return null;
        }

        public bool PeutSupprimerCompte(Compte compte)
        {
            ArgumentNullException.ThrowIfNull(compte);

            if (compte.EstGelé || compte.Solde != 0)
            {
                return false;
            }
            else
            {
                foreach (Compte compareCompte in Comptes) 
                {
                    if (compte.Equals(compareCompte))
                        return true;
                }

                return false;
            }
        }
        public bool PeutSupprimerCompte(int numeroCompte)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numeroCompte);

            foreach (Compte compte in Comptes) 
            {
                if (compte.Numéro == numeroCompte)
                {
                    return PeutSupprimerCompte(compte);
                }
            }

            return false;
        }

        #endregion
        #region méthodes modifiantes

        public Compte CréerCompte(string detenteur)
        {
            List<Compte> tempList = new List<Compte>();

            if (Comptes != null)
            {
                tempList = Comptes.ToList();
            }
            
            Compte newUser = new Compte(ProchainNuméro, detenteur);

            tempList.Add(newUser);
            this._comptes = tempList;
            this._prochainNumero++;

            return newUser;
        }

        public void SupprimerCompte(Compte compte)
        {
            if (PeutSupprimerCompte(compte))
            {
                List<Compte> tempList = Comptes.ToList();
                tempList.Remove(compte);
                this._comptes = tempList;
            }
            else 
            {
                throw new ArgumentException();
            }
        }
        public void SupprimerCompte(int numeroCompte)
        {
            if (PeutSupprimerCompte(numeroCompte))
            {
                List<Compte> tempList = Comptes.ToList();
                tempList.Remove(ChercherCompte(numeroCompte));
                this._comptes = tempList;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        #endregion
    }
}