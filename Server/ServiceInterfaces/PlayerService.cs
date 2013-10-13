using ServiceStack.ServiceHost;

namespace SimpleServiceStack.Models
{
    
    public class PlayerService : IService
    {
        public object Any(Player request)
        {
            //Looks strange when the name is null so we replace with a generic name.
            var name = request.Name ?? "John Doe";
            return new PlayerResponse { player = new Player { ID = 1, Name = "Gerardo Flores" } };
        }
    }
}