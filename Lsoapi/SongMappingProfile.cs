using AutoMapper;
using LsoAPI.Entities;
using LsoAPI.Models;

namespace LsoAPI
{
    public class SongMappingProfile:Profile
    {
        public SongMappingProfile() 
        {
            CreateMap<CreateSongDto, Song>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.LinesNumber, opt => opt.MapFrom(src => src.Lyrics.Count))
                .ForMember(dest => dest.Lines, opt => opt.MapFrom(src => src.Lyrics.Select((lyric, index) => new Line
                {
                    Content = lyric,
                    Verse = index + 1
                })))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoUrl));

            CreateMap<Song, SongDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Lines, opt => opt.MapFrom(src => src.Lines.Select(l => l.Content).ToList()))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoUrl));
        }
    }
}
