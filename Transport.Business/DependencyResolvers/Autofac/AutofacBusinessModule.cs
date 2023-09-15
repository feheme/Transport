using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Business.Abstract;
using Transport.Business.Concrete;
using Transport.Core.CrossCuttingConcerns.Caching.Microsoft;
using Transport.Core.CrossCuttingConcerns.Caching;
using Transport.Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Transport.Core.Utilities.Interceptors;
using Transport.Core.Utilities.Security.JWT;
using Transport.DataAccess.Abstract;
using Transport.DataAccess.Concrete.EntityFramework;

namespace Transport.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();


            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>();

            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>();

            builder.RegisterType<DriverManager>().As<IDriverService>();
            builder.RegisterType<DriverRepository>().As<IDriverRepository>();

            builder.RegisterType<MessageManager>().As<IMessageService>();
            builder.RegisterType<MessageRepository>().As<IMessageRepository>();

            builder.RegisterType<PersonManager>().As<IPersonService>();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();


            builder.RegisterType<ReservationManager>().As<IReservationService>();
            builder.RegisterType<ReservationRepository>().As<IReservationRepository>();

            builder.RegisterType<TeamManager>().As<ITeamService>();
            builder.RegisterType<TeamRepository>().As<ITeamRepository>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<UserOperationClaimRepository>().As<IUserOperationClaimRepository>();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<OperationClaimRepository>().As<IOperationClaimRepository>();


            builder.RegisterType<VehicleManager>().As<IVehicleService>();
            builder.RegisterType<VehicleRepository>().As<IVehicleRepository>();

            //builder.RegisterType<CloudinaryManager>().As<ICloudinaryService>();
            builder.RegisterType<CacheManager>().As<ICacheService>();

            builder.RegisterType<FileLogger>();

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
