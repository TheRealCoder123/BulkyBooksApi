using BulkyBookAPI.Domain.DTOs.CreditCardDTOs;
using BulkyBookAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookAPI.Controllers
{
    [ApiController]
    [Route("credit_cards")]
    public class CreditCardController : Controller
    {

        private readonly ICreditCardRepository _creditCardRepository;

        public CreditCardController(ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }

        [HttpPost]
        [Route("add")]
        [Authorize]
        public async Task<IActionResult> AddCreditCardAsync([FromBody] AddCreditCardDTO addCreditCardDTO) {

            var addResult = await _creditCardRepository.AddCreditCard(addCreditCardDTO);

            if (addResult) {
                return Ok("Successfully added your card");
            }

            return BadRequest("Something went wrong, please try again later");

        }

        [HttpGet]
        [Route("{user_id}")]
        [Authorize]
        public async Task<IActionResult> GetAllCreditCardsByUserIdAsync(Guid user_id) {

            var cards = await _creditCardRepository.GetCreditCardsByUserID(user_id);
            return Ok(cards);
        
        }

        [HttpDelete]
        [Route("{card_id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCreditCardByIdAsync(Guid card_id) {

            var deleteResult = await _creditCardRepository.DeleteCard(card_id);

            if (deleteResult)
            {
                return Ok("Successfully delete your card");
            }

            return BadRequest("Something went wrong, please try again later");


        }

    }
}
