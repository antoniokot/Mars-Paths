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
    class ArvoreCidades
    {
        ArvoreDeBusca<Cidade> arvore;
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
            QtasCidades = 0;
            while(!arq.EndOfStream)
            {
                string linha = arq.ReadLine();
                int id   = int.Parse(linha.Substring(inicioId, tamanhoId).Trim());
                string nome = linha.Substring(inicioNome, tamanhoNome);
                int x    = int.Parse(linha.Substring(inicioX, tamanhoX).Trim());
                int y    = int.Parse(linha.Substring(inicioY, tamanhoY).Trim());
                Cidade novaCidade = new Cidade(id, x, y, nome);
                arvore.Incluir(novaCidade);
                QtasCidades++;
            }

            arq.Close();
        }

        public int QtasCidades { get => qtasCidades; set => qtasCidades = value; }
    }
}
