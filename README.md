# Social Network DB Created.

This project is an example of using MSSQL and SQL Queries.

### What I have used so far:
- Asp.Net Core Web API with `.Net6.0` framework.
- EntityFramwork6 as an ORM and Tools packages.
- MSSQL Server as an Database and SQLServer packages.
- Using DBeaver to display the tables.

## Requirements
- Creating a SocialNetworkDB.
- Messages can be text, image or video.
- Users can add friends.
- Messages can be public or private.
- When user update a message, generate an entry to UserMessageArchive table.
- When user make a request, it will send to FriendShipApproval table.
- Writing a query to return max message senders.

## Installation and Usage

- To get the project :
```
    git clone https://github.com/mhtaldmr/socialnetworkDb-.net.git
```
- To reach the project folder :
```
    cd socialnetworkDb-.net
    cd MuhammetAliDemir.TP.Net.Hw2.Part2
```
- For Creating the DB and sending datas : 
```
    update-database
```

## Design
- Database Tables and Connections
 <br>
<img src="https://github.com/mhtaldmr/socialnetworkDb-.net/blob/main/SocialNetworkDB.png" alt="design" />

## Queries
- Writing 3 query for requirements.
	- For updating messages a [TRIGGER](https://github.com/mhtaldmr/socialnetworkDb-.net/blob/main/Queries/TriggerMessageUpdate.sql) created for Inserting a Message Archive ***BEFORE*** action and then updated.
	- For friend request a [TRIGGER](https://github.com/mhtaldmr/socialnetworkDb-.net/blob/main/Queries/TriggerAfterFriedRequest.sql) created for Inserting a FriendshipApproval ***AFTER*** request action.
	- For Max message senders a [PROCEDURE](https://github.com/mhtaldmr/socialnetworkDb-.net/blob/main/Queries/GetMaxNumberOfMessageSenders.sql) created.

---