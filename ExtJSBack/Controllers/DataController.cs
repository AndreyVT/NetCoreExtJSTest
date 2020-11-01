using ExtJSBack.DB;
using ExtJSBack.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ExtJSBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly DatabaseContext _databaseContext;

        /// <summary>Конструктор.</summary>
        /// <param name="logger"></param>
        /// <param name="databaseContext">Сделано так ради простоты и скорости и в контроллере использовать контекст напрямую bad practice. 
        /// Конечно нужно применять или репозиторий или сервис.</param>
        public DataController(ILogger<DataController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [Authorize]
        [HttpGet]
        public PagedResult<Person> Get([FromQuery] string _dc, [FromQuery] int page, [FromQuery] int start, [FromQuery] int limit)
        {
            _logger.LogTrace($"Запрос персон: Page:{page} Start: {start} Limit: {limit}");

            var result = _databaseContext.Persons.OrderBy(c => c.Name).AsQueryable().GetPaged(page, limit);

            return result;
        }
    }
}
