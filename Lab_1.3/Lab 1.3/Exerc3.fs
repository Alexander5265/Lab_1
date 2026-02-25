open System

 // 1. Добавление элемента в конец списка
let rec addElem element list =
    match list with
    | [] -> [ element ]   // Базовый случай
    | head :: tail -> head :: addElem element tail // Сменяет head элемент


 // 2. Удаление первого найденного элемента
let rec delElem element list =
    match list with
    | [] -> []
    | head :: tail ->
        if head = element then
            tail
        else
            head :: delElem element tail


 // 3. Поиск элемента в списке 
let rec contains element list =
    match list with
    | [] -> false
    | head :: tail ->
        if head = element then
            true
        else
            contains element tail


 // 4. Объединение двух списков
let rec connect list1 list2 =
    match list1 with
    | [] -> list2
    | head :: tail ->
        head :: connect tail list2


 // 5. Получение элемента по индексу
let rec getIndex index list =
    match list with
    | [] -> failwith "Индекс вне диапазона"
    | head :: tail ->
        if index = 0 then
            head
        else
            getIndex (index - 1) tail


 // Пример использования
[<EntryPoint>]
let main _ =
    let list1 = [ 1; 2; 3 ]
    let list2 = [ 4; 5 ]

    printfn "Исходный список: %A" list1

    let added = addElem 10 list1
    printfn "После добавления 10: %A" added

    let deleted = delElem 2 list1
    printfn "После удаления 2: %A" deleted

    let exists = contains 3 list1
    printfn "Есть ли 3 в списке? %b" exists

    let connected = connect list1 list2
    printfn "Сцепка списков: %A" connected

    let element = getIndex 1 list1
    printfn "Элемент с индексом 1: %d" element

    0
