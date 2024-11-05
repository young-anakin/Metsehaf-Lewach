using DentalClinic.Services.Tools;
using LewachBookTrading.Services.BookService;
using LewachBookTrading.Services.CommentService;
using LewachBookTrading.Services.LikeService;
using LewachBookTrading.Services.PostService;
using LewachBookTrading.Services.UserService;

namespace LewachBookTrading
{
    public static class AppServiceRegistration
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IToolsService, ToolsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<ICommentService, CommentService>();
        }
    }
}
