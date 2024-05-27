function Run-BasicTest {
    $b = @{UserName="bob";ProductName="shirt";Quantity=5;Price=5.99}|ConvertTo-Json
    Write-Host "----------------Adding data: $b----------------"
    iwr "http://localhost:5067/transactions" -Method post -Body $b -ContentType "application/json"

    Write-Host "----------------Eporting data----------------"
    Write-Host "### Users ###"
    iwr "http://localhost:5067/users" -Method get
    write-host "### Transactions ###"
    iwr "http://localhost:5067/transactions" -Method get

    write-host "----------------Deleting data----------------"
    iwr "http://localhost:5067/users" -Method Delete
    iwr "http://localhost:5067/transactions" -Method Delete
}

function Run-UserTransactionTest {
    # send data to same user
    $b = @{UserName="bob";ProductName="shirt";Quantity=5;Price=5.99}|ConvertTo-Json
    Write-Host "----------------Adding data: $b----------------"
    $addDataResponse = (iwr "http://localhost:5067/transactions" -Method post -Body $b -ContentType "application/json").Content
    $userid = $addDataResponse | ConvertFrom-Json | Select-Object -ExpandProperty UserID

    # add more data to userid
    $items = @("t-shirt", "pants", "underwear", "hat")
    $items|%{@{ProductName=$_;Quantity=($_.Length);Price=(($_.Length*2)+.99)}|ConvertTo-Json}|%{iwr "http://localhost:5067/transactions/$userid" -Method post -Body $_ -ContentType "application/json"}

    # request transactions for userID
    Write-Host "----------------Exporting Transactions for $userid----------------"
    iwr "http://localhost:5067/transactions/user/$userid" -Method get
    
    Write-Host "----------------Exporting All Transactions----------------"
    iwr "http://localhost:5067/transactions/" -Method get
    
    write-host "----------------Deleting data----------------"
    iwr "http://localhost:5067/users" -Method Delete
}

function Run-BadDataTest {
   # send bad data
   # check output 
}