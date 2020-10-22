using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace telekocsiform
{
    public partial class frmFo : Form
    {
        private List<Auto> autok = new List<Auto>();
        private List<Igeny> igeny = new List<Igeny>();
        public frmFo()
        {
            InitializeComponent();
            lbKimenet.Items.Clear();
        }

        private void btnBeolvasas_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader be = new StreamReader("autok.csv");
                be.ReadLine();
                while (!be.EndOfStream)
                {
                    autok.Add(new Auto(be.ReadLine()));
                }
                be.Close();


                Console.WriteLine($"2. Feladat\n\t{autok.Count} autós hirdet fuvart");

                StreamReader be2 = new StreamReader("igenyek.csv");
                be2.ReadLine();
                while (!be2.EndOfStream)
                {
                    igeny.Add(new Igeny(be2.ReadLine()));
                }
                be2.Close();
                btn_Masodik.Enabled = true;
                btnBeolvasas.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Masodik_Click(object sender, EventArgs e)
        {
            lbKimenet.Items.Add("2.Feladat");
            lbKimenet.Items.Add($"    {autok.Count} autós hirdet fuvart");
            btn_Harmadik.Enabled = true;
            
        }
    }
}
