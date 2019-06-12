module Logic
   
    open FSharp.Data
    open System.Net
    open System.IO

    // Gets web page, downloads all pages that have their links on input page
    // and prints information about every page in format "url --- number of symbols".
    let numberOfLettersOnInnerPages (page: string) =
    
        // Getting html of current page.
        let html = HtmlDocument.Load(page)

        // Filtering html to get links.
        let links = 
            html.Descendants ["a"]
            |> Seq.choose (fun x -> 
                   x.TryGetAttribute("href")
                   |> Option.map (fun a -> a.Value()))
            |> Seq.filter (fun x -> 
                        x.StartsWith("http"))
            |> Seq.toList
       
         // Asynchroniously getting page content and printing information.        
        let fetchAsync (url: string) =
            async {                
                let request = WebRequest.Create(url)
                use! response = request.AsyncGetResponse()
                use stream = response.GetResponseStream()
                use reader = new StreamReader(stream)
                let html = reader.ReadToEnd()
                do printfn "Read %d characters for %s..." html.Length url
                return url
            }
       
        // Executing fetchAsync method for every link.
        Async.Parallel (links |> List.map (fun site -> site |> fetchAsync)) |> Async.RunSynchronously