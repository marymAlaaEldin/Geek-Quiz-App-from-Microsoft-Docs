using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using TriviaQuiz.Models;

[assembly: OwinStartupAttribute(typeof(TriviaQuiz.Startup))]
namespace TriviaQuiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
       
    }
}
