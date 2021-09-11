module BookingUpForBeauty

open System

let schedule = DateTime.Parse

let hasPassed appointmentDate =
    (DateTime.Compare(appointmentDate, DateTime.Now)) < 0

let isAfternoonAppointment (appointmentDate: DateTime) : bool =
    failwith "Please implement the 'isAfternoonAppointment' function"

let description (appointmentDate: DateTime) : string =
    failwith "Please implement the 'description' function"

let anniversaryDate () : DateTime =
    failwith "Please implement the 'anniversaryDate' function"
