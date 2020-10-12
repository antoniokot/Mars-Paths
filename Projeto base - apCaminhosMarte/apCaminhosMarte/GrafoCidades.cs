﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace apCaminhosMarte
{
    class GrafoCidades
    {
        int[,] matrizCidades;
        int qtsCidades;

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

        public GrafoCidades(string nomeArq, int qtasCidades)
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

        public int QtsCidades 
        {  
            get => qtsCidades; 
            set => qtsCidades = value; 
        }

        public int[,] MatrizCidades 
        {   
            get => matrizCidades; 
            set => matrizCidades = value; 
        }

        //public void Exibir(DataGridView dgv)
        //{
        //    dgv.RowCount = QtsCidades;
        //    dgv.ColumnCount = QtsCidades;

        //    for(int i = 0; i < QtsCidades; i++)
        //    {
        //        for(int j = 0; j < QtsCidades; j++)
        //        {
        //            dgv[j, i].Value = matrizCidades[i, j];
        //        }
        //    }

        //    for (int j = 0; j < QtsCidades; j++)
        //    {
        //        dgv.Columns[j].HeaderText = (j).ToString();
        //        dgv.Columns[j].Width = 15;
        //    }

        //    for (int i = 0; i < QtsCidades; i++)
        //        dgv.Rows[i].HeaderCell.Value = (i).ToString();
        //}

        public void AcharCaminhos(int origem, int destino, DataGridView dgvCaminhos, DataGridView dgvMelhor, ArvoreCidades cidades)
        {
            int prox = 1;
            int atual = 0;

            PilhaLista<Movimento> movimentos = new PilhaLista<Movimento>();
            Boolean[] visitadas = new Boolean[QtsCidades];

            ExisteCaminho(origem, destino, ref atual, ref prox, dgvCaminhos, dgvMelhor, cidades, ref movimentos, ref visitadas);
        }

        private Boolean ExisteCaminho(int origem, int destino, ref int atual, ref int prox, DataGridView dgvCaminhos, DataGridView dgvMelhor, ArvoreCidades cidades, ref PilhaLista<Movimento> mov, ref Boolean[] visit)
        { 
            if(prox == destino && matrizCidades[atual, prox] != 0)
            {
                int dist = matrizCidades[atual, prox];
                mov.Empilhar(new Movimento(atual, prox, dist));

                return true;
            }

            if(matrizCidades[atual, prox] == 0)
            {
                prox++;
                ExisteCaminho(origem, destino, ref atual, ref prox, dgvCaminhos, dgvMelhor, cidades, ref mov, ref visit);
            }

            if(matrizCidades[atual, prox] != 0 && !visit[prox])
            {
                visit[prox] = true;

                atual = prox;
                prox = 0;

                ExisteCaminho(origem, destino, ref atual, ref prox, dgvCaminhos, dgvMelhor, cidades, ref mov, ref visit);
            }

            return false;
        }
    }
}