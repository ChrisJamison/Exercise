using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BusinessServices;
using DataModel;
using Exercise.Models;

namespace Exercise.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserServices _iUserServices;

        public UserController(IUserServices iUserServices)
        {
            _iUserServices = iUserServices;
        }
        public ActionResult Index()
        {
            var users = _iUserServices.GetAllUsers();
            var model = Mapper.Map<List<User>, List<UserViewModels>>(users);
            return View(model);
        }
        //
        // GET: /User/
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([ModelBinder(typeof(UserCustomModelBinder))] UserViewModels userView)
        {
            if (ModelState.IsValid)
            {
                var user = Mapper.Map<UserViewModels, User>(userView);
                _iUserServices.CreateUser(user);
                return RedirectToAction("Index");
            }
            return View();
        }
	}
}