namespace RED.Api.DTOs.ToDoListDTOs
{
    public class GetByIDToDoListDTO
    {
        public int ToDoListID { get; set; }
        public string Description { get; set; }
        public bool ToDoListStatus { get; set; }
    }
}
