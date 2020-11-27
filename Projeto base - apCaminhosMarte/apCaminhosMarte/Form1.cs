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

            //deixa os ListBoxes com uma opção já pré-escolhida
            lsbPeso.SetSelected(0, true);
            lsbMetodos.SetSelected(0, true);
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
                    //Opcao de peso
                    int peso = int.Parse(lsbPeso.SelectedItem.ToString().Trim().Substring(0, 2));
                    //Opcao de metodos
                    int met = int.Parse(lsbMetodos.SelectedItem.ToString().Trim().Substring(0, 2));

                    switch (met)
                    {
                        case 1:
                            //Tenta achar os caminhos entre origem e destino (recursao)
                            grafo.AcharCaminhosRec(origem, destino, peso, dgvCaminhos, dgvMelhorCaminho, cidades, g);
                            break;
                        case 2:
                            //Tenta achar os caminhos entre origem e destino (Algoritimo de Dijkstra)
                            grafo.AcharCaminhoDijkstra(origem, destino, peso, dgvMelhorCaminho, dgvCaminhos, cidades, g);
                            break;
                        case 3:
                            //Tenta achar os caminhos entre origem e destino (pilhas)
                            grafo.AcharCaminhosPilhas(origem, destino, peso, dgvCaminhos, dgvMelhorCaminho, cidades, g);
                            break;
                    }

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

        private void dgvCaminhos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //Permite apenas que selecione-se uma linha inteira do dgv
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void dgvCaminhos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Desenha o caminho selecionado do dgv
            //Caso tenha celulas selecionadas
            if (dgvCaminhos.SelectedCells.Count > 0)
            {
                //Limpa a tela
                pbMapa.Image = img;
                pbMapa.Refresh();

                //Elemento Graphics para desenhar na tela
                Graphics g = pbMapa.CreateGraphics();
              
                //Percorre o caminho no dgv
                for (int i = 0; i < dgvCaminhos.SelectedCells.Count; i++)
                {
                    //Verifica se o valor da célula não é vazio
                    if (dgvCaminhos.SelectedCells[i].Value.ToString().Trim() != "")
                    {
                        //Divide a string pela posicao da virgula que separa os indices das cidades do movimento
                        string[] cellString = dgvCaminhos.SelectedCells[i].Value.ToString().Split(',');
                        //Utiliza dos indices separados para "pegar" as cidades respectivas
                        Cidade cid0 = cidades.getCidadeById(int.Parse(cellString[0]));
                        Cidade cid1 = cidades.getCidadeById(int.Parse(cellString[1]));
                        //Usa das coordenadas das cidades para desenhar a linha
                        g.DrawLine(new Pen(Color.Red), 5 + cid0.X / 4, 5 + cid0.Y / 4, 5 + cid1.X / 4, 5 + cid1.Y / 4);
                        //Repinta as cidades
                        cidades.PercorrerPintar(g);
                    }
                }
            }
        }
    }
}
