module BookingUpForBeauty

open System

let schedule = DateTime.Parse

let hasPassed appointmentDate =
    (DateTime.Compare(appointmentDate, DateTime.Now)) < 0

let isAfternoonAppointment (appointmentDate: DateTime) =
    appointmentDate.Hour > 11
    && appointmentDate.Hour < 18

let description (appointmentDate: DateTime) =
    sprintf
        "You have an appointment on %s %s."
        (appointmentDate.ToShortDateString())
        (appointmentDate.ToLongTimeString())

let anniversaryDate () =
    DateTime(DateTime.Today.Year, 9, 15, 0, 0, 0)
