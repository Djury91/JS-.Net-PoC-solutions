# MyNodeServer
Nodejs installation is required.
Latest LTS Version: **16.16.0**
https://nodejs.org/en/download/

## Scenario Two -  HTTPCalls

- We have a TS/JS library that contains a greeter function loads the data using a http call. (We could use a simple node server that returns the decrypted string)
"*via a callback the function can decrypt the binary data using a native crypto library (that crypto lib can be mocked, better option would be to use a standard lib)
the function gets the decrypted value from the callback and returns the Hello ...DecrtyptedValue...*"

- We have native app written in C# that loads the TS/JS greeter function into JS/Web Engine and calls it

> #### environment
>	- Visual Studio 2022 V17.2.6
>		- Target framework .Net 5
>		- Output type Console Application
>	- JS Engine
>		- ClearScript V8  https://github.com/microsoft/ClearScript

# How to start
>-  Install nodejs
>-  Clone the repository
>-  Right click on the Solution(Set Startup Projects...) and check
>       - Multiple startup project
>		- MyNodeServer is set up to Start
>		- HTTPCallsViaJSEngine is set up to Start
> - "appV2.js" is set as Node,js Startup file (the name of the file is bold)
>  - Press F5