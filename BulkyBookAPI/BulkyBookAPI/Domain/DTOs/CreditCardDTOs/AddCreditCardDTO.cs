using BulkyBookAPI.Domain.DTOs.UserDTOs;

namespace BulkyBookAPI.Domain.DTOs.CreditCardDTOs
{
    public class AddCreditCardDTO
    {
       
        public string CardHolderName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CardExpirationDate { get; set; } = string.Empty;
        public string CardVerificationCode { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        public string CardBrand { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
