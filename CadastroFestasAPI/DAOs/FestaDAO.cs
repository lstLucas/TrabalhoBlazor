using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFestasAPI.Models;

namespace CadastroAtletaApi.DAOs
{
    public class AtletaDAO : AutoDAO<festa>
    {
        protected override string Tabela => "festa";
    }
}