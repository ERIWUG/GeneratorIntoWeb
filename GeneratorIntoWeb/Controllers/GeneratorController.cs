using GeneratorIntoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeneratorIntoWeb.Controllers
{
    public class GeneratorController : Controller
    {
        public IActionResult Ticket()
        {
            //массив создан здесь для отладки
            var mas = new MyData[]{

    new("элементами дороги",0,true,1),
    new("Какие из перечисленных элементов являются элементами дороги?",1,true, 1),
    new("Какие из перечисленных элементов(при их наличии) являются элементами дороги?",1,true, 1),
    new("Что является элементом дороги?",1,true, 1),
    new("Что входит в элементы дороги?",1,true, 1),
    new("Какие из перечисленных элементов не являются элементами дороги?",1,false, 1),
    new("Какие из перечисленных элементов(при их наличии) не являются элементами дороги?",1,false, 1),
    new("Что не является элементом дороги?",1,false, 1),
    new("Что не входит в элементы дороги?",1,false, 1),
    new("Разделительные полосы",2,true, 1),
    new("Разделительные зоны",2,true, 1),
    new("Трамвайные пути",2,true, 1),
    new("Островки безопасности",2,true, 1),
    new("Островки, выделенные только разметкой",2,false, 1),
    new("Проезжие части",2,true, 1),
    new("Тротуары",2,true, 1),
    new("Обочины",2,true, 1),
    new("Пешеходные дорожки",2,true, 1),
    new("Велосипедные дорожки",2,true, 1),
    new("Обособленные велосипедные дорожки",2,false, 1),
    new("Пешеходные переходы",2,false, 1),
    new("Велосипедные переезды",2,false, 1),
    new("Перекрестки",2,false, 1),
    new("Кюветы", 2, false, 1),
    new("Обрезы", 2, false, 1),
    new("Придорожные насаждения", 2, false, 1),
    new("Кустарник при дороге", 2, false, 1),
    new("Дорожки для всадников", 2, false, 1),

    };
            List <Question>questions =
          Generator.GenerateTicket(mas, 10).ToList();
            return View(questions);
        }

        public IActionResult Index()
        {
            return View();
        }






    }
}
