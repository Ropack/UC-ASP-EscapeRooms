using System;
using AutoMapper;

namespace US.ASP.EscapeRooms
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(mapper =>
            {
                
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}