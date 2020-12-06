<h1 align="center">
  <br>
  <img width="500" alt="scoopBoxLogo" src="assets/Icon.png">
  <br>
  Boxer
  <br>
</h1>

<h4 align="center">Boxer is cli tool that helps launch Windows Sandbox with preinstalled applications and/or with predefined scripts.</h4>
<h4 align="center">:star: Stars on GitHub always helps!</h4>

<p align="center">
  <a href="https://www.nuget.org/packages/ScoopBox/">
    <img src="https://img.shields.io/badge/boxer-dotnet%20tool-red" alt="dotnet tool">
  </a>
</p>

<p align="center">
  <a href="#windows-sandbox">Windows Sandbox</a> •
  <a href="#scoopbox">ScoopBox</a> •
  <a href="#boxer">Boxer</a> •
  <a href="#documentation">Documentation</a> •
  <a href="#download">Download</a> •
  <a href="#contribute">Contribute</a>
</p>

## Windows Sandbox
Technically [Windows Sandbox](https://docs.microsoft.com/en-us/windows/security/threat-protection/windows-sandbox/windows-sandbox-overview "Windows Sandbox Documentation") is a lightweight virtual machine created on demand which a user can safely run applications in isolation. This virtual machine is using the same OS image as in the host machine. Software installed inside the Windows Sandbox environment remains "sandboxed" and runs separately from the base machine.

Windows sandbox should be enabled before first use. [Check how here.](https://docs.microsoft.com/en-us/windows/security/threat-protection/windows-sandbox/windows-sandbox-overview#installation "Windows Sandbox Installation")

## ScoopBox
[ScoopBox](https://github.com/hasan-hasanov/ScoopBox) is a C# library that helps you launch the Windows Sandbox with preinstalled applications using package managers Scoop and Chocolate.

_You can find more information about Windows Sandbox and ScoopBox in my [blog](https://hasan-hasanov.com/2020/11/25/scoopbox/)._

## Boxer
Boxer is a cli tool that launches Windows Sandbox with preinstalled applications or execute scripts at startup. It takes full advantage of the [ScoopBox](https://github.com/hasan-hasanov/ScoopBox) library implementing and exposing all the functionalities to the end user.

### Quick Start
Start Windows Sandbox with predefined applications using Chocolatey:
```
boxer script --chocolatey "git,fiddler,vscode"
```

Start Windows Sandbox with predefined applications using Scoop:
```
boxer script --scoop "git,fiddler,vscode"
```

Start Windows Sandbox with startup scripts:
```
boxer script -f "C:/Script1.ps1; C:/Script2.ps1"
```

Start Windows Sandbox with startup scripts and applications:
```
boxer script -f "C:/PrepareSandbox.ps1" --chocolatey "git,vscode" -f "C:/CloneRepository.ps1;C:/PrepareDevEnvironment.ps1"
```
## Documentation
### Commands

* **script** - Executes scripts and installs aplications in sandbox.
  * **--chocolatey** - Applications that will be installed with Chocolatey, should be separated by comma (,).
  * **--scoop** - Applications that will be installed with Scoop, should be separated by comma (,).
  * **-f, --file-script** - Full path of the script file including the extension. Supported extensions are **.ps1**, **.bat**, **.cmd**
  * **-s, --literal-script** - Single powershell command.
* **config** - Launch Windows Sandbox using configuration file.
  * **-f, --file** - Path to the config file. Only json configuration is supported.
* **version** - Displays the version of the project in the format: **MAJOR.MINOR.BUILD.REVISION**
* **help** - Displays help for commands and arguments.

### Config
The configuration should be in the following structure:

```json
[
   {
      "args":[],
      "type":""
   }
]
```
Supported types in the schema:
* type: **File**
  * **args:** - Full script file paths
* type: **Chocolatey**
  * **args:** - Applications to install using Chocolatey package manager
* type: **Scoop**
  * **args:** - Applications to install using Scoop package manager
* type: **Literal**
  * **args** - Powershell commands that will be executed
  
 **Here are some valid configuration files that you can use:**
 
 Configuration that installs git and fiddler using Chocolatey and vscode using Scoop package managers:
 
 ```json
 [
   {
      "args":["git", "fiddler"],
      "type":"Chocolatey"
   },
   {
      "args":["vscode"],
      "type":"Scoop"
   }
]
 ```
 
 Configuration that runs **PrepareEnvironment.ps1** script. After the preparation installs vs code and cleans up all the resources. Latsly when everything is done starts notepad.
 ```json
 [
   {
      "args":["C:/PrepareEnvironment.ps1"],
      "type":"File"
   },
   {
      "args":["vscode"],
      "type":"Scoop"
   },
   {
      "args":["C:/Cleanup.ps1"],
      "type":"File"
   },
   {
     "args":["Start-Process 'C:\windows\system32\notepad.exe'"],
      "type":"Literal"
   }
]
 ```
**The order matters. All the scripts are ran in the order they are defined.**

## Download

Coming soon as dotnet tool, chocolatey, scoop and winget

## Contribute

### Did you find a bug?

Ensure the bug was not already reported by searching on GitHub under Issues.
If you're unable to find an open issue addressing the problem, open a new one. Be sure to include a title and clear description, as much relevant information as possible.

### Did you write a patch that fixes a bug?

Open a new GitHub pull request with the patch.
Ensure the PR description clearly describes the problem and solution. Include the relevant issue number if applicable.

### Did you fix whitespace, format code, or make a purely cosmetic patch?
Open a new GitHub pull request with the patch.
