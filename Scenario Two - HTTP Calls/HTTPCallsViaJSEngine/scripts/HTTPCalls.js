//var axios = require("./axios-v0.27.2");

function myGreetings(url, encryptedtext) {
	var decryptedText = "Test Value";

	axios.post(url, encryptedtext)
	.then(res => {
		return res.data;
	})
	.catch(err => {
		console.log("err", err);
	});
}

myGreetings(url, encryptedtext);