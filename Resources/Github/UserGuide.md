### 1.0 Install Nuget Packages

Install one of the following via the `Nuget Package Manager` from within Visual Studio
- [![CefSharp.WinForms.NETCore](http://img.shields.io/nuget/v/CefSharp.WinForms.NETCore.svg?style=flat&label=CefSharp.WinForms.NETCore)](http://www.nuget.org/packages/CefSharp.WinForms.NETCore/)
- [![CefSharp.Wpf.NETCore](http://img.shields.io/nuget/v/CefSharp.Wpf.NETCore.svg?style=flat&label=CefSharp.Wpf.NETCore)](http://www.nuget.org/packages/CefSharp.Wpf.NETCore/)
- [![CefSharp.OffScreen.NETCore](http://img.shields.io/nuget/v/CefSharp.OffScreen.NETCore.svg?style=flat&label=CefSharp.OffScreen.NETCore)](http://www.nuget.org/packages/CefSharp.OffScreen.NETCore/)

### 2.0 Set a [RuntimeIdentifier](https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#runtimeidentifier) in your **proj** file.

A [RuntimeIdentifier](https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#runtimeidentifier) tells `VS/MSBuild` which architecture specific files to copy as part of the build process. If no `<RuntimeIdentifier/>` is specified then files for `x86`, `x64` and `arm64` will all be copied resulting in a very very large bin folder. A `<RuntimeIdentifier/>` must be specified when releasing/publishing your application. 

Use **one** of the following in your proj file.
```xml
<RuntimeIdentifier Condition="'$(RuntimeIdentifier)' == ''">win-x86</RuntimeIdentifier>
<RuntimeIdentifier Condition="'$(RuntimeIdentifier)' == ''">win-x64</RuntimeIdentifier>
<!-- Use $(NETCoreSdkRuntimeIdentifier) in most cases this will be win-x86 -->
<RuntimeIdentifier Condition="'$(RuntimeIdentifier)' == ''">$(NETCoreSdkRuntimeIdentifier)</RuntimeIdentifier>
<!-- .Net 7.0 introduces a new UseCurrentRuntimeIdentifier property-->
<UseCurrentRuntimeIdentifier Condition="'$(UseCurrentRuntimeIdentifier)' == ''">true</UseCurrentRuntimeIdentifier>

<!--
You should also set
SelfContained = false (otherwise the whole .Net Framework will be included in your bin folder
-->
<SelfContained Condition="'$(SelfContained)' == ''">false</SelfContained>
```

If your proj file specifies multiple platforms e.g. `<Platforms>x86;x64</Platforms>` then I'd suggest using the following:

```xml
<PropertyGroup Condition="'$(PlatformTarget)' == 'x86'">
  <RuntimeIdentifier Condition="'$(RuntimeIdentifier)' == ''">win-x86</RuntimeIdentifier>
  <SelfContained Condition="'$(SelfContained)' == ''">false</SelfContained>
</PropertyGroup>

<PropertyGroup Condition="'$(PlatformTarget)' == 'x64'">
  <RuntimeIdentifier Condition="'$(RuntimeIdentifier)' == ''">win-x64</RuntimeIdentifier>
  <SelfContained Condition="'$(SelfContained)' == ''">false</SelfContained>
</PropertyGroup>

<PropertyGroup Condition="'$(PlatformTarget)' == 'arm64'">
  <RuntimeIdentifier Condition="'$(RuntimeIdentifier)' == ''">win-arm64</RuntimeIdentifier>
  <SelfContained Condition="'$(SelfContained)' == ''">false</SelfContained>
</PropertyGroup>
```

### 3.0 Read the Docs

- Review the [Post Installation](https://github.com/cefsharp/CefSharp/blob/master/NuGet/PackageReference/Readme.txt#L7) steps in the `Readme.txt` file that's opened in `Visual Studio` upon installation.
- Review the [Release Notes](https://github.com/cefsharp/CefSharp/releases) for the version you just installed, a list of `Known Issues` for the problems we're currently aware of.
- Check out the [API Doc](http://cefsharp.github.io/api/), it's version specific, make sure you pick the correct version.

### 4.0 Add app.manifest to your application

Add an [app.manifest](https://learn.microsoft.com/en-us/windows/win32/sbscs/application-manifests) to your exe if you don't already have one, it's required for Windows 10/11 compatibility, GPU Acceleration, HighDPI support and tooltips. See https://learn.microsoft.com/en-us/windows/win32/w8cookbook/windows-version-check#declaring-windows-10-compatibility-with-an-app-manifest

```xml
<!-- example.exe.manifest -->
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<assembly manifestVersion="1.0" xmlns="urn:schemas-microsoft-com:asm.v1" xmlns:asmv3="urn:schemas-microsoft-com:asm.v3">
    <assemblyIdentity
        type="win32"
        name="Contoso.ExampleApplication.ExampleBinary"
        version="1.2.3.4"
        processorArchitecture="x86"
    />
    <description>Contoso Example Application</description>
    <compatibility xmlns="urn:schemas-microsoft-com:compatibility.v1">
        <application>
            <!-- Windows 10/11 -->
            <supportedOS Id="{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}"/> <!-- * ADD THIS LINE * -->
        </application>
    </compatibility>
</assembly>
```

The https://github.com/cefsharp/CefSharp.MinimalExample project contains an example app.manifest file in the root of the WPF/WinForms/OffScreen examples. 

### 5.0 Add ChromiumWebBrowser to your application.

<table>
<tr>
<td>Implementation</td>
<td>Example</td>
</tr>
<tr>
<td>WPF</td>
<td>   
For WPF use CefSharp.Wpf.ChromiumWebBrowser

```xaml
<!-- Add a xmlns:wpf="clr-namespace:CefSharp.Wpf;assembly=CefSharp.Wpf" attribute to your parent control -->
<!-- Create a new instance in code or in `xaml` -->
<Border Grid.Row="1" BorderBrush="Gray" BorderThickness="0,1">
    <wpf:ChromiumWebBrowser x:Name="Browser" Address="www.google.com"/>
</Border>
```
</td>
</tr>
<tr>
<td>WinForms</td>
<td>   
For WinForms use CefSharp.WinForms.ChromiumWebBrowser

```c#
using CefSharp;
using CefSharp.WinForms;
//Create a new instance in code or add via the designer
var browser = new ChromiumWebBrowser("www.google.com");
parent.Controls.Add(browser);

//Load a different url
browser.LoadUrl("https://github.com");
```
</td>
</tr>
<tr>
<td>OffScreen</td>
<td>   
For OffScreen use CefSharp.OffScreen.ChromiumWebBrowser

```c#
using CefSharp;
using CefSharp.OffScreen;
//Create a new instance in code
var browser = new ChromiumWebBrowser("www.google.com");

//Load a different url
browser.LoadUrl("https://github.com");
```
</td>
</tr>
</table>
    
### 5.1 Execute some JavaScript (optional)

See https://github.com/cefsharp/CefSharp/wiki/General-Usage#javascript-integration for more details

```c#
// Add usage statement to access additional functionality
// e.g. EvaluateScriptAsync
using CefSharp;
var response = await browser.EvaluateScriptAsync("1 + 1");
if(response.Success)
{
    var result = response.Result;
}
```

### 6.0 Publish

```
# For x86
dotnet publish -c Release -f net6.0-windows -r win-x86
# For x64
dotnet publish -c Release -f net6.0-windows -r win-x64
# For arm64
dotnet publish -c Release -f net6.0-windows -r win-arm64
```

### 7.0 SelfPublish and SelfContained (Optional)

You will need to self host the `BrowserSubProcess` using your main application executable.
See https://github.com/cefsharp/CefSharp/issues/3407 for details
