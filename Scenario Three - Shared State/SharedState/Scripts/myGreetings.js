function myGreetings() {
	var response = myGreetingsPost().Result;

	var decryptedText = decryptString(response);
	var msg = "decrypted text: Greetings " + decryptedText + "!";
	log(msg);
}

myGreetings();