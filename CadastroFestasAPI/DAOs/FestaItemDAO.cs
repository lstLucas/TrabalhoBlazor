using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFestasAPI.Models;

namespace CadastroFestasAPI.DAOs
{
    public class FestaItemDAO : AutoDAO<FestaItem>
    {
        protected override string Tabela => "festa_item";

        protected override string? NomeCampoIdMestre => "IdFesta";
    }
}