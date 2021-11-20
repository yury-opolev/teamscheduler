/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Client.Core
{
    using System.Net.Http.Json;
    using TeamSchedule.Shared.Model;

    public class ApiClient
    {
        public static readonly string NotifySignInUrl = "api/v1.0/notifysignin";

        public static readonly string UsersUrl = "api/v1.0/users";

        public static readonly string TeamsUrl = "api/v1.0/teams";
        public static readonly string TeamUrl = "api/v1.0/team/{0}";

        public static readonly string TeamUsersUrl = "api/v1.0/team/{0}/users";
        public static readonly string TeamUserUrl = "api/v1.0/team/{0}/user/{1}";

        private HttpClient httpClient;

        public ApiClient(IHttpClientFactory clientFactory)
        {
            this.httpClient = clientFactory.CreateClient("TeamSchedule.ServerAPI");
        }

        public async Task<bool> NotifySignInAsync()
        {
            return await this.httpClient.GetFromJsonAsync<bool>(NotifySignInUrl);
        }

        public async Task<IList<Team>> GetTeamsList()
        {
            return await this.httpClient.GetFromJsonAsync<IList<Team>>(TeamsUrl);
        }

        public async Task CreateTeam(Team team)
        {
            var response = await this.httpClient.PostAsJsonAsync(TeamsUrl, team);
            await this.HandleResponseAsync(response);
        }

        public async Task UpdateTeam(Team team)
        {
            var response = await this.httpClient.PutAsJsonAsync(string.Format(TeamUrl, team.Id), team);
            await this.HandleResponseAsync(response);
        }

        public async Task DeleteTeam(Team team)
        {
            var response = await this.httpClient.DeleteAsync(string.Format(TeamUrl, team.Id));
            await this.HandleResponseAsync(response);
        }

        public async Task AddTeamUser(Team team, TeamUser user)
        {
            await this.httpClient.PutAsJsonAsync(string.Format(TeamUserUrl, team.Id, user.Id), string.Empty);
        }

        public async Task RemoveTeamUser(Team team, TeamUser user)
        {
            await this.httpClient.DeleteAsync(string.Format(TeamUserUrl, team.Id, user.Id));
        }

        public async Task<IList<TeamUser>> GetAllUsers()
        {
            return await this.httpClient.GetFromJsonAsync<IList<TeamUser>>(UsersUrl);
        }

        public async Task<IList<TeamUser>> GetTeamUsers(Guid teamId)
        {
            return await this.httpClient.GetFromJsonAsync<IList<TeamUser>>(string.Format(TeamUsersUrl, teamId));
        }

        private async Task HandleResponseAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response: {response.StatusCode} - {content}");
        }
    }
}
