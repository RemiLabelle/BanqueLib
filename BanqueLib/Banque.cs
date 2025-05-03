using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanqueLib
{
    internal class Banque
    {
        #region champs

        private string _nom;
        private IReadOnlyList<Compte> _comptes = null;
        private int _prochainNumero = 0;

        #endregion
        #region constructeur

        public Banque(string nom, int prochainNumero = 0, List<Compte>? comptesList = null, Compte[]? comptesArray = null) 
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nom);
            this._nom = nom;

            if (comptesList == null && comptesArray == null)
            {
                this._prochainNumero = 
                    prochainNumero == 0 ? 
                    this._prochainNumero++ 
                    : this._prochainNumero = prochainNumero;
            }
            else
            {
                if (comptesList == null)
                {
                    foreach (Compte compte in comptesArray) 
                    {
                        ArgumentNullException.ThrowIfNull(compte);

                        foreach (Compte compareCompte in comptesArray) 
                        {
                            if (compte.Numéro == compareCompte.Numéro)
                                throw new ArgumentException();
                        }
                    }

                    this._comptes = comptesArray;
                }
                else
                {
                    foreach (Compte compte in comptesList)
                    {
                        ArgumentNullException.ThrowIfNull(compte);

                        foreach (Compte compareCompte in comptesList) 
                        {
                            if (compte.Numéro == compareCompte.Numéro)
                                throw new ArgumentException();
                        }
                    }

                    this._comptes = comptesList;
                }

                Array.Sort(_comptes.ToArray());

                this._prochainNumero = 
                    prochainNumero == 0 ? 
                    this._prochainNumero = _comptes[_comptes.Count - 1].Numéro + 1 
                    : this._prochainNumero = prochainNumero;
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
            return this._comptes.Count;
        }

        public decimal TotalDesDépôts() 
        {
            decimal total = 0;

            foreach (Compte compte in this._comptes) 
            {
                total += compte.Solde;
            }

            return total;
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
                    else if (i == 4 && j == 7)
                    {
                        string txt = $"Prochain Numéro:  {ProchainNuméro}";
                        output += txt;
                        j += (txt.Length - 1);
                    }
                    else if (i == 5 && j == 7)
                    {
                        string txt = $"Nombre de Comptes:  {NombreDeComptes()}";
                        output += txt;
                        j += (txt.Length - 1);
                    }
                    else if (i == 6 && j == 7)
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

        public string DescriptionDesComptes() //finir allignement
        {
            string output = "";

            for (int i = 0; i < Comptes.Count; i++)
            {
                output += "[RL] ";

                output += $"#{Comptes[i].Numéro}";

                output += Comptes[i].Détenteur;

                output += $"{Comptes[i].Solde:C2}";

                output += Comptes[i].Statut.ToString();

                output += "\n";
            }

            return output;
        }

        public string DescriptionComplète()
        {
            return DescriptionSommaire() + "\n\n" + DescriptionDesComptes();
        }

        public Compte? ChercherCompte(int numeroCompte) //finir
        {
            return null;
        }

        public bool PeutSupprimerCompte(Compte compte) //finir
        {
            return false;
        }
        public bool PeutSupprimerCompte(int numeroCompte) //finir
        {
            return false;
        }

        #endregion
        #region méthodes modifiantes

        public Compte CréerCompte(string detenteur) //finir
        {
            return null;
        }

        public void SupprimerCompte(Compte compte) //finir
        {
            
        }
        public void SupprimerCompte(int numeroCompte) //finir
        {

        }

        #endregion
    }
}