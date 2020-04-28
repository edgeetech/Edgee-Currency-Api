using System.Collections.Generic;
using System.Linq;
using Edgee.Api.Dictionary.DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Edgee.Api.Dictionary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DictionaryController : ControllerBase
    {
        private readonly ILogger<DictionaryController> _logger;
        private readonly DictionaryDbContext _dbContext;

        public DictionaryController(ILogger<DictionaryController> logger, DictionaryDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("GetAll")]
        public IEnumerable<DictionaryItem> GetAll(string languageCode = "en-GB")
        {
            return _dbContext.DictionaryItems
                .AsNoTracking()
                .Where(x => x.Language.LanguageCode.Equals(languageCode))
                .ToList();
        }

        [HttpGet("Get")]
        public string Get(string key, string languageCode = "en-GB")
        {
            var dbItem = _dbContext.DictionaryItems
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Language.LanguageCode.Equals(languageCode) && x.Key.ToLower().Equals(key.ToLower()));

            return dbItem == null ? key : dbItem.Value;
        }
    }
}
