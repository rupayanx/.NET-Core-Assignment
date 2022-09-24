using Hotel_Management_System.Data_Access_Layer;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomController : Controller
    {
        private readonly RoomDbContext dbContext;

        public RoomController(RoomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetRoomDetails()
        {
            return Ok(dbContext.Rooms.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRoomDetail([FromRoute] Guid id)
        {
            var roomid = dbContext.Rooms.Find(id);

            if(roomid == null)
            {
                return NotFound();
            }
            return Ok(roomid);
        }

        [HttpPost] 
        public IActionResult AddRoom(AddRoom addRoom)
        {
            var Room = new Room()
            {
                RoomId = Guid.NewGuid(),
                room_status = addRoom.room_status,
                room_comment = addRoom.room_comment,
                room_inventory = addRoom.room_inventory,
                room_price = addRoom.room_price
            };

            dbContext.Rooms.Add(Room);
            dbContext.SaveChanges();   

            return Ok(Room);    
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateRoom([FromRoute] Guid id,UpdateRoom updateRoom)
        {
            var roomid = dbContext.Rooms.Find(id);

            if (roomid != null)
            {
                roomid.room_comment = updateRoom.room_comment;  
                roomid.room_status = updateRoom.room_status;
                roomid.room_inventory = updateRoom.room_inventory; 
                roomid.room_price = updateRoom.room_price;

                dbContext.SaveChanges();

                return Ok(roomid);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteRoom([FromRoute] Guid id)
        {
            var roomid = dbContext.Rooms.Find(id);

            if(roomid != null)
            {
                dbContext.Rooms.Remove(roomid);
                dbContext.SaveChanges();

                return Ok(roomid);
            }

            return NotFound();
        }
    }
}
