using BanqueLib;

namespace WinFormsSimulerCompte
{
    public partial class Form1 : Form
    {
        private readonly Compte _compte;

        public Form1(Compte compte)
        {
            InitializeComponent();

            _compte = compte;

            Répercuter();
        }

        private void Répercuter() 
        {
            Text += _compte.Détenteur;
            TextBoxNumero.Text = _compte.Numéro.ToString();
            TextBoxDetenteur.Text = _compte.Détenteur;
            TextBoxSolde.Text = $"{_compte.Solde:C2}";
            CheckBoxGele.Checked = _compte.EstGelé;
        }

        private void CheckBoxGele_Clicked(object sender, EventArgs e)
        {
            if (CheckBoxGele.Checked == true)
            {
                _compte.Geler();
                TextBoxLog.AppendText("[RL] " + "Compte Gelé." + Environment.NewLine);
            }
            else 
            {
                _compte.Dégeler();
                TextBoxLog.AppendText("[RL] " + "Compte Dégelé." + Environment.NewLine);
            }
        }
    }
}
