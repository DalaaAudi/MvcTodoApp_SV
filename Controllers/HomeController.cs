[HttpPost]
public IActionResult Edit(int id)
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task != null)
    {
        ViewBag.EditMode = true;
        ViewBag.EditId = task.Id;
        ViewBag.EditTitle = task.Title;
    }
    return View("Index", tasks);
}

[HttpPost]
public IActionResult EditTask(int id, string title)
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task != null && !string.IsNullOrWhiteSpace(title))
    {
        task.Title = title;
    }
    return RedirectToAction("Index");
}
