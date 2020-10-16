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
        | Seventh_task
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | First_task -> "First task"
                | Second_task -> "Second task"
                | Third_task -> "Third task"
                | Fourth_task -> "Fourth task"
                | Fifth_task -> "Fifth task"
                | Sixth_task -> "Sixth task"
                | Seventh_task -> "Terekhov's joke"

       
    [<EntryPoint>]
    let main (argv: string array) =
        let parser = ArgumentParser.Create<CLIArguments>(programName = "ProgrammingCourse")
        try 
        let results = parser.Parse argv

        if  results.Contains First_task then
            let result = hw4.firstTask (hw4.readArray (__SOURCE_DIRECTORY__ + "/input.txt"))
            System.IO.File.WriteAllLines ((__SOURCE_DIRECTORY__ + "/output.txt"), hw4.arrayOfIntIntoArrayOfStrings result)
        elif results.Contains Second_task then
            let result = hw4.secondTask (hw4.readList (__SOURCE_DIRECTORY__ + "/input.txt"))
            System.IO.File.WriteAllLines ((__SOURCE_DIRECTORY__ + "/output.txt"), hw4.arrayOfIntIntoArrayOfStrings (List.toArray result))
        elif results.Contains Third_task then
            let result = hw4.thirdTask (hw4.readList (__SOURCE_DIRECTORY__ + "/input.txt"))
            System.IO.File.WriteAllLines ((__SOURCE_DIRECTORY__ + "/output.txt"), hw4.arrayOfIntIntoArrayOfStrings (List.toArray result))
        elif results.Contains Fourth_task then
            let result = hw4.fourthTask (hw4.readArray (__SOURCE_DIRECTORY__ + "/input.txt"))
            System.IO.File.WriteAllLines ((__SOURCE_DIRECTORY__ + "/output.txt"), hw4.arrayOfIntIntoArrayOfStrings result) 
        elif results.Contains Fifth_task then
            printfn "Enter two int32 numbers:"
            let x = Console.ReadLine () |> int32
            let y = Console.ReadLine () |> int32
            let result = hw4.fifthTask x y
            printfn "%A" result 
        elif results.Contains Sixth_task then
            printfn "Enter four int16 numbers:"
            let x = Console.ReadLine () |> int16
            let y = Console.ReadLine () |> int16
            let z = Console.ReadLine () |> int16
            let a = Console.ReadLine () |> int16
            let result = hw4.sixthTask x y z a
            printfn "%A" result
        elif results.Contains Seventh_task then
            printfn "Анекдот. Один человек предлагает другому коньяка и спрашивает:\n- Сколько?\n- 20\n- Чего 20?\n- А чего сколько?"

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
 

