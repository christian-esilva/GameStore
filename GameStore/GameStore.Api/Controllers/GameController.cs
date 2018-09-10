using GameStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace GameStore.Api.Controllers
{
    [RoutePrefix("api/public/v1")]
    public class GameController : ApiController
    {
        private IGameRepository _repository;

        public GameController(IGameRepository repository)
        {
            _repository = repository;
        }

        #region Read
        [HttpGet]
        [CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        [Route("jogos")]
        public Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _repository.GetWithCategory();
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao recuperar jogos");
                throw;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        #endregion
    }
}
