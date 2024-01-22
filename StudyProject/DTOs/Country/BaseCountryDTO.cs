﻿using System.ComponentModel.DataAnnotations;

namespace StudyProject.DTOs.Country
{
    public abstract class BaseCountryDTO
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
