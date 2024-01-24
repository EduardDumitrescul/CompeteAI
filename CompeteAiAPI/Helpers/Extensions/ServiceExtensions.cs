using CompeteAiAPI.Repositories;

namespace CompeteAiAPI.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<UserRepository>();
            services.AddTransient<ParticipationRepository>();
            services.AddTransient<ResultRepository>();
            services.AddTransient<TournamentRepository>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddTransient<ParticipationService>();
            services.AddTransient<ResultService>();
            services.AddTransient<TournamentService>();

            return services;
        }
    }
}
