using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP3.Repository;

namespace TP3
{
    public class Bootstraper
    {
        public static IUnityContainer Initialize()
        {
            var container = new UnityContainer();

            container.RegisterType<ILivroRepository, LivroRepository>();
            container.RegisterType<IEmprestimoRepository, EmprestimoRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }
    }
}