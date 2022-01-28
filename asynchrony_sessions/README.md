#### Interactive sessions in F# with VSC
some code is from https://livebook.manning.com/book/get-programming-with-f-sharp/chapter-36/63

```
> printfn "Loading data!" 
- System.Threading.Thread.Sleep(5000)
- printfn "Loaded Data!"
- printfn "My name is Simon."
- ;;
Loading data!
Loaded Data!
My name is Simon.
val it : unit = ()

> async { 
-     printfn "Loading data!"
-     System.Threading.Thread.Sleep(5000)
-     printfn "Loaded Data!" }
- |> Async.Start 
- printfn "My name is Simon."
- ;;
My name is Simon.
Loading data!
val it : unit = ()

> Loaded Data!
- ;;
> // it seems async session continues above, 
- // have to use ;; to stop
- ;;
> // the code below will generate mistake 
- ;;
> let asyncHello : Async<string> = async { return "Hello" }
- let length = asyncHello.Length
- ;;

  let length = asyncHello.Length
  ------------------------^^^^^^

/home/dmitri/fsharp_async/asynchrony_sessions/stdin(24,25): error FS0039: The type 'Async<T>' does not define the field, constructor or member 'Length'.

> // it is because the the asyncHello was spawned and still 
- // existed in the form of promise when we try to get the 
- // length of it. Let us change the code to : 
- let asyncHello : Async<string> = async { return "Hello" }
- let text = asyncHello |> Async.RunSynchronously
- let lengthTwo = text.Length
- ;;
val asyncHello : Async<string>
val text : string = "Hello"
val lengthTwo : int = 5

> // now it runs , because due to Async.RunSynchronously 
- // we can be sure the asyncHello will have value to 
- // the moment we will try to get it length

```
--------------------------------------

```
~>/asynchrony_sessions$ dotnet fsi asyncThreads.fsx
THREAD 1: Creating async block
THREAD 1: Created async block
THREAD 1: In block
THREAD 1: Starting long running work!
THREAD 1: test is received
THREAD 1: We have got the length of 'HELLO'
~>/asynchrony_sessions$ 

```
----------------------------------------