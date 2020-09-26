namespace ProgrammingCourse
module hw3 =
    let rec fib1 n = if n <= 2 then 1 else fib1 (n - 1) + fib1 (n - 2)
    let fib2 n =
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
        else
            n
