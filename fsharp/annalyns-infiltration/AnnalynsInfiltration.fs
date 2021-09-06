module AnnalynsInfiltration

// Fast attack: a fast attack can be made if the knight is sleeping, as it takes time for him to get his armor on, so he will be vulnerable.
let canFastAttack (knightIsAwake: bool) : bool = not knightIsAwake

// Spy: the group can be spied upon if at least one of them is awake. Otherwise, spying is a waste of time.
let canSpy (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool) : bool =
    knightIsAwake || archerIsAwake || prisonerIsAwake

// Signal prisoner: the prisoner can be signalled using bird sounds if the prisoner is awake and the archer is sleeping, as archers are trained in bird signaling so they could intercept the message.
let canSignalPrisoner (archerIsAwake: bool) (prisonerIsAwake: bool) : bool = not archerIsAwake && prisonerIsAwake

let canFreePrisoner (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool) (petDogIsPresent: bool) : bool =
    failwith "Please implement the 'canFreePrisoner' function"
