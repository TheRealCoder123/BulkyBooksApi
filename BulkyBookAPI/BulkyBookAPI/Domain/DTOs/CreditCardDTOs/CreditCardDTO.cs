using BulkyBookAPI.Domain.DTOs.UserDTOs;

namespace BulkyBookAPI.Domain.DTOs.CreditCardDTOs
{
    public class CreditCardDTO
    {
        public Guid CardId { get; set; }
        public string CardHolderName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CardExpirationDate { get; set; } = string.Empty;
        public string CardVerificationCode { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        public string CardBrand { get; set; } = string.Empty;


        public UserResponseDTO? User { get; set; }
    }
}
