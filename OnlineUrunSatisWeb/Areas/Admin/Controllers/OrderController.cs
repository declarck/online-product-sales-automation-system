using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineUrunSatisWeb.Data;
using OnlineUrunSatisWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineUrunSatisWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public OrderDetailsVM OrderVM { get; set; }
        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Authorize(Roles =Other.Role_Admin)]
        public IActionResult ConfirmOrder()
        {
            OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(i => i.Id == OrderVM.OrderHeader.Id);
            orderHeader.OrderStatus = Other.Status_Confirmed;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize(Roles = Other.Role_Admin)]
        public IActionResult ShipOrder()
        {
            OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(i => i.Id == OrderVM.OrderHeader.Id);
            orderHeader.OrderStatus = Other.Status_Shipped;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            OrderVM = new OrderDetailsVM
            {
                OrderHeader = _db.OrderHeaders.FirstOrDefault(i => i.Id == id),
                OrderDetails = _db.OrderDetails.Where(x => x.OrderId == id).Include(x => x.Product)
            };
            return View(OrderVM);
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeadersList;
            if (User.IsInRole(Other.Role_Admin))
            {
                orderHeadersList = _db.OrderHeaders.ToList();
            }
            else
            {
                orderHeadersList = _db.OrderHeaders.Where(i => i.ApplicationUserId == claim.Value).Include(i => i.ApplicationUser);
            }
            return View(orderHeadersList);
        }

        public IActionResult OnHold()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeadersList;
            if (User.IsInRole(Other.Role_Admin))
            {
                orderHeadersList = _db.OrderHeaders.Where(i => i.OrderStatus == Other.Status_OnHold);
            }
            else
            {
                orderHeadersList = _db.OrderHeaders.Where(i => i.ApplicationUserId == claim.Value && i.OrderStatus == Other.Status_OnHold).Include(i => i.ApplicationUser);
            }
            return View(orderHeadersList);
        }

        public IActionResult Confirmed()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeadersList;
            if (User.IsInRole(Other.Role_Admin))
            {
                orderHeadersList = _db.OrderHeaders.Where(i => i.OrderStatus == Other.Status_Confirmed);
            }
            else
            {
                orderHeadersList = _db.OrderHeaders.Where(i => i.ApplicationUserId == claim.Value && i.OrderStatus == Other.Status_Confirmed).Include(i => i.ApplicationUser);
            }
            return View(orderHeadersList);
        }

        public IActionResult Shipped()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeadersList;
            if (User.IsInRole(Other.Role_Admin))
            {
                orderHeadersList = _db.OrderHeaders.Where(i => i.OrderStatus == Other.Status_Shipped);
            }
            else
            {
                orderHeadersList = _db.OrderHeaders.Where(i => i.ApplicationUserId == claim.Value && i.OrderStatus == Other.Status_Shipped).Include(i => i.ApplicationUser);
            }
            return View(orderHeadersList);
        }
    }
}
