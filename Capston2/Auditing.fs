module Auditing

open Domain

//let fileSystemAudit account message = 

let console account message =
    printfn "Account %O: %O %s " 
        account.Id System.DateTime.Now message 

