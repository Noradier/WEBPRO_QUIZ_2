using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(student_database.Startup))]
namespace student_database
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
