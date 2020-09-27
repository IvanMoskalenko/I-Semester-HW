namespace ProgrammingCourse
module hw3 =
    let rec fib1 n =
        if n = 2 || n = 1
        then
            1
        elif n = 0
        then
            0
        elif n < 0
        then
            -1
        else
            fib1 (n - 1) + fib1 (n - 2)
    let fib2 n =
        if n = 2 || n = 1
        then
            1
        elif n = 0
        then
            0
        elif n < 0
        then
            -1
        else
            let mutable x = 1 
            let mutable y = 1 
            let mutable i = 2
            while i < n do
                y <- x + y
                x <- y - x
                i <- i + 1
            y
    let rec fib3Helper prev current n =
        if n = 0
        then
            current
        else
            fib3Helper current (prev + current) (n - 1)
    let fib3 n =
        if n > 1
        then
            fib3Helper 1 1 (n - 2)
        elif n = 1 || n = 0
        then
            n
        else
            -1            
    let fib4 n =
        if n < 0 then -1 else
        let a = array2D [ [ 0; 1]; [1; 1] ]
        let A = ProgrammingCourse.matrices.Matrix.ofArray2D a
        let resultMatrix = A ^^ n
        let result = resultMatrix.values.[0,1]
        result
    let fib5 n =
        if n < 0 then -1
        elif n % 2 = 0
        then
            let a = array2D [ [ 0; 1]; [1; 1] ]
            let A = ProgrammingCourse.matrices.Matrix.ofArray2D a
            let pow = n/2
            let resultMatrix = (A ^^ pow) ^^ 2
            let result = resultMatrix.values.[0,1]
            result
        else
            let a = array2D [ [ 0; 1]; [1; 1] ]
            let A = ProgrammingCourse.matrices.Matrix.ofArray2D a
            let pow = (n-1)/2
            let resultMatrix = A * ((A ^^ pow) ^^ 2)
            let result = resultMatrix.values.[0,1]
            result
    let fib6 n =
        let arrayOfresults : int array = Array.zeroCreate (n+1)
        let mutable x = 0
        let mutable y = 1
        arrayOfresults.[1] <- 1
        for i = 2 to n do
            arrayOfresults.[i] <- x + y;
            x <- y
            y <- arrayOfresults.[i]
        arrayOfresults

        
