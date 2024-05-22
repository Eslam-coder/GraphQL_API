using Project_GraphQL_Web_API_Practice.Entities;

namespace Project_GraphQL_Web_API_Practice.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        
        Owner GetById(Guid id);

        Owner CreateOwner(Owner owner);

        Owner UpdateOwner(Owner dbOwner, Owner owner);

        void DeleteOwner(Owner owner);
    }
}
