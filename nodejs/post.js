var http = require('http');

var data = {
    "retain": 1,
    "counters": {
        "PBX/line status.0": 1,
        "PBX/line status.1": 0,
        "PBX/version": "Mock Phone System 1.0"
    },
    "apikey": "MDAwMDAwMDAxM0FDRDhDQj=="
}

var options = {
    host: 'example.com',
    port: 80,
    path: "/restj/ncrest/openmon/update",
    method: "POST",
    headers: {'Content-Type': 'application/json; charset=utf-8'}
};

var req = http.request(options, function(res){
    console.log('STATUS: ' + res.statusCode);
    res.setEncoding('utf8');
    res.on('data', function (chunk) {
        console.log('BODY: ' + chunk);
    });
});

req.on('error', function(e) {
    console.log('problem with request: ' + e.message);
});

req.write(JSON.stringify(data));
req.end();