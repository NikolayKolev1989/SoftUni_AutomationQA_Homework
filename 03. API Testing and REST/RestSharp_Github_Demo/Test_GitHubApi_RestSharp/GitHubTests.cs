using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Test_GitHubApi_RestSharp
{
    public class GitHubTests
    {
        private RestClient client;
        private RestRequest request;
        private string url = "/repos/NikolayKolev1989/SoftUni_AutomationQA_Homework/issues";

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://api.github.com");
            request = new RestRequest(url);
            client.Authenticator = new HttpBasicAuthenticator("NikolayKolev1989", "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");
        }

        [Test]
        public async Task TestGetAllIssues()
        {
            var response = await client.ExecuteAsync(request);
            var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);
            Assert.IsNotNull(response);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            foreach (var issue in issues)
            {
                Assert.That(issue.html_url, Is.Not.Null);
            }
        }

        [Test]
        public async Task TestPostIssue()
        {
            string title = "New test issue from RestSharp";
            string body = "Some body here";
            var issue = await CreateIssue(title, body);
            Assert.Greater(issue.id, 0, "Issue ID");
            Assert.Greater(issue.number, 0, "Issue number");
            Assert.IsNotEmpty(issue.title, "Issue title");
        }


        /*Method to create issue*/
        private async Task<Issue> CreateIssue(string title, string body)
        {
            request.AddBody(new { body, title});
            var response = await this.client.ExecuteAsync(request, Method.Post);
            var issue = JsonSerializer.Deserialize<Issue>(response.Content);
            return issue;
        }
    }
}