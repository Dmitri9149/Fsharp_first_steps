open System.Threading
let printThread text = 
    printfn "THREAD %d: %s" Thread.CurrentThread.ManagedThreadId 
                            text

let doWork() = 
    printThread "Starting long running work!"                            
    Thread.Sleep 5000
    "HELLO"

let asyncLength : Async<int> = 
    printThread "Creating async block"
    let asyncBlock = 
        async {
            printThread "In block"
            let text = doWork()
            printThread "test is received" 
            return (text + " WORLD").Length }
    printThread "Created async block"
    asyncBlock
    
let length = asyncLength |> Async.RunSynchronously
printThread "We have got the length of 'HELLO'"