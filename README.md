# WebCrawler
A multithreaded web crawler written in C# using WinForms and DataSets.

## Database Setup
To get the program to run properly, you have to update the connection string in the `WebCrawler.Infrastructure.Database` settings file. 
The connection string should point to a database with the correct schema. The schema can be restored using the `WebCrawler.Infrastructure.Database/schema.sql` file (MSSQL).

