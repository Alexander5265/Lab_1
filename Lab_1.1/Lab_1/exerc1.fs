open System

let rec readNumbs acc =   // Cюда складываем временный результат
    printf "Введите число (или нажмите Enter для завершения): "
    let input = Console.ReadLine()

    if String.IsNullOrWhiteSpace input then
        acc 
    else
        match Double.TryParse input with
        | true, number ->
            let absoluteValue = abs number
            readNumbs (absoluteValue :: acc)
        | false, _ ->
            printfn "Некорректный ввод. Попробуйте снова."
            readNumbs acc 

[<EntryPoint>] 
let main _ =
    let absoluteValues =
        readNumbs []    
        |> List.rev

    printfn "Список модулей введённых чисел:"
    absoluteValues |> List.iter (printfn "%f")

    0
