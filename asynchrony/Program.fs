open System
open System.IO

let printTotalFileBytes path =
    async {
        let! bytes = File.ReadAllBytesAsync(path) |> Async.AwaitTask
        let fileName = Path.GetFileName(path)
        printfn "File %s has %d bytes" fileName bytes.Length 
}

[<EntryPoint>]

let main argv =
    printTotalFileBytes "data/Alice.txt"
    |> Async.RunSynchronously

    Console.Read() |> ignore
    0


