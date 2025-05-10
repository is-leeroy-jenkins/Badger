#### Badger
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/ProjectTemplates.png)

<div align="left">
  <p>
    <a href="https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Github/Compilation.md">Download</a> •  <a href="https://github.com/is-leeroy-jenkins/Badger?tab=readme-ov-file#-documentation">Documentation</a> •<a href="https://github.com/is-leeroy-jenkins/Badger/tree/master/Resources/Github/Compilation.md">Build</a> • <a href="https://github.com/is-leeroy-jenkins/Badger/blob/main/Properties/LICENSE.txt">License</a>
  </p>
  <p>
    An open source budget execution & data analysis application for federal analysts developed in C# using WPF and released under the MIT license
  </p>
</div>



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/features.png) Features

- Mutliple data providers.
- Datasets can be found on [Kaggle](https://www.kaggle.com/datasets/terryeppler/badger)
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
> Databases play a critical role in environmental data analysis by providing a structured system to store, organize, and efficiently retrieve large amounts of data, allowing analysts to easily access and manipulate information needed to extract meaningful insights through queries and analysis tools; essentially acting as the central repository for data used in data analysis processes.
> Badger provides the following providers to store and analyze data locally.

- [SQLite](https://sqlite.org/index.html) is a C-language library that implements a small, fast, self-contained, high-reliability, full-featured, SQL database engine. 
- [SQL CE](https://www.microsoft.com/en-us/download/details.aspx?id=30709) is a discontinued but still useful relational database produced by Microsoft for applications that run on mobile devices and desktops. 
- [SQL Server Express Edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) is a scaled down, free edition of SQL Server, which includes the core database engine.
- MS Access is a database management system (DBMS) from Microsoft that combines the relational Access Database Engine (ACE) with a graphical user interface and software-development tools. [more here](https://www.microsoft.com/en-us/microsoft-365/access)



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/system_requirements.png) System requirements

- You need [VC++ 2019 Runtime](https://aka.ms/vs/17/release/vc_redist.x64.exe) 32-bit and 64-bit versions
- You will need .NET 8.
- You need to install the version of VC++ Runtime that Baby Browser needs. Since we are using CefSharp 106, according to [this](https://github.com/cefsharp/CefSharp/#release-branches) we need the above versions



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/documentation.png) Documentation

- [Compilation Guide](Resources/Github/Compilation.md) - instructions on how to compile Badger.
- [Configuration Guide](Resources/Github/Configuration.md) - information for the Badger configuration file. 
- [Distribution Guide](Resources/Github/Distribution.md) -  distributing Badger



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/csharp.png) Code


- [Controls](https://github.com/is-leeroy-jenkins/Badger/tree/main/UI/Controls) - main UI layer with numerous controls and related functionality.
- [Styles](https://github.com/is-leeroy-jenkins/Badger/tree/main/UI/Themes/Styles) - XAML-based styles for the Badger UI layer.
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



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/openai.png)  Generative AI

> Vectorization is the process of converting textual data into numerical vectors and is a process that is usually applied once the text is cleaned.
> It can help improve the execution speed and reduce the training time of your code. Badger provides the following vector stores on the Hugging Face and OpenAI platform to support environmental data analysis with machine-learning

- #### [US Federal Appropriations](https://huggingface.co/datasets/leeroy-jankins/Appropriations) - Enacted appropriations from 1990-2024 available for fine-tuning learning models
- #### [Federal Regulations](https://huggingface.co/datasets/leeroy-jankins/Regulations) - Collection of federal financial regulations on the use of appropriatied funds available for fine-tuning learning models
- #### [SF-133](https://huggingface.co/datasets/leeroy-jankins/SF133) - The Report on Budget Execution and Budgetary Resources
- #### [Balances](https://huggingface.co/datasets/leeroy-jankins/Balances) -  U.S. federal agency Account Balances (File A) submitted as part of the DATA Act 2014.
- #### [Outlays](https://huggingface.co/datasets/leeroy-jankins/Outlays) -  The actual disbursements of funds by the U.S. federal government from 1996 to 2025

> Badger incorporates machine learning and artificial intelligence algorithms to extract insights from large datasets.
> This includes the use of vector embeddings and predictive modeling to forecast contaminant spread and resource optimization to allocate resources effectively during emergencies

- #### Example gpt-4o-mini run
## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Bubba.gif)

> Badger incorporates machine learning and artificial intelligence algorithms to extract insights from large datasets.
This includes the use of vector embeddings and predictive modeling to forecast contaminant spread and resource optimization to allocate resources effectively during emergencies.
Badger interacts with pre-trained Large Language Models (LLMs) like GPT-4o and o1-mini  to enhance its analytical capabilities.
Users leverage LLMs for rapid information retrieval from vast datasets, automated report generation, and potentially even expert consultation


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/tools.png)  Data Tools

> The tools used in environmental data analysis & buget execution play a crucial role by facilitating the collection, cleaning, organization, analysis,
> and interpretation of large datasets, allowing users to extract meaningful insights and make informed decisions by transforming raw data
> into actionable information through features like statistical analysis, data visualization, and machine learning algorithms.
> Some of the tools offered by Badger include the following:

- ##### Datagrids
- ##### Pivot Tables
- ##### Plotting
  
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Datagrid.gif)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/pbi.png)  Dashboards

> Environmental data dashboards providing views that help users explore and analyze complex environmental data to make informed decisions,
> manage operations and research.

- ##### Status Of Programs
- ##### OMB Apportionments
- ##### MAX A-11
- ##### General Ledger Reconciliation
  
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Dashboards.gif)

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Analysis.png) Visualization Tools

> Data analysis in environmental science is used for a wide range of applications including: climate change analysis, biodiversity assessment, pollution detection,
> natural disaster management, land use monitoring, ecosystem health evaluation, and identifying environmental trends by utilizing techniques like spatial analysis,
> time series analysis, and statistical modeling, often leveraging satellite imagery and remote sensing data to analyze large datasets effectively.

- ##### 3D Charting
- ##### Pivot Charts
- ##### Plotting & Graphs
  
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Charts.gif)

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/ExcelData.png) The Spreadsheet Interface.

> An excel inspired control that allows you to create, edit, view and format the Microsoft Excel files without excel installed.
> It provides absolute ease of use UI experience with integrated ribbon to cover any possible business scenario.

#### Spreadhsheet Features
-	**Ribbon** – Ribbon integrated with organically enhanced UI experience.
-	**Editing and Selection** - Interactive support for editing and cell selection in workbook.
-	**Formulas** - Provides support for 400+ most widely used formulas which any business user needs and allows you to add, remove and edit the formulas like in excel.
-	**Name Manager** – Supports the name ranges in the formulas. By using the name ranges, you can specify the name of the cell range.
-	**Data validation** – Provides support to ensure the data integrity by enforcing end users to enter valid data into the cells and if entered data does not meet the specified criteria, and error message is displayed.
-	**Floating Cells** - Provides support for floating cell mode that is when the text exceeds the length of the cell, it will float the text to the adjacent cell.
-	**Merge Cells** - Merge two or more adjacent cells into a single cell and display the contents of one cell in the merged cell.
-	**Conditional Formatting** - Provides support for excel compatible conditional formatting and allows you to apply formats to a range of cells depending on the value of cells or formula that meet specific criteria.
- **Import/Export** data
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/ExcelUserInterface.gif)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Maps.png) Maps.
> Visualize data about facilities or specific sites subject to environmental regulation. The EPA's Geospatial Data Access Project provides
> downloadable files of these facilities or sites in the following formats: Extensible Markup Language (XML), Keyhole Markup Language (KML),
> ESRI Geodatabase, and Comma Separated Value (CSV). Within the file is key facility information for use in mapping and reporting applications. 
- ##### Congressional earmark reporting
- ##### Monitor pollution site remediation costs
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Map.gif)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Calculation.png)  Calculations 
- ##### Perform ad-hoc calculations directly on bound data.
- #### Avoid errors caused by toggling to and from different applications to add two numbers.
- ##### Quick access to the full functionality of the widows 10 calculator.
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Calculator.gif)



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/calendar.png) Federal Calendar
> Every year, the U.S. Congress begins work on a federal budget for the next fiscal year.
> The federal government’s fiscal year runs from October 1 of one calendar year through September 30 of the next.
> A fiscal year (FY) is a 52- or 53-week (or, alternatively, a 12-month) period that companies and governments use for taxing or accounting purposes.
> Fiscal years are most commonly used by entities that depend on a cycle that doesn't correspond to the calendar year.

- ##### Calculation based on the federal fiscal year beginning Oct 1.
- ##### Compatible with full-time equivalency metrics.
- ##### Ad-hoc analysis of variable periods of availability.
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/FiscalYear.gif)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/web.png) [Orca](https://github.com/is-leeroy-jenkins/Orca)
>Create, build, and maintain ad-hoc documents with Orca to provide real-time information for others via the web.
- ##### Single or multi-page documents
- #### Present and access media (*.mp3, *mp4, etc)
- ##### Network communications (HTTP, HTTPS, FTP, and UDP)
- ##### HTML5, CSS, and Javascript

  
![](https://github.com/is-leeroy-jenkins/Orca/blob/main/etc/github/Overview.gif)
   
## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/epa.png) Environmental Program Analysis

- Definitions and statutory authorities
- Legal information bound directly to financial data in the user interface.
- [Environmental Monitoring and Assessment Program](https://archive.epa.gov/emap/archive-emap/web/html/)  and [Regional Environmental Monitoring and Assessment Program](https://archive.epa.gov/emap/archive-emap/web/html/index-171.html)
>EMAP was a research program to develop the tools necessary to monitor and assess the status and trends of national ecological resources.
>Data sets generated in the course of EMAP's research are available to be searched and downloaded. The objectives of REMAP are to evaluate and improve
>EMAP concepts for state and local use, assess the applicability of EMAP indicators at differing spatial scales, and demonstrate the
>utility of EMAP for resolving issues of importance to EPA Regions and states. REMAP data are available online like EMAP data, but have smaller spatial and temporal scales.

- [EPA STOrage and RETrieval database (STORET)](https://www3.epa.gov/storet/index-.html#:~:text=Welcome%20to%20STORET%2C%20EPA's%20largest,private%20citizens%2C%20and%20many%20others.)
>The STORET Data Warehouse is U.S. EPA's repository of the water quality monitoring data collected by water resource management groups across the country.
>These organizations, including states, tribes, watershed groups, other federal agencies, volunteer groups and universities, submit datasets to the STORET Warehouse in order to make them publically accessible.

- [Wadeable Streams Assessment (WSA)](https://www.epa.gov/national-aquatic-resource-surveys/wadeable-streams-assessment)
>WSA is a survey of the biological condition of small streams throughout the U.S. conducted by the U.S. EPA in collaboration with states and tribes.
>The first WSA in 2004-2005 sampled 1,392 sites selected at random to represent the condition of all streams in regions that share similar ecological characteristics.
>Participants used the same standard methods at all sites, to ensure results that are comparable across the nation.

![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/EnvironmentalPrograms.gif)
***

 ## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/ORD.png) Some studies
- [Air Research](https://www.epa.gov/air-research)
- [Climate Change Research](https://www.epa.gov/climate-research)
- [Ecosystems Research](https://www.epa.gov/eco-research)
- [Emergency Response](https://www.epa.gov/emergency-response-research)
- [Health Research](https://www.epa.gov/healthresearch)
- [Human Health Risk Assessment](https://www.epa.gov/risk/human-health-risk-assessment)
- [Land and Waste Management Research](https://www.epa.gov/land-research)
-[Chemical Safety Research](https://www.epa.gov/chemical-research)
- [Water Research](https://www.epa.gov/water-research)



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/document.png) Document Viewer
> The PDF Viewer control supports viewing, reviewing, and printing PDF files in the WPF applications. The thumbnail, bookmark, hyperlink, and
> table of contents support provide easy navigation within and outside the PDF files. The form-filling support provides a platform to fill,
> flatten, save, and print PDF files with AcroForm. The PDF files can be reviewed with the abundantly available annotation tools.

- ##### Library of legal documentation used in evnironmental data analysis.
- ##### Interact with, view and access PDFs outside the application
  
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/Guidance.gif)



## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/sql.png) SQL Editors
>Common SQL operations used in data analysis:
>Filtering data: Using the WHERE clause to select specific rows based on conditions.
>Aggregation: Employing functions like SUM, AVG, COUNT, MIN, MAX to calculate summary statistics on groups of data.
>Joining tables: Combining data from multiple tables using JOIN operations to create a comprehensive view.
>Subqueries: Using nested queries to filter data based on results from another query.

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/sqlite.png) SQLite
> A C-language library that implements a small, fast, self-contained, high-reliability, full-featured, SQL database engine
> that's open source and hand's-down one the best tools available.
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/SQLite.gif)

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/SqlCe.png) SQL Compact Edition
> A discontinued but super useful relational database produced by Microsoft for applications that run on mobile devices and desktops.
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/SqlCe.gif)

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/mssql.png) SQL Server Express
> A free edition of MS' flagship database SQL Server, which includes the core database engine.
![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/SqlServer.gif)


## ![](https://github.com/is-leeroy-jenkins/Badger/blob/main/Resources/Assets/GitHubImages/baby.png) Baby 

> A light-weight, full-featured, open source version of Google Chrome web-browser  written in C#.
> Baby embraces modern web standards, and supports HTML5, JavaScript, CSS3 and HTML5 audio/video elements.
> 3D content is supported via WebGL which uses OpenGL/DirectX for hardware accelerated rendering.
> Baby includes embedded modules for PDF, web page printing and the WebKit Inspector (developer tools). Baby has no external dependencies.
- ##### Stand-alone web browser built with the [Chromium Embedded Framework](https://en.wikipedia.org/wiki/Chromium_Embedded_Framework)
- ##### Ad-hoc searches with customized pop-up input.
- ##### customized search using Google's engine to query across multiple government research domains

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


## Popup Search Bar

![](https://github.com/is-leeroy-jenkins/Baby/blob/main/Properties/search.png)


## Downloads Tab

![](https://github.com/is-leeroy-jenkins/Baby/blob/main/Properties/3.png)


## Developer Tools

![](https://github.com/is-leeroy-jenkins/Baby/blob/main/Properties/4.png)

## ![](https://github.com/is-leeroy-jenkins/Badger/blob/master/Resources/Assets/GitHubImages/chrome.png) CefSharp Requirements

#### The binaries directory must contain these required dependencies:

- libcef.dll (Chromium Embedded Framework Core library)
- icudtl.dat (Unicode Support data)
- chrome_elf.dll(Crash reporting library)
- snapshot_blob.bin, v8_context_snapshot.bin (V8 snapshot data)
- locales\en-US.pak, chrome_100_percent.pak, chrome_200_percent.pak, resources.pak, 
- d3dcompiler_47.dll 
- libEGL.dll 
- libGLESv2.dll

#### These are technically listed as optional, but the browser is unlikely to function without these files.

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




## ![](https://github.com/is-leeroy-jenkins/Badger/blob/master/Resources/Assets/GitHubImages/web.png) Privacy Policy

This program will not transfer any information to other networked systems unless specifically requested by the user or the person installing or operating it.

Badger has integrated the following services for additional functions, which can be enabled or disabled at the first start (in the welcome dialog) or at any time in the settings:

- [api.github.com](https://docs.github.com/en/site-policy/privacy-policies/github-general-privacy-statement) (Check for program updates)
- [ipify.org](https://www.ipify.org/) (Retrieve the public IP address used by the client)
- [ip-api.com](https://ip-api.com/docs/legal) (Retrieve network information such as geo location, ISP, DNS resolver used, etc. used by the client)

## 📝 License

Badger is published under the [MIT General Public License v3](https://github.com/is-leeroy-jenkins/Badger/blob/main/LICENSE).


