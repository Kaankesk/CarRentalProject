using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        TokenOptions _tokenOptions;
        IConfiguration Configuration { get; }
        DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }



        public AccessToken CreateToken(User user, List<OperationClaimDto> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signinCredentials = SigninCredentialsHelper.CreateSigninCredentials(securityKey);
            var jwt = CreateSecurityToken(_tokenOptions, signinCredentials, operationClaims, user);
            var jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.WriteToken(jwt);
            return new AccessToken {Token=token, Expiration = _accessTokenExpiration};

        }

        public JwtSecurityToken CreateSecurityToken(TokenOptions tokenOptions, SigningCredentials signingCredentials,
            List<OperationClaimDto> operationClaims, User user)
        {

            // IEnumerable<Claim> claims = null,
            // SigningCredentials signingCredentials = null
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        private List<Claim> SetClaims (User user, List<OperationClaimDto> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
