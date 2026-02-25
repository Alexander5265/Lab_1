open System

//  Функция читает числа и накапливает модули в списке acc 
let rec readNumbs acc =   // Acc - это аккумулятор, сюда складываем временный результат
    printf "Введите число (или нажмите Enter для завершения): "
    let input = Console.ReadLine()

    if String.IsNullOrWhiteSpace input then
        acc 
    else
        match Double.TryParse input with   // Превращение строки в double
        | true, number ->   // Вычисляем модуль числа
            let absoluteValue = abs number
            readNumbs (absoluteValue :: acc)
        | false, _ ->   // Повторяем ввод с тем же списком acc
            printfn "Некорректный ввод. Попробуйте снова."
            readNumbs acc 

// Точка ввода программы (ее начало)
[<EntryPoint>] 
let main _ =
    let absoluteValues =
        readNumbs []    // Создание пустого списка ( |> означает "передаем результат дальше")
        |> List.rev // Превращения списка в reversed для восстонавления правильного порядка

    printfn "Список модулей введённых чисел:"
    absoluteValues |> List.iter (printfn "%f") // List.iter - проход по каждому эл списка || printfn "%f" - вывод чисел float

    0
