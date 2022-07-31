const express = require('express');

const app = express();
app.use(express.json()); //4.16+
const port = 1773

app.get("/hello", (req, res) => {

    res.append("Content-Type", "application/json; charset=UTF-8");
    res.append("Access-Control-Allow-Origin", "*");

    if (req.body) {
        res.status(200).json(req.body);
    }
    else {
        res.status(500)
            .json(
            {
                name: "Error",
                message: "Invalid message!"
            });
    }

    res.end();
})

app.listen(port, function () {
    console.log(`started api server on port ${port}`)
})
