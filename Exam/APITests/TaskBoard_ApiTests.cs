using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace APITests
{
    public class TaskBoard_ApiTests
    {
        private const string url = "https://taskboard.nakov.repl.co/api";
        private RestClient client;
        private RestRequest request;

        [SetUp]
        public void Setup()
        {
            this.client = new RestClient();
        }

        [Test]
        public void Test_GetAllTasks_CheckFirstTask()
        {
            request = new RestRequest(url + "/tasks/board/Done");
            var response = this.client.Execute(request);
            var tasks = JsonSerializer.Deserialize<List<Tasks>>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(tasks.Count, Is.GreaterThan(0));
            Assert.That(tasks[0].title, Is.EqualTo("Project skeleton"));
        }

        [Test]
        public void Test_SearchTasks_CheckFirstTask()
        {
            request = new RestRequest(url + "/tasks/search/home");
            var response = this.client.Execute(request);
            var tasks = JsonSerializer.Deserialize<List<Tasks>>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(tasks.Count, Is.GreaterThan(0));
            Assert.That(tasks[0].title, Is.EqualTo("Home page"));
        }

        [Test]
        public void Test_SearchTasks_EmptyResult()
        {
            request = new RestRequest(url + "/tasks/search/{keyword}");
            request.AddUrlSegment("keyword", "missing123789456");
            var response = this.client.Execute(request);
            var tasks = JsonSerializer.Deserialize<List<Tasks>>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(tasks.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_CreateTask_InvalidData()
        {
            request = new RestRequest(url + "/tasks");
            var body = new
            {
                title = "",
                description = ""
            };

            request.AddJsonBody(body);

            var response = this.client.Execute(request, Method.Post);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Content, Is.EqualTo("{\"errMsg\":\"Title cannot be empty!\"}"));

        }

        [Test]
        public void Test_CreateTask_validData()
        {
            request = new RestRequest(url + "/tasks");
            var body = new
            {
                title = "shano",
                description = "shanizmi",
            };

            request.AddJsonBody(body);

            var response = this.client.Execute(request, Method.Post);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            var allTasks = this.client.Execute(request, Method.Get);
            var tasks = JsonSerializer.Deserialize<List<Tasks>>(allTasks.Content);
            var lastTask = tasks.Last();

            Assert.That(lastTask.title, Is.EqualTo(body.title));
            Assert.That(lastTask.description, Is.EqualTo(body.description));

        }
    }
}