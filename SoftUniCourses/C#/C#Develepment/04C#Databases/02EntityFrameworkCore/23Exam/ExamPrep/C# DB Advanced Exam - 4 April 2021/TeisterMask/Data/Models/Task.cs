﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.Data.Models
{
    public class Task
    {
        public Task()
        {
            this.EmployeesTasks = new HashSet<EmployeeTask>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime OpenDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public ExecutionType ExecutionType { get; set; }

        [Required]
        public LabelType LabelType { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public ICollection<EmployeeTask> EmployeesTasks { get; set; }

        /*•	Id - integer, Primary Key
          •	Name - text with length [2, 40] 
          •	OpenDate - date and time 
          •	DueDate - date and time
          •	ExecutionType - enumeration of type ExecutionType, with possible values 
        (ProductBacklog, SprintBacklog, InProgress, Finished)
          •	LabelType - enumeration of type LabelType, with possible values
        (Priority, CSharpAdvanced, JavaAdvanced, EntityFramework, Hibernate) 
          •	ProjectId - integer, foreign key (required)
          •	Project - Project 
          •	EmployeesTasks - collection of type EmployeeTask

         *
         *
         *
         */
    }
}
