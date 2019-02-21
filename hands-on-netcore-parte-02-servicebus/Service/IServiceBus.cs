using System.Threading.Tasks;

public interface IServiceBus
{
    Task Publicar(string messageId, string body);
}