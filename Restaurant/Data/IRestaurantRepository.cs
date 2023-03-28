using Restaurant.Models;

namespace Restaurant.Data
{
    public interface IRestaurantRepository
    {
        void Create(Food food);
        void Delete(string name);
        IEnumerable<Food> Read();
        Food Read(string name);
        Food? ReadFromId(string id);
        void Update(Food food);
    }
}