﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.Data.Models
{
    public class Ticket
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public decimal Price { get; set; }

        [MaxLength(10)]
        public sbyte RowNumber { get; set; }

        [Required]
        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }

        public virtual Play Play { get; set; }

        [Required]
        [ForeignKey(nameof(Theatre))]
        public int TheatreId { get; set; }

        public virtual Theatre Theatre { get; set; }

        /*
         * •	Id – integer, Primary Key
           •	Price – decimal in the range [1.00….100.00] (required)
           •	RowNumber – sbyte in range [1….10] (required)
           •	PlayId – integer, foreign key (required)
           •	TheatreId – integer, foreign key (required)

         */
    }
}
