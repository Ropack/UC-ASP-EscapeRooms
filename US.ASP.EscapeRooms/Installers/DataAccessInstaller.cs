using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;
using UC.CSP.MeetingCenter.DAL;
using US.ASP.EscapeRooms.Facades;
using US.ASP.EscapeRooms.Repositories;

namespace US.ASP.EscapeRooms.Installers
{
    public class DataAccessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<AppDbContext>()
                    .Forward<DbContext>()
                    .LifestyleTransient(),

                Component.For(typeof(IRepository<>))
                    .ImplementedBy(typeof(RepositoryBase<>))
                    .IsFallback()
                    .LifestyleScoped(),

                Classes.FromAssemblyContaining<Startup>()
                    .BasedOn(typeof(IRepository<>))
                    .WithServiceAllInterfaces()
                    .WithServiceSelf()
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<Startup>()
                    .BasedOn(typeof(IFacade))
                    .LifestyleTransient()
                );
        }
    }
}