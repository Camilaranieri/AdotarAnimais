using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdotarAnimais
{
    static class ConexaoBanco
    {

        private const string servidor = "localhost";
        private const string bancoDados = "adocao";
        private const string usuario = "root";
        private const string senha = "1234";

        static public string bancoServidor = $"server={servidor}; user id={usuario}; database={bancoDados}; password={senha}";
    }

}
