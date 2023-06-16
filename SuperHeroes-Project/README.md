CRUD - Repository pattern - Dependency Injection - SQL Server

Nuget packages
---------
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore

Required Command Line Tool
-------------
dotnet ef

Commands
----------
1. dotnet ef migrations add [...filename]
2. dotnet ef database update


Initial setup
---------------------
1. Create the DataContext file in Data\DataContext
2. Follow the example in this project and define the connection string
3. Double check to make sure the database you're going to create doesn't exist
4. Run -> [dotnet ef migrations add (fileName...[usually for the first migration, name it InitialCreate ])]
5. You'll notice a new folder called migration being created
6. Local DB connection string: "Server=(localdb)\\MSSQLLocalDB;Database=superherodb;Trusted_Connection=true;"
7. Run -> [dotnet ef database update] to trigger a migration process. This will update the database based on your sql scripts

New migrations w/ Entity Framework
------------------
To create a new table
	1. Create a new model
	2. Create a new DbSet<newModel> in the DbContext file
	3. Run -> dotnet ef migrations add [...filename]
	4. Run -> dotnet ef database update

To remove a table
	1. Remove or comment out the table model you're trying to remove. 
		1.1 For example....remove DbSet<newModel> in the DbContext file
	2. Make sure all references to that model has been deleted
	3. Run -> [dotnet ef migrations add (fileName...[name it something like remove_table_name ])]
	4. Run -> dotnet ef database update


Deployment on Azure
------------
Steps to publish the app on Azure
	1. Right click on the project and select Publish

Follow this guide from microsoft
	- https://learn.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-api-management-using-vs?view=aspnetcore-7.0
Note: This does not contain the tutorial to deploy the database


After the site has been deployed...
----------
- Typical convention: 
	- Create 2 appsettings files. One for development and one for production
	- Each one of these should have it's own unique connection string

Azure SQL
----------
- Azure Portal -> Azure SQL Database

