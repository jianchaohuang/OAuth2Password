using System.Collections;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServerCenter
{
    public class Config
    {
        //所有可以访问的Resource
        public static IEnumerable<ApiResource> GetResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api","My Api")
            };
        }

        //客户端
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client()
                {
                    ClientId="client",
                    AllowedGrantTypes= GrantTypes.ClientCredentials,//模式：最简单的模式
                    ClientSecrets={//私钥
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={//可以访问的Resource
                        "api"
                    }
                },
                new Client()
                {
                    ClientId="pwdClient",
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,//模式：最简单的模式
                    ClientSecrets={//私钥
                        new Secret("secret".Sha256())
                    },
                    RequireClientSecret=false,//不需要密码
                    AllowedScopes={//授权的client可以访问范围（scopes）为api的资源
                        "api"
                    }
                }
            };
        }

        //测试用户
        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>{
                new TestUser{
                    SubjectId="1",
                    Username="wyt",
                    Password="123456"
                }
            };
        }
    }
}