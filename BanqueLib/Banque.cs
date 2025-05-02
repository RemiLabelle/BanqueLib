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

        private string Nom;
        private IReadOnlyList<Compte> Comptes = null;
        private int ProchainNuméro = 0;

        #endregion
        #region constructeur

        public Banque(string nom, int prochainNumero = 0, List<Compte>? comptesList = null, Compte[]? comptesArray = null) 
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nom);
            this.Nom = nom;

            if (comptesList == null && comptesArray == null)
            {
                this.ProchainNuméro = 
                    prochainNumero == 0 ? 
                    this.ProchainNuméro++ 
                    : this.ProchainNuméro = prochainNumero;
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

                    this.Comptes = comptesArray;
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

                    this.Comptes = comptesList;
                }

                Array.Sort(Comptes.ToArray());

                this.ProchainNuméro = 
                    prochainNumero == 0 ? 
                    this.ProchainNuméro = Comptes[Comptes.Count - 1].Numéro + 1 
                    : this.ProchainNuméro = prochainNumero;
            }
        }

        #endregion
        #region méthodes calculantes

        public int NombreDeComptes() 
        {
            return this.Comptes.Count;
        }

        public decimal TotalDesDépôts() 
        {
            decimal total = 0;

            foreach (Compte compte in this.Comptes) 
            {
                total += compte.Solde;
            }

            return total;
        }

        #endregion
    }
}