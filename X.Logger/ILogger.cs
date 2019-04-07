using System.Threading.Tasks;

namespace X.Logger
{
    public interface ILogger
    {
        Task Log(string value);
    }
}
