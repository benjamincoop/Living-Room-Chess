const express = require('express');
const url = require('url');

const app = express();
const router = express.Router();
const port = 3000;

let _selectedSpace = '';
let _lastMove = '';

// serve app page
// app.get('/', (request, response) => response.sendFile(__dirname + '/index.html'));
app.use(express.static(__dirname));
app.get('/', (request, response) => response.sendFile('index.html'));

// all api routes prefixed with /api
app.use('/api', router);

router.get('/get_selected', (request, response) => {
	response.json({data: `${_selectedSpace}`});
});

router.get('/send_selected', (request, response) => {
	var parameters = url.parse(request.url, true).query;
	_selectedSpace = parameters.selected;
	response.json({data: `OK`});
});

router.get('/get_move', (request, response) => {
	response.json({data: `${_lastMove}`});
});

router.get('/send_move', (request, response) => {
	var parameters = url.parse(request.url, true).query;
	_lastMove = parameters.move;
	_selectedSpace = '';
	response.json({data: `OK`});
});

app.listen(port, () => console.log(`Listening on port ${port}`));