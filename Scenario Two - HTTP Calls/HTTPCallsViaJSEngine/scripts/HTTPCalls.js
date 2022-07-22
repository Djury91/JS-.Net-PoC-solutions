function myGreetings(url, encryptedText) {
    var method = "POST";
    var request = new XMLHttpRequest();
    request.open(method, url, true);
    request.setRequestHeader("Content-Type", "text/plain");
    request.send(encryptedText);

    if (request.status == 200) {
        return request.responseText;
    }
    else {
        return "default";
    }
}

myGreetings(url, encryptedText);