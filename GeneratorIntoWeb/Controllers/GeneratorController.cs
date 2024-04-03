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

    new("элементами дороги",0,true),
    new("Какие из перечисленных элементов являются элементами дороги?",1,true),
    new("Какие из перечисленных элементов(при их наличии) являются элементами дороги?",1,true),
    new("Что является элементом дороги?",1,true),
    new("Что входит в элементы дороги?",1,true),
    new("Какие из перечисленных элементов не являются элементами дороги?",1,false),
    new("Какие из перечисленных элементов(при их наличии) не являются элементами дороги?",1,false),
    new("Что не является элементом дороги?",1,false),
    new("Что не входит в элементы дороги?",1,false),
    new("Разделительные полосы",2,true),
    new("Разделительные зоны",2,true),
    new("Трамвайные пути",2,true),
    new("Островки безопасности",2,true),
    new("Островки, выделенные только разметкой",2,false),
    new("Проезжие части",2,true),
    new("Тротуары",2,true),
    new("Обочины",2,true),
    new("Пешеходные дорожки",2,true),
    new("Велосипедные дорожки",2,true),
    new("Обособленные велосипедные дорожки",2,false),
    new("Пешеходные переходы",2,false),
    new("Велосипедные переезды",2,false),
    new("Перекрестки",2,false),
    new("Кюветы", 2, false),
    new("Обрезы", 2, false),
    new("Придорожные насаждения", 2, false),
    new("Кустарник при дороге", 2, false),
    new("Дорожки для всадников", 2, false),

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
