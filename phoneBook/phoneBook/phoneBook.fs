module Logic

    open System
    open System.IO
    open System.Runtime.Serialization.Formatters.Binary
    
    /// Phone book type.
    type PhoneBook () = 

         (*
             Methods to deal with a book.
         *)

        // Printing book.
        member this.PrintBook (book: Map<string, string>) = 
            for record in book do
                printfn "%s, %s" record.Key record.Value

        // Add record to a book.
        // If key already exists, overrides it's value.
        member this.AddToBook(book: Map<string, string>, name: string, phone: string) =            
            book |> Map.add name phone 

        // Find phone by name.
        member this.FindPhoneByName (book: Map<string, string>, name: string) =            
            book |> Map.filter (fun key value -> key = name)
        
        // Find name by phone.
        member this.FindNameByPhone (book: Map<string, string>, phone: string) =
            book |> Map.filter (fun key value -> value = phone)

        // Serializing our DB in file.
        member this.Serialize (book: Map<string, string>)=
            
            // Method to write values into file.
            let writeValue outputStream (x: 'a) =
                let formatter = new BinaryFormatter()
                formatter.Serialize(outputStream, box x)

            use fsOut = new FileStream("Data.dat", FileMode.Create)
            writeValue fsOut book
            fsOut.Close()

        // Deserializing our DB from file.
        member this.Deserialize (book: Map<string, string>) =
            
            // Method to read values from file.
            let readValue inputStream =
                let formatter = new BinaryFormatter()
                let res = formatter.Deserialize(inputStream)
                unbox res

            // Trying to find file.
            try
                let fsIn = new FileStream("Data.dat", FileMode.Open)
                let res : Map<string, string> = readValue fsIn            
                fsIn.Close()
                printfn "Successfully loaded data!"
                res
            with
                | :? System.IO.FileNotFoundException -> printfn "Had not found file!"; book
            

        (*
            Phone book console cycle.
        *)

        // Method to print available options.
        member this.PrintOptinons = 
            printf "----------\n1. Exit\n2. Add record (name and phone)\n3. Find phone by name\n4. Find name by phone\n5. Show database\n6. Save database in file\n7. Load database from file\n----------\n"

        // Method starting the loop. 
        member this.ExecuteCommand (book: Map<string, string>, input: string) =
            
            if (input = "1") then
                Environment.Exit(0)
                book

            else if (input = "2") then
                printfn "Enter name:"
                let name = Console.ReadLine()
                printfn "Enter phone:"
                let phone = Console.ReadLine()
                this.AddToBook(book, name, phone)
                                      
            else if (input = "3") then
                printfn "Enter a name to search phone:"
                let name = Console.ReadLine()
                printfn "%O" (this.FindPhoneByName (book, name))
                book

            else if (input = "4") then
                printfn "Enter a phone to search name:"
                let phone = Console.ReadLine()
                printfn "%O" (this.FindNameByPhone (book, phone))
                book

            else if (input = "5") then
                this.PrintBook (book)|> ignore
                book

            else if (input = "6") then
                this.Serialize(book)
                book

            else if (input = "7") then
                this.Deserialize(book)

            else printfn "Wrong command."; book

        member this.StartLoop (book: Map<string, string>) =
            
            // Print available options.
            this.PrintOptinons

            // Waiting input.
            let input = Console.ReadLine()

            // Executing command and starting another loop.
            this.StartLoop(this.ExecuteCommand(book, input))

    /// Starting program.
    let book = PhoneBook()
    let map = Map.empty
                                  .Add("Sanya","+79119727982")
                                  .Add("Fedos","+79312208944")
                                  .Add("Taya","+79210938070")
    book.StartLoop(map) |> ignore