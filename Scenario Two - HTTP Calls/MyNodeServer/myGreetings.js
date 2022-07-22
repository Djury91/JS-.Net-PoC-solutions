var cryptojs = require("./crypto-v3.1.2");

function myGreetings(encryptedText) {
    var decryptedtext = "default";
    decryptedtext = decryptString(encryptedText);
    return "Greetings " + decryptedtext + "!";
};

module.exports.myGreetings = myGreetings;

function decryptString(encryptedText) {
    var key = "8080808080808080";
    var _key = cryptojs.CryptoJS.enc.Utf8.parse(key);
    var _iv = _key;
    var decryptedtext = "default";

    var decryptedbytes = cryptojs.CryptoJS.AES.decrypt(encryptedText, _key, { iv: _iv });
    var decryptedtext = decryptedbytes.toString(cryptojs.CryptoJS.enc.Utf8);

    return decryptedtext;
};