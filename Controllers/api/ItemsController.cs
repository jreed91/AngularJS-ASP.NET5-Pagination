using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using angularjs_aspnet_paginate.Models;

namespace angularjs_aspnet_paginate.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
         private static IEnumerable<Item> _items;
        
        static ItemsController() {
            _items = Enumerable.Range(1, 100)
                                .Select(i => new Item()
                                {
                                    Id = i,
                                    Name = "Item " + i.ToString()
                                }).ToArray();
        }

         // GET: api/paginate
        [HttpGet]
        public PagedCollection<Item> Get(int? page, int? pageSize)
        {
            var currPage = page.GetValueOrDefault(0);
            currPage = currPage - 1;
            var currPageSize = pageSize.GetValueOrDefault(10);

            var paged = _items.Skip(currPage * currPageSize)
                                .Take(currPageSize)
                                .ToArray();

            var totalCount = _items.Count();

            return new PagedCollection<Item>()
            {
                Page = currPage,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((decimal)totalCount / currPageSize),
                Items = paged
            };
        }
    }
}