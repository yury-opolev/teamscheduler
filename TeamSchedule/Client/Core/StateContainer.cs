/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Client.Core
{
    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
    using TeamSchedule.Shared.Model;

    public class StateContainer
    {
        public bool IsInProgress { get; private set; }

        public IList<Team> Teams { get; private set; } = new List<Team>();

        public IList<TeamUser> Users { get; private set; } = new List<TeamUser>();

        public async Task<bool> TryFetchTeamsAsync(ApiClient apiClient)
        {
            return await this.RunActionAsync(async () => { this.Teams = await apiClient.GetTeamsList(); });
        }

        public async Task<bool> TryFetchUsersAsync(ApiClient apiClient)
        {
            return await this.RunActionAsync(async () => { this.Users = await apiClient.GetAllUsers(); });
        }

        public async Task<bool> TryCreateTeamAsync(ApiClient apiClient, Team team)
        {
            return await this.RunActionAsync(async () => { await apiClient.CreateTeam(team); });
        }

        public async Task<bool> TryUpdateTeamAsync(ApiClient apiClient, Team team)
        {
            return await this.RunActionAsync(async () => { await apiClient.UpdateTeam(team); });
        }

        public async Task<bool> RunActionAsync(Func<Task> action)
        {
            this.IsInProgress = true;
            try
            {
                await action();
                return true;
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.GetType()}: {exception.Message}");
                return false;
            }
            finally
            {
                this.IsInProgress = false;
            }
        }
    }
}
