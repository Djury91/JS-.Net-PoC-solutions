const express = require('express');

const app = express();
app.use(express.json()); //4.16+
const port = 1773

app.get("/hello", (req, res) => {
    //let name = req.query.name ?? "nobody";
    //let message = req.query.message ?? "This is default message";

    //console.log("query: "+ req.query);
    //console.log(name + "," + message);

    //res.json({
    //    "name": name,
    //    "message": message
    //});
    if (req.body) {
        res.send(req.body);
    }
    else {
        res.status(500).json({name: "Error", message: ""});
    }
    res.end();


})

app.listen(port, function () {
    console.log(`started api server on port ${port}`)
})
