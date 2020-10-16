using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.CodeDom;
using System.Drawing;

namespace apCaminhosMarte
{
    //Antônio Hideto Borges Kotsubo - 19162
    //Matheus Seiji Luna Noda       - 19190
    class GrafoCidades
    {
        //Matriz de proximidade
        int[,] matrizCidades;
        //Quantidade de cidades na matriz/ no mapa
        int qtsCidades;
        //Armazena a distancia do menor caminho encontrado ate o momento
        int menorDist;

        //Tamanhos das strings dos dados
        const int tamanhoOrigem = 3;
        const int tamanhoDestino = 3;
        const int tamanhoDistancia = 5;
            //Dados nao usados
            //const int tamanhoTempo = 4;
            //const int tamanhoPreco = 5;

        //Endereco de inicio dos dados
        const int inicioOrigem = 0;
        const int inicioDestino = inicioOrigem + tamanhoOrigem;
        const int inicioDistancia = inicioDestino + tamanhoDestino;
            //Dados nao usados
            //const int inicioTempo = inicioDistancia + tamanhoDistancia;
            //const int inicioPreco = inicioTempo + tamanhoTempo;

        //Construtor da classe recebe o nome do arquivo a ser lido e quantas cidades devem ser adicionadas na matriz
        public GrafoCidades(string nomeArq, int qtasCidades)
        {
            QtsCidades = qtasCidades;
            matrizCidades = new int[qtasCidades, qtasCidades];
            menorDist = 0;
            //Zera a matriz inteira
            for (int i = 0; i < qtasCidades; i++)
            {
                for (int j = 0; j < qtasCidades; j++)
                {
                    matrizCidades[i, j] = 0;
                }
            }

            //Ler o arquivo linha a linha, atribuindo os valores as variaveis com as coordenadas establecidas anteriormente (inicio e tamanho)
            StreamReader arq = new StreamReader(nomeArq);
            while (!arq.EndOfStream)
            {
                string linha = arq.ReadLine();
                int origem = int.Parse(linha.Substring(inicioOrigem, tamanhoOrigem).Trim());
                int destino = int.Parse(linha.Substring(inicioDestino, tamanhoDestino));
                int distancia = int.Parse(linha.Substring(inicioDistancia, tamanhoDistancia).Trim());

                //Atribui na matriz os valores da distancia de cada caminho entre as cidades
                matrizCidades[origem, destino] = distancia;

                //Caso os caminhos fossem de ida E VOLTA, deveriamos adicionar esta linha abaixo para espelhar a matriz
                /*matrizCidades[destino, origem] = distancia;*/
            }
            arq.Close();
        }

        //Propriedades
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

        //Metodo publico para achar caminhos, recebe origem e destino, alem das coisas nescessarias para a exibicao dos resultados:
        //      DataGridView  dgvCaminhos: Exibir neste dgv todos os caminhos;
        //      DataGridView  dgvMelhor  : Exibir aqui o melhor caminho;
        //      ArvoreCidades cidades    : Nescessario para pegar as coordenadas das cidades no mapa, para desenhar as rotas entre elas
        //      Graphics      g          : Graphics que virá do PictureBox para que possamos desenhar no mesmo
        public void AcharCaminhos(int origem, int destino, DataGridView dgvCaminhos, DataGridView dgvMelhor, ArvoreCidades cidades, Graphics g)
        {
            //Indices da matriz
            int prox = 0;
            int atual = origem;
            menorDist = 0;

            //Pilha para armazenar o caminho que esta sendo testado no momento
            PilhaLista<Movimento> movimentos = new PilhaLista<Movimento>();

            //Array de Boolean para indicar se já visitamos ou nao certa cidade
            Boolean[] visitadas = new Boolean[QtsCidades];
            for(int i = 0; i < QtsCidades; i++)
                visitadas[i] = false;
            //Sett visitadas[] da cidade origem para true, para que nao voltemos para ela
            visitadas[origem] = true;

            //Primeira chamada do metodo recusivo para achar todos os caminhos
            AcharCaminhos(origem, destino, ref atual, ref prox, dgvCaminhos, dgvMelhor, ref movimentos, ref visitadas, cidades, g);
        }

        //Metod private para achar caminhos, recebe os mesmos parametros que AcharCaminhos(), mas junto com atual, prox, movimentos, visitadas  
        private void AcharCaminhos(int origem, int destino, ref int atual, ref int prox, DataGridView dgvCaminhos, DataGridView dgvMelhor, ref PilhaLista<Movimento> mov, ref Boolean[] visit, ArvoreCidades cidades, Graphics g)
        {
            //Caso o indice do proximo(cidade alvo desta iteracao do metodo) seja maior do que o limite de cidades, desempilha o ultimo movimento pois se acabarao os caminhos possiveis 
            if(prox < visit.Length)
            {
                //Caso prox seja o indice do destino desejado E a distacia entre atual(indice da cidade em que estamos) e prox nao seja 0(existe caminho), encontrou um caminho
                if(prox == destino && matrizCidades[atual, prox] != 0)
                {
                    //Distancia recebe a distancia indicada na matriz
                    int dist = matrizCidades[atual, prox];
                    //Empilha o movimento
                    mov.Empilhar(new Movimento(atual, prox, dist));

                    //Exibi o caminho encontrado
                    ExibirCaminhos(dgvCaminhos, dgvMelhor, mov, cidades, g);

                    //Prox avanca
                    prox++;
                    //Desempilha o ultimo movimento para tentar achar outros possiveis caminhos
                    mov.Desempilhar();
                    //Entra na nova interacao do metodo com prox já atualizado
                    AcharCaminhos(origem, destino, ref atual, ref prox, dgvCaminhos, dgvMelhor, ref mov, ref visit, cidades, g);
                }
                //Else, se a distancia entra ambos atual e prox for 0, nao há caminhos entre as cidades indicadas, OU se a cidade já tiver sido visitada, nao ha caminho, prox vanca +1
                else if(matrizCidades[atual, prox] == 0 || visit[prox])
                {
                    //prox avanca
                    prox++;
                    //Entra na nova iteracao do metodo com prox já atualizado
                    AcharCaminhos(origem, destino, ref atual, ref prox, dgvCaminhos, dgvMelhor, ref mov, ref visit, cidades, g);
                }
                //Senao, vamos entrar em uma nova cidade para prosseguir tentando achar algum caminhos
                else
                {
                    //Set o status de visitada ou nao da cidade atual para true
                    visit[atual] = true;
                    //Distacia recebe a distancia indicada pela matriz
                    int dist = matrizCidades[atual, prox];
                    //Empilha o movimento
                    mov.Empilhar(new Movimento(atual, prox, dist));

                    //Atual avanca para o indice de prox
                    atual = prox;   
                    //prox volta a valer 0
                    prox = 0;

                    //Entra na nova interacao do metodo com atual e prox avancados
                    AcharCaminhos(origem, destino, ref atual, ref prox, dgvCaminhos, dgvMelhor, ref mov, ref visit, cidades, g);
                }  
            }
            else if(!mov.EstaVazia)
            {
                //Desempilha, caso a pilha tenha algo dentro dela, o ultimo movimento da pilha
                var ultimoMov = mov.Desempilhar();
                //Atribui a origem do ultimo movimento para atual
                atual = ultimoMov.Origem;
                //E prox recebe o destino do movimento incrementado de 1
                prox = ultimoMov.Destino + 1;
                //Entra em uma nova iteracao do metodo com os valores atualizados
                AcharCaminhos(origem, destino, ref atual, ref prox, dgvCaminhos, dgvMelhor, ref mov, ref visit, cidades, g);
            }
        }
        
        /*Metodo de exibir os caminhos encontrados recebendo, alem dos parametros nescessarios para realizar a exibicao, a 
        * PilhaLista<Movimento> com todos os movimentos do caminho em questao*/
        private void ExibirCaminhos(DataGridView dgv, DataGridView dgvMenor, PilhaLista<Movimento> mov, ArvoreCidades cidades, Graphics g)
        {
            //Aumenta, ou nao, o tamanho do dgv geral de todos os caminhos para comportar o caminho recebido
            if(dgv.ColumnCount < mov.Tamanho)
                dgv.ColumnCount = mov.Tamanho;

            //Pilha auxiliar para a leitura da pilha original, sem destrui-la
            PilhaLista<Movimento> aux = new PilhaLista<Movimento>();
            //soma recebera a soma de todas as distancias em cada movimento da pilha
            int soma = 0;
            //Enquanto a pilha nao estiver vazia
            while (!mov.EstaVazia)
            {
                //Movimento atual recebe o movimento desempilhado
                var atual = mov.Desempilhar();
                //Cidade 0 do movimento
                Cidade cidO = cidades.getCidadeById(atual.Origem);
                //Cidade 1 do movimento
                Cidade cid1 = cidades.getCidadeById(atual.Destino);

                //Desenha a linha entre as duas cidades no mapa
                g.DrawLine(new Pen(Color.Red), 5 + cidO.X/4, 5 + cidO.Y/4, 5 + cid1.X/4, 5 + cid1.Y/4);
                //Metodo que pinta as cidades no mapa(redesenha elas por cima da linha desenhada)
                cidades.PercorrerPintar(g);
                //Incremeta a soma a cada distancia lida de movimento
                soma += atual.Distancia;
                //Empilha em auxililar o movimento
                aux.Empilhar(atual);
            }
            //Exibir, agora em ordem certa(mov vem em ordem contraria), a pilha de movimentos
            aux.Exibir(dgv);

            //Caso a soma seja menor do que a menor distancia já encontrada ate entao, ou se nenhuma tiver sido encontrada ate o momento, achamos um novo menor caminho
            if(soma < menorDist || menorDist == 0)
            {
                //Limpa o dgb de menor caminho
                dgvMenor.Rows.Clear();
                dgvMenor.Refresh();

                //Guarda o valor do novo menor caminho
                menorDist = soma;
                //Metodo exibir da Pilha
                aux.Exibir(dgvMenor);
            }
            
            //Desenverte a pilha auxiliar de volta para a pilha original, preservando-a
            while (!aux.EstaVazia)
            {
                mov.Empilhar(aux.Desempilhar());
            }
        }
    }
}
