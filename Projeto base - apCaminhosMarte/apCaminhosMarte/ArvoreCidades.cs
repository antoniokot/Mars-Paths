using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Arvore;
using System.Windows.Forms;
using System.Drawing;

namespace apCaminhosMarte
{
    //Antônio Hideto Borges Kotsubo - 19162
    //Matheus Seiji Luna Noda       - 19190
    class ArvoreCidades : ArvoreDeBusca<Cidade>
    {
        //Quantidade de cidades
        int qtasCidades;

        //Tamanho dos dados a serem lidos do arquivo
        const int tamanhoId = 3;
        const int tamanhoNome = 15;
        const int tamanhoX = 5;
        const int tamanhoY = 5;

        //Inicio dos dados no arquivo
        const int inicioId = 0;
        const int inicioNome = inicioId + tamanhoId;
        const int inicioX = inicioNome + tamanhoNome;
        const int inicioY = inicioX + tamanhoX;

        //Construtor recebe o nome do arquivo a ser lido
        public ArvoreCidades(string nomeArq)
        {
            //Le o arquivo
            StreamReader arq = new StreamReader(nomeArq);
            qtasCidades = 0;
            //A cada linha do arquivo ate o final do mesmo
            while (!arq.EndOfStream)
            {
                string linha = arq.ReadLine();
                //Recebe os valore do arquivo com as coordenadas de inicio e tamanho
                int id = int.Parse(linha.Substring(inicioId, tamanhoId).Trim());
                string nome = linha.Substring(inicioNome, tamanhoNome);
                int x = int.Parse(linha.Substring(inicioX, tamanhoX).Trim());
                int y = int.Parse(linha.Substring(inicioY, tamanhoY).Trim());
                //Cria uma nova cidade
                Cidade novaCidade = new Cidade(id, x, y, nome);
                //Inclui a cidade
                Incluir(novaCidade);

                //Incrementa contagem de cidades
                qtasCidades++;
            }
            
            //Fecha o arquivo
            arq.Close();
        }

        //Propriedade de qtasCidades
        public int QtasCidades 
        { 
            get => qtasCidades;
        }

        //Metodo para pegar uma cidade via seu id
        public Cidade getCidadeById(int cod)
        {
            //Percorre a arvore partido de raiz, ate encontrar (ou nao) o cod procurada
            NoArvore<Cidade> now = Raiz;
            while(now != null)
            {
                if(now.Info.CodCidade == cod)
                    return now.Info;
                else if(now.Info.CodCidade < cod)
                    now = now.Dir;
                else
                    now = now.Esq;
            }

            //Em nossa chamada de método em GrafoCidades, sabemos que nunca cai aqui
            return null;
        }

        //Pinta as cidades no mapa
        private void PintarCidades(NoArvore<Cidade> at, Graphics g)
        {
            //Enquanto at (atual) nao for null
            if (at != null)
            {   
                //Desenha um circulo nas coordenadas da cidade em at.Info recebida
                g.FillEllipse(new SolidBrush(Color.Black), at.Info.X / 4, at.Info.Y / 4, 10, 10);
                //Desenha o nome de at.Info
                g.DrawString(at.Info.NomeCidade, new Font("Courier New", 9, FontStyle.Bold), Brushes.Black, new PointF(-26 + at.Info.X / 4, 7 + at.Info.Y / 4));
                //Chamada recursiva do metodo para percorre a arvore inteira
                PintarCidades(at.Esq, g);
                PintarCidades(at.Dir, g);
            }
        }

        //Meteod publico de pintar as cidades no mapa
        public void PercorrerPintar(Graphics g)
        {
            PintarCidades(Raiz, g);
        }

        //Desenha a arvore na TabPage
        public void DesenharArvore(bool primeiraVez, NoArvore<Cidade> raiz, int x, int y, double angulo, double incremento, double comprimento, Graphics g)
        {
            //Cordenadas xf, yf
            int xf, yf;
            //Enquanto "raiz" nao for null
            if (raiz != null)
            {
                Pen caneta = new Pen(Color.Green);
                xf = (int)Math.Round(x + Math.Cos(angulo) * comprimento);
                yf = (int)Math.Round(y + Math.Sin(angulo) * comprimento);
                if (primeiraVez)
                {
                    yf = 25;
                    xf = x;
                }
                g.DrawLine(caneta, x, y, xf, yf);
                DesenharArvore(false, raiz.Esq, xf, yf, Math.PI / 2 + incremento, incremento * 0.50, comprimento * 0.8, g);
                DesenharArvore(false, raiz.Dir, xf, yf, Math.PI / 2 - incremento, incremento * 0.50, comprimento * 0.8, g);
                SolidBrush preenchimento = new SolidBrush(Color.Magenta);
                g.FillEllipse(preenchimento, xf - 25, yf - 15, 45, 25);
                g.DrawString(Convert.ToString(raiz.Info.CodCidade) , new Font("Courier New", 11), new SolidBrush(Color.Black), xf - 12, yf - 7);
                g.DrawString(Convert.ToString(raiz.Info.NomeCidade) , new Font("Courier New", 7), new SolidBrush(Color.Black), xf - 22, yf + 20);
            }
        }
    }
}
