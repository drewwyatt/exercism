module LogLevels

let splitLog (line: string) =
    let pieces = line.Split ":"

    if Array.length pieces = 2 then
        Some(pieces.[0].Trim(), pieces.[1].Trim())
    else
        None

let (|INFO|_|) input =
    match splitLog input with
    | Some ("[INFO]", message) -> Some(message)
    | _ -> None

let (|WARNING|_|) input =
    match splitLog input with
    | Some ("[WARNING]", message) -> Some(message)
    | _ -> None

let (|ERROR|_|) input =
    match splitLog input with
    | Some ("[ERROR]", message) -> Some(message)
    | _ -> None


let message logLine =
    match logLine with
    | INFO message
    | WARNING message
    | ERROR message -> message
    | _ -> failwith (sprintf "could not parse log line '%s'" logLine)


let logLevel logLine =
    match logLine with
    | INFO _ -> "info"
    | WARNING _ -> "warning"
    | ERROR _ -> "error"
    | _ -> failwith (sprintf "could not parse log line '%s'" logLine)

let reformat logLine =
    sprintf "%s (%s)" (message logLine) (logLevel logLine)
