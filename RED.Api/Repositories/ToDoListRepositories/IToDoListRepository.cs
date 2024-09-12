using RED.Api.DTOs.ToDoListDTOs;

namespace RED.Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDTO>> GetAllToDoListAsync();
        void CreateToDoList(CreateToDoListDTO ToDoListDTO);
        void DeleteToDoList(int id);
        void UpdateToDoList(UpdateToDoListDTO ToDoListDTO);
        Task<GetByIDToDoListDTO> GetToDoList(int id);
    }
}
