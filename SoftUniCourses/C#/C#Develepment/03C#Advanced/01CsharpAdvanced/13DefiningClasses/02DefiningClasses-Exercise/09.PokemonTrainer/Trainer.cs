﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {

       

        public Trainer(string name)
       
        {
            Name = name;

            Badges = 0;

            Pokemons = new List<Pokemon>();

        }

        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public void AddPockemons(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

    }
}
