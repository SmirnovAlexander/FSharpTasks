module Logic

    open System
    open System.IO
    open System.Runtime.Serialization.Formatters.Binary
    
    // Our phone book type.
    type phoneBook () = 

        (*
            Book member.         
        *)

        // Phone book.
        let mutable mutBook =
            Map.empty

        // Class member phone book.
        member this.book = mutBook

         (*
             Methods to deal with a book.
         *)

        // Printing book.
        member this.printBook = 
            for record in this.book do
                printfn "%s, %s" record.Key record.Value

        // Add record to a book.
        // Addind record only with unique name and phone.
        member this.addToBook(name: string, phone: string) =
            
            let mutable counter = 0
            
            for record in this.book do
                if (record.Key = name || record.Value = phone) then
                    counter <- counter + 1

            if (counter = 0) then
                mutBook <- this.book.Add(name, phone)
                true 
                             else
                false

        // Find phone by name.
        member this.findPhoneByName (name: string) =
            
            let mutable ifExists = false
            let mutable phone = ""
            
            for record in this.book do
                if (record.Key = name) then
                    phone <- record.Value
                    ifExists <- true
            
            if (ifExists) then phone
                          else "No phone matching this name."
        
        // Find name by phone.
        member this.findNameByPhone (phone: string) =
            
            let mutable ifExists = false
            let mutable name = ""
            
            for record in this.book do
                if (record.Value = phone) then
                    name <- record.Key
                    ifExists <- true
            
            if (ifExists) then name
                          else "No name matching this phone."

        // Serializing our DB in file.
        member this.serealize =
            
            // Method to write values into file.
            let writeValue outputStream (x: 'a) =
                let formatter = new BinaryFormatter()
                formatter.Serialize(outputStream, box x)

            let fsOut = new FileStream("Data.dat", FileMode.Create)
            writeValue fsOut this.book
            fsOut.Close()

        // Deserializing our DB from file.
        member this.deserealize =
            
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
                | :? System.IO.FileNotFoundException -> printfn "Had not found file!"; this.book
            

        (*
            Phone book console cycle.
        *)

        // Method to print available options.
        member this.printOptinons = 
            printf "----------\n1. Exit\n2. Add record (name and phone)\n3. Find phone by name\n4. Find name by phone\n5. Show database\n6. Save database in file\n7. Load database from file\n----------\n"

        // Method starting the loop. 
        member this.startBook =
            
            // Exit condition.
            let mutable exit = false

            // While we not put 1 we run.
            while (exit = false) do

                // Print available options.
                this.printOptinons

                // Waiting input
                let input = Console.ReadLine()

                (*
                    Handling input.
                *)

                if (input = "1") then
                    exit <- true

                else if (input = "2") then
                    printfn "Enter name:"
                    let name = Console.ReadLine()
                    printfn "Enter phone:"
                    let phone = Console.ReadLine()
                    if (this.addToBook(name, phone)) then printfn "Succesfully added to book!"
                                                     else printfn "There is already a record with this name or phone."
                                      
                else if (input = "3") then
                    printfn "Enter a name to search phone:"
                    let name = Console.ReadLine()
                    printfn "%s" (this.findPhoneByName name)

                else if (input = "4") then
                    printfn "Enter a phone to search name:"
                    let phone = Console.ReadLine()
                    printfn "%s" (this.findNameByPhone phone)

                else if (input = "5") then
                    this.printBook

                else if (input = "6") then
                    this.serealize

                else if (input = "7") then
                    mutBook <- this.deserealize

                else printfn "Wrong command."

            // Exiting console if exited loop.
            Environment.Exit(0)
    
    
    let book = phoneBook ()
    book.startBook