namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.DB
{
    public class UserData
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Seniority { get; set; }
    }
}
