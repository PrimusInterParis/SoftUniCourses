﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstates.Data;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
         var districts =   this.dbContext.Districts.Select(x => new DistrictInfoDto()
            {
                Name = x.Name,
                PropertiesCount = x.Properties.Count(),
                AveragePricePerSquareMeter = x.Properties.Where(p => p.Price.HasValue)
                    .Average(p => p.Price / (decimal)p.Size ?? 0)
            }).OrderByDescending(x => x.AveragePricePerSquareMeter).Take(count).ToList();


         return districts;
        }
    }
}
