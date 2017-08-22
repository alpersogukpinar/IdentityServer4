using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer4.Stores
{
    public interface IDecryptionKeysStore
    {
        /// <summary>
        /// Gets all decryption keys.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SecurityKey>> GetDecryptionKeysAsync();
    }
}
