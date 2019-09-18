using MyFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _18092019_Food_Exam.Controllers
{
    public class FoodController : ApiController
    {
        ManageFoodDAO mf = new ManageFoodDAO();
        public HttpResponseMessage Get()
        {
            List<Food> foods = mf.GetAllFoods();
            return Request.CreateResponse(HttpStatusCode.OK, foods);
        }
        public HttpResponseMessage Get(int id)
        {
            Food food = mf.GetFoodById(id);
            return Request.CreateResponse(HttpStatusCode.OK, food);
        }

        public HttpResponseMessage Post([FromBody]Food value)
        {
            mf.AddFood(value);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put(int id, [FromBody]Food value)
        {
            Food food = mf.UpdateFood(value);
            return Request.CreateResponse(HttpStatusCode.OK, food);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Food food = mf.DeleteFood(id);
            return Request.CreateResponse(HttpStatusCode.OK, food);
        }

        [Route("api/controller/byname/{name}")]
        [HttpGet]
        public HttpResponseMessage GetByName(string name)
        {
            Food food = mf.GetFoodByName(name);
            return Request.CreateResponse(HttpStatusCode.OK, food);
        }

        [Route("api/controller/bymincalor/{minCalories}")]
        [HttpGet]
        public HttpResponseMessage GetByMinCalories(int minCalories)
        {
            List<Food> foods = mf.GetAllFoodsByMinCalories(minCalories);
            return Request.CreateResponse(HttpStatusCode.OK, foods);
        }

    }
}
