open System

let getLastDigit number =
    abs number % 10  
    
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
    |> Seq.choose id                          

let numbers = getNumbersFromUser ()  
let lastDigits = numbers |> Seq.map getLastDigit  

printfn "Последние цифры: %A" lastDigits
