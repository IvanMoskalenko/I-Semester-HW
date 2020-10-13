namespace HW2_3

module Main =
    open Argu
    open System
    type CLIArguments =
        | First_task2 of x: float
        | Second_task2 of x: float
        | Third_task2
        | Forth_task2
        | Fifth_task2
        | Sixth_task2
        | First_task3 of x: int
        | Second_task3 of x: int
        | Third_task3 of x: int
        | Forth_task3 of x: int
        | Fifth_task3 of x: int
        | Sixth_task3 of x: int
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | First_task2 _  -> "First task, second HW"
                | Second_task2 _ -> "Second task, second HW"
                | Third_task2 -> "Third task, second HW"
                | Forth_task2 -> "Forth task, second HW"
                | Fifth_task2 -> "Fifth task, second HW"
                | Sixth_task2 -> "Sixth task, second HW"
                | First_task3 _ -> "First task, third HW"
                | Second_task3 _ -> "Second task, third HW"
                | Third_task3 _ -> "Third task, third HW"
                | Forth_task3 _ -> "Forth task, third HW"
                | Fifth_task3 _ -> "Fifth task, third HW"
                | Sixth_task3 _ -> "Sixth task, third HW"

       
    [<EntryPoint>]
    let main (argv: string array) =
        let parser = ArgumentParser.Create<CLIArguments>(programName = "ProgrammingCourse")
        try 
        let results = parser.Parse argv

        //HW2
        if  results.Contains First_task2 then
            let x = results.GetResult (First_task2)
            let result = hw2.firstTask x
            printf "Результат: "
            printf "%A" result
        elif results.Contains Second_task2 then
            let x = results.GetResult (Second_task2)
            let result = hw2.firstTask x
            printf "Результат: "
            printf "%A" result
        elif results.Contains Third_task2 then
            printf "Введите число элементов массива: "
            let number_of_elements = Console.ReadLine () |> int
            let created_array: int array = hw2.createArray number_of_elements
            printf "Введите число, больше которого элементы массива не должны быть: "
            let supremum = Console.ReadLine () |> int
            let third_task_array = hw2.thirdTask created_array number_of_elements supremum
            printfn "%A" third_task_array
        elif results.Contains Forth_task2 then
            printf "Введите число элементов массива: "
            let number_of_elements = Console.ReadLine () |> int
            let created_array: int array = hw2.createArray number_of_elements
            printf "Введите левую границу диапазона: "
            let left_limit =  Console.ReadLine () |> int
            printf "Введите правую границу диапазона: "
            let right_limit =  Console.ReadLine () |> int
            let forth_task_array = hw2.forthTask created_array left_limit right_limit number_of_elements
            printf "Индексы элементов массива, лежащие вне диапазона: "
            printfn "%A" forth_task_array
        elif results.Contains Fifth_task2 then
            let numberOfElements = 2
            let createdArray: int array = hw2.createArray numberOfElements
            let fifthTaskArray = hw2.fifthTask createdArray
            printf "Изменённый массив: "
            printfn "%A" fifthTaskArray
        elif results.Contains Sixth_task2 then
            printf "Введите число элементов массива: "
            let numberOfElements = Console.ReadLine () |> int
            let createdArray: int array = hw2.createArray numberOfElements
            printf "Введите индексы элементов массива, которые необходимо поменять местами: "
            let i =  Console.ReadLine () |> int
            let j =  Console.ReadLine () |> int
            if (i > -1) && (i < numberOfElements) && (j > -1) && (j < numberOfElements) && (i <> j) then
                let sixthTaskArray = hw2.sixthTask createdArray i j
                printf "Изменённый массив: "
                printfn "%A" sixthTaskArray
            else printf "Вы ввели неправильные индексы элементов"

        //HW3
        elif results.Contains First_task3 then
            let n = results.GetResult (First_task3)
            let result = hw3.fib1 n
            printf "Результат: "
            printfn "%A" result
        elif results.Contains Second_task3 then
            let n = results.GetResult (Second_task3)
            let result = hw3.fib2 n
            printf "Результат: "
            printfn "%A" result
        elif results.Contains Third_task3 then
            let n = results.GetResult (Third_task3)
            let result = hw3.fib3 n
            printf "Результат: "
            printfn "%A" result
        elif results.Contains Forth_task3 then
            let n = results.GetResult (Forth_task3)
            let result = hw3.fib4 n
            printf "Результат: "
            printfn "%A" result
        elif results.Contains Fifth_task3 then
            let n = results.GetResult (Fifth_task3)
            let result = hw3.fib5 n
            printf "Результат: "
            printfn "%A" result
        elif results.Contains Sixth_task3 then
            let n = results.GetResult (Sixth_task3)
            let result = hw3.fib6 n
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
 

