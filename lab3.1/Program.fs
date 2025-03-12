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

    Seq.initInfinite (fun _ -> readNumber ()) 
    |> Seq.takeWhile Option.isSome            
    |> Seq.map Option.get                   


let numbers = getNumbersFromUser () 

let numbersList = numbers |> Seq.toList

let lastDigits = numbersList |> Seq.map getLastDigit

printfn "Исходные числа: %A" numbersList  
printfn "Последние цифры: %A" (lastDigits |> Seq.toList)  