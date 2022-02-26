using AutoMapper;
using System;

namespace TodoApp.Service.Mapping
{
    public static class ObjectMapper
    {
        // Lazy loading = sadece ihtiyaç olduğunda yüklesin
        // ilk bu object mapperin içindeki ben istediğim zaman yüklensin,
        // ben çağırmazsam memoryde bulunmasın

        private static readonly Lazy<IMapper> lazy = new(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();

            });

            return config.CreateMapper();

        });

        // bu şekilde sadece get yapısını kodlarım. sadece datayı alıcam
        // ObjectMapper sınıfının Mapper' ini çağırana kadar yukardaki kod yüklenmicek.
        public static IMapper Mapper => lazy.Value;
    }
}
