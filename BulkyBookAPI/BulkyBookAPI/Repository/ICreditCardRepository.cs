using BulkyBookAPI.Domain.DTOs.CreditCardDTOs;

namespace BulkyBookAPI.Repository
{
    public interface ICreditCardRepository
    {

        Task<bool> AddCreditCard(AddCreditCardDTO addCreditCardDTO);
        Task<IEnumerable<CreditCardDTO>> GetCreditCardsByUserID(Guid userId);
        Task<bool> DeleteCard(Guid cardID);


    }
}
