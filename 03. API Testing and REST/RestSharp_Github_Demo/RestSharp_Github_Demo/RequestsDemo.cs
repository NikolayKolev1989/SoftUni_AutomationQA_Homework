using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text.Json;

/*GET HTTP Requests*/

//Get all repos names

/*var client = new RestClient("https://api.github.com");
var request = new RestRequest("/users/{user}/repos");
request.AddUrlSegment("user", "NikolayKolev1989");

var response = await client.ExecuteAsync(request);

var repos = JsonSerializer.Deserialize<List<Repo>>(response.Content);
foreach (var repo in repos)
{
    Console.WriteLine("REPO FULL NAME: " + repo.full_name);
}*/


//Get all issues status codes and body content

/*var request = new RestRequest("/repos/{user}/{repo}/issues");
request.AddUrlSegment("user", "NikolayKolev1989");
request.AddUrlSegment("repo", "SoftUni_AutomationQA_Homework");

var response = await client.ExecuteAsync(request);

var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

Console.WriteLine("STATUS CODE: " + response.StatusCode);
Console.WriteLine("BODY: " + response.Content);*/


/*Create Issue with POST HTTP Request*/

var client = new RestClient("https://api.github.com");
client.Authenticator = new HttpBasicAuthenticator("NikolayKolev1989", "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");
var request = new RestRequest("/repos/{user}/{repo}/issues");
request.AddUrlSegment("user", "NikolayKolev1989");
request.AddUrlSegment("repo", "SoftUni_AutomationQA_Homework");

request.AddBody(new { title = "New Issue from RestSharp"});

var response = await client.ExecuteAsync(request, Method.Post);

Console.WriteLine("STATUS CODE: " + response.StatusCode);
Console.WriteLine("CONTENT: " + response.Content);