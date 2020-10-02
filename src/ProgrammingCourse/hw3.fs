namespace ProgrammingCourse
module hw3 =

    let rec fib1 n =
        if n = 1 || n = 0 then n
        elif n < 0
        then
            failwith "It's unreal to find Fibonacci number if N below zero"
        else
            fib1 (n - 1) + fib1 (n - 2)
    let fib2 n =
        if n = 1 || n = 0 then n
        elif n < 0
        then
            failwith "It's unreal to find Fibonacci number if N below zero"
        else
            let mutable x = 1 
            let mutable y = 1 
            let mutable i = 2
            while i < n do
                y <- x + y
                x <- y - x
                i <- i + 1
            y
   
    let fib3 n =
        let rec fib3Helper prev current n =
               if n = 0
               then
                   current
               else
                   fib3Helper current (prev + current) (n - 1)
        if n > 1
        then
            fib3Helper 1 1 (n - 2)
        elif n = 1 || n = 0 then n
        else
            failwith "It's unreal to find Fibonacci number if N below zero"

    let matrix_multiply (matrix1: int[,]) (matrix2: int[,]) =
        let row1 = matrix1.[0,*].Length
        let col2 = matrix2.[*,0].Length
        let result = Array2D.zeroCreate row1 col2
        if row1 = col2
        then
            for i = 0 to row1 - 1 do
                for k = 0 to col2 - 1 do
                    for r = 0 to row1 - 1 do
                            result.[i,k] <- result.[i,k] + matrix1.[i,r] * matrix2.[r,k]
            result
        else failwith "Matrices isn't matched"

    let matrix_power (matrix: int[,]) pow =
        if pow < 1 then failwith "It's unreal to find Matrix power zero or below"
        elif pow = 1 then matrix
        else
            let mutable result = matrix
            for i = 2 to pow do
                result <- matrix_multiply result matrix
            result

    let fib4 n =
        if n = 0 then 0
        elif n < 0
        then
            failwith "It's unreal to find Fibonacci number if N below zero"
        else
            let a = array2D [ [ 0; 1]; [1; 1] ]
            let res = matrix_power a n
            res.[0,1]

    let fib5 n =
        if n < 0 then failwith "It's unreal to find Fibonacci number if N below zero"
        elif n = 0 || n = 1 then n
        else
            let a = array2D [ [ 0; 1]; [1; 1] ]
            if n % 2 = 0
            then
                let pow = n / 2
                let resultMatrix = matrix_power (matrix_power a pow) 2
                resultMatrix.[0,1]
            else
                let pow = (n-1) / 2
                let resultMatrix = matrix_multiply (matrix_power (matrix_power a pow) 2) (a)
                resultMatrix.[0,1]

    let fib6 n =
        let arrayOfresults : int array = Array.zeroCreate (n+1)
        if n > 0
        then
            arrayOfresults.[1] <- 1
            for i = 2 to n do
                arrayOfresults.[i] <- arrayOfresults.[i-1] + arrayOfresults.[i-2];
        elif n < 0 then failwith "It's unreal to find Fibonacci numbers if N below zero"
        arrayOfresults

        
