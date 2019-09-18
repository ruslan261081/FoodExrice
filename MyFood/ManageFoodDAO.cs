using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFood
{
    public class ManageFoodDAO
    {
        public List<Food> GetAllFoods()
        {
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                return foodEntites.Foods.Where(f => f.ID > 0).ToList();
            }
        }

        public Food GetFoodById(int id)
        {
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                return foodEntites.Foods.FirstOrDefault(f => f.ID == id);
            }
        }

        public void AddFood(Food food)
        {
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                foodEntites.Foods.Add(food);
                foodEntites.SaveChanges();
            }
             
        }

        public Food UpdateFood(Food food)
        {
            Food foodForUpdate;
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                foodForUpdate = foodEntites.Foods.FirstOrDefault(f => f.ID == food.ID);
                foodForUpdate.Name = food.Name;
                foodForUpdate.Calories = food.Calories;
                foodForUpdate.Ingridents = food.Ingridents;
                foodForUpdate.Grade = food.Grade;
                foodEntites.SaveChanges();
            }
            return foodForUpdate;
        }

        public Food DeleteFood(int id)
        {
            Food foodForRemove;
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
               foodForRemove = foodEntites.Foods.FirstOrDefault(f => f.ID == id);
                foodEntites.Foods.Remove(foodForRemove);
                foodEntites.SaveChanges();
            }
            return foodForRemove;
        }

        public Food GetFoodByName(string name)
        {
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                return foodEntites.Foods.FirstOrDefault(f => f.Name == name);
            }
        }

        public List<Food> GetAllFoodsByMinCalories(int Calories)
        {
            using (FoodDBEntities foodEntites = new FoodDBEntities())
            {
                return foodEntites.Foods.Where(f => f.Calories > Calories).ToList();
            }
        }
    }
}
