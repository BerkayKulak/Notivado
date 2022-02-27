


<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

<img width="100%" src="https://user-images.githubusercontent.com/61355143/155889704-e3a22007-4c5f-4db0-a5ac-5f9f3b6ad366.gif">

<img width="100%" src="https://user-images.githubusercontent.com/61355143/155890691-889fc839-2e49-4272-aec9-fecbb7be53ec.gif">


Here's why:

The Todo application allows each user to create, edit, and delete their own unique todo list.

To-Do App is a task management application. It allows users to manage their tasks from a smartphone, tablet and computer. The technology is produced by the team behind   Wunderlist, which was acquired by Microsoft, and the stand-alone apps feed into the existing Tasks feature of the Outlook product range.

## You will find answers to the following questions

- How to develop an api project with a layered architecture for token-based authentication?
- How can we protect our other APIs with token-based authentication?
- Json Web Belirteci (JWT) nedir?
- How to use the .NET Core (Backend) Repository Pattern,Unit of Work
- What is an Access Token and a Refresh Token? what does it do ?
- How to implement authorization
- How to Use Lazy Loading
- Automapper ASP.NET How do we use it in Core
- How to create a great looking user interface using Bootstrap
- How to Use an Angular Reactive Form.
- What is a claim?
- How can we sign json web tokens symmetrically?
- ASP.Net how to add CORS (Cross-Origin Resource Sharing) feature to our api projects?
- What is Error Handling




### Built With

This section should list any major frameworks/libraries used to bootstrap your project. Leave any add-ons/plugins for the acknowledgements section. Here are a few examples.

* [Angular](https://angular.io/)
* [Asp.Net Core API](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio)
* [MSSQL](https://www.microsoft.com/en-us/sql-server/sql-server-2019)

### Software Engineer Assessment
- .Net Core ✅
- Dependencjy Injection ✅
- Couchbase 💥
- Swagger ✅
- NUnit and Mockito ✅
- Docker  💥

### Technologies and Methods

- N-Tier Architecture ✅
- Client-side front-end using Angular CLI Angular UI ✅
- Repository Pattern, Unit of Work pattern ✅
- MSSQL ✅
- JWT Token ✅
- Use of Lazy Loading ✅
- Using Automapper ✅
- NLog library ✅
- Fluent Validation ✅
- Fluent API ✅
- Global Error Handling ✅
- Filters ✅
- Swagger Documentation ✅
- Dotnet CLI ✅
- SOLID ✅
- CORS Security ✅
- Autofac ✅
- Comment lines ✅
- Nunit Test ✅
- Angular Reactive Form ✅ 
- Login and Register Forms ✅




<p align="right">(<a href="#top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started


### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* dotnet TodoApp.API.csproj
  ```sh
  <PackageReference Include="Autofac" Version="6.3.0" />
  <PackageReference Include="Autofac.Extensions.DependencyInjection" Version="7.2.0" />
  <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="5.0.14" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.14">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  </PackageReference>
  <PackageReference Include="NLog" Version="4.7.14" />
  <PackageReference Include="NLog.Web.AspNetCore" Version="4.14.0" />
  <PackageReference Include="Swashbuckle.AspNetCore" Version="5.6.3" />
  <PackageReference Include="System.Data.SqlClient" Version="4.8.3" />
  ```
  
* dotnet TodoApp.Core.csproj
  ```sh
  <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="5.0.14" />
  <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="5.0.14" />
  <PackageReference Include="Microsoft.AspNetCore.Mvc" Version="2.2.0" />
  ```
  
* dotnet TodoApp.NUnitTest.csproj
  ```sh
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.9.4" />
  <PackageReference Include="Moq" Version="4.16.1" />
  <PackageReference Include="NUnit" Version="3.13.1" />
  <PackageReference Include="NUnit3TestAdapter" Version="3.17.0" />
  <PackageReference Include="coverlet.collector" Version="3.0.2" />
  ```
  
  
## Database Configuration (appsettings.json)


```bash
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=[YOUR_LOCAL_DB];Initial Catalog=[YOUR_DB_NAME];Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
    "Redis": "localhost"
  },
```


### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

To clone and run this application, The .NET command-line interface (CLI) is a cross-platform toolchain for developing, building, running, and publishing .NET applications.

1. Clone the repo
   ```sh
   https://github.com/BerkayKulak/TodoApp.git
   ```
2. Update Nuget packages
   ```sh
   dotnet tool update <PACKAGE_ID> -g|--global
   ```
3. Add Migration
   ```js
   dotnet ef migrations add InitialCreate
   ```
4. Update Database
   ```js
   dotnet ef database update
   ```

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

```bash
# Go into the repository API
$ cd \TodoApp\TodoApp.API

# Run the app
$ dotnet run
$ dotnet run --project ./projects/proj1/proj1.csproj
```


<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ROADMAP -->
## Bug / Feature Request

If you find a bug (the website couldn't handle the query and / or gave undesired results), kindly open an issue [here](https://github.com/BerkayKulak/TodoApp/issues/new) by including your search query and the expected result.

If you'd like to request a new function, feel free to do so by opening an issue [here](https://github.com/BerkayKulak/TodoApp/issues/new). Please include sample queries and their corresponding results.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Berkay Kulak - (https://www.linkedin.com/in/berkay-kulak-3442311b1/) - kulakberkay15@gmail.com

Project Link:   (https://github.com/BerkayKulak/TodoApp)

<p align="right">(<a href="#top">back to top</a>)</p>



## API 

<img width="100%" src="https://user-images.githubusercontent.com/61355143/155894923-c2c285c1-d447-410c-9b9e-d0f085ddd2ab.png">


## VALIDATIONS COMPLETED
1) failure to register the same user
<img width="100%" src="https://user-images.githubusercontent.com/61355143/155894984-e04c1023-c94c-481e-b971-7e9064ebbdc0.png">

2) if the email or password is incorrect
<img width="100%" src="https://user-images.githubusercontent.com/61355143/155895143-dffe76fe-5440-44d3-b896-1602f76aad4f.png">

## TODO TASK
1) Each user has a different TODO+

A PERSON
<img width="100%" src="https://user-images.githubusercontent.com/61355143/155895296-afb6a013-7cc3-4343-b466-f8001fc4bf5d.png">

B PERSON
<img width="100%" src="https://user-images.githubusercontent.com/61355143/155895390-a6cd8a7a-9ee7-4952-ad79-8340c8501448.png">

## UNIT TEST
All tests are Successful
<img width="100%" src="https://user-images.githubusercontent.com/61355143/155895690-9ffb3ac4-faf4-45b2-8394-948bb5ffd59d.gif">

