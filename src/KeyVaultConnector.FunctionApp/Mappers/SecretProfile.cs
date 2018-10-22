using AutoMapper;

using KeyVaultConnector.FunctionApp.Extensions;
using KeyVaultConnector.FunctionApp.Models;

using Microsoft.Azure.KeyVault.Models;

namespace KeyVaultConnector.FunctionApp.Mappers
{
    /// <summary>
    /// This represents the mapping profile entity for secret.
    /// </summary>
    public class SecretProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecretProfile"/> class.
        /// </summary>
        public SecretProfile()
        {
            this.CreateMap<SecretBundle, SecretModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.SecretIdentifier.Name))
                .ForMember(d => d.Value, o => o.MapFrom(s => s.Value))
                .ForMember(d => d.Enabled, o => o.MapFrom(s => s.Attributes.Enabled))
                .ForMember(d => d.Managed, o => o.MapFrom(s => s.Managed))
                .ForMember(d => d.Version, o => o.MapFrom(s => s.SecretIdentifier.Version))
                .ForMember(d => d.ContentType, o => o.MapFrom(s => s.ContentType))
                .ForMember(d => d.RecoveryLevel, o => o.MapFrom(s => s.Attributes.RecoveryLevel))
                .ForMember(d => d.Created, o => o.MapFrom(s => s.Attributes.Created.ToDateTimeOffset()))
                .ForMember(d => d.Updated, o => o.MapFrom(s => s.Attributes.Updated.ToDateTimeOffset()))
                .ForMember(d => d.Expires, o => o.MapFrom(s => s.Attributes.Expires.ToDateTimeOffset()))
                .ForMember(d => d.NotBefore, o => o.MapFrom(s => s.Attributes.NotBefore.ToDateTimeOffset()))
                ;
        }
    }
}