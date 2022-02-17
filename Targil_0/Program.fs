// Learn more about F# at http://fsharp.org

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
    let outputFileWriter = new StreamWriter(path, true)
    outputFileWriter.WriteLine("this is written in the output file")

    printfn "m = %f " 4.0



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

    //let file = File.Create(Path)
    //let writeFile = File.WriteAllText(Path, FirstFileNameA)
    //let outputFileWriter = new StreamWriter(Path, true)
    //outputFileWriter.WriteLine("this is written in the output file")

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
               printfn "%A" line
    
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
            // Display line.
            printfn "%A" line
   
    0 // return an integer exit code

