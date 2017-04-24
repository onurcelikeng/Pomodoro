using System;
using System.Net.Http;
using Pomodoro.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pomodoro.Services
{
    public class DataClient
    {
        private HttpClient client = new HttpClient();
        private string ApiUrl = "http://pomodoro.azurewebsites.net";


        public DataClient()
        {
            client.BaseAddress = new Uri(ApiUrl);
        }


		public void SetToken(string token)
		{
			client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
		}

        public async Task<bool> Register(RegisterModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage req = await client.PostAsync("/account/register", content);

			if (req != null && req.IsSuccessStatusCode)
			{
				var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(data);
			}

            return false;
        }

        public async Task<TokenModel> Login(LoginModel model)
        {
			var json = JsonConvert.SerializeObject(model);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

			HttpResponseMessage req = await client.PostAsync("/token", new FormUrlEncodedContent(
				new Dictionary<string, string>()
				{
	                { "grant_type", model.grant_type },
	                { "Username", model.Username },
					{ "Password", model.Password }
				}));

			if (req != null && req.IsSuccessStatusCode)
			{
				var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TokenModel>(data);
			}

			return null;
        }

        public async Task<List<ProjectModel>> GetProjects()
        {
            HttpResponseMessage req = await client.GetAsync("/api/getproject");

            if(req != null && req.IsSuccessStatusCode)
            {
				var data = await req.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<ProjectModel>>(data);
            }

            return null;
        }



		public async Task<ProjectModel> GetCurrentProject()
		{
			HttpResponseMessage req = await client.GetAsync("/api/currentproject");

			if (req != null && req.IsSuccessStatusCode)
			{
				var data = await req.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<ProjectModel>(data);
			}

			return null;
		}

        public async Task<bool> DeleteProject(int id)
		{
			HttpResponseMessage req = await client.GetAsync("/api/deleteproject?id=" + id);

			if (req != null && req.IsSuccessStatusCode)
			{
				var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(data);
			}

            return false;
		}

		public async Task<bool> FinishProject(int id)
		{
			HttpResponseMessage req = await client.GetAsync("/api/finishproject?id=" + id);

			if (req != null && req.IsSuccessStatusCode)
			{
				var data = await req.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<bool>(data);
			}

			return false;
		}

		public async Task<bool> finishTask(int id)
		{
			HttpResponseMessage req = await client.GetAsync("/api/finishtask?id=" + id);

			if (req != null && req.IsSuccessStatusCode)
			{
				var data = await req.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<bool>(data);
			}

			return false;
		}

		public async Task<bool> DeleteTask(int id)
		{
			HttpResponseMessage req = await client.GetAsync("/api/deletetask?id=" + id);

			if (req != null && req.IsSuccessStatusCode)
			{
				var data = await req.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<bool>(data);
			}

			return false;
		}

        public async Task<ProjectModel> AddProject(ProjectModel model)
        {
			var json = JsonConvert.SerializeObject(model);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

			HttpResponseMessage req = await client.PostAsync("/api/addproject", content);

			if (req != null && req.IsSuccessStatusCode)
			{
				var data = await req.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<ProjectModel>(data);
			}

            return null;
        }

        public async Task<List<TaskModel>> GetTasks(int id)
		{
			HttpResponseMessage req = await client.GetAsync("/api/gettask?id=" + id);

			if (req != null && req.IsSuccessStatusCode)
			{
				var data = await req.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<TaskModel>>(data);
			}

			return null;
		}

        public async Task<TaskModel> AddTasks(AddTaskModel model)
		{
			var json = JsonConvert.SerializeObject(model);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

			HttpResponseMessage req = await client.PostAsync("/api/addtask", content);

			if (req != null && req.IsSuccessStatusCode)
			{
				var data = await req.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<TaskModel>(data);
			}

			return null;
		}

    }
}