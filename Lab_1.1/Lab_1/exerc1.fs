open System

(*  функция читает числа и накапливает модули в списке acc *)
let rec readNumbs acc =   // acc - аккумулятор, сюда складываем временный результат
    printf "Введите число (или нажмите Enter для завершения): "
    let input = Console.ReadLine()

    if String.IsNullOrWhiteSpace input then
        acc   // если ввели enter, то запрос на ввод останавливается и список acc возвращается с полученными данными
    else
        match Double.TryParse input with   // превращение строки в доубл
        | true, number ->   // все норм, вычисляем модуль числа
            let absoluteValue = abs number
            readNumbs (absoluteValue :: acc)   // добавляем в список найденный модуль (:: добавляет в начало списка)
        | false, _ ->   // все не норм, повторяем ввод с тем же списком acc
            printfn "Некорректный ввод. Попробуйте снова."
            readNumbs acc 

(* точка ввода программы (ее начало) *)
[<EntryPoint>] 
let main _ =
    let absoluteValues =
        readNumbs []    // создаем пустой список ( |> означает "передаем результат дальше")
        |> List.rev // превращаем список в реверсед, чтобы восстановить порядок 

    printfn "Список модулей введённых чисел:"
    absoluteValues |> List.iter (printfn "%f") (* List.iter - проход по каждому эл списка || printfn "%f" - вывод чисел float *)

    0