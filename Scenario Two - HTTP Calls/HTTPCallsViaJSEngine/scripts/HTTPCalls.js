var axios = require("axios-v0.27.2.js");

function myGreetings(url, encryptedtext) {
	var decryptedText = "Test Value";

	axios.post(url, encryptedtext, {
		headers: {
			"Content-Type": "text/plain", // multipart/form-data, text/plain, application/x-www-form-urlencoded
			"Access-Control-Allow-Origin": "*"
		}
    })
	.then(res => {
			return res.data;
	})
	.catch(err => {
		console.log("err", err);
	});
}

myGreetings(url, encryptedtext);