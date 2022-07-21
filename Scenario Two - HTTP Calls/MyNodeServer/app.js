//import * as greetings from "./myGreetings"
//var greetings = require("myGreetings.js");
var http = require("http"); // Import Node.js core module
var crypto = require('crypto');
//const hostname = '127.0.0.1';
//const port = 5858;

var server = http.createServer(function (req, res) { // creating server
    var encryptedText = "";
    var decryptedText = "";

    if (req.url = "/mygreetings") {
        req.on(
            "data", chunk => {
                encryptedText += chunk;
            }
        );
        req.on(
            "end", () => {
                console.log("encryptedText: " + encryptedText);
            }
        );

        decryptedText = myGreetings(encryptedText);

        res.writeHead(200, { "Content-Type": "text/plain" });
        res.write(decryptedText);
        res.end();
        console.log("decryption")
    }

}).listen(5000);


function myGreetings(encryptedText) {
    var decryptedtext = decryptString(encryptedText);
    return "Greetings " + decryptedtext + "!";
};

function decryptString(encryptedtext) {
    var algorithm = "sha256";
    var key = "8080808080808080";
    var _key = crypto.scryptSync(key, "", 16);//Buffer.from(key, 'utf-8');
    //var _key = crypto.createHash(algorithm, key).digest();
    var _iv = crypto.createHash(algorithm, key).digest();
    var decryptedText = "default";

    //crypto.scryptSync(key, "", 16)

    //var decipher = crypto.createDecipheriv(algorithm, _key, _iv);
    //var decryptedbuffer = decipher.update(encryptedtext);
    //var decrypted = buffer.concat([decryptedbuffer, decipher.final("utf-8")]);
    //decryptedText = decrypted.tostring();

    return decryptedText;
};

//server.listen(port, hostname, () => {
//    console.log(`Server running at http://${hostname}:${port}/`);
//});

// install nodejs
// to run single server.js file
// run prompt as administaror
// if Node is missing from the SYSTEM PATH, try this in your command line
// setx Path "%PATH%;C:\C:\Program Files (x86)\nodejs"
// setx Path "%PATH%;C:\C:\Program Files\nodejs"
// restart your command prompt

// test curl -i http://localhost:port