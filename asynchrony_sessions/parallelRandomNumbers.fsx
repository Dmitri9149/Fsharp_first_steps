// parallel random numbers

let random = System.Random()
let pickANumberAsync = async { return random.Next(10) }
let createFiftyNumbers =
    let workflows = [ for i in 1 .. 50 -> pickANumberAsync ]

    async {
        printf "Begin\n"
        let! numbers = workflows |> Async.Parallel
//        let summ = numbers |> Array.sum
        printf "End\n"
        printfn "Total is %d" (numbers|>Array.sum) }
createFiftyNumbers |> Async.RunSynchronously
// Async.Start will not print "End" and 
// "Total is ......"  !!!! 
// Just "Begin"