namespace HW6

module hw6 =
    [<Measure>] type _rows
    [<Measure>] type _column
    type Coordinates = I of x: int<_rows> * y: int<_column>
    type Matrix<'a> =
        | Nil
        | Cons of Coordinates * Matrix<Coordinates>




