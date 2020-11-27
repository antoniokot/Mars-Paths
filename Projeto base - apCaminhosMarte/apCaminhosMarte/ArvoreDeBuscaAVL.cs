using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arvore
{
    class ArvoreDeBuscaAVL<Tipo> : IComparable<Tipo> where Tipo : IComparable<Tipo>
    {
        NoArvore<Tipo> raiz, atual, antecessor;

        public NoArvore<Tipo> Raiz { get => raiz; set => raiz = value; }
        public NoArvore<Tipo> Atual { get => atual; set => atual = value; }
        public NoArvore<Tipo> Antecessor { get => antecessor; set => antecessor = value; }

        public int CompareTo(Tipo o)
        {
            return atual.Info.CompareTo(o);
        }

        public int CompareTo(NoArvore<Tipo> o)
        {
            return atual.Info.CompareTo(o.Info);
        }

        public NoArvore<Tipo> Incluir(Tipo item, NoArvore<Tipo> n)
        {
            if (n == null)
                n = new NoArvore<Tipo>(item); // atributo Altura valerá 0!
            else
            {
                if (item.CompareTo(n.Info) < 0)
                {
                    n.Esq = Incluir(item, n.Esq);
                    if (getAltura(n.Esq) - getAltura(n.Dir) == 2)  // o método getAltura testa nulo!
                        if (item.CompareTo(n.Esq.Info) < 0)
                            n = RotateWithLeftChild(n);
                        else
                            n = DoubleWithLeftChild(n);
                }
                else if (item.CompareTo(n.Info) > 0)
                {
                    n.Dir = Incluir(item, n.Dir);
                    if (getAltura(n.Dir) - getAltura(n.Esq) == 2)  // o método get Altura testa nulo!
                        if (item.CompareTo(n.Dir.Info) > 0)
                            n = RotateWithRightChild(n);
                        else
                            n = DoubleWithRightChild(n);
                }
                //else ; -não faz nada, valor duplicado
                n.Altura = Math.Max(getAltura(n.Esq), getAltura(n.Dir)) + 1;
            }
            return n;
        }

        private NoArvore<Tipo> RotateWithLeftChild(NoArvore<Tipo> no)
        {
            NoArvore<Tipo> temp = no;  // apenas para declarar
            temp = no.Esq;
            no.Esq = temp.Dir;
            temp.Dir = no;
            no.Altura = Math.Max(getAltura(no.Esq), getAltura(no.Dir)) + 1;
            temp.Altura = Math.Max(getAltura(temp.Esq), getAltura(no)) + 1;
            return temp;
        }

        private NoArvore<Tipo> RotateWithRightChild(NoArvore<Tipo> no)
        {
            NoArvore<Tipo> temp = no;  // apenas para declarar
            temp = no.Dir;
            no.Dir = temp.Esq;
            temp.Esq = no;
            no.Altura = Math.Max(getAltura(no.Esq), getAltura(no.Dir)) + 1;
            temp.Altura = Math.Max(getAltura(temp.Dir), getAltura(no)) + 1;
            return temp;
        }

        private NoArvore<Tipo> DoubleWithLeftChild(NoArvore<Tipo> no) 
        { 
            no.Esq = RotateWithRightChild(no.Esq); 
            return RotateWithLeftChild(no); 
        }

        private NoArvore<Tipo> DoubleWithRightChild(NoArvore<Tipo> no) 
        { 
            no.Dir = RotateWithLeftChild(no.Dir); 
            return RotateWithRightChild(no); 
        }

        public int getAltura(NoArvore<Tipo> no) 
        { 
            if (no != null)
                return no.Altura; 
            else
                return - 1; 
        }

        // Inserir() do Projeto 2 (sem árvore AVL)
        //public void Incluir(Tipo dadoLido)
        //{
        //    //Incluir(dadoLido, raiz);
        //    Incluir(ref raiz, dadoLido);
        //}

        //private void Incluir(ref NoArvore<Tipo> atual, Tipo dadoLido)
        //{
        //    if (atual == null)
        //    {
        //        atual = new NoArvore<Tipo>(dadoLido);
        //    }
        //    else
        //    if (dadoLido.CompareTo(atual.Info) == 0)
        //        throw new Exception("Já existe esse registro!");
        //    else
        //    if (dadoLido.CompareTo(atual.Info) > 0)
        //    {
        //        NoArvore<Tipo> apDireito = atual.Dir;
        //        Incluir(ref apDireito, dadoLido);
        //        atual.Dir = apDireito;
        //    }
        //    else
        //    {
        //        NoArvore<Tipo> apEsquerdo = atual.Esq;
        //        Incluir(ref apEsquerdo, dadoLido);
        //        atual.Esq = apEsquerdo;
        //    }
        //}

    }
}