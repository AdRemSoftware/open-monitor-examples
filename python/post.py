import urllib.request
from urllib.error import HTTPError, URLError
import json

ENDPOINT = "http://example.com"

data = {
    "retain": 1,
    "counters": {
        "crm/day-orders": 121,
        "crm/today-emails": 234
    },
    "apikey": "MDAwMDAwMDAxM0FDRDhDQj=="
}

try:
    url = ENDPOINT + "/restj/ncrest/openmon/update"
    opener = urllib.request.build_opener()
    opener.addHeaders = [('Content-Type', 'application/json; charset=utf-8')]
    u = opener.open(url, json.dumps(data).encode('utf-8'))
    print("Response: " + u.read().decode('utf-8'))
except HTTPError as e:
    print("HTTPError: %s" % e.code)
except URLError as e:
    print(e)
