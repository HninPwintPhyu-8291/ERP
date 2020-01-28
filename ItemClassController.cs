using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCErp.BusinessLogic;
using BCErp.DTO;

namespace BCErp.Controllers
{
    public class ItemClassController : Controller
    {
        ItemClassBL itemClassBL = new ItemClassBL();
        public ActionResult Index()
        {
            List<ItemClassDTO> itemClassDTOs = itemClassBL.GetAll();
            ViewBag.ItemClassList = itemClassDTOs;
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }


        [HttpPost, ActionName("Create")]
        public ActionResult Create_Post(ItemClassDTO itemClassDTO)
        {
            if (itemClassBL.Create(itemClassDTO) > 0)
            {
                ResultMessage resultMessage = new ResultMessage() { Code = "000", Description = "Success save" };
                return Json(resultMessage, JsonRequestBehavior.AllowGet);
            }

            return Json(new ResultMessage() { Code = "001", Description = "Create fail" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            List<ItemClassDTO> itemClassList = itemClassBL.GetAll();
            ViewBag.ItemClassList = new SelectList(itemClassList, "Id", "Name");
            ItemClassDTO itemClassDTO = itemClassBL.GetById(Id);
            return View(itemClassDTO);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult Edit_Post(ItemClassDTO itemClassDTO)
        {
            if (itemClassBL.Edit(itemClassDTO) > 0)
            {
                ResultMessage resultMessage = new ResultMessage() { Code = "000", Description = "Success save" };
                return Json(resultMessage, JsonRequestBehavior.AllowGet);
            }

            return Json(new ResultMessage() { Code = "001", Description = "Create fail" }, JsonRequestBehavior.AllowGet);
        }
    }
}