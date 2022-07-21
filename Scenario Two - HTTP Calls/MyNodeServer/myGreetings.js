var crypto = require('crypto');

export function myGreetings(encryptedText) {
//    var decryptedtext = decryptString(encryptedText);
    return "Greetings " + "default" + "!";
};

//function decryptstring(encryptedtext) {
//    var algorithm = "aes-128-cbc";
//    var key = "8080808080808080";
//    var _key = crypto.createhash(algorithm).update(key).digest();
//    var _iv = _key;

//    var decipher = crypto.createdecipheriv(algorithm, _key, _iv);
//    var decryptedbuffer = decipher.update(encryptedtext);
//    decrypted = buffer.concat([decryptedbuffer, decipher.final("utf-8")]);

//    return decrypted.tostring();
//};