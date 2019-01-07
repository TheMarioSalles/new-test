using AutoMapper;
using MarioLucci.Ituran.Domain.Dtos.Entities;
using MarioLucci.Ituran.Api.Models.Entities;
namespace MarioLucci.Ituran.Api.Helpers
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

            CreateMap<Currency, CurrencyDto>();
            CreateMap<CurrencyDto, Currency>();
        }
    }
}
