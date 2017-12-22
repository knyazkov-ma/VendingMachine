using System.Web.Http;
using VendingMachine.DataService.Interface;
using VendingMachine.DataService.DTO;

namespace VendingMachine.WebApp.Controllers
{
    public class OrderController : BaseApiController
    {
        private readonly IOrderService orderService;
        
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [Route("api/Order/GetAssortment")]
        [HttpGet]
        public IHttpActionResult GetGetAssortment()
        {
            return execute(delegate()
            {
                var assortment = orderService.GetAssortment();
                result = Json(new { success = true, data = assortment });
            });
        }

        [Route("api/Order/GetOrderCost")]
        [HttpPost]
        public IHttpActionResult GetOrderCost(OrderDTO order)
        {
            return execute(delegate ()
            {
                var cost = orderService.GetOrderCost(order);
                result = Json(new { success = true, data = cost });
            });
        }
        
    }
}