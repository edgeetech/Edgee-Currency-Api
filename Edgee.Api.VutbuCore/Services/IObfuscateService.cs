using Edgee.Api.VutbuCore.Message;

namespace Edgee.Api.VutbuCore.Services
{
    public interface IObfuscateService
    {
        public void ObfuscateUser(EditUserMessage userMessage);
    }
}
