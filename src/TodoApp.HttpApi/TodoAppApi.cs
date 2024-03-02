using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Controllers;

namespace TodoApp
{
    public class TodoAppApi : TodoAppController
    {
        private readonly ITodoAppService _todoAppService;
        public TodoAppApi(ITodoAppService todoAppService)
        {
            _todoAppService = todoAppService;
        }

        [HttpGet]
        public async Task<List<TodoItemDto>> GetTodoItems()
        {
            var result = await _todoAppService.GetListAsync();
            return result;
        }

        [HttpPost]
        public async Task<TodoItemDto> PostTodoItem(string text)
        {
            var result = await _todoAppService.CreateAsync(text);
            return result;
        }

        [HttpDelete]
        public async Task RemoveTodoItem(Guid id)
        {
            await _todoAppService.DeleteAsync(id);
            
        }




    }
}
