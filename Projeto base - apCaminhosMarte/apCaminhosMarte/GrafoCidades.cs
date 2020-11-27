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
        Peso[,] matrizCidades;
        //Quantidade de cidades na matriz/ no mapa
        int qtsCidades;
        //Armazena a distancia do menor caminho encontrado ate o momento
        int menorDist;

        //Tamanhos das strings dos dados
        const int tamanhoOrigem = 3;
        const int tamanhoDestino = 3;
        const int tamanhoDistancia = 5;
        const int tamanhoTempo = 4;
        const int tamanhoPreco = 5;

        //Endereco de inicio dos dados
        const int inicioOrigem = 0;
        const int inicioDestino = inicioOrigem + tamanhoOrigem;
        const int inicioDistancia = inicioDestino + tamanhoDestino;
        const int inicioTempo = inicioDistancia + tamanhoDistancia;
        const int inicioPreco = inicioTempo + tamanhoTempo;

        //================================
        //      DIJKSTRA!!!!!!!!!!!!!!!!!!!!      
        //================================
        Vertice[] vertices;
        PesoOriginal[] percurso;
        int infinity = 1000000;
        int verticeAtual; 
        int doInicioAteAtual; 
        int nTree;


        //Construtor da classe recebe o nome do arquivo a ser lido e quantas cidades devem ser adicionadas na matriz
        public GrafoCidades(string nomeArq, int qtasCidades)
        {
            QtsCidades = qtasCidades;
            matrizCidades = new Peso[qtasCidades, qtasCidades];
            menorDist = 0;
            nTree = 0;
            vertices = new Vertice[qtsCidades];
            percurso = new PesoOriginal[qtasCidades];

            //Zera a matriz inteira
            for (int i = 0; i < qtasCidades; i++)
            {
                vertices[i] = new Vertice(i.ToString());  
                for (int j = 0; j < qtasCidades; j++)
                {
                    matrizCidades[i, j] = new Peso(infinity, infinity, infinity);
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
                int tempo = int.Parse(linha.Substring(inicioTempo, tamanhoTempo).Trim());
                int preco = int.Parse(linha.Substring(inicioPreco, tamanhoPreco).Trim());

                //Seta o peso 
                Peso peso = new Peso(distancia, tempo, preco);

                //Atribui na matriz os valores do pesos de cada caminho entre as cidades
                matrizCidades[origem, destino] = peso;
            }
            arq.Close();

            
        }

        //Propriedades
        public int QtsCidades 
        {  
            get => qtsCidades; 
            set => qtsCidades = value; 
        }

        public Peso[,] MatrizCidades 
        {   
            get => matrizCidades; 
            set => matrizCidades = value; 
        }


        //=================================================================
        //DIJKSTRA!
        public void AcharCaminhoDijkstra(int inicioDoPercurso, int finalDoPercurso, int peso, DataGridView dgv, DataGridView dgv2, ArvoreCidades cidades, Graphics g )
        {
            menorDist = 0;
            for (int j = 0; j < QtsCidades; j++)
            {
                // Deixa todos o vetor de visitados como false, com excecao da origem/inicio
                vertices[j].FoiVisitado = false;
            }
            vertices[inicioDoPercurso].FoiVisitado = true;

            for (int j = 0; j < QtsCidades; j++)
            {
                // anotamos no vetor percurso a distância entre o inicioDoPercurso e cada vértice
                // se não há ligação direta, o valor da distância será infinity
                Peso tempPeso = new Peso(matrizCidades[inicioDoPercurso, j]);
                percurso[j] = new PesoOriginal(inicioDoPercurso, tempPeso);
            }
            

            for (int nTree = 0; nTree < QtsCidades; nTree++)
            {
                // Procuramos a saída não visitada do vértice inicioDoPercurso com a menor distância
                int indiceDoMenor = ObterMenor(peso);
                // e anotamos essa menor distância
                int distanciaMinima = percurso[indiceDoMenor].Peso.getQualPesoById(peso);
                // o vértice com a menor distância passa a ser o vértice atual
                // para compararmos com a distância calculada em AjustarMenorCaminho()
                verticeAtual = indiceDoMenor;
                doInicioAteAtual = percurso[indiceDoMenor].Peso.getQualPesoById(peso);// visitamos o vértice com a menor distância desde o inicioDoPercurso
                vertices[verticeAtual].FoiVisitado = true;
                AjustarMenorCaminho(peso);
            }
            // Exibi os percursos no dgv melhor caminho e apaga o de todos caminhos
            dgv2.Rows.Clear();
            ExibirPercursos(inicioDoPercurso, finalDoPercurso, peso, dgv, cidades, g);
        }

        // Obtem a menor distancia par ir, baseando-se no indice de qual dos pesos ele deve comparar (dist, tempo, custo)
        public int ObterMenor(int peso)
        {
            int pesoMinimo = infinity;
            int indiceDaMinima = 0;
            for (int j = 0; j < QtsCidades; j++)
                if (!(vertices[j].FoiVisitado) && (percurso[j].Peso.getQualPesoById(peso) < pesoMinimo))
                {
                    pesoMinimo = percurso[j].Peso.getQualPesoById(peso);
                    indiceDaMinima = j;
                }
             return indiceDaMinima;
        }

        public void AjustarMenorCaminho(int peso)
        {
            for (int coluna = 0; coluna < QtsCidades; coluna++)
                if (!vertices[coluna].FoiVisitado) // para cada vértice ainda não visitado
                {
                    // acessamos a distância desde o vértice atual (pode ser infinity)
                    int atualAteMargem = matrizCidades[verticeAtual, coluna].getQualPesoById(peso);
                    // calculamos a distância desde inicioDoPercurso passando por vertice atual até
                    // esta saída
                    int doInicioAteMargem = doInicioAteAtual + atualAteMargem;
                    // quando encontra uma distância menor, marca o vértice a partir do
                    // qual chegamos no vértice de índice coluna, e a soma da distância
                    // percorrida para nele chegar
                    int distanciaDoCaminho = percurso[coluna].Peso.getQualPesoById(peso);
                    if (doInicioAteMargem < distanciaDoCaminho)
                    {
                        percurso[coluna].VerticePai = verticeAtual;
                        percurso[coluna].Peso.setQualPesoById(peso, doInicioAteMargem);
                    }
                }
        }

        // Exibi o percusrono dgv passado, alem de escrever no mapa
        public void ExibirPercursos(int inicioDoPercurso, int finalDoPercurso, int peso, DataGridView dgv, ArvoreCidades cidades, Graphics g)
        {
            int onde = finalDoPercurso;
            PilhaLista<string> pilha = new PilhaLista<string>();
            int cont = 0;
            int cont2 = 0;
            while (onde != inicioDoPercurso)
            {
                onde = percurso[onde].VerticePai;
                if (percurso[onde].VerticePai.ToString() != vertices[onde].Rotulo)
                {
                    pilha.Empilhar(percurso[onde].VerticePai + "," + vertices[onde].Rotulo);
                }
                cont++;
            }
            if ((cont == 1) && (percurso[finalDoPercurso].Peso.getQualPesoById(peso) == infinity))
                return;

            dgv.RowCount = 1;
            if (dgv.ColumnCount < pilha.Tamanho)
                dgv.ColumnCount = pilha.Tamanho;
            while (pilha.Tamanho != 0)
            {
                dgv[cont2, 0].Value = pilha.Desempilhar();
                String idsString = dgv[cont2, 0].Value.ToString();
                int idOrigem = int.Parse(idsString.Substring(0, idsString.IndexOf(',')));
                int idDestino = int.Parse(idsString.Substring(idsString.IndexOf(',') + 1));
                Cidade cidO = cidades.getCidadeById(idOrigem);
                Cidade cid1 = cidades.getCidadeById(idDestino);

                //Desenha a linha entre as duas cidades no mapa
                g.DrawLine(new Pen(Color.Red), 5 + cidO.X / 4, 5 + cidO.Y / 4, 5 + cid1.X / 4, 5 + cid1.Y / 4);
                //Metodo que pinta as cidades no mapa(redesenha elas por cima da linha desenhada)
                cidades.PercorrerPintar(g);
                cont2++;
            }

            // Recebe e escreve os valores no dgv
            String strPenultimaCelula = dgv[cont2 - 1, 0].Value.ToString();
            int ultimoId = int.Parse(strPenultimaCelula.Substring(strPenultimaCelula.IndexOf(',') + 1));
            dgv[cont2, 0].Value = ultimoId + "," + vertices[finalDoPercurso].Rotulo;
            // Pega as cidades dos indexes escritos para desenha-los no mapa
            Cidade ultimaCidade = cidades.getCidadeById(ultimoId);
            Cidade proximaCidade = cidades.getCidadeById(finalDoPercurso);
            g.DrawLine(new Pen(Color.Red), 5 + ultimaCidade.X / 4, 5 + ultimaCidade.Y / 4, 5 + proximaCidade.X / 4, 5 + proximaCidade.Y / 4);
        }
        //=================================================================


        //=================================================================
        //Metodo por PILHAS
        public void AcharCaminhosPilhas(int origem, int destino, int peso, DataGridView dgvTodos, DataGridView dgvMelhor, ArvoreCidades cidades, Graphics g)
        {
            // Resseta a menor distancia
            menorDist = 0;
            
            // Seta o estado de visitados de vertices para false
            foreach (Vertice v in vertices)
            {
                v.FoiVisitado = false; 
            }
            // Com excecao sendo a origem
            vertices[origem].FoiVisitado = true;
            int prox = infinity;
            int atual = origem;
            // Variabel para determinar quando para o while
            Boolean temCaminhos = true;
            PilhaLista<Movimento> movimentos = new PilhaLista<Movimento>();
            while((prox != origem && prox < QtsCidades) || temCaminhos)
            {
                if (prox == infinity)
                    prox = 0;

                //Verifica de prox é nosso destino e que ele possui um camnho (Distancia != infinity)
                if (prox == destino && matrizCidades[atual, prox].Distancia != infinity)
                {
                    //Empilha o movimento
                    movimentos.Empilhar(new Movimento(atual, prox, new Peso(matrizCidades[atual, prox])));
                    //Exibi o percurso encontrado
                    ExibirPercursoPilha(movimentos, peso, dgvTodos, dgvMelhor, cidades, g);
                    
                    //Desempilha o ultimo movimento para continuar procurando
                    Movimento tempMov = movimentos.Desempilhar();
                    //Reposiciona as posicoes
                    atual = tempMov.Origem;
                    prox = tempMov.Destino + 1;
                }
                else
                {
                    //Se nao foi visitado mas tem caminho (nao para destino)
                    if (!vertices[prox].FoiVisitado && matrizCidades[atual, prox].Distancia != infinity)
                    {
                        //Seta FoiVisitado para true
                        vertices[prox].FoiVisitado = true;
                        //Empilha o movimento
                        movimentos.Empilhar(new Movimento(atual, prox, new Peso(matrizCidades[atual, prox])));
                        atual = prox;
                        prox = 0;
                        temCaminhos = true;
                    }
                    else
                    {
                        //Pula para a proxima cidade da matriz
                        prox++;
                    }
                }

                //Quando chega no final da matriz de cidades sem encontrar um/outro possivel caminho
               if (prox >= QtsCidades)
               {
                    //Se a pila nao estiver vazia
                    if (!movimentos.EstaVazia)
                    {
                        //Desempilha
                        Movimento tempMov = movimentos.Desempilhar();
                        atual = tempMov.Origem;
                        prox = tempMov.Destino;

                        //Verifica se tem algum outro possivel caminho do novo atual
                        for (int i = prox; i < qtsCidades; i++)
                        {
                            if (matrizCidades[atual, i].Distancia != infinity)
                            {
                                if (vertices[i].FoiVisitado == false)
                                {
                                    //Se sim sai do for com o novo prox
                                    temCaminhos = true;
                                    prox = i;
                                    break;
                                }
                                temCaminhos = false;
                            }
                        }

                        //Desempilha mais uma vez se nescessario e possivel
                        if (!temCaminhos && !movimentos.EstaVazia)
                        {
                            tempMov = movimentos.Desempilhar();
                            atual = tempMov.Origem;
                            prox = tempMov.Destino;
                        }
                    }
                    else
                    {
                        //Nao tem caminho
                        temCaminhos = false;
                    }
                }
            }
            
        }


        //Exibi o percurso no dgv e desenha no mapa
        private void ExibirPercursoPilha(PilhaLista<Movimento> movimentos, int peso, DataGridView dgv, DataGridView dgvMelhor, ArvoreCidades cidades, Graphics g)
        {
            int soma = 0;
            //Resseta o tamanho do dgv
            if(dgv.ColumnCount < movimentos.Tamanho)
                dgv.ColumnCount = movimentos.Tamanho;

            //Pilha que devera ser invertida
            PilhaLista<Movimento> pilhaInversa = new PilhaLista<Movimento>();
            while(movimentos.Tamanho > 0)
            {
                //Recebe os movimentos
                Movimento aux = movimentos.Desempilhar();
                //Soma em soma o peso especificado como parametro
                soma += aux.Peso.getQualPesoById(peso);
                pilhaInversa.Empilhar(aux);

                //Independentemente da ordem, desenha no mapa
                Cidade cid0 = cidades.getCidadeById(aux.Origem);
                Cidade cid1 = cidades.getCidadeById(aux.Destino);

                g.DrawLine(new Pen(Color.Red), 5 + cid0.X / 4, 5 + cid0.Y / 4, 5 + cid1.X / 4, 5 + cid1.Y / 4);
                cidades.PercorrerPintar(g);
            }

            //Exibi no dgv sem estragar a pilha
            pilhaInversa.Exibir(dgv);

            //Verifica se é melhor que o ultimo melhor caminho encontrado caminho
            if(soma < menorDist || menorDist == 0)
            {
                menorDist = soma;
                dgvMelhor.Rows.Clear();
                //Exibi o novo melhor caminho
                pilhaInversa.Exibir(dgvMelhor);
            }

            //Reverte a pilha original
            while (pilhaInversa.Tamanho > 0)
            {
                movimentos.Empilhar(pilhaInversa.Desempilhar());
            }
        }




        //Metodo publico para achar caminhos, recebe origem e destino, alem das coisas nescessarias para a exibicao dos resultados:
        //      DataGridView  dgvCaminhos: Exibir neste dgv todos os caminhos;
        //      DataGridView  dgvMelhor  : Exibir aqui o melhor caminho;
        //      ArvoreCidades cidades    : Nescessario para pegar as coordenadas das cidades no mapa, para desenhar as rotas entre elas
        //      Graphics      g          : Graphics que virá do PictureBox para que possamos desenhar no mesmo
        public void AcharCaminhosRec(int origem, int destino, int qualPeso, DataGridView dgvCaminhos, DataGridView dgvMelhor, ArvoreCidades cidades, Graphics g)
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
            AcharCaminhos(origem, destino, qualPeso, ref atual, ref prox, dgvCaminhos, dgvMelhor, ref movimentos, ref visitadas, cidades, g);
        }

        //Metod private para achar caminhos, recebe os mesmos parametros que AcharCaminhos(), mas junto com atual, prox, movimentos, visitadas  
        private void AcharCaminhos(int origem, int destino, int qualPeso, ref int atual, ref int prox, DataGridView dgvCaminhos, DataGridView dgvMelhor, ref PilhaLista<Movimento> mov, ref Boolean[] visit, ArvoreCidades cidades, Graphics g)
        {
            //Caso o indice do proximo(cidade alvo desta iteracao do metodo) seja maior do que o limite de cidades, desempilha o ultimo movimento pois se acabarao os caminhos possiveis 
            if(prox < visit.Length)
            {
                //Caso prox seja o indice do destino desejado E a distacia entre atual(indice da cidade em que estamos) e prox nao seja 0(existe caminho), encontrou um caminho
                if(prox == destino && matrizCidades[atual, prox].Distancia != infinity)
                {
                    //Distancia recebe a distancia indicada na matriz
                    Peso peso = matrizCidades[atual, prox];
                    //Empilha o movimento
                    mov.Empilhar(new Movimento(atual, prox, peso));

                    //Exibi o caminho encontrado
                    ExibirCaminhos(dgvCaminhos, dgvMelhor, mov, qualPeso, cidades, g);

                    //Prox avanca
                    prox++;
                    //Desempilha o ultimo movimento para tentar achar outros possiveis caminhos
                    mov.Desempilhar();
                    //Entra na nova interacao do metodo com prox já atualizado
                    AcharCaminhos(origem, destino, qualPeso, ref atual, ref prox, dgvCaminhos, dgvMelhor, ref mov, ref visit, cidades, g);
                }
                //Else, se a distancia entra ambos atual e prox for 0, nao há caminhos entre as cidades indicadas, OU se a cidade já tiver sido visitada, nao ha caminho, prox vanca +1
                else if(matrizCidades[atual, prox].Distancia == infinity || visit[prox])
                {
                    //prox avanca
                    prox++;
                    //Entra na nova iteracao do metodo com prox já atualizado
                    AcharCaminhos(origem, destino, qualPeso, ref atual, ref prox, dgvCaminhos, dgvMelhor, ref mov, ref visit, cidades, g);
                }
                //Senao, vamos entrar em uma nova cidade para prosseguir tentando achar algum caminhos
                else
                {
                    //Set o status de visitada ou nao da cidade atual para true
                    visit[atual] = true;
                    //Distacia recebe a distancia indicada pela matriz
                    Peso peso = matrizCidades[atual, prox];
                    //Empilha o movimento
                    mov.Empilhar(new Movimento(atual, prox, peso));

                    //Atual avanca para o indice de prox
                    atual = prox;   
                    //prox volta a valer 0
                    prox = 0;

                    //Entra na nova interacao do metodo com atual e prox avancados
                    AcharCaminhos(origem, destino, qualPeso, ref atual, ref prox, dgvCaminhos, dgvMelhor, ref mov, ref visit, cidades, g);
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
                AcharCaminhos(origem, destino, qualPeso, ref atual, ref prox, dgvCaminhos, dgvMelhor, ref mov, ref visit, cidades, g);
            }
        }
        
        /*Metodo de exibir os caminhos encontrados recebendo, alem dos parametros nescessarios para realizar a exibicao, a 
        * PilhaLista<Movimento> com todos os movimentos do caminho em questao*/
        private void ExibirCaminhos(DataGridView dgv, DataGridView dgvMenor, PilhaLista<Movimento> mov, int qualPeso, ArvoreCidades cidades, Graphics g)
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
                switch (qualPeso)
                {
                    case 1: 
                        soma += atual.Peso.Distancia;
                        break;
                    case 2:
                        soma += atual.Peso.Tempo;
                        break;
                    case 3:
                        soma += atual.Peso.Preco;
                        break;
                }
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
