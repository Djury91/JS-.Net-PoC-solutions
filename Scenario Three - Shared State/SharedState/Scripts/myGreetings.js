/*
	https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/async_function
	A Promise which will be resolved with the value returned by the async function, 
	or rejected with an exception thrown from, or uncaught within, the async function.
*/

async function myGreetingsAsync() {
	return await myGreetingsGetAsync();	
}

function logging(msg) {
	log(msg);
	insertLog2MySQLite(msg);
}

// https://www.w3schools.com/js/js_async.asp
myGreetingsAsync()
	.then((res) => {
		//log("from js res - " + JSON.stringify(res))
		var decryptedText = decryptString(res.Result);
		var msg = "from js res - decrypted text: Greetings " + decryptedText + "!";
		logging(msg);
	})
	.catch((err) => {
		//log("from js err - " + err)
		var msg = "from js err - " + err;
		logging(msg);
	});