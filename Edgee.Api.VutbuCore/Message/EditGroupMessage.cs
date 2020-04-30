namespace Edgee.Api.VutbuCore.Message
{
    public class EditGroupMessage
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupPhoto { get; set; }

        public int GroupAdminId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
    }
}