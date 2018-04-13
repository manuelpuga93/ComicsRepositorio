using Comics.Contratos.Negocios;
using Microsoft.Practices.Unity;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiComics.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IComicNegocio, ComicNegocio>(new HierarchicalLifetimeManager());
            container.RegisterType<ICompaniaNegocio, CompaniaNegocio>(new HierarchicalLifetimeManager());
            container.RegisterType<IEscritorNegocio, EscritorNegocio>(new HierarchicalLifetimeManager());
            container.RegisterType<ICompaniaNegocio, CompaniaNegocio>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}