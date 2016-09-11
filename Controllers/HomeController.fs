namespace KestrelFSharp.Controllers

open System
open System.Collections.Generic

type HomeRendition() =
    [<DefaultValue>] val mutable Message : string
    [<DefaultValue>] val mutable Time : string
 
type HomeController() =
    inherit ApiController()
    member this.Get() =
        this.Request.CreateResponse(
            HttpStatusCode.OK,
            HomeRendition(
                Message = "Hello from F#",
                Time = DateTimeOffset.Now.ToString("o")))