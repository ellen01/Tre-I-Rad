using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tre_i_rad
{
    public partial class Form1 : Form
    {
        bool turn = true; //true = X tur, false = O tur
        int turn_count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void OmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Välj en ruta och klicka på den för att markera ditt X eller O. Den första som får tre i rad vinner.");
        } // Visar spelreglerna

        private void StängToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } // Stänger spelet

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender; //Skriver ut X och O vid knapptryck
            if (turn)
                b.Text = "X";
            else b.Text = "O";

                    turn = !turn;
            b.Enabled = false; //Gör det omöjligt att ändra X eller O värdet
            turn_count++;
            checkForWinner();
        }

        private void checkForWinner () //Bestämmer vem som vinner
        {
            
                bool det_finns_en_vinnare = false;

            //Horisontellt
                if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                    det_finns_en_vinnare = true;
                else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                    det_finns_en_vinnare = true;
                else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                    det_finns_en_vinnare = true;

               //Vertikalt
                else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                det_finns_en_vinnare = true;
                else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                det_finns_en_vinnare = true;
                else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                det_finns_en_vinnare = true;

               //Diagonalt
                else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                det_finns_en_vinnare = true;
                else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                det_finns_en_vinnare = true;

            if (det_finns_en_vinnare) //Skriver ut vem som vinner
            {
                disableButtons();
                String vinnare = "";
                if (turn)
                    vinnare = "O";
                else
                    vinnare = "X";
                MessageBox.Show(vinnare + " vinner!");
            }
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("Oavgjort!");
            }
     
        } 

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void NyttSpelToolStripMenuItem_Click(object sender, EventArgs e) //Startar nytt spel
        {
            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch
            {

            }
        }
    }
}
