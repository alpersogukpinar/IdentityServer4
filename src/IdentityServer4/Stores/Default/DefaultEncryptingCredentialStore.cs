using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer4.Stores
{
    public class DefaultEncryptingCredentialStore : IEncryptingCredentialStore
    {
        private readonly EncryptingCredentials _credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="BOAEncryptingCredentialsStore"/> class.
        /// </summary>
        /// <param name="credential">The credential.</param>
        public DefaultEncryptingCredentialStore(EncryptingCredentials credential)
        {
            _credential = credential;
        }

        public Task<EncryptingCredentials> GetEncryptingCredentialsAsync()
        {
            return Task.FromResult(_credential);
        }
    }
}
