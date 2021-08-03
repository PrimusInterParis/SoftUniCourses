﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public class DriverRepository :Repository<IDriver>
    {
        

        public IDriver GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.models.AsReadOnly();
        }

        public void Add(IDriver model)
        {
            this.models.Add(model);
        }

        public bool Remove(IDriver model)
        {
            return this.models.Remove(model);
        }
    }
}
