open System

let getLastDigit number =
    let absNumber = abs number 
    absNumber % 10             

let rec getNumbersFromUser () =
    let rec readNumber () =
        printf "Введите число (или 'q' для завершения): "
        let input = Console.ReadLine() 
        
        if input.ToLower() = "q" then 
            None
        else
            match Int32.TryParse(input) with 
            | (true, number) -> Some number  
            | _ ->                           
                printfn "Ошибка: Введите целое число!"  
                readNumber ()  

    let rec collectNumbers list =
        match readNumber () with
        | Some number -> collectNumbers (number :: list)  
        | None -> List.rev list

    collectNumbers []              


let numbers = getNumbersFromUser () 
let lastDigits = numbers |> Seq.map getLastDigit

printfn "Исходные числа: %A" numbers 
printfn "Последние цифры: %A" (lastDigits |> Seq.toList)  
