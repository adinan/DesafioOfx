using DesafioOfx.Core.DomainObjects;
using System.Collections.Generic;

namespace DesafioOfx.Domain
{
    public class Banco : Entity
    {
        public Banco(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome; 
        }

        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public  List<Agencia> Agencias { get; private set; }

    }
}
