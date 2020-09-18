namespace ProgrammingCourse
module hw2 =
    open System
    let first_task x = x*x*x*x+x*x*x+x*x+x+1.0
    let second_task y =
        let q = y*y                             //x^2
        let r = q + y                           //x^2+x
        q*r+r+1.0                               //x^2(x^2+x)+(x^2+x)+1=x^4+x^3+x^2+x+1
                                                // 2 умножения и 3 сложения
    let third_task number_of_elements =
        let task3_array : int array = Array.zeroCreate number_of_elements
        printf "Теперь придётся ввести все элементы массива: "
        for i = 1 to number_of_elements do
            let element = Console.ReadLine() |> int
            task3_array.[i-1] <- element
        printf "Введите число, больше которого не должны быть элементы массива: "
        let max = Console.ReadLine() |> int
        printf "Индексы элементов массива, не большие, чем заданное число:"
        for i = 1 to number_of_elements do
            if task3_array.[i-1] <= max then
                printf " "
                printf "%A" i
                
