using ServiceStack.ServiceHost;

namespace SimpleServiceStack.Models
{
    [Route("/players")]
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class PlayerResponse
    {
        public Player player { get; set; }
    }
}