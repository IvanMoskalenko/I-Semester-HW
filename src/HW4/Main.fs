namespace HW4

module Main =
    open Argu
    open System
    type CLIArguments =
        | First_task
        | Second_task
        | Third_task
        | Fourth_task
        | Fifth_task
        | Sixth_task
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | First_task -> "First task"
                | Second_task -> "Second task"
                | Third_task -> "Third task"
                | Fourth_task -> "Fourth task"
                | Fifth_task -> "Fifth task"
                | Sixth_task -> "Sixth task"

       
    [<EntryPoint>]
    let main (argv: string array) =
        let parser = ArgumentParser.Create<CLIArguments>(programName = "ProgrammingCourse")
        try 
        let results = parser.Parse argv

        if  results.Contains First_task then
            let result = hw4.firstTask (hw4.readArray "input.txt")
            printfn "%A" result
        elif results.Contains Second_task then
            let result = hw4.secondTask [17; 16; 43; 12; 56; 99; 228; 1; -10]
            printfn "%A" result
        elif results.Contains Third_task then
            let result = hw4.thirdTask [17; 16; 43; 12; 56; 99; 228; 1; -10]
            printfn "%A" result
        elif results.Contains Fourth_task then
            let result = hw4.fourthTask (hw4.readArray "input.txt")
            printfn "%A" result 
        elif results.Contains Fifth_task then
            printfn "Enter two int32 numbers:"
            let x = Console.ReadLine () |> int32
            let y = Console.ReadLine () |> int32
            let result = hw4.unpack64bitinto32bit (hw4.pack32bitinto64bit x y)
            printfn "%A" result 
        elif results.Contains Sixth_task then
            printfn "Enter four int16 numbers:"
            let x = Console.ReadLine () |> int16
            let y = Console.ReadLine () |> int16
            let z = Console.ReadLine () |> int16
            let a = Console.ReadLine () |> int16
            let result = hw4.unpack64bitinto16bit (hw4.pack16bitinto64bit x y z a)
            printfn "%A" result 

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
 

