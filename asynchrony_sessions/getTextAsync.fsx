// var test receive the "Hello" from async code , 
// let! await async execution and binds "HELLO" 
// string to text

let getTextAsync = async { return "HELLO" }
let printHelloWorld =
    async {
                let! text  = getTextAsync
        return printf "%s WORLD \n" text }
printHelloWorld |> Async.Start

