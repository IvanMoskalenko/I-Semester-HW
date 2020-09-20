module Tests


open Expecto
open ProgrammingCourse

[<Tests>]
let tests =
    testList "samples"
        [   testCase "0 в любой степени кроме 0 = 0, первая задача" <| fun _ ->
                let subject = ProgrammingCourse.hw2.first_task 0.0
                Expect.equal subject 1.0 "result must be equal 1"
            testCase "-1 в нечетной степени равен -1, а в четной 1 (первая задача)" <| fun _ ->
                let subject = ProgrammingCourse.hw2.first_task -1.0
                Expect.equal subject 1.0 "result must be equal 1"
            testCase "0 в бой степени кроме 0 = 0, вторая задача" <| fun _ ->
                let subject = ProgrammingCourse.hw2.second_task 0.0
                Expect.equal subject 1.0 "result must be equal 1"
            testCase "-1 в нечетной степени равен -1, а в четной 1 (вторая задача)" <| fun _ ->
                let subject = ProgrammingCourse.hw2.second_task -1.0
                Expect.equal subject 1.0 "result must be equal 1"
            testCase "Положительное число всегда больше отрицательного, ноль всегда меньше положительных и больше отрицательных" <| fun _ ->
                let subject = ProgrammingCourse.hw2.third_task [| -2; -1; 1; 2 |] 4 0
                Expect.equal subject [| 0; 1 |] "result must be equal [| 0; 1 |]"
            testCase "В промежутке положительных чисел никак не могут встретиться отрицательные" <| fun _ ->
                let subject = ProgrammingCourse.hw2.forth_task [| -4; -3; 3; 4 |]  [| 2; 5 |]  4
                Expect.equal subject [| 0; 1 |] "result must be equal [| 0; 1 |]"
            testCase "В промежутке отрицательных чисел никак не могут встретиться положительные" <| fun _ ->
                let subject = ProgrammingCourse.hw2.forth_task [| -4; -3; 3; 4 |] [| -5; -2 |] 4
                Expect.equal subject [| 2; 3 |] "result must be equal [| 2; 3 |]"
            testCase "Иногда могут генерироваться два очень больших числа, для складывании которых необходимо использовать int64, а не int32 (пятая задача)" <| fun _ ->
                let subject = ProgrammingCourse.hw2.fifth_task [| 2147483645; 2147483644 |]
                Expect.equal subject [| 2147483644; 2147483645 |] "result must be equal [| 2147483644; 2147483645 |]"
            testCase "Иногда могут генерироваться два очень больших числа, для складывании которых необходимо использовать int64, а не int32 (шестая задача)" <| fun _ ->
                let subject = ProgrammingCourse.hw2.sixth_task [| 1; 2; 2147483645; 2147483644; 5; 89 |] 2 3
                Expect.equal subject [| 1; 2; 2147483644; 2147483645; 5; 89 |] "result must be equal [| 1; 2; 2147483644; 2147483645; 5; 89 |]" ]
