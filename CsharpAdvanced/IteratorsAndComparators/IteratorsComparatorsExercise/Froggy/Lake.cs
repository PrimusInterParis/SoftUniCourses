﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly int[] lakeStones;

        public Lake(params int[] stones)

        {
            this.lakeStones = stones;
        }


        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < lakeStones.Length; i += 2)
            {
                yield return this.lakeStones[i];
            }

            for (int i = this.lakeStones.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.lakeStones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
