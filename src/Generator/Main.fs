module Main
open Generator
open Argu

type CliArguments =
    | Generator of rows: int * cols: int * amount: int * sparsity: float * path: string * bType: string
    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Generator _ -> "specify a working directory."

[<EntryPoint>]
    let main (argv: string array) =
        let parser = ArgumentParser.Create<CliArguments>(programName = "Generator")
        try
        let results = parser.Parse argv
        if results.Contains Generator then
            let x = results.GetResult Generator
            let rows = x |> first
            let cols = x |> second
            let amount = x |> third
            let sparsity = x |> fourth
            let path = x |> fifth
            let bType = x |> sixth
            generator rows cols amount sparsity path bType   
        else
            parser.PrintUsage() |> printfn "%s"
        0    
        with
        | :? ArguParseException as ex ->
            printfn "%s" ex.Message
            1
        | ex ->
            printfn "Internal Error:"
            printfn "%s" ex.Message
            2     