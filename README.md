


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

<img width="100%" src="https://user-images.githubusercontent.com/61355143/154852071-e2d8ce7c-b318-41a1-b832-1d118e27d846.gif">
<img width="100%" src="https://user-images.githubusercontent.com/61355143/154852634-1025e6a2-bd65-4d1a-8d99-d3f6aab31e5c.gif">



Here's why:

Learn one way to build applications with Angular and reuse your code and abilities to build apps for any deployment target. For web, mobile web, native mobile and native desktop. Achieve the maximum speed possible on the Web Platform today, and take it further, via Web Workers and server-side rendering. Build features quickly with simple, declarative templates. Extend the template language with your own components and use a wide array of existing components. Get immediate Angular-specific help and feedback with nearly every IDE and editor. All this comes together so you can focus on building amazing apps rather than trying to make the code work. Angular puts you in control over scalability. Meet huge data requirements by building data models on RxJS, Immutable.js or another push-model.

## You will find answers to the following questions

- How to set up a developer environment
- How to create a multi-project .net core application using Dotnet CLI
- How to create client-side front-end Angular UI using Angular CLI for store
- How to use the .NET Core (Backend) Repository Pattern,Unit of Work
- How to use multiple DbContext
- How to implement authorization
- How to Use Lazy Loading
- Automapper ASP.NET How do we use it in Core
- How to create a great looking user interface using Bootstrap
- How to Use an Angular Reactive Form.
- How to adapt Paging, Sorting, Search and Filtering to the project.
- How do we use Redis to store a shopping cart
- How to create an order from the shopping cart
- How do we accept payment via Stripe using the new EU standards for 3D security.




### Built With

This section should list any major frameworks/libraries used to bootstrap your project. Leave any add-ons/plugins for the acknowledgements section. Here are a few examples.

* [Angular](https://angular.io/)
* [Asp.Net Core API](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio)
* [MSSql](https://www.microsoft.com/en-us/sql-server/sql-server-2019)

### Technologies and Methods

- Dotnet CLI
- Client-side front-end using Angular CLI Angular UI
- epository Pattern,Unit of Work pattern
- Using multiple DbContext
- For login and registration ASP.NET Using identity
- Use of Lazy Loading
- Using Automapper
- Bootstrap
- Angular Reactive Form 
- Pagination, Sorting, Search dec Filtering
- Redis
- Stripe



<p align="right">(<a href="#top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* dotnet ECommerce.NET-Angular.API.csproj
  ```sh
  <PackageReference Include="AutoMapper" Version="11.0.1" />
  <PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="11.0.0" />
  <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="5.0.13" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.13">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  </PackageReference>
  <PackageReference Include="Stripe.net" Version="39.90.0" />
  <PackageReference Include="Swashbuckle.AspNetCore" Version="5.6.3" />
  ```
  
* dotnet ECommerce.NET-Angular.Core.csproj
  ```sh
  <PackageReference Include="Microsoft.Extensions.Identity.Stores" Version="5.0.13" />
  ```
  
* dotnet ECommerce.NET-Angular.Infrastructure.csproj
  ```sh
  <PackageReference Include="Microsoft.AspNetCore.Identity" Version="2.2.0" />
  <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="5.0.13" />
  <PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.13" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.13">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  </PackageReference>
  <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.13" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.0.13">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  </PackageReference>
  <PackageReference Include="Microsoft.IdentityModel.Tokens" Version="6.15.1" />
  <PackageReference Include="StackExchange.Redis" Version="2.2.4" />
  <PackageReference Include="Stripe.net" Version="39.90.0" />
  <PackageReference Include="System.IdentityModel.Tokens.Jwt" Version="6.15.1" />
  ```
## Database Configuration (appsettings.json)


```bash
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=[YOUR_LOCAL_DB];Initial Catalog=[YOUR_DB_NAME];Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
    "Redis": "localhost"
  },
```

## Stripe Integration


```bash
 "StripeSettings": {
    "PublishableKey": "[PUBLISH_KEY]",
    "SecretKey": "[SECRET_KEY]"
  },
```

### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

To clone and run this application, The .NET command-line interface (CLI) is a cross-platform toolchain for developing, building, running, and publishing .NET applications.

1. Clone the repo
   ```sh
   https://github.com/BerkayKulak/Commerce-Coop.git
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
$ cd \ECommerce.NET-Angular\ECommerce.NET-Angular.API

# Run the app
$ dotnet run
$ dotnet run --project ./projects/proj1/proj1.csproj
```


<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ROADMAP -->
## Bug / Feature Request

If you find a bug (the website couldn't handle the query and / or gave undesired results), kindly open an issue [here](https://github.com/BerkayKulak/Commerce-Coop/issues/new) by including your search query and the expected result.

If you'd like to request a new function, feel free to do so by opening an issue [here](https://github.com/BerkayKulak/Commerce-Coop/issues/new). Please include sample queries and their corresponding results.

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

Project Link:   (https://github.com/BerkayKulak/Commerce-Coop)

<p align="right">(<a href="#top">back to top</a>)</p>





