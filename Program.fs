namespace KestrelFSharp

module Main = 
    open System
    open Microsoft.AspNetCore.Hosting
    open Microsoft.AspNetCore.Builder
    open Microsoft.AspNetCore.Hosting
    open Microsoft.AspNetCore.Http
    open Microsoft.Extensions.Configuration


    type Startup() = 
        member this.Configure(app: IApplicationBuilder) =
        app.Run(fun context -> context.Response.WriteAsync("Hello from ASP.NET Core!"))

    let configuration = (new ConfigurationBuilder())
                            .AddInMemoryCollection(dict["server.urls","http://localhost:8090";])
                            .AddEnvironmentVariables()
                            .Build()

    [<EntryPoint>]
    let main argv = 
        let host = WebHostBuilder().UseKestrel().UseConfiguration(configuration).UseStartup<Startup>().Build()
        host.Run()
        printfn "Server finished!"
        0
