﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP235MVCFinal.Models
{
    public class Movies // This class holds a list of Movies
    {
        public List<Movie> Items { get; set; }

        public int EditIndex { get; set; }
        public Movies() { }

    }
}