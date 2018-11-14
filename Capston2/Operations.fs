module Operations

open Domain

let deposit amount account = 
    { account with Balance = account.Balance + amount }

let withdraw amount account = 
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount }

let auditAs (operationName:string) (audit:Account -> string -> unit)
    (operation:decimal -> Account -> Account)  (amount:decimal)
    (account:Account) : Account =
    
    audit account (sprintf "Beginning balance $%M Performing %s of $%M " account.Balance operationName amount)
    let newAccount = operation amount account

    let accountChanged = account <> newAccount
    
    if accountChanged then audit newAccount (sprintf "Transaction Accepted.  New balance %M" newAccount.Balance)
    else audit newAccount (sprintf "Transaction rejected")

    newAccount