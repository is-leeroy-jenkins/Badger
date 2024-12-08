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

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Providers.png) Database Providers

- [SQLite](https://sqlite.org/index.html) is a C-language library that implements a small, fast, self-contained, high-reliability, full-featured, SQL database engine. 
- [SQL CE](https://www.microsoft.com/en-us/download/details.aspx?id=30709) is a discontinued but still useful relational database produced by Microsoft for applications that run on mobile devices and desktops. 
- [SQL Server Express Edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) is a scaled down, free edition of SQL Server, which includes the core database engine.
- MS Access is a database management system (DBMS) from Microsoft that combines the relational Access Database Engine (ACE) with a graphical user interface and software-development tools. [more here](https://www.microsoft.com/en-us/microsoft-365/access)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/system_requirements.png) System requirements

- You need [VC++ 2019 Runtime](https://aka.ms/vs/17/release/vc_redist.x64.exe) 32-bit and 64-bit versions

- You will need .NET 6.

- You need to install the version of VC++ Runtime that Baby Browser needs. Since we are using CefSharp 106, according to [this](https://github.com/cefsharp/CefSharp/#release-branches) we need the above versions



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/documentation.png) Documentation

- [Compilation Guide](Resources/Github/Compilation.md) 
- [Configuration Guide](Resources/Github/Configuration.md)
- [Distribution Guide](Resources/Github/Distribution.md)



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/openai.png)  Generative AI
> Vectorization is the process of converting textual data into numerical vectors and is a process that is usually applied once the text is cleaned. It can help improve the execution speed and reduce the training time of your code. In this article, we will discuss some of the best techniques to perform vectorization.
- [Federal Appropriations](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Github/Appropriations.md) - vectorized data set of federal appropriations available for fine-tuning learning models
- [Federal Regulations](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Github/Regulations.md) - vectorized dat aset of federal, financial regulations available for fine-tuning learning models




## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/csharp.png) Code


- [Controls](https://github.com/is-leeroy-jenkins/Badger/tree/main/UI/Controls) - main UI layer with 36 controls and related functionality.
- [Styles](https://github.com/is-leeroy-jenkins/Badger/tree/main/UI/Themes/Styles) - XAML-based styles for the Bubba UI layer.
- [Enumerations](https://github.com/is-leeroy-jenkins/Badger/tree/main/Enumerations) - various enumerations used for budgetary accounting.
- [Extensions](https://github.com/is-leeroy-jenkins/Badger/tree/main/Extensions)- useful extension methods for budget analysis by type.
- [Clients](https://github.com/is-leeroy-jenkins/Badger/tree/main/Clients) - other tools used and available.
- [Ninja](https://github.com/is-leeroy-jenkins/Badger/tree/main/Ninja) - models used in EPA budget data analysis.
- [IO](https://github.com/is-leeroy-jenkins/Badger/tree/main/IO) - input output classes used for networking and the file systemm.
- [Static](https://github.com/is-leeroy-jenkins/Badger/tree/main/Static) - static types used in the analysis of environmental budget data.
- [Interfaces](https://github.com/is-leeroy-jenkins/Badger/tree/Interfaces) - abstractions used in the analysis of environmental budget data.
- `bin` - Binaries are included in the `bin` folder due to the complex Baby setup required. Don't empty this folder.
- Badger uses CefSharp 106 for Baby Browser and is built on NET 8
- Badger supports x64 specific builds
- `bin/storage` - HTML and JS required for downloads manager and custom error pages


  
## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/tools.png)  Data Tools
- ##### Datagrids
- ##### Pivot Tables
- ##### Plotting
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Datagrid.gif)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/excel.png) The Interface.
- ##### User Interface based on MS Excel over a real database.
- ##### Import and export spreadsheet data.
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/ExcelUserInterface.gif)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Maps.png) Maps.
- ##### Congressional earmark reporting
- ##### Monitor pollution site remediation costs
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Map.gif)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Calculation.png) Budget Calculations 
- ##### Perform ad-hoc calculations directly on bound data.
- #### Avoid errors caused by toggling to and from different applications to add two numbers.
- ##### Quick access to the full functionality of the widows 10 calculator.
![](https://github.com/is-leeroy-jenkins/Sherpa/blob/main/Resources/Assets/GitHubImages/Calculator.gif)



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/calendar.png) Federal Calendar
- ##### Calculation based on the federal fiscal year beginning Oct 1.
- ##### Compatible with full-time equivalency metrics.
- ##### Ad-hoc analysis of variable periods of availability.
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/FiscalYear.gif)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/web.png) [Orca](https://github.com/is-leeroy-jenkins/Orca)
>Create, build, and maintain ad-hoc documents with Orca to provide real-time information for other analysts, scientists, and engineers via the web.
- ##### Single or multi-page documents
- #### Present and access media (*.mp3, *mp4, etc)
- ##### Network communications (HTTP, HTTPS, FTP, and UDP)
- ##### HTML5, CSS, and Javascript

  
![](https://github.com/is-leeroy-jenkins/Orca/blob/main/etc/github/Overview.gif)
   
## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/epa.png) Environmental Program Analysis

- Definitions and statutory authorities
- Legal information bound directly to financial data in the user interface.

![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/EnvironmentalPrograms.gif)

- Monitoring Data Sets Available Online
> [Environmental Monitoring and Assessment Program](https://archive.epa.gov/emap/archive-emap/web/html/)  and [Regional Environmental Monitoring and Assessment Program](https://archive.epa.gov/emap/archive-emap/web/html/index-171.html)
EMAP was a research program to develop the tools necessary to monitor and assess the status and trends of national ecological resources. Data sets generated in the course of EMAP's research are available to be searched and downloaded. The objectives of REMAP are to evaluate and improve EMAP concepts for state and local use, assess the applicability of EMAP indicators at differing spatial scales, and demonstrate the utility of EMAP for resolving issues of importance to EPA Regions and states. REMAP data are available online like EMAP data, but have smaller spatial and temporal scales.

- [EPA STOrage and RETrieval database (STORET)](https://www3.epa.gov/storet/index-.html#:~:text=Welcome%20to%20STORET%2C%20EPA's%20largest,private%20citizens%2C%20and%20many%20others.)
>The STORET Data Warehouse is U.S. EPA's repository of the water quality monitoring data collected by water resource management groups across the country. These organizations, including states, tribes, watershed groups, other federal agencies, volunteer groups and universities, submit datasets to the STORET Warehouse in order to make them publically accessible.

- [Wadeable Streams Assessment (WSA)](https://www.epa.gov/national-aquatic-resource-surveys/wadeable-streams-assessment)
>WSA is a survey of the biological condition of small streams throughout the U.S. conducted by the U.S. EPA in collaboration with states and tribes. The first WSA in 2004-2005 sampled 1,392 sites selected at random to represent the condition of all streams in regions that share similar ecological characteristics. Participants used the same standard methods at all sites, to ensure results that are comparable across the nation.

 ## Active studies
- [Air Research](https://www.epa.gov/air-research)
- [Climate Change Research](https://www.epa.gov/climate-research)
- [Ecosystems Research](https://www.epa.gov/eco-research)
- [Emergency Response](https://www.epa.gov/emergency-response-research)
- [Health Research](https://www.epa.gov/healthresearch)
- [Human Health Risk Assessment](https://www.epa.gov/risk/human-health-risk-assessment)
- [Land and Waste Management Research](https://www.epa.gov/land-research)
-[Chemical Safety Research](https://www.epa.gov/chemical-research)
- [Water Research](https://www.epa.gov/water-research)



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Analysis.png) Visualization Tools
>Data analysis in environmental science is used for a wide range of applications including: climate change analysis, biodiversity assessment, pollution detection, natural disaster management, land use monitoring, ecosystem health evaluation, and identifying environmental trends by utilizing techniques like spatial analysis, time series analysis, and statistical modeling, often leveraging satellite imagery and remote sensing data to analyze large datasets effectively.

- ##### 3D Charting
- ##### Pivot Charts
- ##### Plotting & Graphs
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Charts.gif)



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/document.png) Document Viewer
- ##### Library of legal documentation used in evnironmental data analysis.
- ##### Interact with, view and access PDFs outside the application
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Guidance.gif)



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/sql.png) SQL Editors
>Common SQL operations used in data analysis:
Filtering data: Using the WHERE clause to select specific rows based on conditions. 
Aggregation: Employing functions like SUM, AVG, COUNT, MIN, MAX to calculate summary statistics on groups of data. 
Joining tables: Combining data from multiple tables using JOIN operations to create a comprehensive view. 
Subqueries: Using nested queries to filter data based on results from another query

- ##### SQLite
> A C-language library that implements a small, fast, self-contained, high-reliability, full-featured, SQL database engine
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/SQLite.gif)

- ##### MS Access
> A database management system (DBMS) from Microsoft that combines the relational Access Database Engine (ACE) with a graphical user interface and software-development tools

![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Access.gif)

- ##### SQL Compact Edition
> A discontinued but super useful relational database produced by Microsoft for applications that run on mobile devices and desktops.
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/SqlCe.gif)

- ##### SQL Server Express
> A free edition of MS' flagship database SQL Server, which includes the core database engine.
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/SqlServer.gif)



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/baby.png) Baby 

> A light-weight, full-featured, open source version of Google Chrome web-browser  written in C#.
- HTML5, CSS3, JS, HTML5 Video, WebGL 3D, WebAssembly, etc
- Tabbed browsing
- Address bar (also opens Google)
- Back, Forward, Stop, Refresh
- Developer tools
- Search bar (also highlights all instances)
- Download manager
- Custom error pages
- Custom context menu
- Easily add vendor-specific branding, buttons or hotkeys
- View online & offline webpages

## Baby Overview
- ##### Stand-alone web browser built with the [Chromium Embedded Framework](https://en.wikipedia.org/wiki/Chromium_Embedded_Framework)
- ##### Ad-hoc searches with customized pop-up input.
- ##### customized search using Google's engine to query across multiple government research domains
  
![](https://github.com/is-leeroy-jenkins/Baby/blob/main/Properties/Overview.gif)


## ![](https://github.com/is-leeroy-jenkins/Baby/blob/main/Properties/tools.png)  Hotkeys

Hotkeys | Function
------------ | -------------
Ctrl+T		| Add a new tab
Ctrl+N		| Add a new window
Ctrl+W		| Close active tab
F5			| Refresh active tab
F12			| Open developer tools
Ctrl+Tab	| Switch to the next tab
Ctrl+Shift+Tab	| Switch to the previous tab
Ctrl+F		| Open search bar (Enter to find next, Esc to close)

## What is WebAssembly? 

>WebAssembly or WASM is a "binary instruction format for a stack-based virtual machine [...] designed as a portable compilation target for programming languages, enabling deployment on the web". Said another way it's an intermediate bytecode format that can shipped to browsers to be run. This is notable because as an intermediate format it enables language designers to target browser development from languages beyond JavaScript. Many languages today have compilers available that will output WASM as a target some notable examples are C/C++, C#, Rust, Zig. Beyond that the ubiquity of javascript engines there's a large number of environments that have suddenly become possible WASM targets.

## What is WebGL?
>WebGL a 3D graphics API based on OpenGL ES itself a subset of the OpenGL graphics API designed for mobile or embedded applications. WebGL is notable because it offers a powerful, cross platform, 3D graphics target for the browser. For many targets the browser is able to use 3D acceleration and run directly on the computer's GPU which provides a much high performance graphics target than you otherwise have access to from the browser APIs. There are examples of rich 3D environments, games, and 3D accelerated applications that have shipped to browsers enabled by this technology.


![](https://github.com/is-leeroy-jenkins/Baby/blob/main/Properties/5.png)


## YouTube

![](https://github.com/is-leeroy-jenkins/Baby/blob/main/Properties/6.png)


## Google Maps

![](https://github.com/is-leeroy-jenkins/Baby/blob/main/Properties/2.png)


## Search Bar

![](https://github.com/is-leeroy-jenkins/Baby/blob/main/Properties/search.png)


## Downloads Tab

![](https://github.com/is-leeroy-jenkins/Baby/blob/main/Properties/3.png)


## Developer Tools

![](https://github.com/is-leeroy-jenkins/Baby/blob/main/Properties/4.png)

## ![](https://github.com/is-leeroy-jenkins/Bubba/blob/master/Resources/Assets/GitHubImages/chrome.png) CefSharp Requirements

#### The binaries directory must contain these required dependencies:

- libcef.dll (Chromium Embedded Framework Core library)
- icudtl.dat (Unicode Support data)
- chrome_elf.dll(Crash reporting library)
- snapshot_blob.bin, v8_context_snapshot.bin (V8 snapshot data)
- locales\en-US.pak, chrome_100_percent.pak, chrome_200_percent.pak, resources.pak, 
- d3dcompiler_47.dll 
- libEGL.dll 
- libGLESv2.dll

#### Whilst these are technically listed as optional, the browser is unlikely to function without these files.

- CefSharp.Core.dll, CefSharp.dll 
- CefSharp.Core.Runtime.dll
- CefSharp.BrowserSubprocess.exe 
- CefSharp.BrowserSubProcess.Core.dll

#### These are required CefSharp binaries that are the common core logic binaries of CefSharp (only 1 required).

- CefSharp.WinForms.dll
- CefSharp.Wpf.dll
- CefSharp.OffScreen.dll

#### By default `CEF` has it's own log file, `Debug.log` which is located in your executing folder. e.g. `bin`



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




## ![](https://github.com/is-leeroy-jenkins/Bubba/blob/master/Resources/Assets/GitHubImages/web.png) Privacy Policy

This program will not transfer any information to other networked systems unless specifically requested by the user or the person installing or operating it.

Bubba has integrated the following services for additional functions, which can be enabled or disabled at the first start (in the welcome dialog) or at any time in the settings:

- [api.github.com](https://docs.github.com/en/site-policy/privacy-policies/github-general-privacy-statement) (Check for program updates)
- [ipify.org](https://www.ipify.org/) (Retrieve the public IP address used by the client)
- [ip-api.com](https://ip-api.com/docs/legal) (Retrieve network information such as geo location, ISP, DNS resolver used, etc. used by the client)

## 📝 License

Bubba is published under the [MIT General Public License v3](https://github.com/is-leeroy-jenkins/Bubba/blob/main/LICENSE).

The licenses of the libraries used can be found [here](https://github.com/is-leeroy-jenkins/Bubba/tree/main/Resources/Licenses).

