# JobsityChat

1 - Clone JobsityChat project in your local
2 - Add StorageAccount to appsettings.json (The key was sent in the email)
3 - Perform a 'EntityFrameworkCore\Update-Database' in your Package Manager Console
4 - Clone botFunction in your local
5 - Replace local.settings.json with the values send by email
6 - Make sure that NotificationEndpoint port is matching with the port you are using for JobsityChat (NotificationEndpoint is a key in local.settings.json)
7 - Run both projects


# Clarifications

1 - JobsityChat is using .Net Identity, but confirmation email was not apply due to the time
2 - Any user can create a room to start chatting
3 - Users can be in several rooms at the same time
4 - Rooms can't be edited or deleted
5 - If the room is disabled no one can join
6 - The project is using an Azure Queue and the reader is an Azure Function
7 - The room is notifing whenever a user join or left the room
8 - If the user try to send a stock message but the value inserted is wrong, he'll receive an 'invalid stock name' notification
9 - I don't know how to calculate a stock so I just applied an average function
10 - The first idea was to deploy everything in Azure but I ran out of time. Sorry