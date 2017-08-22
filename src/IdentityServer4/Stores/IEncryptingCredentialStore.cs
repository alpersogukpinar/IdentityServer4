using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace IdentityServer4.Stores
{
    public interface IEncryptingCredentialStore
    {
        /// <summary>
        /// Gets the signing credentials.
        /// </summary>
        /// <returns></returns>
        Task<EncryptingCredentials> GetEncryptingCredentialsAsync();
    }
}
