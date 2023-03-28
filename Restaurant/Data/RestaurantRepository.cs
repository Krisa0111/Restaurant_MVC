using Restaurant.Models;

namespace Restaurant.Data
{
    public class RestaurantRepository : IRestaurantRepository
    {
        RestaurantDbContext context;

        public RestaurantRepository(RestaurantDbContext context)
        {
            this.context = context;
        }
        public void Create(Food food)
        {
            context.Foods.Add(food);
            context.SaveChanges();
        }
        public IEnumerable<Food> Read()
        {
            System.Threading.Thread.Sleep(2000);
            return context.Foods;
        }

        public Food? Read(string name)
        {
            return context.Foods.FirstOrDefault(t => t.Név == name);
        }
        public Food? ReadFromId(string id)
        {
            return context.Foods.FirstOrDefault(t => t.Id == id);
        }
        public void Delete(string name)
        {
            var food = Read(name);
            context.Foods.Remove(food);
            context.SaveChanges();
        }
        public void Update(Food food)
        {
            var old = Read(food.Név);
            old.Név = food.Név;   // itt lehet hiba
            old.Ár = food.Ár;
            old.Tápérték = food.Tápérték;
            old.Kategória = food.Kategória;
            context.SaveChanges();
        }
    }
}
