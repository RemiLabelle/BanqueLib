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

            R�percuter();
        }

        private void R�percuter() 
        {
            Text += _compte.D�tenteur;
            TextBoxNumero.Text = _compte.Num�ro.ToString();
            TextBoxDetenteur.Text = _compte.D�tenteur;
            TextBoxSolde.Text = $"{_compte.Solde:C2}";
            CheckBoxGele.Checked = _compte.EstGel�;
        }

        private void CheckBoxGele_Clicked(object sender, EventArgs e)
        {
            if (CheckBoxGele.Checked == true)
            {
                _compte.Geler();
                TextBoxLog.AppendText("[RL] " + "Compte Gel�." + Environment.NewLine);
            }
            else 
            {
                _compte.D�geler();
                TextBoxLog.AppendText("[RL] " + "Compte D�gel�." + Environment.NewLine);
            }
        }
    }
}
