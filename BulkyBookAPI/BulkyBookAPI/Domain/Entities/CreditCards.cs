using System.ComponentModel.DataAnnotations;

namespace BulkyBookAPI.Domain.Entities
{
    public class CreditCards
    {

        [Key]
        public Guid CardId { get; set; }
        public string CardHolderName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CardExpirationDate { get; set; } = string.Empty;
        public string CardVerificationCode { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        public string CardBrand { get; set; } = string.Empty;


        public User User { get; set; }

    }
}
