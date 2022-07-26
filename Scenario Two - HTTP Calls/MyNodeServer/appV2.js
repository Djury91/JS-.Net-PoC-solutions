var http = require("http"); // Import Node.js core module
var port = 5000;

var server = http.createServer(function (req, res) { // creating server
    var encryptedText = "";

    if (req.url = "/mynodeapp") {
        console.log("reciving...");
        req.on(
            "data", chunk => {
                encryptedText += chunk;
            }
        );
        req.on(
            "end", () => {
                console.log("encryptedText: " + encryptedText);

                res.writeHead(200, {
                    "Content-Type": "text/plain",
                    "Access-Control-Allow-Origin": "*"
                });
                res.write(encryptedText);
                res.end();
                console.log("req end...");
            }
        );
    }
});

server.listen(port); // listen for any incoming requests

console.log('Node.js appv2 web server at port ' + port + ' is running...')

// install nodejs
// to run single server.js file
// run prompt as administaror
// if Node is missing from the SYSTEM PATH, try this in your command line
// setx Path "%PATH%;C:\C:\Program Files (x86)\nodejs"
// setx Path "%PATH%;C:\C:\Program Files\nodejs"
// restart your command prompt

// test curl -i http://localhost:port