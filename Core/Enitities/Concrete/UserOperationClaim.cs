using Core.Entities;

namespace Core.Enitities.Concrete
{
    public class UserOperationClaim : IEntity
    {

        public int id   { get; set; }
        public int UserId   { get; set; }
        public int OperationClaimId { get; set; }


    }
}
