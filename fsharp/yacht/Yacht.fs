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

let scoreFullHouse dice =
    let mutable expectedCounts = [ 2; 3 ]

    let countAvaiable (_, count) =
        if List.contains count expectedCounts then
            expectedCounts <- List.filter (fun c -> c <> count) expectedCounts
            true
        else
            false


    let counts =
        dice
        |> List.toSeq
        |> Seq.countBy id
        |> Seq.filter countAvaiable

    if (Seq.length counts) = 2 then
        List.sumBy valueOf dice
    else
        0

let scoreFourOfAKind dice =
    let result =
        dice
        |> List.toSeq
        |> Seq.countBy id
        |> Seq.tryFind (fun (_, count) -> count > 3)

    match result with
    | Some (die, _) -> (valueOf die) * 4
    | None -> 0

let scoreStraight category dice =
    let values = List.map valueOf dice |> List.sort

    match (category, values) with
    | (LittleStraight, [ 1; 2; 3; 4; 5 ]) -> 30
    | (BigStraight, [ 2; 3; 4; 5; 6 ]) -> 30
    | _ -> 0



let scoreYacht dice =
    let numberOfFivs =
        dice
        |> List.filter (fun die -> die = Five)
        |> List.length

    if numberOfFivs = 5 then 50 else 0

let score category dice =
    match category with
    | FullHouse -> scoreFullHouse dice
    | FourOfAKind -> scoreFourOfAKind dice
    | LittleStraight
    | BigStraight -> scoreStraight category dice
    | Yacht -> scoreYacht dice
    | _ -> sumAll (dieFrom category) dice
