module ValentinesDay

type Approval =
    | Yes
    | No
    | Maybe

type Cuisine =
    | Korean
    | Turkish

type Genre =
    | Crime
    | Horror
    | Romance
    | Thriller

type Activity =
    | BoardGame
    | Chill
    | Movie of Genre
    | Restaurant of Cuisine
    | Walk of int

let rateActivity activity =
    match activity with
    | Movie genre when genre = Romance -> Yes
    | Restaurant cuisine when cuisine = Korean -> Yes
    | Restaurant _ -> Maybe
    | Walk kilometers when kilometers < 3 -> Yes
    | Walk kilometers when kilometers < 5 -> Maybe
    | _ -> No
