module Tests
open Expecto
open hw6

[<Tests>]
let boolMatricesMultiply =
    testList "Matrix multiply"
        [
            testCase "Multiplication 3x3 and 3x3 matrices" <| fun _ ->
                let matrix1 = Matrix (3, 3, [Coordinates(0 * 1<hw6._rows>, 0 * 1<hw6._column>); Coordinates(2 * 1<hw6._rows>, 1 * 1<hw6._column>)])
                let matrix2 = Matrix (3, 3, [Coordinates(0 * 1<hw6._rows>, 2 * 1<hw6._column>); Coordinates(2 * 1<hw6._rows>, 1 * 1<hw6._column>)])
                let subject = multiplyMatrix matrix1 matrix2
                Expect.equal subject (Matrix (3, 3, [Coordinates(0 * 1<hw6._rows>, 2 * 1<hw6._column>)])) ""

            testCase "Multiplication 4x4 and 4x4 matrices" <| fun _ ->
                let matrix1 = Matrix (4, 4, [Coordinates(1 * 1<hw6._rows>, 1 * 1<hw6._column>); Coordinates(2 * 1<hw6._rows>, 2 * 1<hw6._column>)])
                let matrix2 = Matrix (4, 4, [Coordinates(1 * 1<hw6._rows>, 0 * 1<hw6._column>)])
                let subject = multiplyMatrix matrix1 matrix2
                Expect.equal subject (Matrix (4, 4, [Coordinates(1 * 1<hw6._rows>, 0 * 1<hw6._column>)])) ""

            testCase "Multiplication 5x5 and 5x5 matrices" <| fun _ ->
                let matrix1 = Matrix (5, 5, [Coordinates(2 * 1<hw6._rows>, 0 * 1<hw6._column>); Coordinates(3 * 1<hw6._rows>, 2 * 1<hw6._column>)])
                let matrix2 = Matrix (5, 5, [Coordinates(0 * 1<hw6._rows>, 4 * 1<hw6._column>)])
                let subject = multiplyMatrix matrix1 matrix2
                Expect.equal subject (Matrix (5, 5, [Coordinates(2 * 1<hw6._rows>, 4 * 1<hw6._column>)])) ""

            testCase "Multiplication 2x5 and 5x2 matrices" <| fun _ ->
                let matrix1 = Matrix (2, 5, [Coordinates(0 * 1<hw6._rows>, 1 * 1<hw6._column>)])
                let matrix2 = Matrix (5, 2, [Coordinates(4 * 1<hw6._rows>, 1 * 1<hw6._column>)])
                let subject = multiplyMatrix matrix1 matrix2
                Expect.equal subject (Matrix (2, 2, [])) ""

            testCase "Multiplication 3x4 and 4x3 matrices" <| fun _ ->
                let matrix1 = Matrix (3, 4, [Coordinates(0 * 1<hw6._rows>, 1 * 1<hw6._column>)])
                let matrix2 = Matrix (4, 3, [Coordinates(1 * 1<hw6._rows>, 1 * 1<hw6._column>); Coordinates(3 * 1<hw6._rows>, 2 * 1<hw6._column>)])
                let subject = multiplyMatrix matrix1 matrix2
                Expect.equal subject (Matrix (3, 3, [Coordinates(0 * 1<hw6._rows>, 1 * 1<hw6._column>)])) ""

            testCase "Multiplication 3x5 and 5x3 matrices" <| fun _ ->
                let matrix1 = Matrix (3, 5, [Coordinates(0 * 1<hw6._rows>, 0 * 1<hw6._column>)])
                let matrix2 = Matrix (5, 3, [Coordinates(0 * 1<hw6._rows>, 0 * 1<hw6._column>); Coordinates(1 * 1<hw6._rows>, 1 * 1<hw6._column>)])
                let subject = multiplyMatrix matrix1 matrix2
                Expect.equal subject (Matrix (3, 3, [Coordinates(0 * 1<hw6._rows>, 0 * 1<hw6._column>)])) ""

            testCase "Multiplication 6x7 and 7x6 matrices" <| fun _ ->
                let matrix1 = Matrix (6, 7, [Coordinates(0 * 1<hw6._rows>, 0 * 1<hw6._column>); Coordinates(4 * 1<hw6._rows>, 4 * 1<hw6._column>)])
                let matrix2 = Matrix (7, 6, [Coordinates(0 * 1<hw6._rows>, 5 * 1<hw6._column>); Coordinates(3 * 1<hw6._rows>, 1 * 1<hw6._column>)])
                let subject = multiplyMatrix matrix1 matrix2
                Expect.equal subject (Matrix (6, 6, [Coordinates(0 * 1<hw6._rows>, 5 * 1<hw6._column>)])) ""
        ]
