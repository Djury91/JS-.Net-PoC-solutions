var crypto = require("crypto");
//var cryptoJS = require("./crypto-v3.1.2");

export function myGreetings(encryptedText) {
    var decryptedtext = "";
    //decryptedtext = decryptString(encryptedText);
    return "Greetings " + decryptedtext + "!";
};

export function decryptString(encryptedtext) {
    var algorithm = "aes-256";
    var key = "8080808080808080";
    //var _key = cryptoJS.enc.Utf8.parse(key);
    //var _key = crypto.scryptSync(key, "", 16);//Buffer.from(key, 'utf-8');
    //var _key = crypto.createHash(algorithm, key).digest();
    //var _iv = crypto.createHash(algorithm, key).digest();
    var decryptedText = "default";

    //crypto.scryptSync(key, "", 16)

    //var decipher = crypto.createDecipheriv(algorithm, _key, _iv);
    //var decryptedbuffer = decipher.update(encryptedtext);
    //var decrypted = buffer.concat([decryptedbuffer, decipher.final("utf-8")]);
    //decryptedText = decrypted.tostring();

    return decryptedText;
};