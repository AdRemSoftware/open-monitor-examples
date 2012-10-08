<?php 
$endpoint = "http://example.com";

$data = Array(
    "retain"=> 1,
    "PBX/line status.0" => 1,
    "PBX/line status.1" => 0,
    "PBX/version" => "Mock Phone System 1.0",
    "apikey" => "MDAwMDAwMDAxM0FDRDhDQj=="
);
$curl = curl_init($endpoint."/restj/ncrest/openmon/counter?".http_build_query($data)); 
curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
$result = curl_exec($curl); 

if(!curl_errno($curl)){ 
  echo 'Response: '.$result; 
} else { 
  echo 'Curl error: ' . curl_error($curl); 
} 
curl_close($curl); 
?>