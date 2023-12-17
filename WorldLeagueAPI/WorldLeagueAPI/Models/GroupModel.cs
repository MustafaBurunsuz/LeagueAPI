using System.Text.Json.Serialization;

namespace WorldLeagueAPI.Models
{
    public class GroupModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public List<TeamModel> Teams { get; set; }
    }
}
