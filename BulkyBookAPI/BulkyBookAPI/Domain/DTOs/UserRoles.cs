namespace BulkyBookAPI.Domain.DTOs
{
    public class UserRoles
    {

        //System admin, can add,remove,edit,delete books,authors and genres
        public string ADMIN { get; set; } = "Admin";

        //User that can edit books, authors, and genres
        public string Moderator { get; set; } = "Moderator";

        //A normal user that can only buy products
        public string BUYER { get; set; } = "Buyer";

    }
}
