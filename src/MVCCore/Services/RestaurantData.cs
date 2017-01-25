using MvcCoreApplication.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MvcCoreApplication.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRes);
        void commit();
    }

    public class SqlRestaurantData:IRestaurantData
    {
        private MvcCoreApplicationDbContext _context;

        public SqlRestaurantData(MvcCoreApplicationDbContext context )
        {
            _context = context;
        }

        public Restaurant Add(Restaurant newRes)
        {
            _context.Add(newRes);
          
            return newRes;
        }

        public void commit()
        {
            _context.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return _context.restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.restaurants;
        }
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
       static List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id=1,Name="Game of Thrones"},
                new Restaurant {Id=2,Name="Sherlock Homes" },
                new Restaurant {Id=3,Name="Breaking Bad" }

            };
        }

        public Restaurant Add(Restaurant newRes)
        {
            newRes.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRes);
            return newRes;
        }

        public void commit()
        {
            // No Op
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r=>r.Id==id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}
