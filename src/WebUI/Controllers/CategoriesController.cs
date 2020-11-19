using CodeClinic.Application.Categories.Commands.CreateCategory;
using CodeClinic.Application.Categories.Commands.DeleteCategory;
using CodeClinic.Application.Categories.Commands.UpdateCategory;
using CodeClinic.Application.Categories.Queries.GetCategory;
using CodeClinic.Application.Categories.Queries.GetCategoryList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.WebUI.Controllers
{
    public class CategoriesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<CategoryListVm>> GetAll()
        {
            return await Mediator.Send(new GetCategoryListQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailVm>> GetCategoryById(int id)
        {
            return await Mediator.Send(new GetCategoryDetailQuery { Id = id });
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
        {
            return await Mediator.Send(command); 
        }
         
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(UpdateCategoryCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCategoryCommand { Id =id});

            return NoContent();
        }
    }
}
