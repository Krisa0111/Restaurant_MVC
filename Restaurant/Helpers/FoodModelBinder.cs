using Microsoft.AspNetCore.Mvc.ModelBinding;
using Restaurant.Models;

namespace Restaurant.Helpers
{
    public class FoodModelBinder :IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            Food food = new Food();
            food.Név = bindingContext.ValueProvider.GetValue("név").FirstValue;
            food.Tápérték = int.Parse(bindingContext.ValueProvider.GetValue("tápérték").FirstValue);
            food.Kategória = bindingContext.ValueProvider.GetValue("kategória").FirstValue;
            food.Ár = int.Parse(bindingContext.ValueProvider.GetValue("ár").FirstValue);

            if (bindingContext.HttpContext.Request.Form.Files.Count > 0)
            {
                var file = bindingContext.HttpContext.Request.Form.Files[0];
                using (var stream = file.OpenReadStream())
                {
                    byte[] buffer = new byte[file.Length];
                    stream.Read(buffer, 0, (int)file.Length);
                    string filename = food.Id + "." + file.FileName.Split('.')[1];
                    food.ImageFileName = filename;
                    //db módszer
                    food.Data = buffer;
                    food.ContentType = file.ContentType;
                }
            }

            bindingContext.Result = ModelBindingResult.Success(food);
            return Task.CompletedTask;

        }
    }
}
