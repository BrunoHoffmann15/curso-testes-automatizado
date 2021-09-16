using System;

namespace Cwi.Treinamento.TesteAutomatizado.Tests.Models
{
    public class AuthenticationResponse
    {
        public string AccessToken { get; set; }

        public DateTime Expiration { get; set; }

        public DateTime Created { get; set; }

    }
}
