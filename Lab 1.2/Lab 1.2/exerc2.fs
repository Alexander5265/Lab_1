open System

let rec factorial n =
    if n <= 1 then   // тк факториал 0 или 1 равен 1
        1
    else
        n * factorial (n - 1)   // формула факториала уже с рекурсией

[<EntryPoint>]
let main _ =
    printf "Введите неотрицательное число: "
    let input = Console.ReadLine()

    match Int32.TryParse input with // деалем из инпута число
    | true, number when number >= 0 ->    // паттерн матчинг при тру
        let result = factorial number
        printfn "Факториал числа %d равен %d" number result
    | _ ->    // паттерн матчинг при фалсе
        printfn "Некорректный ввод."

    0