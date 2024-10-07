using RED.Api.DTOs.ToDoListDTOs;

namespace RED.Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDTO>> GetAllToDoList();
        Task CreateToDoList(CreateToDoListDTO ToDoListDTO);
        Task DeleteToDoList(int id);
        Task UpdateToDoList(UpdateToDoListDTO ToDoListDTO);
        Task<GetByIDToDoListDTO> GetToDoList(int id);
    }
}
