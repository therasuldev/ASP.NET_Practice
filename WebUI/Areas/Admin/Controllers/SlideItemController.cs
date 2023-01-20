using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.ViewsModels.Slider;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SlideItemController : Controller
    {
        private ISlideItemRepository _repository;

        public SlideItemController(ISlideItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SlideItemMV item)
        {
            if (!ModelState.IsValid) return View(item);
            SlideItem slideItem = new()
            {
                Photo = item.Photo,
                Name = item.Name,
                Price = item.Price,
                OldPrice = item.OldPrice,

            };
            await  _repository.CreateAsync(slideItem);
            await _repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _repository.GetAsync(id);
            if (model == null) return NotFound();
            SlideUpdateMV updateModel = new()
            {
                Photo = model.Photo,
                Name = model.Name,
                Price = model.Price,
                OldPrice = model.OldPrice,
            };
           
            return View(updateModel); 
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, SlideUpdateMV item)
        {
            if (id != item.Id) return BadRequest();
            if (!ModelState.IsValid) return View(item);
            var model = await _repository.GetAsync(id);
            if (model == null) return NotFound();

            model.Photo = item.Photo!;
            model.Name = item.Name!;
            model.Price = item.Price!;
            _repository.Update(model);
            await _repository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _repository.GetAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public  async Task<IActionResult> DeletePost(int id)
        {
            var model = await _repository.GetAsync(id);
            if (model == null) return NotFound();
            _repository.Delete(model);
            await _repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}

