using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace apCaminhosMarte
{
    class GrafoRecursivo
    {
        int[,] matrizCidades;

        const int tamanhoOrigem = 3;
        const int tamanhoDestino = 3;
        const int tamanhoDistancia = 5;
        //const int tamanhoTempo = 4;
        //const int tamanhoPreco = 5;

        const int inicioOrigem = 0;
        const int inicioDestino = inicioOrigem + tamanhoOrigem;
        const int inicioDistancia = inicioDestino + tamanhoDestino;
        //const int inicioTempo = inicioDistancia + tamanhoDistancia;
        //const int inicioPreco = inicioTempo + tamanhoTempo;

        public GrafoRecursivo(string nomeArq, int qtasCidades)
        {
            matrizCidades = new int[qtasCidades, qtasCidades];

            StreamReader arq = new StreamReader(nomeArq);
            while (!arq.EndOfStream)
            {
                string linha = arq.ReadLine();
                int origem = int.Parse(linha.Substring(inicioOrigem, tamanhoOrigem).Trim());
                int destino = int.Parse(linha.Substring(inicioDestino, tamanhoDestino));
                int distancia = int.Parse(linha.Substring(inicioDistancia, tamanhoDistancia).Trim());

                matrizCidades[origem, destino] = distancia;
            }
        }
    }
}
