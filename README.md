# Commify Demo
- This is a .NET 9 framework project for the Commify interview cycle utilizing Blazor Server pages/components for the frontend.

# Tools & Software
- VS 2022
- .NET 9
- Blazor Server
- MSSQL Server 2022
- Docker w/ Docker Desktop
- Linux or WSL if using Windows OS

# Solution Name
- TaxDemo

# Projects
- TaxDemo
- TaxDemo.Tests

# NuGet Packages
- coverlet.collector (Version 6.0.4)
- Microsoft.AspNetCore.Components.QuickGrid (Version 9.0.6)
- Microsoft.AspNetCore.Identity.EntityFrameworkCore (Version 9.0.6)
- Microsoft.AspNetCore.Identity.UI (Version 9.0.6)
- Microsoft.Data.SqlClient (Version 6.0.2)
- Microsoft.EntityFrameworkCore.Sqlite (Version 9.0.0)
- Microsoft.EntityFrameworkCore.SqlServer (Version 9.0.3)
- Microsoft.EntityFrameworkCore.Tools (Version 9.0.3)
- Microsoft.NET.Test.Sdk (Version 17.14.1)
- Microsoft.VisualStudio.Azure.Containers.Tools.Targets (Version 1.22.1-Preview.1)
- Microsoft.VisualStudio.Web.CodeGeneration.Design (Version 9.0.0)
- NUnit (Version 4.3.2)
- NUnit.Analyzers (Version 4.9.2)
- NUnit3TestAdapter (Version 5.0.0)
- Selenium.WebDriver (Version 4.33.0)

# Setup Process
- From the TaxDemo root folder, run 'docker compose up' to launch sqlserver container and the identitycontextdb container.
  - Check the compose.yml file in the root folder for password placeholder items for the sqlserver PW and identity, replace them and adjust ports if needed.

- If desired, test the connection to the sqlserver container with SSMS or another provider.

- Run 'dotnet ef database update' to attach the migrations to the database container or you can use Visual Studio's Connected Services Window as well.

- Once migrations have been applied, launch the app w/o debugging if you want to run the TaxDemo.Tests project.
  - IISExpress was used for launching in development
  - Debug mode will work for running an app. There is an exception caught dealing with Blazor's NavManager NavigateTo() method that is a current known bug from the Blazor dev team. Continuing past the exception works fine.

- Register with an example email and password, click the confirmation hyperlink in the account confirmation page and the site pages will be accessible afterwards.

- If you wish to run the tests project, the TaxDemo.Tests/TestSetups/TestWebDriverBase.cs has two placeholder passwords for the user and conn string, adjust accordingly and port numbers as well.
  - IISExpress was used for launching in development w/ port 44345
  - If tests for the webdriver cannot locate the localhost address, check which port the app is defaulting to when launching w/o debugging and use that port in the TestWebDriverBase.CS file.
  - If you wish to run the web page tests w/o the GUI, change "chromeOptions.AddArguments("--start-maximized");" to "chromeOptions.AddArguments("--headless");" in TaxDemo.Tests/TestSetups/TestWebDriverBase.cs
