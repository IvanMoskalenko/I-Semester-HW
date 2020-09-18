namespace ProgrammingCourse

module Main =
    open Argu
    open System
    type CLIArguments =
        | First_task
        | Second_task
        | Third_task
        | Forth_task
        | Fifth_task
        | Sixth_task
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | First_task -> "First task"
                | Second_task -> "Second task"
                | Third_task-> "Third task"
                | Forth_task -> "Forth task"
                | Fifth_task -> "Fifth task"
                | Sixth_task -> "Sixth task"
       
    [<EntryPoint>]
    let main (argv: string array) =
        let parser = ArgumentParser.Create<CLIArguments>(programName = "ProgrammingCourse")
        try 
        let results = parser.Parse argv
        if results.Contains First_task then
            printf "Введите число: "
            let x = Console.ReadLine() |> float
            let result = x*x*x*x+x*x*x+x*x+x+1.0
            printf "Результат: "
            printfn "%A" result        
        elif results.Contains Second_task then
            printf "Введите число: "
            let y = Console.ReadLine() |> float
            let q = y*y                             //x^2
            let r = q + y                           //x^2+x
            let result = q*r+r+1.0                  //x^2(x^2+x)+(x^2+x)+1=x^4+x^3+x^2+x+1
            printf "Результат: "                    // 2 умножения
            printfn "%A" result                     // и 3 сложения
        elif results.Contains Third_task then
            printfn "Nothing"
        elif results.Contains Forth_task then
            printfn "Nothing"
        elif results.Contains Fifth_task then
            printfn "Nothing"
        elif results.Contains Sixth_task then
            printfn "Nothing"
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
 

