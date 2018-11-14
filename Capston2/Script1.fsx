type Customer = { Name:string }
type Account = { Id:System.Guid; Owner:Customer; Balance:decimal }

let deposit amount account = 
    { account with Balance = account.Balance + amount }

let withdraw amount account = 
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount }

let fileSystemAudit account message = 

let console account message =
    printfn "Account %O: %O %s " 
        account.Id System.DateTime.Now message 

let auditAs (operationName:string) (audit:Account -> string -> unit)
    (operation:decimal -> Account -> Account)  (amount:decimal)
    (account:Account) : Account =
    
    audit account (sprintf "Beginning balance $%M Performing %s of $%M " account.Balance operationName amount)
    let newAccount = operation amount account

    let accountChanged = account <> newAccount
    
    if accountChanged then audit newAccount (sprintf "Transaction Accepted.  New balance %M" newAccount.Balance)
    else audit newAccount (sprintf "Transaction rejected")

    newAccount



let withdrawConsoleAudit = auditAs "withdraw" 
let customer = { Name = "Brian" }
let account = { Id = System.Guid.Empty; Owner = customer; Balance = 100M }
let account2 = account |> withdraw 25M |> deposit 50M
let con = console account "Withdraw"

let consoleWithdraw = auditAs "withdraw" console withdraw
let consoleDeposit = auditAs "Deposit" console deposit

account |> consoleWithdraw 25M |> consoleDeposit 50M |> consoleWithdraw 200M