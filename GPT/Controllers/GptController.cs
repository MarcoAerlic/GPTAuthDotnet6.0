using Core.Model.CoreEntity;
using MarcosWebApiProject.ApplicationService.ADProduct;
using MarcosWebApiProject.ApplicationService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GPT.Model;

namespace GPT.Controllers
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
      //  [AuthorizeByApiKey]
        public async Task<ActionResult<ADProductResponseModel>> GenerateADGPTTurbo([FromBody] List<GPTMessage> aDGenerateRequestModel)
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
        //[AuthorizeByApiKey]
        public async Task<ActionResult<ADProductResponseModel>> ExtractADDataGpt4([FromBody] List<GPTMessage> aDGenerateRequestModel)
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
       // [AuthorizeByApiKey]
        public async Task<ActionResult<ADProductResponseModel>> GenerateADDavinci([FromBody] CustomerRequestModel aDGenerateRequestModel)
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
