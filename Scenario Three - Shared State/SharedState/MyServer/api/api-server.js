const express = require('express');

const app = express();
app.use(express.json());
const port = 1773

app.get('/hello', (req, res) => {
    //let name = req.query.name ?? "nobody";
    //let message = req.query.message ?? "This is default message";

    //console.log("query: "+ req.query);
    //console.log(name + "," + message);

    //res.json({
    //    "name": name,
    //    "message": message
    //});
    res.send(req.body);


})

app.listen(port, function () {
    console.log(`started api server on port ${port}`)
})
