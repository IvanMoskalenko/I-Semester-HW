namespace ProgrammingCourse

module Main =
    open Argu
    open System
    type CLIArguments =
        | First_task of x: float
        | Second_task of x: float
        | Third_task
        | Forth_task
        | Fifth_task
        | Sixth_task
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | First_task _  -> "First task"
                | Second_task _ -> "Second task"
                | Third_task-> "Third task"
                | Forth_task -> "Forth task"
                | Fifth_task -> "Fifth task"
                | Sixth_task -> "Sixth task"
       
    [<EntryPoint>]
    let main (argv: string array) =
        let parser = ArgumentParser.Create<CLIArguments>(programName = "ProgrammingCourse")
        try 
        let results = parser.Parse argv
        if  results.Contains First_task then
            let x = results.GetResult(First_task)
            let result = ProgrammingCourse.hw2.first_task x
            printf "Результат: "
            printf "%A" result
        elif results.Contains Second_task then
            let x = results.GetResult(Second_task)
            let result = ProgrammingCourse.hw2.first_task x
            printf "Результат: "
            printf "%A" result
        elif results.Contains Third_task then
            printf "Введите число элементов массива: "
            let number_of_elements = Console.ReadLine() |> int
            let created_array: int array = ProgrammingCourse.hw2.create_array number_of_elements
            printf "Введите число, больше которого элементы массива не должны быть: "
            let supremum = Console.ReadLine() |> int
            let third_task_array = ProgrammingCourse.hw2.third_task created_array number_of_elements supremum
            printfn "%A" third_task_array
        elif results.Contains Forth_task then
            printf "Введите число элементов массива: "
            let number_of_elements = Console.ReadLine() |> int
            let created_array: int array = ProgrammingCourse.hw2.create_array number_of_elements
            printf "Введите левую границу диапазона: "
            let left_limit =  Console.ReadLine() |> int
            printf "Введите правую границу диапазона: "
            let right_limit =  Console.ReadLine() |> int
            let forth_task_array = ProgrammingCourse.hw2.forth_task created_array left_limit right_limit number_of_elements
            printf "Индексы элементов массива, лежащие вне диапазона: "
            printfn "%A" forth_task_array
        elif results.Contains Fifth_task then
            let number_of_elements = 2
            let created_array: int array = ProgrammingCourse.hw2.create_array number_of_elements
            let fifth_task_array = ProgrammingCourse.hw2.fifth_task created_array
            printf "Изменённый массив: "
            printfn "%A" fifth_task_array
        elif results.Contains Sixth_task then
            printf "Введите число элементов массива: "
            let number_of_elements = Console.ReadLine() |> int
            let created_array: int array = ProgrammingCourse.hw2.create_array number_of_elements
            printf "Введите индексы элементов массива, которые необходимо поменять местами: "
            let i =  Console.ReadLine() |> int
            let j =  Console.ReadLine() |> int
            if (i > -1) && (i < number_of_elements) && (j > -1) && (j < number_of_elements) && (i <> j) then
                let sixth_task_array = ProgrammingCourse.hw2.sixth_task created_array i j
                printf "Изменённый массив: "
                printfn "%A" sixth_task_array
            else printf "Вы ввели неправильные индексы элементов"
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
 

