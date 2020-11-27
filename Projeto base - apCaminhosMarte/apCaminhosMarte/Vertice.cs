using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class Vertice
    {
        private String rotulo;
        private bool foiVisitado;
        private bool estaAtivo;
        public Vertice(string nomeDoVertice)
        {
            Rotulo = nomeDoVertice;
            FoiVisitado = false;
            EstaAtivo = true;
        }

        public string Rotulo { get => rotulo; set => rotulo = value; }
        public bool FoiVisitado { get => foiVisitado; set => foiVisitado = value; }
        public bool EstaAtivo { get => estaAtivo; set => estaAtivo = value; }
    }
}
