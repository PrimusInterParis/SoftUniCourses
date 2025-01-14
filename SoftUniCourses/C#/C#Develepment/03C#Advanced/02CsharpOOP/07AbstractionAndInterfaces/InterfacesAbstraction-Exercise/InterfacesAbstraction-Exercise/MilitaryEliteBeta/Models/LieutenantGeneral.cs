﻿using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<ISoldier> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates  => (IReadOnlyCollection<IPrivate>)this.privates; 

        public void AddPrivate(ISoldier @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");


            foreach (var soldiersPrivate in this.privates)
            {
                sb.AppendLine($"  {soldiersPrivate.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}