using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Security.JWT;
using Public_Offering.Business.Abstract;
using Public_Offering.Business.Concrete;
using Public_Offering.Core.Utilities.Interceptors;
using Public_Offering.Core.Utilities.Security.JWT;
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

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();


            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>();

            builder.RegisterType<PublicOfferManager>().As<IPublicOfferService>();
            builder.RegisterType<PublicOfferRepository>().As<IPublicOfferRepository>();


            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>();

            builder.RegisterType<UserCommentLikeManager>().As<IUserCommentLikeService>();
            builder.RegisterType<UserCommentLikeRepository>().As<IUserCommentLikeRepository>();
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
