using Microsoft.AspNetCore.Mvc;

namespace StudentMvcApp.Components;

public class TodayInfoViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var model = new TodayInfoVm
        {
            Date = DateTime.Now,
            Message = "Have a great coding day! 😊"
        };

        return View(model);
    }
}

public class TodayInfoVm
{
    public DateTime Date { get; set; }
    public string Message { get; set; } = string.Empty;
}
