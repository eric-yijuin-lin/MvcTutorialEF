using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTutorialEF.Models;
using MvcTutorialEF.Models.ViewModel;

namespace MvcTutorialEF.Controllers
{
    public class TblHeroesController : Controller
    {
        private readonly HomeworkDBContext _context;

        // 建構式注入
        public TblHeroesController(HomeworkDBContext context)
        {
            _context = context;
        }

        // GET: TblHeroes
        // Alt + Shit + .
        public IActionResult Index()
        {
            // ? : 三元運算子
            return _context.TblHeroes != null ?
                        View(_context.TblHeroes.ToList()) :
                        Problem("Entity set 'HomeworkDBContext.TblHeroes'  is null.");
        }

        // GET: TblHeroes/Details/5
        // Value Type, int default = 0
        public IActionResult Details(int? id) // 123545365
        {
            if (id == null || _context.TblHeroes == null)
            {
                return NotFound(); // 404 Not found
            }

            var tblHero = _context.TblHeroes
                .FirstOrDefault(m => m.Id == id);
            if (tblHero == null)
            {
                return NotFound();
            }

            return View(tblHero);
        }

        // GET: TblHeroes/Create
        // 拿空白表單
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblHeroes/Create
        // 提交表單，開始處理
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Atk,Hp")] TblHero tblHero)// Model Binding 模型繫結
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblHero);
                _context.SaveChanges(); // 儲存變更
                return RedirectToAction(nameof(Index)); // 重新導向某個頁面
                // ctrl + shift + 空白（一定要 ENG 輸入模式）
            }
            return View(tblHero);
        }

        // GET: TblHeroes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.TblHeroes == null)
            {
                return NotFound();
            }

            // First vs Find
            var tblHero = _context.TblHeroes.Find(id); // Primary Key
            if (tblHero == null)
            {
                return NotFound();
            }
            return View(tblHero);
        }

        // POST: TblHeroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Name,Atk,Hp")] TblHero tblHero)
        {
            if (id != tblHero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblHero);
                    _context.SaveChanges(); // 有動到資料庫的資料，就必須 SaveChanges
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblHeroExists(tblHero.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblHero);
        }

        // GET: TblHeroes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.TblHeroes == null)
            {
                return NotFound();
            }

            var tblHero = _context.TblHeroes
                .FirstOrDefault(m => m.Id == id);
            if (tblHero == null)
            {
                return NotFound();
            }

            return View(tblHero);
        }

        // POST: TblHeroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteASDFGHJK(int id)
        {
            if (_context.TblHeroes == null)
            {
                return Problem("Entity set 'HomeworkDBContext.TblHeroes'  is null.");
            }
            var tblHero = _context.TblHeroes.Find(id);
            if (tblHero != null)
            {
                _context.TblHeroes.Remove(tblHero);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: 取得表單
        public IActionResult Search()
        {
            // ViewData ViewBag (Controller -> View)
            ViewData["Message"] = "英雄搜尋 GET => 取得表單";
            var model = new HeroSearchViewModel();
            return View(model); // new => 避免 null reference 發生
        }

        [HttpPost]
        public IActionResult Search(HeroSearchParams searchParams)
        {
            var viewModel = new HeroSearchViewModel();
            var searchResult = _context.TblHeroes
                .Where(x => x.Atk >= searchParams.MinAtk && x.Atk <= searchParams.MaxAtk);

            viewModel.SearchParams = searchParams;
            viewModel.Heroes = searchResult.ToList();
            ViewData["Message"] = $"找到 {viewModel.Heroes.Count} 個英雄";

            return View(viewModel);
        }
        public async Task<IActionResult> GetDummySelectList()
        {
            await Task.Delay(3000);
            return Json(new List<DemoListItem>()
            {
                new DemoListItem() { Name = "選項 1", Value = "value 1" },
                new DemoListItem() { Name = "選項 2", Value = "value 2" },
                new DemoListItem() { Name = "選項 3", Value = "value 3" },
            });
        }

        private bool TblHeroExists(int id)
        {
            return (_context.TblHeroes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
