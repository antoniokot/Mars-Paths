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
    //Antônio Hideto Borges Kotsubo - 19162
    //Matheus Seiji Luna Noda       - 19190
    public partial class Form1 : Form
    {
        //Arvore de cidades
        ArvoreCidades cidades;
        //Grafo para encontrar os caminhos
        GrafoCidades grafo;
        //De maneira a limpar e reescrever o mapa, apagando caminhos entre cidades diferentes, precisamos salvar a imagem original, para reescreve-la depois,
        // e apagar a busca anterior
        Image img;

        public Form1()
        {
            InitializeComponent();

            //cidades le o arquivo de cidades 
            cidades = new ArvoreCidades("../../../CidadesMarte.txt");
            //grafo le o arquivo de caminhos
            grafo = new GrafoCidades("../../../../CaminhosEntreCidadesMarte.txt", cidades.QtasCidades);
            //Recebe a imagem antes de algo ser desenhado nela
            img = pbMapa.Image;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            //Limpa o dgv de caminhos
            dgvCaminhos.Rows.Clear();
            dgvCaminhos.Refresh();

            //Limpa o dgb de Melhor caminho
            dgvMelhorCaminho.Rows.Clear();
            dgvMelhorCaminho.Refresh();

            //Limpa o mapa
            pbMapa.Image = img;
            pbMapa.Refresh();

            //Caso nada tenha sido selecionado em algum dos ListBox
            if (lsbDestino.SelectedIndex == -1 || lsbOrigem.SelectedIndex == -1)
                MessageBox.Show("Selecione ambos os campos de origem e destino");
            else 
            {
                //Valor de lsbOrigem
                int origem = int.Parse(lsbOrigem.SelectedItem.ToString().Trim().Substring(0, 2));
                //Valor de lsbDestino
                int destino = int.Parse(lsbDestino.SelectedItem.ToString().Trim().Substring(0, 2));
                //Caso sejam selecionados cidades diferentes
                if (origem != destino)
                {
                    //Graphics de pbMapa
                    Graphics g = pbMapa.CreateGraphics();
                    //Tenta achar os caminhos entre origem e destino
                    grafo.AcharCaminhos(origem, destino, dgvCaminhos, dgvMelhorCaminho, cidades, g);

                    //Caso nenhum caminho seja encontrado
                    if (dgvMelhorCaminho.RowCount == 0)
                        MessageBox.Show("Nenhum caminho encontrado");
                }
                else
                    MessageBox.Show("Selecione origem e destino distintos");     
            }
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            //Pinta todas as cidades no mapa
            cidades.PercorrerPintar(e.Graphics);
        }

        private void tpArvore_Paint(object sender, PaintEventArgs e)
        {
            //Desenha a arvore na TabPage
            cidades.DesenharArvore(true, cidades.Raiz, 569, 5, Math.PI/2, 1.2, 250, e.Graphics);
        }
    }
}
