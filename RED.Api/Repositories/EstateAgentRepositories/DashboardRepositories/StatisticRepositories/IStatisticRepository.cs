namespace RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories
{
    public interface IStatisticRepository
    {
        int PropertyCountByEmployeeId(int id);
        int PropertyCountByStatusTrue(int id);
        int PropertyCountByStatusFalse(int id);
        int AllPropertyCount();
    }
}
