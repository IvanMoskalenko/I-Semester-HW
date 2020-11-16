namespace HW6

module hw6 =

    [<Measure>] type _rows
    [<Measure>] type _column
    type Coordinates = I of x: int<_rows> * y: int<_column>
    [<Struct>]
    type Matrix =
        val M: int
        val N: int
        val boolMatrix: list<Coordinates>
        new (m, n, list) = {M = m; N = n; boolMatrix = list}

    let readMatrix file =
        let inputArray = System.IO.File.ReadAllLines file
        let rowsNum = inputArray.Length
        let colNum = inputArray.[1].Length
        let array = Array.zeroCreate (rowsNum * colNum)
        let mutable k = 0
        for i = 0 to rowsNum - 1 do
            if inputArray.[i].Length <> colNum then failwith "Matrix has incorrect format"
            let pow = inputArray.[i]
            for j = 0 to colNum - 1 do
                if pow.[j] <> '0' && pow.[j] <> '1' then failwith "Matrix has incorrect format"
                else
                        array.[k] <- (pow.[j], (I(i * 1<_rows>, j * 1<_column>)))
                        k <- k + 1
        let list = Array.toList array
        let resList = List.filter (fun x -> (fst x) = '1') list |> List.map (fun x -> snd x)
        let matrix = Matrix (rowsNum, colNum, resList)
        matrix

    let multiplyMatrix (matrix1: Matrix) (matrix2: Matrix) =
        if matrix1.N <> matrix2.M then failwith "Matrices aren't matched"
        else
            let array = Array.zeroCreate (matrix1.M * matrix2.N)
            let mutable r = 0
            for i = 0 to matrix1.M - 1 do
                for j = 0 to matrix2.N - 1 do
                    for k = 0 to matrix1.N - 1 do
                        let is x = x = (I(i * 1<_rows>, k * 1<_column>))
                        let is2 x = x = (I(k * 1<_rows>, j * 1<_column>))
                        let a = (1, (I(i * 1<_rows>, j * 1<_column>)))
                        let b = (0, (I(i * 1<_rows>, j * 1<_column>)))
                        match List.tryFind is matrix1.boolMatrix with
                        | Some value ->
                            match List.tryFind is2 matrix2.boolMatrix with
                            | Some value ->
                                if r > 0 && array.[r - 1] <> a
                                then array.[r] <- a; r <- r + 1
                                elif r = 0 then array.[r] <- a; r <- r + 1
                            | None ->
                                array.[r] <- b
                                if r > 0 && k = matrix1.N - 1 && array.[r - 1] <> a then r <- r + 1
                                elif r = 0 && k = matrix1.N - 1 then r <- r + 1
                        | None ->
                         array.[r] <- b
                         if r > 0 && k = matrix1.N - 1 && array.[r - 1] <> a then r <- r + 1
                         elif r = 0 && k = matrix1.N - 1 then r <- r + 1
            let list = Array.toList array
            let resList = List.filter (fun x -> (fst x) = 1) list |> List.map (fun x -> snd x)
            let matrix = Matrix (matrix1.M, matrix2.N, resList)
            matrix

    let ourMatrixToArrayOfStrings (matrix: Matrix) =
        let matrixArray = Array.zeroCreate matrix.M
        for i = 0 to matrix.M - 1 do
            for j = 0 to matrix.N - 1 do
                let is x = x = (I(i * 1<_rows>, j * 1<_column>))
                match List.tryFind is matrix.boolMatrix with
                | Some value -> matrixArray.[i] <- matrixArray.[i] + "1"
                | None -> matrixArray.[i] <- matrixArray.[i] + "0"
        matrixArray



