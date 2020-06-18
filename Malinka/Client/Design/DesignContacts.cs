using Malinka.API.Client.Interfaces;
using Malinka.Core.Models;
using Malinka.Core.Models.Enums;
using Malinka.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malinka.Client.Design
{
    class DesignContacts : IContacts
    {
        const string alph = "qwertyuiopasdfghjklzxcvbnm123456789";
        static Random rn = new Random();

        public event ContactAction UserAdded;
        public event ContactRemoved UserRemoved;
        public event ContactAction UserChanged;

        string GetString(int length)
        {
            return new string(Enumerable.Range(0, length).Select(x => alph[rn.Next(0, alph.Length)]).ToArray());
        }

        public Task<MalinkaResponse<IEnumerable<MalinkaUser>>> GetAllAsync()
        {
            return Task.FromResult(
                    new MalinkaResponse<IEnumerable<MalinkaUser>>(
                        Enumerable.Range(0, 25)
                            .Select(x => new MalinkaUser
                            {
                                Id = x,
                                Name = GetString(rn.Next(10, 20)),
                                Verified = rn.Next(0, 2) == 0
                            }), ResponseCode.Ok));
        }

        public Task<MalinkaResponse<MalinkaUser>> GetById(int id)
        {
            return Task.FromResult(new MalinkaResponse<MalinkaUser>(new MalinkaUser { Id = id, Name = "GetById", Verified = id % 2 == 0 }, ResponseCode.Ok));
        }

        public Task<MalinkaResponse<bool, ContactsResponseCode>> AddAsync(int id)
        {
            return Task.FromResult(new MalinkaResponse<bool, ContactsResponseCode>(true, ResponseCode.Ok, ContactsResponseCode.Ok));
        }

        public Task<MalinkaResponse<bool, ContactsResponseCode>> RemoveAsync(int id)
        {
            UserRemoved?.Invoke(id);
            return Task.FromResult(new MalinkaResponse<bool, ContactsResponseCode>(true, ResponseCode.Ok, ContactsResponseCode.Ok));
        }

        public Task<MalinkaResponse<bool, ContactsResponseCode>> UpdateAsync(MalinkaUser item)
        {
            UserChanged?.Invoke(item);
            return Task.FromResult(new MalinkaResponse<bool, ContactsResponseCode>(true, ResponseCode.Ok, ContactsResponseCode.Ok));
        }
    }
}
