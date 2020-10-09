using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arvore
{
    class ArvoreDeBusca<Tipo> : IComparable<Tipo> where Tipo : IComparable<Tipo>
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

        public void Incluir(Tipo dadoLido)
        {
            Incluir(ref raiz, dadoLido);
        }

        private void Incluir(ref NoArvore<Tipo> atual, Tipo dadoLido)
        {
            if (atual == null)
            {
                atual = new NoArvore<Tipo>(dadoLido);
            }
            else
            if (dadoLido.CompareTo(atual.Info) == 0)
                throw new Exception("Já existe esse registro!");
            else
            if (dadoLido.CompareTo(atual.Info) > 0)
            {
            NoArvore<Tipo> apDireito = atual.Dir;
                Incluir(ref apDireito, dadoLido);
                atual.Dir = apDireito;
            }
            else
            {
                NoArvore<Tipo> apEsquerdo = atual.Esq;
                Incluir(ref apEsquerdo, dadoLido);
                atual.Esq = apEsquerdo;
            }
        }

    }
}