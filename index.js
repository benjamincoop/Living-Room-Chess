const express = require('express');
const url = require('url');

const app = express();
const router = express.Router();
const port = 3000;

//app.get('/', (request, response) => response.send('Hello World'));

// all routes prefixed with /api
app.use('/api', router);

/* router.get('/', (request, response) => {
	response.json({message: 'Hello, welcome to my server'});
}); */

router.get('/move', (request, response) => {
	var parameters = url.parse(request.url, true).query;
	response.json({message: `Moved ${parameters.src} to ${parameters.dest}`});
});

app.listen(port, () => console.log(`Listening on port ${port}`));