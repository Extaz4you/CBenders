using CBenders.Web.Models;

namespace CBenders.Web.Services.Interfaces
{
    public interface IBaseService : IDisposable
    {
        public  ViewModel Model { get; set; }
        Task<T> SendASync<T>(ApiRequest request);
    }
}
