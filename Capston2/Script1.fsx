type Customer = { Name:string }
type Account = { Id:System.Guid; Owner:Customer; Balance:decimal }

let deposit amount account = 
    { account with Balance = account.Balance + amount }

let withdraw amount account = 
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount }

let fileSystemAudit account message = 

let console account message =
    printfn "Account %A: Performed operation %s.  Balance is now $%M" account.Id message account.Balance

let auditAs (operationName:string) (audit:Account -> string -> unit)
    (operation:decimal -> Account -> Account)  (amount:decimal)
    (account:Account) : Account =


let withdrawConsoleAudit = auditAs "withdraw" 
let customer = { Name = "Brian" }
let account = { Id = System.Guid.Empty; Owner = customer; Balance = 100M }
let account2 = account |> withdraw 25M |> deposit 50M
let con = console account "Withdraw"