<?php 
$endpoint = "http://example.com";

$data = Array(
    "retain"=> 1,
	"counters" => Array(
		"PBX/line status.0" => 1,
		"PBX/line status.1" => 0,
		"PBX/version" => "Mock Phone System 1.0"
	),
    "apikey" => "MDAwMDAwMDAxM0FDRDhDQj=="

);
$curl = curl_init($endpoint."/restj/ncrest/openmon/update"); 

$options = array(
	CURLOPT_POST => true, 
	CURLOPT_HTTPHEADER => array('Content-type: application/json; charset=utf-8'),
	CURLOPT_POSTFIELDS => json_encode($data),
	CURLOPT_RETURNTRANSFER => true
);
curl_setopt_array( $curl, $options );

$result = curl_exec($curl); 

if(!curl_errno($curl)){ 
  echo 'Response: '.$result; 
} else { 
  echo 'Curl error: ' . curl_error($curl); 
} 
curl_close($curl); 
?>