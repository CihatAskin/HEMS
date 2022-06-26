using AutoMapper;
using HEMS.Application.Services.Contracts;
using HEMS.Client.Models.Category;
using HEMS.Shared.Requests.Category;
using Microsoft.AspNetCore.Mvc;

namespace HEMS.Client.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                return RedirectToError();
            }

            var request = new CategoryReadRequest(id);
            var response = await _categoryService.Get(request);
            if (response.IsSucceeded)
            {
                return View(_mapper.Map<CategoryEditModel>(response.Item));
            }

            return RedirectToError();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditModel model)
        {
            if (ModelState.IsValid)
            {
                var request = _mapper.Map<CategoryEditRequest>(model);
                var response = await _categoryService.Edit(request);
                if (response.IsSucceeded)
                {
                    return RedirectToAction(nameof(List));
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var request = _mapper.Map<CategoryCreateRequest>(model);
                var response = await _categoryService.Create(request);

                if (response.IsSucceeded)
                {
                    return RedirectToAction(nameof(List));
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var request = new CategoryReadListRequest();
            var response = await _categoryService.List(request);

            if (response.IsSucceeded)
            {
                return View(_mapper.Map<List<CategoryReadModel>>(response.Items));
            }

            return RedirectToError();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var result = new { messages = string.Empty };
            if (string.IsNullOrWhiteSpace(id))
            {
                return Json(result);
            }

            var request = new CategoryDeleteRequest(id);
            var response = await _categoryService.Delete(request);
            if (response.IsSucceeded)
            {
                return Json(result);
            }

            return Json(new { messages=response.ErrorMessages[0]});
        }
    }
}
