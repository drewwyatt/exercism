module AnnalynsInfiltration

// Fast attack: a fast attack can be made if the knight is sleeping, as it takes time for him to get his armor on, so he will be vulnerable.
let canFastAttack (knightIsAwake: bool) : bool = not knightIsAwake

// Spy: the group can be spied upon if at least one of them is awake. Otherwise, spying is a waste of time.
let canSpy (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool) : bool =
    knightIsAwake || archerIsAwake || prisonerIsAwake

let canSignalPrisoner (archerIsAwake: bool) (prisonerIsAwake: bool) : bool =
    failwith "Please implement the 'canSignalPrisoner' function"

let canFreePrisoner (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool) (petDogIsPresent: bool) : bool =
    failwith "Please implement the 'canFreePrisoner' function"
