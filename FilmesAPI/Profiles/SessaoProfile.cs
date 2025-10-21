using AutoMapper;
using CodeCine.Data.Dtos;
using CodeCine.Models;

namespace CodeCine.Profiles;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<ReadSessaoDto, Sessao>();
    }
}
