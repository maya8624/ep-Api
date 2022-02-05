using AutoMapper;
using ep.Service.Interfaces;
using ep.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Service.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _wrapper;

        public MessageService(IMapper mapper, IRepositoryWrapper wrapper)
        {
            _mapper = mapper;
            _wrapper = wrapper;
        }

        //public async Task CreateMessage(Message message)
        //{
        //    await _repository.CreateAsync(message);
        //}

        //public async Task<Message> GetMessageByOrderNo(int shopId, string orderNo)
        //{
        //    return await _repository.GetByOrderNoAsync(shopId, orderNo);
        //}

        //public void UpdateMessage(Message message)
        //{
        //    _repository.Update(message);
        //}
    }
}
