using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class PlayerController : ApiController
    {
        private readonly PlayerExtractRepository _playerRepository;

        public PlayerController()
        {
            _playerRepository = new PlayerExtractRepository();
        }

        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {
                var titans = _playerRepository.Get();
                if (titans != null)
                {
                    response.Content = new StringContent(JsonConvert.SerializeObject(titans));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.StatusCode = HttpStatusCode.NotAcceptable;
            }

            return response;
        }
    }
}
