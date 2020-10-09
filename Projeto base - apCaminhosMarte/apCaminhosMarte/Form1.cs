using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apCaminhosMarte
{
    public partial class Form1 : Form
    {
        ArvoreCidades cidades;

        public Form1()
        {
            InitializeComponent();

            cidades = new ArvoreCidades("../../../CidadesMarte.txt");
        }

        private void TxtCaminhos_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buscar caminhos entre cidades selecionadas");
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            cidades.PercorrerPintar(e.Graphics);
        }

        private void tpArvore_Paint(object sender, PaintEventArgs e)
        {
            cidades.DesenharArvore(true, cidades.Raiz, 569, 5, Math.PI/2, 1.2, 250, e.Graphics);
        }
    }
}
