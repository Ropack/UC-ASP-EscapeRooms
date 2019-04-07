using System.Collections.Generic;
using AutoMapper;
using US.ASP.EscapeRooms.DAL.Entities;
using US.ASP.EscapeRooms.DTOs;
using US.ASP.EscapeRooms.Repositories;

namespace US.ASP.EscapeRooms.Facades
{
    public class RoomsFacade : FacadeBase
    {
        private IRepository<Room> RoomsRepository { get; }
        public RoomsFacade(IRepository<Room> roomsRepository)
        {
            RoomsRepository = roomsRepository;
        }

        public List<RoomDTO> GetAll()
        {
            return Mapper.Map<List<RoomDTO>>(RoomsRepository.GetAll());

        }

        public RoomDTO GetById(int id)
        {
            return Mapper.Map<RoomDTO>(RoomsRepository.GetById(id));
        }
    }
}