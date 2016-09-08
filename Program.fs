namespace KestrelFSharp

module Main = 
    open System
    open System.IO
    open System.Text
    open Microsoft.AspNetCore.Hosting
    open Microsoft.AspNetCore.Builder
    open Microsoft.AspNetCore.Hosting
    open Microsoft.AspNetCore.Http
    open Microsoft.AspNetCore.Mvc
    open Microsoft.Extensions.Configuration
    open Microsoft.Extensions.Configuration.Json
    open Microsoft.Extensions.DependencyInjection


    type Startup() = 

        member this.ConfigureServices(services: IServiceCollection) =
            //services.AddOptions() |> ignore
            //services.AddLogging() |> ignore
            services.AddMvcCore().AddJsonFormatters() |> ignore

        member this.Configure(app: IApplicationBuilder) =
            app.UseMvc() |> ignore
            app.Run(fun context -> context.Response.WriteAsync("Hello from ASP.NET Core!"))

    let configuration = (new ConfigurationBuilder())
                            .AddInMemoryCollection(dict["server.urls","http://localhost:8090";])
                            .Build()

    [<EntryPoint>]
    let main argv = 
        let host = WebHostBuilder().UseKestrel().UseConfiguration(configuration).UseStartup<Startup>().Build()
        host.Run()
        printfn "Server finished!"
        0
