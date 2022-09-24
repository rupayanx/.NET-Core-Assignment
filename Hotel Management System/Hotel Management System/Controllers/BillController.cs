using Hotel_Management_System.Data_Access_Layer;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers
{
    [ApiController]
    [Route("api/bill")]
    public class BillController : Controller
    {
        private readonly BillDbContext billDb;

        public BillController(BillDbContext billDb)
        {
            this.billDb = billDb;
        }

        [HttpGet]
        public IActionResult GetBill()
        {
            return Ok(billDb.Bills.ToList());
            
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetBillDetail([FromRoute] Guid id)
        {
            var billid = billDb.Bills.Find(id);

            if (billid == null)
            {
                return NotFound();
            }
            return Ok(billid);
        }
        [HttpPost]
        public IActionResult AddBill(AddBill addBill)
        {
            var Bill = new Bill()
            {
                BillId = Guid.NewGuid(),
                GuestId = addBill.GuestId,
                BillDate = addBill.BillDate,
                Amount = addBill.Amount,
                reservationId = addBill.reservationId
            };

            billDb.Bills.Add(Bill);
            billDb.SaveChanges();

            return Ok(Bill);
        }

    }
}
