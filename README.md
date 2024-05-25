![](https://github.com/KarmaScripter/Badger/blob/main/Resources/Images/GitHubImages/Badger.png)

## Badger is an open source data analysis application for EPA Analysts developed in C# using WPF and released under the MIT license
####

## Badger Features

- Mutliple data providers including SQLite, MS Access, SQL CE, and SQL Servers Express Edition.
- Charting and reporting.
- Its own internal web browser with searches optimized for researching data in the government domain with [Baby Browser](https://github.com/KarmaScripter/Baby/blob/main/README.md)
- Pre-defined schema for 100 actively used environmental budget data tables.
- Editors for SQLite, SQL Compact Edition, MS Access, SQL Server Express.
- Excel-like user interface over real databases.
- Mapping for congressional earmark reporting and montioring of polluction sites.
- Easy access to environmental program project descriptions and statutory authority.
- Quick budget and accouting calculations directly on bound data.
- Easily add agency/region/division-specific branding.
- The winforms version of Badger is BugdetExecution and it can be found [here](https://github.com/KarmaScripter/BudgetExecution/tree/main?tab=readme-ov-file) 

## Providers

- SQLite is a C-language library that implements a small, fast, self-contained, high-reliability, full-featured, SQL database engine. 
- SQL CE is a discontinued but still useful relational database produced by Microsoft for applications that run on mobile devices and desktops. 
- SQL Server Express Edition is a scaled down, free edition of SQL Server, which includes the core database engine.
- MS Access is a database management system (DBMS) from Microsoft that combines the relational Access Database Engine (ACE) with a graphical user interface and software-development tools. [more here](https://www.microsoft.com/en-us/microsoft-365/access)


## System requirements

- You need [VC++ 2019 Runtime](https://aka.ms/vs/17/release/vc_redist.x64.exe) 32-bit and 64-bit versions

- You will need .NET 6.

- You need to install the version of VC++ Runtime that Baby Browser needs. Since we are using CefSharp 106, according to [this](https://github.com/cefsharp/CefSharp/#release-branches) we need the above versions


## Getting started

- See the [Compilation Guide](Resources/Github/Compilation.md) for steps to get started.


## Documentation

- [User Guide](Resources/Github/Users.md)
- [Compilation Guide](Resources/Github/Compilation.md)
- [Configuration Guide](Resources/Github/Configuration.md)
- [Distribution Guide](Resources/Github/Distribution.md)


## Code

- Badger uses CefSharp 106 for Baby Browser and is built on NET 6
- Badger supports AnyCPU as well as x86/x64 specific builds
- [Controls](https://github.com/KarmaScripter/Badger/tree/main/Controls) - main UI layer and associated controls and related functionality.
- [Enumerations](https://github.com/KarmaScripter/Badger/tree/main/Enumerations) - various enumerations used for budgetary accounting.
- [Extensions](https://github.com/KarmaScripter/Badger/tree/main/Extensions)- useful extension methods for budget analysis by type.
- [Clients](https://github.com/KarmaScripter/Badger/tree/main/Clients) - other tools used and available.
- [Ninja](https://github.com/KarmaScripter/Badger/tree/main/Ninja) - models used in EPA budget data analysis.
- [IO](https://github.com/KarmaScripter/Badger/tree/main/IO) - input output classes used for networking and the file systemm.
- [Static](https://github.com/KarmaScripter/Badger/tree/main/Static) - static types used in the analysis of environmental budget data.
- [Interfaces](https://github.com/KarmaScripter/Badger/tree/Interfaces) - abstractions used in the analysis of environmental budget data.
- `bin` - Binaries are included in the `bin` folder due to the complex Baby setup required. Don't empty this folder.
- `bin/storage` - HTML and JS required for downloads manager and custom error pages

## Financial Data Analysis
- ##### Datagrids
- ##### Pivot Tables
![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/Datagrid.gif)

## User Interface with a familiar look & feel.
- ##### Excel-like interface over a relational database
- ##### Import and export spreadsheet data
![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/ExcelUserInterface.gif)

## Geospatial Information (GIS) Mapping.
- ##### Congressional earmark reporting
- ##### Monitor pollution site remediation costs
![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/Map.gif)

## Baby
- ##### Stand-alone web browser built with the [Chromium Embedded Framework](https://en.wikipedia.org/wiki/Chromium_Embedded_Framework)
![](https://github.com/KarmaScripter/Baby/blob/main/Properties/Images/Overview.gif)

## Budget Calculator 
- ##### Quick & dirty accounting and budget calculations directly on bound data.
- ##### Easy access to the full functionality of the widows calculator

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/Calculator.gif)

## Federal Fiscal Year Calendar
- ##### Calculations using full-time equivalency metrics.
- ##### Ad-hoc analysis of variable periods of availability.
![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/FiscalYear.gif)

## Ad-hoc web development with  [Orca](https://github.com/KarmaScripter/Orca)
- ##### Create ad-hoc web information
- ##### HTML5, CSS, and Javascript
  
![](https://github.com/KarmaScripter/Orca/blob/main/etc/github/Overview.gif)
   
## Environmental Program Anaylsis
- ##### Definitions and statutory authorities
- ##### Information bound directly to financial data

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/EnvironmentalPrograms.gif)

## Data Visualization
- ##### 3D Charting
- ##### Pivot Charts
- ##### Plotting from ScottPlot
  
![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/Charts.gif)


## DocViewer
- ##### Library of legal documentation used in evnironmental data analysis.
- ##### Interact with, view and access PDFs outside the application
![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/Guidance.gif)



## SQL Editors

- SQLite

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/SQLite.gif)

- MS Access

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/Access.gif)

- SQL Compact Edition

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/SqlCe.gif)

- SQL Server Express

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/SqlServer.gif)



## Credits

