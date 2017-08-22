// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace IdentityServer4.UnitTests.Common
{
    static class TestCert
    {
        public static X509Certificate2 Load()
        {
            var cert = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "idsvrtest.pfx");
            return new X509Certificate2(cert, "idsrv3test");
        }

        public static SigningCredentials LoadSigningCredentials()
        {
            var cert = Load();
            return new SigningCredentials(new X509SecurityKey(cert), "RS256");
        }

        public static EncryptingCredentials LoadEncryptingCredentials()
        {
            var encryptionKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.Default.GetBytes("KmjEOLl5e_q3RdCK"));
            return new EncryptingCredentials(encryptionKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.Aes128KW, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.Aes128CbcHmacSha256);

        }
    }
}