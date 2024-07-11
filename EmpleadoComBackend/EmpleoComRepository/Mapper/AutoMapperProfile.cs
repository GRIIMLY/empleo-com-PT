using AutoMapper;
using EmpleoComRepository.DTOs;
using EmpleoComRepository.Models;

namespace PruebaDitechRepository.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Demandante, DemandanteDTO>().ReverseMap();
            CreateMap<HabilidadUsuarioTrabajo, HabilidadUsuarioTrabajoDTO>().ReverseMap();

        }
    }
}
