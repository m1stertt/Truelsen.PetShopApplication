namespace Truelsen.PetShopApplication.Core.Models.Authorization
{
    public class Role
    {
        public long RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public enum RoleTypes
    {
        User = 1,
        Administrator = 2
    }
}