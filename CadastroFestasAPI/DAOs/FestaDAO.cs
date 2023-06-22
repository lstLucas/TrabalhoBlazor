using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFestasAPI.Models;

namespace CadastroFestasAPI.DAOs
{
    public class FestaDAO : AutoDAO<Festa>
    {
        protected override string Tabela => "festa";
    }
}