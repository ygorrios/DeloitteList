using Deloitte.Business.Interface;
using Deloitte.Model;
using System.Web.Mvc;

namespace Deloitte.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskBusiness _taskBusiness;
        public HomeController(
            ITaskBusiness taskBusiness
            )
        {
            _taskBusiness = taskBusiness;
            //AddFakeRecords();
        }
        public ActionResult Index(int UserId)
        {
            var list = _taskBusiness.ListByUser(UserId);
            ViewBag.UserId = UserId;
            return View(list);
        }

        private void AddFakeRecords()
        {
            var result = _taskBusiness.Add(new TaskDetailViewModel
            {
                Description = "Buy eggs",
                Checked = false,
                CreatedBy = 1
            });

            result = _taskBusiness.Add(new TaskDetailViewModel
            {
                Description = "Buy rice",
                Checked = false,
                CreatedBy = 1
            });

            result = _taskBusiness.Add(new TaskDetailViewModel
            {
                Description = "Take the trash out",
                Checked = true,
                CreatedBy = 1
            });

            result = _taskBusiness.Add(new TaskDetailViewModel
            {
                Description = "Clean my room",
                Checked = true,
                CreatedBy = 1
            });
        }

        public ActionResult Create(int UserId)
        {
            return View(new TaskDetailViewModel { CreatedBy = UserId });
        }

        [HttpPost]
        public ActionResult Create(TaskDetailViewModel request)
        {
            var result = _taskBusiness.Add(request);
            return RedirectToAction("Index", new { UserId = request.CreatedBy });
        }

        public ActionResult Edit(int? Id, int UserId)
        {
            if (!Id.HasValue)
                return RedirectToAction("Index", new { UserId = UserId });

            return View(_taskBusiness.GetById(Id.Value));
        }

        [HttpPost]
        public ActionResult Edit(TaskDetailViewModel request)
        {
            var result = _taskBusiness.Edit(request);
            return RedirectToAction("Index", new { UserId = request.CreatedBy });
        }

        public ActionResult Delete(int? Id, int UserId)
        {
            if (!Id.HasValue)
                return RedirectToAction("Index", new { UserId = UserId });

            _taskBusiness.Remove(Id.Value);

            return RedirectToAction("Index", new { UserId = UserId });
        }
    }
}
