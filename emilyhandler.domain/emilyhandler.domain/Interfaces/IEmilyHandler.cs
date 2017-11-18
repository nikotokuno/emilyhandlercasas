using System.Threading.Tasks;
using emilyhandler.domain.Entities;
using emilyhandler.Domain.Entities;
using emilyhandler.Domain.Value_Objects;

namespace emilyhandler.Domain.Interfaces
{
    public interface IEmilyHandler
    {
        void Setup();
        Root Deserialize(string json);
        Task<RequestCategory> DetermineRequestCategory(Parameters requestParameters);
        Task<Response> CreateIntroResponse();
        Task<Response> Answer(RequestCategory category, Response response);
    }
}
