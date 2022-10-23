# Candy Shop

#### By Skylan Lew

#### Independent Project 11 for Epicodus

## Technologies Used

- C#
- .NET 5
- ASP.NET Core MVC
- Entity
- Identity
- MySQL
- Javascript
- HTML

## Description

This application is a flavor and treat tracker for a candy store. Users may access the site anonymously to view a list of all the treats and flavors, or may register and log in to add treats and flavors to the list.

The user may click any treat to view its flavors, and any flavor to view its treats.

Logged in users may edit and delete treats/flavors, and delete links between treats and flavors. When a treat or flavor is deleted, its associated links are removed as well.

## Setup/Installation Requirements


- Create a file named `appsettings.json` in the project folder `/CandyShop/`
- Put the following code inside `appsettings.json`, making sure to set your uid and pwd:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=candyshop;uid=YOURUSERNAME;pwd=YOURPASSWORD;"
  }
}
```

### Requires

- [.NET 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) - <https://dotnet.microsoft.com/en-us/download/dotnet/5.0>
- MySQL - Recommend [MySQL Workbench](https://dev.mysql.com/downloads/workbench/)

### Download/Run Instructions (git)

- clone: `$ git clone https://github.com/doublespoiler/candyshop.git` or Code>Download ZIP
- navigate to project folder: `$ cd /CandyShop`
- restore: `$ dotnet restore`
- build: `$ dotnet build`
- Apply migrations: `$ dotnet ef database update`
- run: `$ dotnet run`
- Access the site by visiting http://localhost:5000

## Known Bugs

## License

[MIT](https://choosealicense.com/licenses/mit/)
`[MIT](https://choosealicense.com/licenses/mit/)`

Copyright (c) 2022 Skylan Lew
