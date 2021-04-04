﻿using SGP.Application.Requests.Common;

namespace SGP.Application.Requests.AuthRequests
{
    public class AuthRequest : BaseRequest
    {
        public AuthRequest(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public AuthRequest()
        {
        }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}