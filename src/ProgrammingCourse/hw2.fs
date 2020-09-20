namespace ProgrammingCourse
module hw2 =
    open System
    let first_task x = x*x*x*x+x*x*x+x*x+x+1.0
    let second_task y =
        let q = y*y                             // x^2
        let r = q + y                           // x^2+x
        q*r+r+1.0                               // x^2(x^2+x)+(x^2+x)+1=x^4+x^3+x^2+x+1
                                                // 2 умножения и 3 сложения
    let create_array number_of_elements =
        let genRandomNumbers count =
            let rnd = System.Random()
            Array.init count (fun _ -> rnd.Next ())
        let created_array = genRandomNumbers number_of_elements
        printf "Сгенерированные элементы массива: "
        printfn "%A" created_array
        created_array
    let third_task (created_array: int array) number_of_elements supremum =        
        printf "Индексы элементов массива, не больших, чем заданное число:"
        for i = 0 to number_of_elements-1 do
            if created_array.[i] <= supremum then
                printf " "
                printf "%A" i
    let forth_task (created_array: int array) (limits_array: int array) number_of_elements =
        printf "Индексы элементов массива, лежащие вне диапазона: "
        for i = 0 to number_of_elements-1 do
            if (created_array.[i] < limits_array.[0]) || (created_array.[i] > limits_array.[1]) then
                printf " "
                printf "%A" i
    let fifth_task (created_array: int array) =
        created_array.[0] <- created_array.[0] + created_array.[1]
        created_array.[1] <- created_array.[0] - created_array.[1]
        created_array.[0] <- created_array.[0] - created_array.[1]
        printf "Изменённый массив: "
        for i = 0 to 1 do
            printf " "
            printf "%A " created_array.[i]
    let sixth_task (created_array: int array) number_of_elements i j =
        created_array.[i] <- created_array.[i] + created_array.[j]
        created_array.[j] <- created_array.[i] - created_array.[j]
        created_array.[i] <- created_array.[i] - created_array.[j]
        printf "Изменённый массив: "
        for k = 0 to number_of_elements-1 do
            printf " "
            printf "%A " created_array.[k]

        
                
        
        

