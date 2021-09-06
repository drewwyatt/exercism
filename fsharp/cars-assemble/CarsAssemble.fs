module CarsAssemble

// At its lowest speed (`1`), `221` cars are produced each hour.
// The production increases linearly with the speed. So with the speed set to `4`, it should produce `4 * 221 = 884` cars per hour.
// However, higher speeds increase the likelihood that faulty cars are produced, which then have to be discarded. The following table shows how speed influences the success rate:

// - `0`: 0% success rate.
// - `1` to `4`: 100% success rate.
// - `5` to `8`: 90% success rate.
// - `9`: 80% success rate.
// - `10`: 77% success rate.


let productionRatePerHour (speed: int) : float =
    let successRate =
        if speed < 5 then 1.0
        else if speed < 9 then 0.9
        else if speed = 9 then 0.8
        else 0.77

    (float (speed * 221)) * successRate

let workingItemsPerMinute (speed: int) : int =
    (int (productionRatePerHour speed)) / 60
