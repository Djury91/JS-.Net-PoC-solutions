function myGreetings() {
	var msg = "";
	var response = myGreetingsGetAsync().Result;

	if (response) {
		var decryptedText = decryptString(response);
		var msg = "from js - decrypted text: Greetings " + decryptedText + "!";
	}
    else {
		msg = "from js: Response can npt be null!";
	}

	log(msg);
}

myGreetings();