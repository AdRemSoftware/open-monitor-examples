use strict;
use warnings;

use LWP::Simple;
use URI;

my $endpoint = "http://example.com/restj/ncrest/openmon/counter";

my %data = (
    "retain"=> 1,
    "PBX/line status.0" => 1,
    "PBX/line status.1" => 0,
    "PBX/version" => "Mock Phone System 1.0",
    "apikey" => "MDAwMDAwMDAxM0FDRDhDQj=="
);

my $uri = URI->new( $endpoint );
$uri->query_form(%data);

my $req = HTTP::Request->new(GET => $uri);
my $ua = LWP::UserAgent->new;
my $response = $ua->request($req);

if($response->is_success()) {
	print "Counter updated.\n";
} else {
	print "Error updating counter.\n";
}
