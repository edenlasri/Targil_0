// Learn more about F# at http://fsharp.org
//Avishag woker
//ID: 207269069
//Eden Lasri
//ID:315485987

open System
open System.IO

type Data() =
    member x.Read() =
        // Read in a file with StreamReader.
        use stream = new StreamReader @"C:\programs\file.txt"
        // Continue reading while valid lines.
        let mutable valid = true
        while (valid) do
            let line = stream.ReadLine()
            if (line = null) then
                valid <- false
            else
                // Display line.
                printfn "%A" line


let HandleBuy ProductName Amount Price path = 
    
    let readFile = File.ReadAllLines(path)
    let result = readFile |> Seq.fold(fun acc x -> acc+x) ""
    let amount = Amount |> float
    let price =Price |> float
    let Cost=amount*price|>string
    let t= [result+ "### BUY " + ProductName+ " ###" + Environment.NewLine+ Cost]
    File.WriteAllLines(path,t)
    
let HandleSell ProductName Amount Price path = 
    let readFile = File.ReadAllLines(path)
    let result = readFile |> Seq.fold(fun acc x -> acc+x) ""
    let amount = Amount |> float
    let price =Price |> float
    let Cost=amount*price|>string
    let t= [result+ "$$$ CELL " + ProductName+ " $$$" + Environment.NewLine+ Cost]
    File.WriteAllLines(path,t)


let readLines (filePath:string) = seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
}


[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!" 
    //open file
    let DictPath="C:\Users\edenl\F#\Targil_0"

    let ArrayFile= System.IO.Directory.GetFiles("C:\Users\edenl\F#\Targil_0", "*.vm")

    let PathFirstFileA = ArrayFile.[0]
    let FirstFileA = (ArrayFile.[0]).Split '\\'
    let FirstFileNameA = ((Array.get FirstFileA (FirstFileA.Length - 1)).Split '.').[0]
    printfn "%s " FirstFileNameA
    printfn "%s " PathFirstFileA


    //Targil_0
    let path = DictPath.Split '\\'
    let Path=DictPath+'\\'.ToString()+(Array.get path (path.Length - 1)) + ".asm"
    printfn "%s " (Path)

   
    File.WriteAllText(Path, FirstFileNameA)
    

    // Read in a file with StreamReader.
    use stream = new StreamReader(PathFirstFileA)
    // Continue reading while valid lines.
    let mutable valid = true
    while (valid) do
        let line = stream.ReadLine()
        if (line = null) then
            valid <- false
        else
            let a=line.Split ' '
            // Display line.
            if (a.[0]="buy") then
                HandleBuy a.[1] a.[2] a.[3] Path
                //printfn "a is less than 20\n"
            else
               //printfn "a is not less than 20\n"
               HandleSell a.[1] a.[2] a.[3] Path
    
    let PathSecondFileB = ArrayFile.[1]
    let SecondFileB = (ArrayFile.[1]).Split '\\'
    let SecondFileNameB = ((Array.get SecondFileB (SecondFileB.Length - 1)).Split '.').[0]
    printfn "%s " SecondFileNameB
    printfn "%s " PathSecondFileB

    // Read in a file with StreamReader.
    use stream = new StreamReader(PathSecondFileB)
    // Continue reading while valid lines.
    let mutable valid = true
    while (valid) do
        let line = stream.ReadLine()
        if (line = null) then
            valid <- false
        else
              let a=line.Split ' '
              // Display line.
              if (a.[0]="buy") then
                  HandleBuy a.[1] a.[2] a.[3] Path
                  //printfn "a is less than 20\n"
              else
                 //printfn "a is not less than 20\n"
                 HandleSell a.[1] a.[2] a.[3] Path
   
    0 // return an integer exit code

