require 'rest-client'
ENDPOINT = "http://example.com"

data = {
    "retain" => 1,
    "crm/day-orders" => 121,
    "crm/today-emails" => 234,
    "apikey" => "MDAwMDAwMDAxM0FDRDhDQj=="
}

begin
    response = RestClient.get ENDPOINT + "/restj/ncrest/openmon/counter", params: data
    puts "Response: #{response}"
rescue RestClient::Exception => e
    puts "Error[#{e.http_code}]: #{e.response}"
rescue Exception => e
    puts "Error: Low-level error: #{e}"
end

