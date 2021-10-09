/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Server.Core
{
    using System.Text;

    public static class ExceptionsHelper
    {
        public static string GetBriefDescription(Exception e)
        {
            var sb = new StringBuilder($"{e.GetType()}: {e.Message}");
            while (!(e.InnerException is null))
            {
                sb.Append($" -> {e.GetType()}: {e.Message}");
            }

            return sb.ToString();
        }
    }
}
