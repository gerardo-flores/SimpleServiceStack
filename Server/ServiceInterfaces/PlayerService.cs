using ServiceStack.ServiceHost;
using PetaPoco;

namespace SimpleServiceStack.Models
{
    
    public class PlayerService : IService
    {
        public Database db { get; set; }

        public object Get(Player request)
        {
            return db.Query<Player>("SELECT * FROM Players");
        }

        public object Post(Player request)
        {
            var result = db.Insert(request);
            return result;
        }
    }
}