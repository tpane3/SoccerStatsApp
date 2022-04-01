using Autofac;
using Module = Autofac.Module;
using Microsoft.Extensions.Configuration;
using SoccerStats.Infrastructure.Data;
using SoccerStats.Infrastructure.Data.Repositories;
using SoccerStats.Core.Interfaces.Repositories;

namespace SoccerStats.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly bool _isDevelopment = false;
        private readonly IConfiguration _config;


        public DefaultInfrastructureModule(bool isDevelopment, IConfiguration config)
        {
            this._isDevelopment = isDevelopment;
            this._config = config;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<SoccerStatsContext>()
                .WithParameter("options", DbContextOptionsFactory.GetOptions(this._config))
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<PlayerRepository>()
                .As<IPlayerRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TeamRepository>()
                .As<ITeamRepository>()
                .InstancePerLifetimeScope();
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add development only services
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add production only services
        }
    }
}