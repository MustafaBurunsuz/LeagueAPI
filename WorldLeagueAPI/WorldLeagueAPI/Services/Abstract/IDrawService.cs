using WorldLeagueAPI.Models;

namespace WorldLeagueAPI.Services.Abstract
{
    public interface IDrawService
    {
        public List<GroupModel> RunDraw(int groupCount, string firstName, string lastName);
    }
}
