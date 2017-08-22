// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using IdentityServer4.Stores;

namespace IdentityServer4.Services
{
    /// <summary>
    /// The default key material service
    /// </summary>
    /// <seealso cref="IdentityServer4.Services.IKeyMaterialService" />
    public class DefaultKeyMaterialService : IKeyMaterialService
    {
        private readonly ISigningCredentialStore _signingCredential;
        private readonly IEnumerable<IValidationKeysStore> _validationKeys;        
        private readonly IEncryptingCredentialStore _encryptingCredential;
        private readonly IEnumerable<IDecryptionKeysStore> _decryptionKeys;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultKeyMaterialService"/> class.
        /// </summary>
        /// <param name="validationKeys">The validation keys stores.</param>
        /// <param name="signingCredential">The signing credential store.</param>
        public DefaultKeyMaterialService(IEnumerable<IValidationKeysStore> validationKeys, ISigningCredentialStore signingCredential = null, IEnumerable<IDecryptionKeysStore> decryptionKeys = null, IEncryptingCredentialStore encrytingCredential = null)
        {
            _signingCredential = signingCredential;
            _validationKeys = validationKeys;
            _decryptionKeys = decryptionKeys;
            _encryptingCredential = encrytingCredential;
        }
    

        /// <summary>
        /// Gets the signing credentials.
        /// </summary>
        /// <returns></returns>
        public async Task<SigningCredentials> GetSigningCredentialsAsync()
        {
            if (_signingCredential != null)
            {
                return await _signingCredential.GetSigningCredentialsAsync();
            }

            return null;
        }

        /// <summary>
        /// Gets all validation keys.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SecurityKey>> GetValidationKeysAsync()
        {
            var keys = new List<SecurityKey>();

            foreach (var store in _validationKeys)
            {
                keys.AddRange(await store.GetValidationKeysAsync());
            }

            return keys;
        }        

        /// <summary>
        /// Gets the encrypting credentials.
        /// </summary>
        /// <returns></returns>
        public async Task<EncryptingCredentials> GetEncryptingCredentialsAsync()
        {
            if (_encryptingCredential != null)
            {
                return await _encryptingCredential.GetEncryptingCredentialsAsync();
            }

            return null;
        }

        /// <summary>
        /// Gets all decryption keys
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SecurityKey>> GetDecryptionKeysAsync()
        {
            var keys = new List<SecurityKey>();

            foreach (var store in _decryptionKeys)
            {
                keys.AddRange(await store.GetDecryptionKeysAsync());
            }

            return keys;
        }
    }
}