const WebSocket = require('ws');

const port = 8083
const wss = new WebSocket.Server({port: port});

console.log(`started websocket server on port ${port}`)

wss.on('connection', (ws) => {

    ws.on('message', (data) => {
        console.log('received: %s', data);
    });

    const interval = setInterval(() => {
        ws.send(`here comes your lucky number: ${Math.floor(Math.random() * 42)}`);
    }, 2000);

    ws.on('close', () => {
        console.log('closing')
        clearInterval(interval);
    });

    ws.send('hi dude!');
});
