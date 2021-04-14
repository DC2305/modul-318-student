using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeineTransportApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Hilfe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nachdem Sie eine Start- und Endstation eingegeben haben, " +
                "können Sie auf 'Suchen' drücken, um die nächsten Verbindungen zu sehen oder auf 'Löschen'," +
                "um die von Ihnen eingegebenen Stationen aus dem Textfeld zu löschen.\n" +
                "Wenn Sie 'Abfahrtstafel' auswählen, zeigt es Ihnen alle Verbindungen, die von der eingegebenen " +
                "Station weg gehen.", "Hilfe", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Suchen_Click(object sender, EventArgs e)
        {

        }

        private void Loeschen_Click(object sender, EventArgs e)
        {

        }
    }
}
