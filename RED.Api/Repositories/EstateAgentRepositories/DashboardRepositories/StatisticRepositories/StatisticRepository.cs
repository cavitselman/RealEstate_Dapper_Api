using Dapper;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }
        public int AllPropertyCount()
        {
            string query = "Select Count(*) From Property";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int PropertyCountByEmployeeId(int id)
        {
            string query = "Select Count(*) From Property Where AppUserId=@appUserId";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query,parameters);
                return values;
            }
        }

        public int PropertyCountByStatusFalse(int id)
        {
            string query = "Select Count(*) From Property Where AppUserId=@appUserId And PropertyStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public int PropertyCountByStatusTrue(int id)
        {
            string query = "Select Count(*) From Property Where AppUserId=@appUserId And PropertyStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }
    }
}
