﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {

        public Medicament()
        {
            this.Prescriptions = new List<PatientMedicament>();
        }

        public int MedicamentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
