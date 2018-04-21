namespace SpaStore
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    /// <summary> Program. </summary>
    public class Program
    {
        /// <summary> Main. </summary>
        /// <param name="args"> args. </param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary> BuildWebHost. </summary>
        /// <param name="args"> args. </param>
        /// <returns> IWebHost </returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
