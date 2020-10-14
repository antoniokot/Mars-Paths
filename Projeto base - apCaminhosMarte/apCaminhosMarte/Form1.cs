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
        GrafoCidades grafo;

        public Form1()
        {
            InitializeComponent();

            cidades = new ArvoreCidades("../../../CidadesMarte.txt");
            grafo = new GrafoCidades("../../../../CaminhosEntreCidadesMarte.txt", cidades.QtasCidades);
        }

        private void TxtCaminhos_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dgvCaminhos.Rows.Clear();
            dgvCaminhos.Refresh();

            dgvMelhorCaminho.Rows.Clear();
            dgvMelhorCaminho.Refresh();

            int origem = int.Parse(lsbOrigem.SelectedItem.ToString().Trim().Substring(0,1));
            int destino = int.Parse(lsbDestino.SelectedItem.ToString().Trim().Substring(0,1));
            if (origem != destino)
                grafo.AcharCaminhos(origem, destino, dgvCaminhos, dgvMelhorCaminho, cidades);
            else
                MessageBox.Show("Selecione origem e destino distintos");
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
