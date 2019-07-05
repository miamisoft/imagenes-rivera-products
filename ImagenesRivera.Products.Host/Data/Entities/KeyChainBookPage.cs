﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImagenesRivera.Products.Data.Entities
{
    public class KeyChainBookPage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Number { get; set; }
        public string CustomText { get; set; }
        public string ImageUrl { get; set; }

        public int KeyChainBookId { get; set; }
        public KeyChainBook KeyChainBook { get; set; }
    }
}
