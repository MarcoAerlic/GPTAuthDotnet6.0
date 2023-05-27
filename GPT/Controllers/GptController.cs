using Core.Model.CoreEntity;
using MarcosWebApiProject.ApplicationService.ADProduct;
using MarcosWebApiProject.ApplicationService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class GptController : ControllerBase
    {

        private readonly IADProductService _adProduct;
        public GptController(IADProductService adProduct)
        {
            _adProduct = adProduct;
        }

        [HttpPost("ExtractDataGptTurbo")]
        [Authorize]
        public async Task<ActionResult<ADProductResponseModel>> GenerateADGPTTurbo(List<GPTMessage> aDGenerateRequestModel)
        {
            try
            {

                var response = await _adProduct.GenerateAdContentGptTurbo(aDGenerateRequestModel);

                return response;
            }
            catch (System.Exception ex)
            {

                return null;
            }

        }

        [HttpPost("ExtractDataGpt4")]
        [Authorize]
        public async Task<ActionResult<ADProductResponseModel>> ExtractADDataGpt4(List<GPTMessage> aDGenerateRequestModel)
        {
            try
            {

                var response = await _adProduct.GenerateAdContentGpt4(aDGenerateRequestModel);

                return response;
            }
            catch (System.Exception ex)
            {

                return null;
            }

        }

        [HttpPost("ExtractDataDavinci")]
        [Authorize]
        public async Task<ActionResult<ADProductResponseModel>> GenerateADDavinci(CustomerRequestModel aDGenerateRequestModel)
        {
            try
            {

                var response = await _adProduct.GenerateAdContentDaVinci(aDGenerateRequestModel);

                return response;
            }
            catch (System.Exception ex)
            {

                return null;
            }

        }

    }
}
