using CoreLib.HttpServiceV2.Services.Interfaces;
using ExampleCore.Dal.Base;
using ExampleCore.HttpLogic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ObjectPool;
using ProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;
using ProfileConnectionLib.ConnectionServices.DtoModels.UserNameLists;
using ProfileConnectionLib.ConnectionServices.Interfaces;
using ProfileConnectionLib.ConnectionServices.RabbitConnectionServer;
using RabbitMQ.Client;
using ExampleCore.RPC;

namespace ProfileConnectionLib.ConnectionServices;

public class ProfileConnectionService<TModel> : IProfileConnectionServcie where TModel : BaseEntityDal<Guid>
{
    private readonly IHttpRequestService _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly RabbitGetUserNameListService<TModel> _getUserNameListConsumer;

    public ProfileConnectionService(IConfiguration configuration, IServiceProvider serviceProvider, ObjectPool<IConnection> connectionPool,
        IServiceScopeFactory serviceScopeFactory, ILogger<ProfileConnectionService<TModel>> logger)
    {
        if (configuration.GetSection("ConnectionType").Value == "http")
        {
            _httpClientFactory = serviceProvider.GetRequiredService<IHttpRequestService>();
        }
        else if (_configuration.GetSection("ConnectionType").Value == "rabbitmq")
        {
            _getUserNameListConsumer = new RabbitGetUserNameListService<TModel>(serviceScopeFactory, connectionPool);
        }
    }
    
    
    public async Task<UserNameProfileApiResponse[]> GetUserNameListAsync(UserNameProfileApiRequest request)
    {
        if (_httpClientFactory != null)
            return await GetUserNameListByHttp(request);

        if (_getUserNameListConsumer != null)
        {
            var isMessagePublished = await ProfileConnectionService<TModel>.GetUserNameListByRabbit(request, "GetProjectQueue");

            if (isMessagePublished)
            {
                return new UserNameProfileApiResponse[]
                {
                    
                };
            }
            else
                throw new Exception("Сообщение не было доставлено");
        }

        throw new Exception("Не получилось настроить метод связи");
    }
    
    public async Task<UserNameProfileApiResponse[]> GetUserNameListByHttp(UserNameProfileApiRequest request)
    {
        var data = new HttpRequestData()
        {
            Uri = new Uri($"http://localhost:5183/api/get{request.UserId}"),
            Method = HttpMethod.Get,
            ContentType = ContentType.ApplicationJson,
            Body = request
        };

        var user = await _httpClientFactory.SendRequestAsync<UserNameProfileApiResponse[]>(data);

        return user.Body;
    }
    

    private static async Task<bool> GetUserNameListByRabbit(UserNameProfileApiRequest request, string queueName)
    {
        var publisher = new Publisher<UserNameProfileApiRequest>(queueName, request);
        var result = await publisher.PublishAsync();
        publisher.Dispose();

        return result;
    }

    

    public async Task<CheckUserExistProfileApiResponse> CheckUserExistAsync(CheckUserExistProfileApiRequest checkUserExistProfileApiRequest)
    {
        
        var data = new HttpRequestData()
        {
            Uri = new Uri("http://localhost:5136/public/user/exist"),
            Method = HttpMethod.Post,
            ContentType = ContentType.ApplicationJson,
            Body = checkUserExistProfileApiRequest
        };
        var user = await _httpClientFactory.SendRequestAsync<CheckUserExistProfileApiResponse>(data);
        
        return user.Body.UserId != uint.MinValue ? user.Body : throw new Exception("Пользователь не найден");
    }
}


