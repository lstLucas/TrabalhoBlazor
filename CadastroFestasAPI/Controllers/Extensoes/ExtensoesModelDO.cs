using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFestasAPI.DAOs;
using CadastroFestasAPI.Models;
using CadastroFestaDll.DOs;

namespace CadastroFestasAPI.Controllers.Extensoes
{
    public static class ExtensoesModelDO
    {
        public static FestaDO ToDO(this Festa obj)
        {
            return new FestaDO
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Tema = obj.Tema,
                Data = obj.Data
            };
        }

        public static IList<FestaDO> ToDO(this IList<Festa> listaModels)
        {
            var lista = new List<FestaDO>();

            foreach (var obj in listaModels)
                lista.Add(ToDO(obj));

            return lista;
        }
        
        public static async Task<Festa> ToModel(this FestaDO objDO)
        {
            Festa? obj = null;

            if (objDO.Id != null)
            {
                var dao = new FestaDAO();
                obj = await dao.RetornarPorIdAsync(objDO.Id);
            }

            if (obj == null)
                obj = new Festa();

            obj.Nome = objDO.Nome;
            obj.Tema = objDO.Tema;
            obj.Data = objDO.Data;

            return obj;
        }

        public static async Task<IList<Festa>> ToModel(this IList<FestaDO> listaDO)
        {
            var lista = new List<Festa>();

            foreach (var obj in listaDO)
                lista.Add(await ToModel(obj));

            return lista;
        }

        public static FestaItemDO ToDO(this FestaItem obj)
        {
            return new FestaItemDO
            {
                Id = obj.Id,
                IdFesta = obj.IdFesta,
                Nome = obj.Nome,
                Quantidade = obj.Quantidade
            };
        }

        public static IList<FestaItemDO> ToDO(this IList<FestaItem> listaModels)
        {
            var lista = new List<FestaItemDO>();

            foreach (var obj in listaModels)
                lista.Add(ToDO(obj));

            return lista;
        }

        public static async Task<FestaItem> ToModel(this FestaItemDO objDO)
        {
            FestaItem? obj = null;

            if (objDO.Id != null)
            {
                var dao = new FestaItemDAO();
                obj = await dao.RetornarPorIdAsync(objDO.Id);
            }

            if (obj == null)
                obj = new FestaItem();

            obj.IdFesta = objDO.IdFesta;
            obj.Nome = objDO.Nome ?? "";
            obj.Quantidade = objDO.Quantidade;

            return obj;
        }

        public static async Task<IList<FestaItem>> ToModel(this IList<FestaItemDO> listaDO)
        {
            var lista = new List<FestaItem>();

            foreach (var obj in listaDO)
                lista.Add(await ToModel(obj));

            return lista;
        }
    }
}
