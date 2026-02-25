open System

let rec factorial n =
    if n <= 1 then
        1
    else
        n * factorial (n - 1)

[<EntryPoint>]
let main _ =
    printf "Введите неотрицательное число: "
    let input = Console.ReadLine()

    match Int32.TryParse input with // Pattern matching 
    | true, number when number >= 0 -> 
        let result = factorial number
        printfn "Факториал числа %d равен %d" number result
    | _ ->  
        printfn "Некорректный ввод."

    0
