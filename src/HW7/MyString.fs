module myString
open myList

type MyString = MyList<char>

let concatenateMyString (str1: MyString) (str2: MyString) : MyString =
    concatenateMyLists str1 str2

let transformSystemStringToMyString (str: string) : MyString =
    Seq.toList str |> transformSystemListToMyList

