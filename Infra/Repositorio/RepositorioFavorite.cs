using Domain.Interfaces.IFavorite;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infra.Repositorio
{
    public class RepositorioFavorite : RepositoryGenerics<Favorite>, InterfaceFavorite
    {
        private readonly DbContextOptions<ContextBase> _dbContextOptions;
        public RepositorioFavorite()
        {
            this._dbContextOptions = new DbContextOptions<ContextBase>();
        }


    }
}
