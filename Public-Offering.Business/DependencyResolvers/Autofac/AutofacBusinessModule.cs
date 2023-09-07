using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Public_Offering.Business.Abstract;
using Public_Offering.Business.Concrete;
using Public_Offering.Core.Utilities.Interceptors;
using Public_Offering.DataAccess.Abstract;
using Public_Offering.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {


         

            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>();

            builder.RegisterType<PublicOfferManager>().As<IPublicOfferService>();
            builder.RegisterType<PublicOfferRepository>().As<IPublicOfferRepository>();

            //builder.RegisterType<CarImageRepository>().As<ICarImageRepository>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
