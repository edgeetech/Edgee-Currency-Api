using Edgee.Api.VutbuCore.DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Edgee.Api.VutbuCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private readonly VutbuDbContext _dbContext;

        public GroupController(ILogger<GroupController> logger, VutbuDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        //[HttpGet("CreateGroup")]
        //public IEnumerable<DictionaryItem> CreateGroup(string languageCode = "en-GB")
        //{
        //    return _dbContext.DictionaryItems
        //        .AsNoTracking()
        //        .Where(x => x.Language.LanguageCode.Equals(languageCode))
        //        .ToList();
        //}
    }
}
