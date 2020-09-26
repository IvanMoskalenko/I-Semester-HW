namespace ProgrammingCourse

module Main =
    open Argu
    open System
    type CLIArguments =
        | First_task1 of x: float
        | Second_task1 of x: float
        | Third_task1
        | Forth_task1
        | Fifth_task1
        | Sixth_task1
        | First_task2 of x: int
        | Second_task2 of x: int
        | Third_task2 of x: int
        | Forth_task2 of x: int
        | Fifth_task2 of x: int
        | Sixth_task2 of x: int
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | First_task1 _  -> "First task, second HW"
                | Second_task1 _ -> "Second task, second HW"
                | Third_task1 -> "Third task, second HW"
                | Forth_task1 -> "Forth task, second HW"
                | Fifth_task1 -> "Fifth task, second HW"
                | Sixth_task1 -> "Sixth task, second HW"
                | First_task2 _ -> "First task, third HW"
                | Second_task2 _ -> "Second task, third HW"
                | Third_task2 _ -> "Third task, third HW"
                | Forth_task2 _ -> "Forth task, third HW"
                | Fifth_task2 _ -> "Fifth task, third HW"
                | Sixth_task2 _ -> "Sixth task, third HW"

       
    [<EntryPoint>]
    let main (argv: string array) =
        let parser = ArgumentParser.Create<CLIArguments>(programName = "ProgrammingCourse")
        try 
        let results = parser.Parse argv
        if  results.Contains First_task1 then
            let x = results.GetResult (First_task1)
            let result = ProgrammingCourse.hw2.first_task x
            printf "Результат: "
            printf "%A" result
        elif results.Contains Second_task1 then
            let x = results.GetResult (Second_task1)
            let result = ProgrammingCourse.hw2.first_task x
            printf "Результат: "
            printf "%A" result
        elif results.Contains Third_task1 then
            printf "Введите число элементов массива: "
            let number_of_elements = Console.ReadLine () |> int
            let created_array: int array = ProgrammingCourse.hw2.create_array number_of_elements
            printf "Введите число, больше которого элементы массива не должны быть: "
            let supremum = Console.ReadLine () |> int
            let third_task_array = ProgrammingCourse.hw2.third_task created_array number_of_elements supremum
            printfn "%A" third_task_array
        elif results.Contains Forth_task1 then
            printf "Введите число элементов массива: "
            let number_of_elements = Console.ReadLine () |> int
            let created_array: int array = ProgrammingCourse.hw2.create_array number_of_elements
            printf "Введите левую границу диапазона: "
            let left_limit =  Console.ReadLine () |> int
            printf "Введите правую границу диапазона: "
            let right_limit =  Console.ReadLine () |> int
            let forth_task_array = ProgrammingCourse.hw2.forth_task created_array left_limit right_limit number_of_elements
            printf "Индексы элементов массива, лежащие вне диапазона: "
            printfn "%A" forth_task_array
        elif results.Contains Fifth_task1 then
            let number_of_elements = 2
            let created_array: int array = ProgrammingCourse.hw2.create_array number_of_elements
            let fifth_task_array = ProgrammingCourse.hw2.fifth_task created_array
            printf "Изменённый массив: "
            printfn "%A" fifth_task_array
        elif results.Contains Sixth_task1 then
            printf "Введите число элементов массива: "
            let number_of_elements = Console.ReadLine () |> int
            let created_array: int array = ProgrammingCourse.hw2.create_array number_of_elements
            printf "Введите индексы элементов массива, которые необходимо поменять местами: "
            let i =  Console.ReadLine () |> int
            let j =  Console.ReadLine () |> int
            if (i > -1) && (i < number_of_elements) && (j > -1) && (j < number_of_elements) && (i <> j) then
                let sixth_task_array = ProgrammingCourse.hw2.sixth_task created_array i j
                printf "Изменённый массив: "
                printfn "%A" sixth_task_array
            else printf "Вы ввели неправильные индексы элементов"
        elif results.Contains First_task2 then
            let n = results.GetResult (First_task2)
            let result = ProgrammingCourse.hw3.fib1 n
            printf "Результат: "
            printfn "%A" result
        elif results.Contains Second_task2 then
            let n = results.GetResult (Second_task2)
            let result = ProgrammingCourse.hw3.fib2 n
            printf "Результат: "
            printfn "%A" result
        elif results.Contains Third_task2 then
            let n = results.GetResult (Third_task2)
            let result = ProgrammingCourse.hw3.fib3 n
            printf "Результат: "
            printfn "%A" result
        elif results.Contains Forth_task2 then
            let n = results.GetResult (Forth_task2)
            printfn "Not done yet"
        elif results.Contains Fifth_task2 then
            let n = results.GetResult (Fifth_task2)
            printfn "Not done yet"
        elif results.Contains Sixth_task2 then
            let n = results.GetResult (Sixth_task2)
            printfn "Not done yet"
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
 

