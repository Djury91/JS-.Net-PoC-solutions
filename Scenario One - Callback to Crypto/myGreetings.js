function myGreetings(encryptedText) {
    {
        var decryptedtext = decryptString(encryptedText);
        var msg = "decryptedText: Greetings " + decryptedtext + "!";
        log(msg);
    }
};

myGreetings(encryptedText);