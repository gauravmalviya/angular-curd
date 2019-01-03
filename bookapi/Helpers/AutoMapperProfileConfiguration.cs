using AutoMapper;
using bookapi.Data.Entities;
using bookapi.ViewModels;
using System.Linq;

namespace bookapi.Helpers
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        : this("MyProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<Book, BookViewModel>().
                ForMember(d => d.Authors, o => o.MapFrom(s => s.Authors.Select(c => c.Name).ToArray())); ;
            CreateMap<BookViewModel, Book>();

        }
    }
}