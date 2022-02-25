using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DTOs;
using TodoApp.Core.Model;

namespace TodoApp.Core.Configuration
{
    public interface ITokenService
    {
        TokenDto CreateToken(User user);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
