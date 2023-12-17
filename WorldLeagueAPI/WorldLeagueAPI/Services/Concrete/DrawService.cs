using Microsoft.Data.SqlClient;
using WorldLeagueAPI.Models;
using WorldLeagueAPI.Services.Abstract;


namespace WorldLeagueAPI.Services.Concrete
{
    public class DrawService : IDrawService
    {
        private readonly DataContext _context;

        public DrawService(DataContext context)
        {
            _context = context;
        }

        public List<GroupModel> RunDraw(int groupCount,string firstName,string lastName)
        {
            if (groupCount != 4 && groupCount != 8)
            {
                throw new ArgumentException("Geçersiz grup sayısı");
            }

            var teams = _context.Teams.ToList();
            var groups = new List<GroupModel>();

            for (int teamIndex = 0; teamIndex < (groupCount == 4 ? 8 : 4); teamIndex++)
            {
                for (int groupIndex = 0; groupIndex < groupCount; groupIndex++)
                {
                    var group = groups.FirstOrDefault(g => g.GroupName == ((char)('A' + groupIndex)).ToString());

                    if (group == null)
                    {
                        group = new GroupModel
                        {
                            GroupName = ((char)('A' + groupIndex)).ToString(),
                            Teams = new List<TeamModel>()
                        };
                        groups.Add(group);
                    }

                    var selectedTeam = SelectTeam(teams, group.Teams.Select(t => t.Country).ToList());

                    if (selectedTeam != null)
                    {
                        group.Teams.Add(selectedTeam);
                        teams.Remove(selectedTeam);
                    }
                    else
                        break;
                }
            }

            SaveDrawResults(groups,firstName,lastName);
            groups = groups.OrderBy(g => g.GroupName).ToList();

            return groups;
        }
        private TeamModel SelectTeam(List<TeamModel> allTeams, List<string> excludedCountries)
        {
            var availableTeams = allTeams
                .Where(t => !excludedCountries.Contains(t.Country))
                .ToList();

            if (availableTeams.Any())
            {
                var selectedTeam = availableTeams.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                return selectedTeam;
            }
            else
                return null;
        }
        private void SaveDrawResults(List<GroupModel> groups,string firstName,string lastName)
        {
            var drawResults = new List<DrawResult>();

            foreach (var group in groups)
            {
                foreach (var team in group.Teams)
                {
                    var drawResult = new DrawResult
                    {
                        GroupName = group.GroupName,
                        TeamName = team.Name,
                        Country = team.Country,
                        FirstName = firstName, 
                        LastName = lastName
                    };

                    drawResults.Add(drawResult);
                }
            }
            _context.DrawResults.AddRange(drawResults);
            _context.SaveChanges();
        }
    }
}
