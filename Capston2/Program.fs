// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Domain
open Operations
open Auditing
open System

let customer = 
    Console.Write("Enter customer name: ")
    {Name = Console.ReadLine() }

let balance = 
    Console.Write("Enter beginning balance: ")
    Decimal.Parse(System.Console.ReadLine())



[<EntryPoint>]
let main argv = 
    let mutable account = {Id = System.Guid.NewGuid(); Owner = customer; Balance = balance }
    let consoleDeposit = auditAs "deposit" console deposit
    let consoleWithdraw = auditAs "withdraw" console withdraw

    while true do
        let action = 
            Console.Write("Enter (D)eposit, (W)ithdraw or E(x)it: ")
            Console.ReadLine()
        
        if action = "x" then Environment.Exit 0
        let amount = 
            Console.Write("Enter amount: ")
            Decimal.Parse(Console.ReadLine())

        account <- 
            if action = "d" then account |> consoleDeposit amount
            elif action = "w" then account |> consoleWithdraw amount
            else account

//    printfn "%A" account
    0 // return an integer exit code
