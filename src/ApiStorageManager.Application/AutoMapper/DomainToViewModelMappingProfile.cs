using ApiStorageManager.Application.ViewModels;
using AutoMapper;
using File = ApiStorageManager.Domain.Models.File;

namespace ApiStorageManager.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() 
        {
            CreateMap<File, FileViewModel>();
        }
    }
}
