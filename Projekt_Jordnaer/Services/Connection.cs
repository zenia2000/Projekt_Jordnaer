namespace Projekt_Jordnaer.Services
{
    public abstract class Connection
    {
        protected String connectionString;
        public IConfiguration Configuration { get; }

        public Connection(IConfiguration configuration)
        {
            Configuration = configuration;
            //connectionString = Configuration["ConnectionStrings:SarahConnection"];
            connectionString = Configuration["ConnectionStrings:JulieConnection"];
        }

    }

}
