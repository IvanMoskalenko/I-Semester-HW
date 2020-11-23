module hw6

    [<Measure>] type _rows
    [<Measure>] type _column
    [<Struct>]
    type Coordinates =
        val X: int<_rows>
        val Y: int<_column>
        new (x, y) = { X = x; Y = y }
    [<Struct>]
    type Matrix =
        val numOfRows: int
        val numOfCols: int
        val data: list<Coordinates>
        new (m, n, list) = {numOfRows = m; numOfCols = n; data = list}

    let readMatrix file =
        let processLine (str: string) (i, lst) =
            str.Split ' '
            |> Array.fold (
                           fun (j, lst) c ->
                               if c = "1"
                               then (j + 1, Coordinates(i * 1<_rows>, j * 1<_column>) :: lst)
                               elif c = "0"
                               then (j + 1, lst)
                               else failwith "Matrix has incorrect format")
                            (0, lst)

        let rows = System.IO.File.ReadAllLines file
        let lengths = rows |> Array.map String.length |> Array.distinct
        if lengths.Length > 1 then failwith "Matrix has incorrect format"

        let mtx =
            rows
            |> Array.fold (fun (i, lst) str -> (i + 1, processLine str (i, snd lst))) (0, (0, []))

        let matrix = Matrix (fst mtx, fst (snd mtx), snd (snd mtx))
        matrix

    let multiplyMatrix (matrix1: Matrix) (matrix2: Matrix) =
        if matrix1.numOfCols <> matrix2.numOfRows then failwith "Matrices aren't matched"
        else
            let lst =
                [ for i in matrix1.data do
                    for j in matrix2.data do
                        if int i.Y = int j.X then Coordinates(i.X, j.Y) ]
                |> List.distinct
            let matrix = Matrix (matrix1.numOfRows, matrix2.numOfCols, lst)
            matrix

    let boolSparseMatrixToArrayOfStrings (matrix: Matrix) =
        let matrixArray = Array.zeroCreate matrix.numOfRows
        for i = 0 to matrix.numOfRows - 1 do
            for j = 0 to matrix.numOfCols - 1 do
                let is x = x = Coordinates(i * 1<_rows>, j * 1<_column>)
                match List.tryFind is matrix.data with
                | Some value -> matrixArray.[i] <- matrixArray.[i] + "1 "
                | None -> matrixArray.[i] <- matrixArray.[i] + "0 "
        matrixArray

    let multiplyInputMatrices inputPath inputPath2 =
        let matrix1 = readMatrix inputPath
        let matrix2 = readMatrix inputPath2
        multiplyMatrix matrix1 matrix2

    let writeMatrix (matrix: Matrix) outputPath =
        System.IO.File.WriteAllLines ((outputPath), boolSparseMatrixToArrayOfStrings matrix)



