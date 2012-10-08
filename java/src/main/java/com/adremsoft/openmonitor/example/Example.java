package com.adremsoft.openmonitor.example;

import com.google.gson.Gson;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.utils.URIBuilder;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;

import java.io.IOException;
import java.net.URISyntaxException;
import java.util.HashMap;
import java.util.Map;


class RequestData {
    int retain = 1;
    String apikey;
    Map<String, String> counters = new HashMap<String, String>();
}

public class Example {
    public static void simpleRequest() throws URISyntaxException, IOException {
        URIBuilder uri = new URIBuilder();
        uri.setScheme("http")
                .setHost("example.com")
                .setPort(80)
                .setPath("/restj/ncrest/openmon/counter")
                .setParameter("retain", "1")
                .setParameter("PBX/line status.0", "1")
                .setParameter("PBX/line status.1", "0")
                .setParameter("PBX/version", "Mock Phone System 1.0")
                .setParameter("apikey", "MDAwMDAwMDAxM0FDRDhDQj==");


        HttpGet httpGet = new HttpGet(uri.build());

        HttpClient client = new DefaultHttpClient();
        HttpResponse response = client.execute(httpGet);

        try {
            HttpEntity entity = response.getEntity();
            System.out.println(EntityUtils.toString(entity));
        } finally {
            httpGet.releaseConnection();
        }
    }

    public static void jsonRequest() throws URISyntaxException, IOException {
        HttpPost httpPost = new HttpPost("http://example.com/restj/ncrest/openmon/update");
        Gson gson = new Gson();

        RequestData data = new RequestData();
        data.retain = 5;
        data.counters.put("PBK/line status.0", "1");
        data.counters.put("PBK/line status.1", "0");
        data.counters.put("PBK/version", "Mock Phone System 1.0");
        data.apikey = "MDAwMDAwMDAxM0FDRDhDQj==";

        httpPost.setEntity(new StringEntity(gson.toJson(data)));
        httpPost.setHeader("Content-Type", "application/json; charset=utf-8");
        HttpClient client = new DefaultHttpClient();
        HttpResponse response = client.execute(httpPost);

        try {
            HttpEntity entity = response.getEntity();
            System.out.println(EntityUtils.toString(entity));
        } finally {
            httpPost.releaseConnection();
        }
    }

    public static void main(String[] args) throws Exception {
        simpleRequest();
        jsonRequest();
    }
}
