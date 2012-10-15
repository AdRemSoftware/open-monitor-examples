# OpenMonitor example clients

## REST API & Data Format

To access API all you need to access your server web access port with given URL. All request must also add API key configured in open monitor options.

### Simple Update Counter (URL form)
    
	http://example.com/ncintf/rest/1/openmon/counter?crm%2Fday-orders=121&crm%2Ftoday-emails=234&retain=1&apikey=MDAwMDAwMDAxM0FDRDhDQj==

### Update Counters (POST) with JSON data

You need send POST request to `http://example.com/ncintf/rest/1/openmon/update` with JSON content.

#### Example JSON content
	
    {
      "retain": 1,
      "apikey": "MDAwMDAwMDAxM0FDRDhDQj==",
      "counters": {
        "PBX/line status.0": 1,
        "PBX/line status.1": 0,
        "PBX/version": "Mock Phone System 1.0"
	  }
    }
 
Remember to set `Content-Type` header to `application/json`. As you see you can add any data as counter but only numeric counters can be used in threshold events and trends. Other values can be seen in Node Status page.