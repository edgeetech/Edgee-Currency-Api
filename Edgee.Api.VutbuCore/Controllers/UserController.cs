using Edgee.Api.VutbuCore.DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Edgee.Api.VutbuCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly VutbuDbContext _dbContext;

        public UserController(ILogger<UserController> logger, VutbuDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        //[HttpGet("GetAll")]
        //public IEnumerable<DictionaryItem> GetAll(string languageCode = "en-GB")
        //{
        //    return _dbContext.DictionaryItems
        //        .AsNoTracking()
        //        .Where(x => x.Language.LanguageCode.Equals(languageCode))
        //        .ToList();
        //}
    }
}
