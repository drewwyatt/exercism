module Yacht

type Category =
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

type Die =
    | One
    | Two
    | Three
    | Four
    | Five
    | Six

let dieFrom category =
    match category with
    | Ones -> One
    | Twos -> Two
    | Threes -> Three
    | Fours -> Four
    | Fives -> Five
    | Sixes -> Six
    | _ -> failwith (sprintf "Unhandled category '%A'" category)

let valueOf die =
    match die with
    | One -> 1
    | Two -> 2
    | Three -> 3
    | Four -> 4
    | Five -> 5
    | Six -> 6

let sumAll die dice =
    dice
    |> List.filter (fun d -> d = die)
    |> List.sumBy valueOf

let scoreYacht dice =
    let numberOfFivs =
        dice
        |> List.filter (fun die -> die = Five)
        |> List.length

    if numberOfFivs = 5 then 50 else 0


let score category dice =
    match category with
    | Yacht -> scoreYacht dice
    | _ -> sumAll (dieFrom category) dice
