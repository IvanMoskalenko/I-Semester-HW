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
        printf "Индексы элементов массива, не больших, чем заданное число: "
        let mutable j = 0
        for i = 0 to number_of_elements-1 do
            if created_array.[i] <= supremum then
                j <- j+1
        let third_task_array = Array.zeroCreate j
        j <- 0 
        for i = 0 to number_of_elements-1 do
            if created_array.[i] <= supremum then
                third_task_array.[j] <- i
                j <- j+1
        third_task_array    
    let forth_task (created_array: int array) (limits_array: int array) number_of_elements =
        let mutable j = 0
        for i = 0 to number_of_elements-1 do
            if (created_array.[i] < limits_array.[0]) || (created_array.[i] > limits_array.[1]) then
                j <- j+1
        let forth_task_array = Array.zeroCreate j
        j <- 0 
        for i = 0 to number_of_elements-1 do
            if (created_array.[i] < limits_array.[0]) || (created_array.[i] > limits_array.[1]) then
                forth_task_array.[j] <- i
                j <- j+1
        forth_task_array
    let fifth_task (created_array: int array) =
        created_array.[0] <- created_array.[0] + created_array.[1]
        created_array.[1] <- created_array.[0] - created_array.[1]
        created_array.[0] <- created_array.[0] - created_array.[1]
        created_array
    let sixth_task (created_array: int array) i j =
        created_array.[i] <- created_array.[i] + created_array.[j]
        created_array.[j] <- created_array.[i] - created_array.[j]
        created_array.[i] <- created_array.[i] - created_array.[j]
        created_array

        
                
        
        

