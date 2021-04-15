using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwissTransport.Core;
using SwissTransport.Models;

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
            ITransport transport = new Transport();     //Transport API wird verwendet
            SwissTransport.Models.Connection temp2 = new SwissTransport.Models.Connection();

            if (comboBox1.Text == "" && comboBox2.Text == "")
            {
                MessageBox.Show("Geben Sie noch die Start- und Endstation ein!");
                return;
            }

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Geben Sie noch die Startstation ein!");
                return;
            }

            if (comboBox2.Text == "")
            {
                MessageBox.Show("Geben Sie noch die Endstation ein!");
                return;
            }

            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("Nicht gleiche Stationsnamen eingeben!");
                return;
            }

            dataGridView1.Rows.Clear();
            foreach (SwissTransport.Models.Connection temp in transport.GetConnections(comboBox1.Text, comboBox2.Text).ConnectionList)
            {
                dataGridView1.Rows.Add(Verbindung(temp));
            }
        }

        private string[] Verbindung(SwissTransport.Models.Connection temp)
        {
            string[] daten =
            {
                    temp.From.Departure.ToString().Substring(0, 10),     //Datum
                    temp.From.Departure.ToString().Substring(11, 5),     //Zeit
                    temp.To.Arrival.ToString().Substring(11, 5),         //Zeit
                    temp.From.Platform
            };
            return daten;
        }

        private void Loeschen_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();        //entfernt die vorgeschlagenen Stationen
            comboBox1.ResetText();          //entfernt den eingegebenen Text
            comboBox2.Items.Clear();
            comboBox2.ResetText();
            dataGridView1.Rows.Clear();     //entfernt die Verbindungen
        }

        private void VorschlagLeer(ComboBox transport)
        {
            transport.Items.Clear();
            transport.SelectionStart = transport.Text.Length;
            transport.SelectionLength = 0;
        }

        private void VorschlagVoll(ComboBox transport)
        {
            try
            {
                ITransport temp = new Transport();
                transport.DroppedDown = true;
                foreach (SwissTransport.Models.Station station in temp.GetStations(transport.Text).StationList)
                {
                    if (station.Name != null)
                        transport.Items.Add(station.Name);
                }
            }
            catch { }
        }

        private void Startstation_TextUpdate(object sender, EventArgs e)
        {
            VorschlagLeer(comboBox1);
            VorschlagVoll(comboBox1);
        }

        private void Endstation_TextUpdate(object sender, EventArgs e)
        {
            VorschlagLeer(comboBox2);
            VorschlagVoll(comboBox2);
        }
    }
}
