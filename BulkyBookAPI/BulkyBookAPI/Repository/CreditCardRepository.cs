using BulkyBookAPI.Data;
using BulkyBookAPI.Domain.DTOs.CreditCardDTOs;
using BulkyBookAPI.Domain.Entities;
using BulkyBookAPI.Migrations;
using BulkyBookAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookAPI.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {

        private BulkyDbContext bulkyDbContext;

        public CreditCardRepository(BulkyDbContext bulkyDbContext)
        {
            this.bulkyDbContext = bulkyDbContext;
        }

        public async Task<bool> AddCreditCard(AddCreditCardDTO addCreditCardDTO)
        {

            var user = await bulkyDbContext.User.FirstOrDefaultAsync(x => x.UserId == addCreditCardDTO.UserId);

            if (user == null) {

                return false;

            }
              
            
            var creditCard = new CreditCards
            {
                CardId = Guid.NewGuid(),
                CardHolderName = addCreditCardDTO.CardHolderName,
                CardNumber = addCreditCardDTO.CardNumber,
                CardExpirationDate = addCreditCardDTO.CardExpirationDate,
                CardType = addCreditCardDTO.CardType,
                CardVerificationCode = addCreditCardDTO.CardVerificationCode,
                CardBrand = addCreditCardDTO.CardBrand,
                User = user
            };

            await bulkyDbContext.CreditCard.AddAsync(creditCard);
            await bulkyDbContext.SaveChangesAsync();

            var isAdded = bulkyDbContext.CreditCard.Contains(creditCard);

            if (isAdded) { 
             
                return true;

            }

            return false;
           
        }

        public async Task<bool> DeleteCard(Guid cardID)
        {
            var creditCard = await bulkyDbContext.CreditCard.FirstOrDefaultAsync(x => x.CardId == cardID);

            if (creditCard == null) {
                return false;
            }

            bulkyDbContext.CreditCard.Remove(creditCard);
            await bulkyDbContext.SaveChangesAsync();

            var isAdded = bulkyDbContext.CreditCard.Contains(creditCard);

            if (!isAdded) {
                return true;
            }

            return false;

        }

        public async Task<IEnumerable<CreditCardDTO>> GetCreditCardsByUserID(Guid userId)
        {
            var creditCards = await bulkyDbContext.CreditCard.Include(x => x.User)
                .Where(x => x.User.UserId == userId).ToListAsync();

            var creditCardsDTO = creditCards.Select(x => {

                return new CreditCardDTO
                {
                    CardId = x.CardId,
                    CardHolderName = x.CardHolderName,
                    CardNumber = x.CardNumber,
                    CardExpirationDate = x.CardExpirationDate,
                    CardType = x.CardType,
                    CardVerificationCode = x.CardVerificationCode,
                    CardBrand = x.CardBrand,
                    User = x.User.ToUserDTO()
                };

            });

            return creditCardsDTO;

        }
    }
}
