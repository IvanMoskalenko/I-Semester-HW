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
            let result = ProgrammingCourse.hw2.first_task x
            printf "Результат: "
            printf "%A" result
        elif results.Contains Second_task then
            printf "Введите число: "
            let y = Console.ReadLine() |> float
            let result = ProgrammingCourse.hw2.first_task y
            printf "Результат: "
            printf "%A" result
        elif results.Contains Third_task then
            printf "Введите число элементов массива: "
            let number_of_elements = Console.ReadLine() |> int
            let created_array: int array = ProgrammingCourse.hw2.create_array number_of_elements
            printf "Введите число, больше которого элементы массива не должны быть: "
            let supremum = Console.ReadLine() |> int
            ProgrammingCourse.hw2.third_task created_array number_of_elements supremum
        elif results.Contains Forth_task then
            printf "Введите число элементов массива: "
            let number_of_elements = Console.ReadLine() |> int
            let created_array: int array = ProgrammingCourse.hw2.create_array number_of_elements
            printf "Введите левую границу диапазона: "
            let left_limit =  Console.ReadLine() |> int
            printf "Введите правую границу диапазона "
            let right_limit =  Console.ReadLine() |> int
            let limits_array = [|left_limit; right_limit|]
            ProgrammingCourse.hw2.forth_task created_array limits_array number_of_elements 
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
 

