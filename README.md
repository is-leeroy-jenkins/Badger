## _
 ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/ProjectTemplates.png)


## An open source data analysis application for federal analysts developed in C# using WPF and released under the MIT license
####

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/features.png) Features

- Mutliple data providers.
- Charting and reporting.
- Internal web browser, [Baby](https://github.com/is-leeroy-jenkins/Baby/blob/main/README.md),  with queries optimized for searching .gov domains.
- Pre-defined schema for moret than 100 environmental data models.
- Editors for SQLite, SQL Compact Edition, MS Access, SQL Server Express.
- Excel-ish UI on top of a real databases.
- Mapping for congressional earmark reporting and montioring of polluction sites.
- Finanical data bound to environmental programs and statutory authority.
- Ad-hoc calculations.
- Add agency/region/division-specific branding.
- The winforms version of Badger is [Sherpa](https://github.com/is-leeroy-jenkins/Sherpa?tab=readme-ov-file) 

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Providers.png) Providers

- [SQLite](https://sqlite.org/index.html) is a C-language library that implements a small, fast, self-contained, high-reliability, full-featured, SQL database engine. 
- [SQL CE](https://www.microsoft.com/en-us/download/details.aspx?id=30709) is a discontinued but still useful relational database produced by Microsoft for applications that run on mobile devices and desktops. 
- [SQL Server Express Edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) is a scaled down, free edition of SQL Server, which includes the core database engine.
- MS Access is a database management system (DBMS) from Microsoft that combines the relational Access Database Engine (ACE) with a graphical user interface and software-development tools. [more here](https://www.microsoft.com/en-us/microsoft-365/access)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/system_requirements.png) System requirements

- You need [VC++ 2019 Runtime](https://aka.ms/vs/17/release/vc_redist.x64.exe) 32-bit and 64-bit versions

- You will need .NET 6.

- You need to install the version of VC++ Runtime that Baby Browser needs. Since we are using CefSharp 106, according to [this](https://github.com/cefsharp/CefSharp/#release-branches) we need the above versions



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/documentation.png) Documentation

- [User Guide](Resources/Github/Users.md)
- [Compilation Guide](Resources/Github/Compilation.md)
- [Configuration Guide](Resources/Github/Configuration.md)
- [Distribution Guide](Resources/Github/Distribution.md)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/csharp.png) Code

- Badger uses CefSharp 106 for Baby Browser and is built on NET 6
- Badger supports AnyCPU as well as x86/x64 specific builds
- [Controls](https://github.com/is-leeroy-jenkins/Badger/tree/main/Controls) - main UI layer and associated controls and related functionality.
- [Enumerations](https://github.com/is-leeroy-jenkins/Badger/tree/main/Enumerations) - various enumerations used for budgetary accounting.
- [Extensions](https://github.com/is-leeroy-jenkins/Badger/tree/main/Extensions)- useful extension methods for budget analysis by type.
- [Clients](https://github.com/is-leeroy-jenkins/Badger/tree/main/Clients) - other tools used and available.
- [Ninja](https://github.com/is-leeroy-jenkins/Badger/tree/main/Ninja) - models used in EPA budget data analysis.
- [IO](https://github.com/is-leeroy-jenkins/Badger/tree/main/IO) - input output classes used for networking and the file systemm.
- [Static](https://github.com/is-leeroy-jenkins/Badger/tree/main/Static) - static types used in the analysis of environmental budget data.
- [Interfaces](https://github.com/is-leeroy-jenkins/Badger/tree/Interfaces) - abstractions used in the analysis of environmental budget data.
- `bin` - Binaries are included in the `bin` folder due to the complex Baby setup required. Don't empty this folder.
- `bin/storage` - HTML and JS required for downloads manager and custom error pages

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/tools.png)  Data Tools
- ##### Datagrids
- ##### Pivot Tables
- ##### Plotting
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Datagrid.gif)

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/excel.png) The Interface.
- ##### Excel-ish UI over a real database.
- ##### Import and export spreadsheet data.
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/ExcelUserInterface.gif)

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Maps.png) Maps.
- ##### Congressional earmark reporting
- ##### Monitor pollution site remediation costs
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Map.gif)

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/baby.png) Baby 
- ##### Stand-alone web browser built with the [Chromium Embedded Framework](https://en.wikipedia.org/wiki/Chromium_Embedded_Framework)
- ##### Ad-hoc searches with customized pop-up input.
- ##### Search across multiple .gov domains
![](https://github.com/is-leeroy-jenkins/Baby/blob/main/Properties/Images/Overview.gif)

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Calculation.png) Budget Calculations 
- ##### Ad-hoc calculations directly on bound data.
- ##### Quick access to the full functionality of the widows 10 calculator.

![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Calculator.gif)

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/calendar.png) Federal Calendar
- ##### Calculation based on the federal fiscal year beginning Oct 1.
- ##### Compatible with full-time equivalency metrics.
- ##### Ad-hoc analysis of variable periods of availability.
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/FiscalYear.gif)

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/web.png) [Orca](https://github.com/is-leeroy-jenkins/Orca)
- ##### Ad-hoc web development
- ##### Network communications
- ##### HTML5, CSS, and Javascript
  
![](https://github.com/is-leeroy-jenkins/Orca/blob/main/etc/github/Overview.gif)
   
## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/epa.png) Environmental Program Analysis
- ##### Definitions and statutory authorities
- ##### Legal information bound directly to financial data

![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/EnvironmentalPrograms.gif)

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Analysis.png) Visualization Tools
- ##### 3D Charting
- ##### Pivot Charts
- ##### Plotting & Graphs
  
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Charts.gif)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/document.png) Document Viewer
- ##### Library of legal documentation used in evnironmental data analysis.
- ##### Interact with, view and access PDFs outside the application
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Guidance.gif)



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/sql.png) Editors

- ##### SQLite

![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/SQLite.gif)

- ##### MS Access

![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Access.gif)

- ##### SQL Compact Edition

![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/SqlCe.gif)

- ##### SQL Server Express

![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/SqlServer.gif)




## 🙏 Acknowledgements

Badger uses the following projects and libraries. Please consider supporting them as well (e.g., by starring their repositories):

|                                                                               |                                                                        |
| ----------------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| [CefSharp.WPF.Core](https://github.com/cefsharp)                              | .NET (WPF/Windows Forms) bindings for the Chromium Embedded Framework  |
| [Epplus](https://github.com/EPPlusSoftware/EPPlus)                  		    | EPPlus-Excel spreadsheets for .NET      								 |
| [Google.Api.CustomSearchAPI.v1](https://developers.google.com/custom-search)  | Google APIs Client Library for working with Customsearch v1            |
| [LiveCharts.Core](https://github.com/beto-rodriguez/LiveCharts2)              | Simple, flexible, interactive & powerful charts, maps        			 |
| [Microsoft.Interop.Outlook](https://docusaurus.io/)                           | This an assembly you can use for Outlook 2013/2016/2019 COM interop    |
| [ModernWpfUI](https://github.com/Kinnara/ModernWpf)                           | Modern styles and controls for your WPF applications                   |
| [RestoreWindowPlace](https://github.com/punker76/gong-wpf-dragdrop)   	    | An easy to use window restore package									 |
| [System.Data.SQLite](https://github.com/lduchosal/ipnetwork)                  | .NET Framework Data Provider for SQLite.								 |
| [System.Data.SqlCe](https://github.com/zeluisping/LoadingIndicators.WPF)      | .NET Framework Data Provider for SQL Compact Edition.					 |
| [System.Data.OleDb](https://github.com/zeluisping/LoadingIndicators.WPF) 	    | .NET Framework Data Provider for OLE DB.								 |
| [System.Data.SqlClient](https://github.com/zeluisping/LoadingIndicators.WPF)  | A collection of loading indicators for WPF                             |  
| [MahApps.Metro](https://mahapps.com/)                                         | UI toolkit for WPF applications                                        |
| [ToastNotifications.Messages.Net6](https://github.com/rafallopatka)		    | Toast notifications for WPF 											 |
| [ToastNotifications.Messages](https://github.com/rafallopatka)			    | Toast notifications for WPF											 |
| [Syncfusion 24.1.41](https://www.syncfusion.com/)  							| Custom Controls Used in Badger                                         |
