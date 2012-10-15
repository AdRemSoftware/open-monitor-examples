import urllib.request
from urllib.error import HTTPError, URLError

ENDPOINT = "http://example.com"

data = {
    "retain": 1,
    "crm/day-orders": 121,
    "crm/today-emails": 234,
    "apikey": "MDAwMDAwMDAxM0FDRDhDQj=="
}
try:
    url = ENDPOINT + "/ncintf/rest/1/openmon/counter?" + urllib.parse.urlencode(data)
    u = urllib.request.urlopen(url)
    print("Response: " + u.read().decode('utf-8'))
except HTTPError as e:
    print("HTTPError: %s" % e.code)
except URLError as e:
    print(e)