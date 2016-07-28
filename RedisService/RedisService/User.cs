using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisService
{
    public class User
    {
        public int Id { get; set; } = 1;

        public string FirstName { get; set; } = "Ark";

        public string SurName { get; set; } = "Get";

        public int Age { get; set; } = 26;

        public string Email { get; set; } = "arkadiy.getmantsev@gmail.com";

        public string Address { get; set; } = "Novorossyskay 14";
    }
}
