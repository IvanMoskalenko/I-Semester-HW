namespace HW2_3
module hw2 =
    open System
    let firstTask x = x * x * x * x + x * x * x + x * x + x + 1.0

    let secondTask y =
        let q = y * y                               // x^2
        let r = q + y                               // x^2+x
        q * r + r + 1.0                             // x^2(x^2+x)+(x^2+x)+1=x^4+x^3+x^2+x+1
                                                    // 2 умножения и 3 сложения

    let createArray numberOfElements =
        let genRandomNumbers count =
            let rnd = System.Random ()
            Array.init count (fun _ -> rnd.Next ())
        let createdArray = genRandomNumbers numberOfElements
        printf "Сгенерированные элементы массива: "
        printfn "%A" createdArray
        createdArray

    let thirdTask (createdArray: int array) numberOfElements supremum =        
        printf "Индексы элементов массива, не больших, чем заданное число: "
        let mutable j = 0
        for i = 0 to numberOfElements - 1 do
            if createdArray.[i] <= supremum then
                j <- j + 1
        let thirdtaskArray = Array.zeroCreate j
        j <- 0 
        for i = 0 to numberOfElements - 1 do
            if createdArray.[i] <= supremum then
                thirdtaskArray.[j] <- i
                j <- j + 1
        thirdtaskArray
        
    let forthTask (createdArray: int array) leftLimit rightLimit numberOfElements =
        let mutable j = 0
        for i = 0 to numberOfElements - 1 do
            if (createdArray.[i] < leftLimit) || (createdArray.[i] > rightLimit) then
                j <- j + 1
        let forthTaskArray = Array.zeroCreate j
        j <- 0 
        for i = 0 to numberOfElements - 1 do
            if (createdArray.[i] < leftLimit) || (createdArray.[i] > rightLimit) then
                forthTaskArray.[j] <- i
                j <- j + 1
        forthTaskArray

    let fifthTask (createdArray: int array) =
        createdArray.[0] <- createdArray.[0] + createdArray.[1]
        createdArray.[1] <- createdArray.[0] - createdArray.[1]
        createdArray.[0] <- createdArray.[0] - createdArray.[1]
        createdArray

    let sixthTask (createdArray: int array) i j =
        createdArray.[i] <- createdArray.[i] + createdArray.[j]
        createdArray.[j] <- createdArray.[i] - createdArray.[j]
        createdArray.[i] <- createdArray.[i] - createdArray.[j]
        createdArray

        
                
        
        

