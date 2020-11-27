using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class Peso
    {
        int distancia;
        int tempo;
        int preco;

        public Peso(int d, int t, int pds)
        {
            Distancia = d;
            Tempo = t;
            Preco = pds;
        }

        public int Distancia { get => distancia; set => distancia = value; }
        public int Tempo { get => tempo; set => tempo = value; }
        public int Preco { get => preco; set => preco = value; }

        public int getQualPesoById(int id)
        {
            switch (id)
            {
                case 1:
                    return Distancia;
                case 2:
                    return Tempo;
                case 3:
                    return Preco;
            }

            return -1;
        }

        public void setQualPesoById(int id, int value)
        {
            switch(id)
            {
                case 1:
                    Distancia = value;
                    break;
                case 2:
                    Tempo = value;
                    break;
                case 3:
                    Preco = value;
                    break;
            }
        }

        public Peso(Peso obj)
        {
            if (obj != null)
            {
                this.Distancia = obj.Distancia;
                this.Tempo = obj.Tempo;
                this.Preco = obj.Preco;
            }
            else
                throw new Exception("Deu ruim na copia");
        }
    }
}
