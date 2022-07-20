# JS-.Net-PoC-solutions

## Scenario One - Callback to Crypto

- We have a TS/JS library that contains a simple greeter function that takes an encrypted String as parameter (binary data)
via a callback the function can decrypt the binary data using a native crypto library (that crypto lib can be mocked, better option would be to use a standard lib)
the function gets the decrypted value from the callback and returns the String "Hello *...DecrtyptedValue...*"

- We have native app written in C# that loads the TS/JS greeter function into JS/Web Engine calls it with some decrypted value

> #### environment
>	- Visual Studio 2022 V17.2.6
>		- Target framework .Net 5
>		- Output type Console Application
>	- JS Engine
>		- Jint  https://github.com/sebastienros/jint
>	- JS Crypto library
>		- https://cdnjs.cloudflare.com/ajax/libs/crypto-js/3.1.2/rollups/aes.js