using Hotel_Management_System.Data_Access_Layer;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : Controller
    {
        private readonly PaymentDbContext paymentDb;

        public PaymentController(PaymentDbContext paymentDb)
        {
            this.paymentDb = paymentDb;
        }

        [HttpGet]
        public IActionResult GetPayment()
        {
            return Ok(paymentDb.payments.ToList());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetPaymentDetail([FromRoute] Guid id)
        {
            var paymentid = paymentDb.payments.Find(id);

            if (paymentid == null)
            {
                return NotFound();
            }
            return Ok(paymentid);
        }
        [HttpPost]
        public IActionResult AddPayment(AddPayment addPayment)
        {
            var Payment=new Payment()
            {
                PaymentId=Guid.NewGuid(),
                PaymentCard=addPayment.PaymentCard,
                CardHolderName=addPayment.CardHolderName,
                BillId=addPayment.BillId
            };

            paymentDb.payments.Add(Payment);
            paymentDb.SaveChanges();

            return Ok(Payment);
        }
    }
}
