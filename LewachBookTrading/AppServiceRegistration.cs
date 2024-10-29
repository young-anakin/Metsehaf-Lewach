using DentalClinic.Services.Tools;
using LewachBookTrading.Services.JournalTypeService;
using LewachBookTrading.Services.UserService;

namespace LewachBookTrading
{
    public static class AppServiceRegistration
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IToolsService, ToolsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJournalTagService, JournalTagService>();
        }
    }
}
