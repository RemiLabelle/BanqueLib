using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BanqueLib
{
    public enum StatutCompte { Ok, Gelé };

    public class Compte
    {
        #region ----- champs -----

        private readonly int _numCompte;
        private string _detenteur;
        private decimal _solde;
        private bool _estGele;
        private StatutCompte _statut;

        #endregion
        #region ----- constructeurs -----

        public Compte(int numero, string detenteur, decimal solde = 0, StatutCompte statut = StatutCompte.Ok)
        {
            if (numero <= 0)
                throw new ArgumentOutOfRangeException(message: $"Numéro ('{numero}') must be a non-negative and non-zero value.", paramName: "Numéro", actualValue: numero);
            this._numCompte = numero;

            SetDétenteur(detenteur);

            if ((((solde % 1) * 100) % 1) != 0)
                throw new ArgumentOutOfRangeException(message: $"Solde ('{solde}') must be equal to '0.00'.", paramName: "Solde", actualValue: solde);
            if (solde < 0)
                throw new ArgumentOutOfRangeException(message: $"Solde ('{solde}') must a non-negative value.", paramName: "Solde", actualValue: solde);
            this._solde = solde;

            this._statut = statut;

            this._estGele
                = this._statut == StatutCompte.Ok ? false
                : true;
        }

        #endregion
        #region ----- getters -----

        public int Numéro => _numCompte;
        public string Détenteur => _detenteur;
        public decimal Solde => _solde;
        public bool EstGelé => _estGele;
        public StatutCompte Statut => _statut;

        #endregion
        #region ----- setters -----

        [MemberNotNull("_detenteur")]
        public void SetDétenteur(string detenteur)
        {
            if (detenteur == null)
                throw new ArgumentNullException(paramName: "Détenteur");
            if (detenteur.Trim() == "")
                throw new ArgumentException(message: "The value cannot be an empty string or composed entirely of whitespace.", paramName: "Détenteur");
            this._detenteur = detenteur.Trim();
        }

        #endregion
        #region ----- méthodes calculantes -----

        public string Description()
        {
            string output = "";

            for (int i = 0; i < 8; i++) //rangées
            {
                output += "[RL] ";

                for (int j = 0; j < 55; j++)  //colonnes
                {
                    if (i == 0 || i == 7)
                    {
                        output += "*";
                    }
                    else if (i == 2 && j == 5)
                    {
                        string txt = $"COMPTE : {Numéro}";
                        output += txt;
                        j += (txt.Length - 1);
                    }
                    else if (i == 3 && j == 9)
                    {
                        string txt = $"De : {Détenteur}";
                        output += txt;
                        j += (txt.Length - 1);
                    }
                    else if (i == 4 && j == 6)
                    {
                        string txt = $"Solde : {Solde:C2}";
                        output += txt;
                        j += (txt.Length - 1);
                    }
                    else if (i == 5 && j == 5)
                    {
                        string txt = $"Statut : {Statut}";
                        output += txt;
                        j += (txt.Length - 1);
                    }
                    else
                    {
                        if (j == 0 || j == 54)
                        {
                            output += "*";
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
        public bool PeutDéposer(decimal montant = 1)
        {
            if ((((montant % 1) * 100) % 1) != 0)
                throw new ArgumentOutOfRangeException(message: $"montant ('{montant}') must be equal to '1.00'.", paramName: "montant", actualValue: montant);
            if (montant <= 0)
                throw new ArgumentOutOfRangeException(message: $"montant ('{montant}') must be a non-negative and non-zero value.", paramName: "montant", actualValue: montant);

            return
                !EstGelé ? true : false;
        }
        public bool PeutRetirer(decimal? montant = null)
        {
            if (montant == null) montant = Solde;

            if ((((montant % 1) * 100) % 1) != 0)
                throw new ArgumentOutOfRangeException(message: $"montant ('{montant}') must be equal to '1.00'.", paramName: "montant", actualValue: montant);
            if (montant <= 0)
                throw new ArgumentOutOfRangeException(message: $"montant ('{montant}') must be a non-negative and non-zero value.", paramName: "montant", actualValue: montant);

            if (montant <= Solde && !EstGelé) return true;
            else return false;
        }

        #endregion
        #region ----- méthodes modifiantes -----

        public void Déposer(decimal montant)
        {
            if (PeutDéposer(montant) == false) //check comportement (si arg except dans PeutDéposer transpose)
                throw new InvalidOperationException(message: "Déposer");

            this._solde += montant;
        }
        public void Retirer(decimal montant)
        {
            if (PeutRetirer(montant) == false) //idem
                throw new InvalidOperationException(message: "Retirer");

            this._solde -= montant;
        }
        public decimal Vider()
        {
            if (Solde == 0 || EstGelé)
                throw new InvalidOperationException(message: "Vider");

            decimal contenuCompte = Solde;
            this._solde = 0;
            return contenuCompte;
        }
        public void Geler()
        {
            if (EstGelé)
                throw new InvalidOperationException(message: "Geler");

            this._estGele = true;
            this._statut = StatutCompte.Gelé;
        }
        public void Dégeler() 
        {
            if (!EstGelé)
                throw new InvalidOperationException(message: "Dégeler");

            this._estGele = false;
            this._statut = StatutCompte.Ok;
        }

        #endregion
    }
}
