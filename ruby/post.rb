require 'rest-client'
require 'json'

ENDPOINT = "http://example.com"

data = {
    "retain" => 1,
    "counters" => {
        "PBX/line status.0" => 1,
        "PBX/line status.1" => 0,
        "PBX/version" => "Mock Phone System 1.0"
    },
    "apikey" => "MDAwMDAwMDAxM0FDRDhDQj=="

}
begin
    response = RestClient.post ENDPOINT + "/restj/ncrest/openmon/update", data.to_json, :content_type => :json
    puts "Response: #{response}"
rescue RestClient::Exception => e
    puts "Error[#{e.http_code}]: #{e.response}"
rescue Exception => e
    puts "Error: Low-level error: #{e}"
end



