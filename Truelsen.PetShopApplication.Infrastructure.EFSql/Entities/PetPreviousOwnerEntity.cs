namespace Truelsen.PetShopApplication.Infrastructure.EFSql.Entities
{
    public class PetPreviousOwnerEntity
    {
        public int PetId { get; set; }
        public int PreviousOwnerId { get; set; }
        public int PetTypeId { get; set; }
        

    }
}