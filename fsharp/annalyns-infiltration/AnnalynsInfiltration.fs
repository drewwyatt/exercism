module AnnalynsInfiltration

// Fast attack: a fast attack can be made if the knight is sleeping, as it takes time for him to get his armor on, so he will be vulnerable.
let canFastAttack (knightIsAwake: bool) : bool = not knightIsAwake

// Spy: the group can be spied upon if at least one of them is awake. Otherwise, spying is a waste of time.
let canSpy (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool) : bool =
    knightIsAwake || archerIsAwake || prisonerIsAwake

// Signal prisoner: the prisoner can be signalled using bird sounds if the prisoner is awake and the archer is sleeping, as archers are trained in bird signaling so they could intercept the message.
let canSignalPrisoner (archerIsAwake: bool) (prisonerIsAwake: bool) : bool = not archerIsAwake && prisonerIsAwake

// Free prisoner:
//   if the prisoner is awake and the other two characters are sleeping, a sneaky entry into the camp can free the prisoner.
//   This won't work if the prisoner is sleeping, as the prisoner will be startled by the sudden appearance of her friend and the knight and archer will be awoken.
//   The prisoner can also be freed if the archer is sleeping and Annalyn has her pet dog with her, as the knight will be scared by the dog and will withdraw, and the archer can't equip his bow fast enough to prevent the prisoner from being freed.
let canFreePrisoner (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool) (petDogIsPresent: bool) : bool =
    (prisonerIsAwake
     && not archerIsAwake
     && not knightIsAwake)
    || (not archerIsAwake && petDogIsPresent)
