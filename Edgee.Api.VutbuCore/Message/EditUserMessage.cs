namespace Edgee.Api.VutbuCore.Message
{
    public class EditUserMessage
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProfilePhoto { get; set; }

        public string EmailAddress { get; set; }
        public string RegionCode { get; set; }
        public string TelephoneNumber { get; set; }
        public string PostCode { get; set; }
    }
}