module Tests


open Expecto
open ProgrammingCourse

[<Tests>]
let tests =
    testList "samples"
        [
            //second h/w
            testCase "0 в любой степени кроме 0 = 0, первая задача" <| fun _ ->
                let subject = ProgrammingCourse.hw2.firstTask 0.0
                Expect.equal subject 1.0 "result must be equal 1"
            testCase "-1 в нечетной степени равен -1, а в четной 1 (первая задача)" <| fun _ ->
                let subject = ProgrammingCourse.hw2.firstTask -1.0
                Expect.equal subject 1.0 "result must be equal 1"
            testCase "0 в любой степени кроме 0 = 0, вторая задача" <| fun _ ->
                let subject = ProgrammingCourse.hw2.secondTask 0.0
                Expect.equal subject 1.0 "result must be equal 1"
            testCase "-1 в нечетной степени равен -1, а в четной 1 (вторая задача)" <| fun _ ->
                let subject = ProgrammingCourse.hw2.secondTask -1.0
                Expect.equal subject 1.0 "result must be equal 1"
            testCase "Положительное число всегда больше отрицательного, ноль всегда меньше положительных и больше отрицательных" <| fun _ ->
                let subject = ProgrammingCourse.hw2.thirdTask [| -2; -1; 1; 2 |] 4 0
                Expect.equal subject [| 0; 1 |] "result must be equal [| 0; 1 |]"
            testCase "В промежутке положительных чисел никак не могут встретиться отрицательные" <| fun _ ->
                let subject = ProgrammingCourse.hw2.forthTask [| -4; -3; 3; 4 |] 2 5 4
                Expect.equal subject [| 0; 1 |] "result must be equal [| 0; 1 |]"
            testCase "В промежутке отрицательных чисел никак не могут встретиться положительные" <| fun _ ->
                let subject = ProgrammingCourse.hw2.forthTask [| -4; -3; 3; 4 |] -5 -2 4
                Expect.equal subject [| 2; 3 |] "result must be equal [| 2; 3 |]"
            testCase "Иногда могут генерироваться два очень больших числа, для складывании которых необходимо использовать int64, а не int32 (пятая задача)" <| fun _ ->
                let subject = ProgrammingCourse.hw2.fifthTask [| 2147483645; 2147483644 |]
                Expect.equal subject [| 2147483644; 2147483645 |] "result must be equal [| 2147483644; 2147483645 |]"
            testCase "Иногда могут генерироваться два очень больших числа, для складывании которых необходимо использовать int64, а не int32 (шестая задача)" <| fun _ ->
                let subject = ProgrammingCourse.hw2.sixthTask [| 1; 2; 2147483645; 2147483644; 5; 89 |] 2 3
                Expect.equal subject [| 1; 2; 2147483644; 2147483645; 5; 89 |] "result must be equal [| 1; 2; 2147483644; 2147483645; 5; 89 |]"


            //third h/w
            testCase "First Fibonacci number, first task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib1 1
                Expect.equal subject 1 "result must be equal 1"
            testCase "Second Fibonacci number, first task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib1 2
                Expect.equal subject 1 "result must be equal 1"
            testCase "Third Fibonacci number, first task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib1 3
                Expect.equal subject 2 "result must be equal 2"
            testCase "Forth Fibonacci number, first task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib1 4
                Expect.equal subject 3 "result must be equal 3"
            testCase "Fifth Fibonacci number, first task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib1 5
                Expect.equal subject 5 "result must be equal 5"
            testCase "Tenth Fibonacci number, first task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib1 10
                Expect.equal subject 55 "result must be equal 55"

            testCase "First Fibonacci number, second task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib2 1
                Expect.equal subject 1 "result must be equal 1"
            testCase "Second Fibonacci number, second task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib2 2
                Expect.equal subject 1 "result must be equal 1"
            testCase "Third Fibonacci number, second task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib2 3
                Expect.equal subject 2 "result must be equal 2"
            testCase "Forth Fibonacci number, second task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib2 4
                Expect.equal subject 3 "result must be equal 3"
            testCase "Fifth Fibonacci number, second task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib2 5
                Expect.equal subject 5 "result must be equal 5"
            testCase "Tenth Fibonacci number, second task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib2 10
                Expect.equal subject 55 "result must be equal 55"

            testCase "First Fibonacci number, third task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib3 1
                Expect.equal subject 1 "result must be equal 1"
            testCase "Second Fibonacci number, third task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib3 2
                Expect.equal subject 1 "result must be equal 1"
            testCase "Third Fibonacci number, third task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib3 3
                Expect.equal subject 2 "result must be equal 2"
            testCase "Forth Fibonacci number, third task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib3 4
                Expect.equal subject 3 "result must be equal 3"
            testCase "Fifth Fibonacci number, third task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib3 5
                Expect.equal subject 5 "result must be equal 5"
            testCase "Tenth Fibonacci number, third task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib3 10
                Expect.equal subject 55 "result must be equal 55"

            testCase "First Fibonacci number, forth task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib4 1
                Expect.equal subject 1 "result must be equal 1"
            testCase "Second Fibonacci number, forth task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib4 2
                Expect.equal subject 1 "result must be equal 1"
            testCase "Third Fibonacci number, forth task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib4 3
                Expect.equal subject 2 "result must be equal 2"
            testCase "Forth Fibonacci number, forth task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib4 4
                Expect.equal subject 3 "result must be equal 3"
            testCase "Fifth Fibonacci number, forth task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib4 5
                Expect.equal subject 5 "result must be equal 5"
            testCase "Tenth Fibonacci number, forth task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib4 10
                Expect.equal subject 55 "result must be equal 55"

            testCase "First Fibonacci number, fifth task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib5 1
                Expect.equal subject 1 "result must be equal 1"
            testCase "Second Fibonacci number, fifth task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib5 2
                Expect.equal subject 1 "result must be equal 1"
            testCase "Third Fibonacci number, fifth task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib5 3
                Expect.equal subject 2 "result must be equal 2"
            testCase "Forth Fibonacci number, fifth task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib5 4
                Expect.equal subject 3 "result must be equal 3"
            testCase "Fifth Fibonacci number, fifth task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib5 5
                Expect.equal subject 5 "result must be equal 5"
            testCase "Tenth Fibonacci number, fifth task" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib5 10
                Expect.equal subject 55 "result must be equal 55"

            testCase "0 - 1 Fibonacci numbers" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib6 1
                Expect.equal subject [| 0; 1 |] "result must be equal 0, 1"
            testCase "0 - 2 Fibonacci numbers" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib6 2
                Expect.equal subject [| 0; 1; 1 |] "result must be equal 0, 1, 1"
            testCase "0 - 3 Fibonacci numbers" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib6 3
                Expect.equal subject [| 0; 1; 1; 2 |] "result must be equal 0, 1, 1, 2"
            testCase "0 - 4 Fibonacci numbers" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib6 4
                Expect.equal subject [| 0; 1; 1; 2; 3 |] "result must be equal 0, 1, 1, 2, 3"
            testCase "0 - 5 Fibonacci numbers" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib6 5
                Expect.equal subject [| 0; 1; 1; 2; 3; 5 |] "result must be equal 0, 1, 1, 2, 3, 5"
            testCase "0 - 10 Fibonacci numbers" <| fun _ ->
                let subject = ProgrammingCourse.hw3.fib6 10
                Expect.equal subject [| 0; 1; 1; 2; 3; 5; 8; 13; 21; 34; 55 |] "result must be equal 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55"

            let testPropertyHelper n =
                if n < 0 then -n else n
           
            testProperty "Fib2 = Fib3" 
                <| fun (n: int) -> Expect.equal (ProgrammingCourse.hw3.fib2 (testPropertyHelper n)) (ProgrammingCourse.hw3.fib3 (testPropertyHelper n)) "Fib2 must be equal to Fib3"
            testProperty "Fib3 = Fib4" 
                <| fun (n: int) -> Expect.equal (ProgrammingCourse.hw3.fib3 (testPropertyHelper n)) (ProgrammingCourse.hw3.fib4 (testPropertyHelper n)) "Fib3 must be equal to Fib4"
            testProperty "Fib4 = Fib5" 
                <| fun (n: int) -> Expect.equal (ProgrammingCourse.hw3.fib4 (testPropertyHelper n)) (ProgrammingCourse.hw3.fib5 (testPropertyHelper n)) "Fib4 must be equal to Fib5"
        ]


