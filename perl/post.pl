use strict;
use warnings;

use LWP::Simple;
use JSON;

my $endpoint = "http://example.com/restj/ncrest/openmon/update";
	
my $data = {
    "retain" => 1,
	"counters" => {
		"PBX/line status.0" => 1,
		"PBX/line status.1" => 0,
		"PBX/version" => "Mock Phone System 1.0"
	},
    "apikey" => "MDAwMDAwMDAxM0FDRDhDQj=="
};

my $req = HTTP::Request->new(POST => $endpoint);
$req->content_type('application/json');
$req->content(encode_json($data));

my $ua = LWP::UserAgent->new;
my $response = $ua->request($req);

if($response->is_success()) {
	print "Counter updated.\n";
} else {
	print "Error updating counter.\n";
}
