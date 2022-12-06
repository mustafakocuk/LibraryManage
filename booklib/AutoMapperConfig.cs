using AutoMapper;
using booklib.Entities;
using booklib.Models;

namespace bookLib
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Book, BorrowBookModel>().ReverseMap();
            CreateMap<Lib, LibViewModel>().ReverseMap();
        }
    }
}