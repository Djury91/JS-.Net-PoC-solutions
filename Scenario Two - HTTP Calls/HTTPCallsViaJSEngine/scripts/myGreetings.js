function myGreetings() {
	var msg = "";
	var response = myGreetingsPost().Result;

	if (!response) {
		msg = "The response was null or empty!";
	}
	else {
		var decryptedText = decryptString(response);
		var msg = "decrypted text: Greetings " + decryptedText + "!";
	}
	log(msg);
}

myGreetings();