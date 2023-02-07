using ApiStorageManager.Application.ViewModels;
using ApiStorageManager.Domain.Commands;
using AutoMapper;

namespace ApiStorageManager.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() 
        {
            CreateMap<FileViewModel, UploadNewFileCommand>()
                .ConstructUsing(c => new UploadNewFileCommand(c.Id, c.Name, c.Metadata, c.Type, c.Extension, c.Bytes));
            CreateMap<FileViewModel, UpdateFileCommand>()
                .ConstructUsing(c => new UpdateFileCommand(c.Id, c.Name, c.Empresa, c.CodigoEvento, c.Metadata, c.Type, c.Extension, c.Bytes));
        }
    }
}
