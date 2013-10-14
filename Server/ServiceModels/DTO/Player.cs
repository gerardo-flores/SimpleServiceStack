using ServiceStack.ServiceHost;

namespace SimpleServiceStack.Models
{
    [PetaPoco.TableName("Players")]
    [PetaPoco.PrimaryKey("ID")]
    [Route("/players")]
    public class Player
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class PlayerResponse
    {
        public Player player { get; set; }
    }
}