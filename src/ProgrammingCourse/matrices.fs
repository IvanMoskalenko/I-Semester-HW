namespace ProgrammingCourse
module matrices =
    type Matrix = { values: int[,] }
    with
        static member ofArray2D (values: int [,]) = 
            { values = values }
        static member sizes matrix =
            let rows = matrix.values.[*,0].Length
            let cols = matrix.values.[0,*].Length
            (rows, cols)
        static member identityMatrix rows cols =
            let array2d = Array2D.init rows cols (fun x y -> if x = y then 1 else 0)
            { values = array2d }
        static member isMatched matrix1 matrix2 = 
            let row1Count = matrix1.values.[0,*].Length
            let col2Count = matrix2.values.[*,0].Length
            row1Count = col2Count
        static member (*) (matrix1, (matrix2: Matrix)) =
            if Matrix.isMatched matrix1 matrix2 then
                let row1Count = matrix1.values.[*,0].Length
                let col2Count = matrix2.values.[0,*].Length
                let values = Array2D.zeroCreate row1Count col2Count
                for r in 0..row1Count-1 do
                    for c in 0..col2Count-1 do
                        let row = Array.toList matrix1.values.[r,*]
                        let col = Array.toList matrix2.values.[*,c]       
                        let cell = List.fold2 (fun acc val1 val2 -> acc + (val1 * val2)) 0 row col
                        values.[r,c] <- cell       
                { values = values }       
            else failwith "Matrix1 is not matched to Matrix2"
        static member (^^) (matrix, value) =
            let inRecPow m p =
                let rec recPow acc p =
                    match p with
                    | x when x > 0 ->
                        let nextAcc = acc*m
                        recPow nextAcc (x-1)
                    | _ -> acc
                let dim = Matrix.sizes matrix
                let colCount = snd dim
                let rowCount = fst dim
                let u = Matrix.identityMatrix rowCount colCount
                recPow u p
            let powMatrix = inRecPow matrix value
            { values = powMatrix.values }
    end

