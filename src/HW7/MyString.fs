module myString

type MyString = myList.MyList<char>

let concatenate (str1: MyString) (str2: MyString) : MyString =
    myList.concatenate str1 str2

let toMyString (str: string) : MyString =
    Seq.toList str |> myList.toMyList


