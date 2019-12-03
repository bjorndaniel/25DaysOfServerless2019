module HttpTrigger

open Microsoft.Azure.WebJobs
open Microsoft.AspNetCore.Mvc
open Microsoft.Azure.WebJobs.Extensions.Http
open Microsoft.AspNetCore.Http
open System

type Dreidl = Nun = 0|Gimmel = 1|Hay = 2|Shin = 3
let rand = Random()

[<FunctionName("Day1")>]
let httpTriggerFunction ([<HttpTrigger(AuthorizationLevel.Function, "get", Route = null)>] req : HttpRequest) =
    async {
        let value : Dreidl = enum (rand.Next() % 4)
        let result = "{'id':'" + (string (int value)) + "','value':'" + value.ToString() + "'}" //TODO: Must be a better way to do this in F#
        return JsonResult result
    } |> Async.StartAsTask