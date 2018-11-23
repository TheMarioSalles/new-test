using AutoMapper;
using Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities;
using Sow.Interfaces.AdminWAPP.WebApi.Models.Entities;
namespace Sow.Interfaces.AdminWAPP.WebApi.Helpers
{
    public class AutoMapperProfileHelper : Profile
    {
        public AutoMapperProfileHelper()
        {
            //CreateMap<Agent, AgentDTO>();
            //CreateMap<AgentDTO, Agent>();

            //CreateMap<Account, AccountDto>();
            //CreateMap<AccountDto, Account>();

            //CreateMap<Chat, ChatDto>();
            //CreateMap<ChatDto, Chat>();

            //CreateMap<Client, ClientDto>();
            //CreateMap<ClientDto, Client>();

            //CreateMap<EndPoint, EndPointDto>();
            //CreateMap<EndPointDto, EndPoint>();

            //CreateMap<Message, MessageDTO>();
            //CreateMap<MessageDTO, Message>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
