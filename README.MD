

# Task
Implement the bet and win controllers. You can use any classes in the .Net framework and in the BL folder. 
You can setup static instances of the services if you want to preserve the state between request. Warning, they are not thread safe so stay away from concurrent requests, this is not a web scale implementation :) 

# Specification

Each bet and win belong to a round. Each round can have multiple bet's but only one win. The round should be closed / ended once the win has been submitted. If a player does not have a win then a win with amount = 0 will be submitted for the round in order to close it.

Each call should be idempotent meaning that a bet / win with the same transaction id should only be processed once and even if it is called multiple times. Subsequent calls with the same transaction id should return the same response.

The response should have the players balance as it is after the action has been processed, the returned transaction id is our internal id for the transaction.


## POST /bet
Request
```
{
	"PlayerId": int,
	"Game": string, // Game identifier
	"TransactionId": string, // Unique transaction identifier
	"Currency": string, // ISO currency code
	"Amount": decimal,
	"RoundId": long
}
```
Response:
```
{
	"TransactionId": string, // Unique transaction identifier, can use internal representation
	"Balance": decimal // Players balance
}
```

## POST /win
Request
```
{
	"PlayerId": int,
	"Game": string, // Game identifier
	"TransactionId": string, // Unique transaction identifier
	"Currency": string, // ISO currency code
	"Amount": decimal,
	"RoundId": long
}
```
Response:
```
{
	"TransactionId": string, // Unique transaction identifier, can use internal representation
	"Balance": decimal // Players balance
}
```