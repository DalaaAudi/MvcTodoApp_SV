using Microsoft.AspNetCore.Mvc;
using MvcTodoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcTodoApp.Controllers
{
    public class HomeController : Controller
    {
        // قائمة محاكاة لقاعدة البيانات (في الذاكرة)
        private static List<TaskItem> tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "تدرب على MVC Design Pattern", IsComplete = false },
            new TaskItem { Id = 2, Title = "تدرب على N-tier Architecture", IsComplete = false },
            new TaskItem { Id = 3, Title = "تدرب على استخدام git", IsComplete = false },
        };

        /// <summary>
        /// يعرض القائمة الرئيسية للمهام.
        /// </summary>
        public IActionResult Index()
        {
            // TODO: إضافة دعم للبحث أو التصفية حسب الحالة (مكتملة / غير مكتملة)
            return View(tasks);
        }

        /// <summary>
        /// إضافة مهمة جديدة.
        /// </summary>
        [HttpPost]
        public IActionResult AddTask(string title)
        {
            // TODO: إضافة تحقق من صحة الإدخال (مثلاً منع إضافة مهمة فارغة أو مكررة)
            if (!string.IsNullOrEmpty(title))
            {
                int newId = tasks.Max(t => t.Id) + 1;
                var newTask = new TaskItem { Id = newId, Title = title, IsComplete = false };
                tasks.Add(newTask);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// تعيين مهمة كمكتملة.
        /// </summary>
        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
                task.IsComplete = true;

            // TODO: إضافة ميزة إلغاء تحديد المهمة كمكتملة (Toggle Complete)
            return RedirectToAction("Index");
        }
    }
}
