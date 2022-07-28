function myGreetings() {
	var msg = "";
	var response = myGreetingsGetAsync().Result;

	if (response) {
		var decryptedText = decryptString(response);
		var msg = "from js - decrypted text: Greetings " + decryptedText + "!";
	}
    else {
		msg = "from js: Response can not be null!";
	}

	log(msg);
	insertLog2MySQLite(msg);
}

myGreetings();