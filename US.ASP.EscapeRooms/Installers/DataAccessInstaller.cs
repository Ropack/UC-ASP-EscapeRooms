using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;
using UC.CSP.MeetingCenter.DAL;

namespace US.ASP.EscapeRooms.Installers
{
    public class DataAccessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<AppDbContext>()
                    .Forward<DbContext>()
                    .LifestyleTransient()
                );
        }
    }
}