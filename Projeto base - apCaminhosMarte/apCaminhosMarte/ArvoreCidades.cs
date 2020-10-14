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
    class ArvoreCidades : ArvoreDeBusca<Cidade>
    {
        int qtasCidades;

        const int tamanhoId = 3;
        const int tamanhoNome = 15;
        const int tamanhoX = 5;
        const int tamanhoY = 5;

        const int inicioId = 0;
        const int inicioNome = inicioId + tamanhoId;
        const int inicioX = inicioNome + tamanhoNome;
        const int inicioY = inicioX + tamanhoX;

        public ArvoreCidades(string nomeArq)
        {
            StreamReader arq = new StreamReader(nomeArq);
            qtasCidades = 0;
            while (!arq.EndOfStream)
            {
                string linha = arq.ReadLine();
                int id = int.Parse(linha.Substring(inicioId, tamanhoId).Trim());
                string nome = linha.Substring(inicioNome, tamanhoNome);
                int x = int.Parse(linha.Substring(inicioX, tamanhoX).Trim());
                int y = int.Parse(linha.Substring(inicioY, tamanhoY).Trim());
                Cidade novaCidade = new Cidade(id, x, y, nome);
                Incluir(novaCidade);

                qtasCidades++;
            }

            arq.Close();
        }

        public int QtasCidades 
        { 
            get => qtasCidades;
        }

        public void PintarCidades(NoArvore<Cidade> at, Graphics g)
        {
            if (at != null)
            {
                g.FillEllipse(new SolidBrush(Color.Black), at.Info.X / 4, at.Info.Y / 4, 10, 10);
                g.DrawString(at.Info.NomeCidade, new Font("Courier New", 9, FontStyle.Bold), Brushes.Black, new PointF(-26 + at.Info.X / 4, 7 + at.Info.Y / 4));
                PintarCidades(at.Esq, g);
                PintarCidades(at.Dir, g);
            }
        }

        public void PercorrerPintar(Graphics g)
        {
            PintarCidades(Raiz, g);
        }

        public void DesenharArvore(bool primeiraVez, NoArvore<Cidade> raiz, int x, int y, double angulo, double incremento, double comprimento, Graphics g)
        {
            int xf, yf;
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
