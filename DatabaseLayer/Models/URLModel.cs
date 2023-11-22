﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    internal class URLModel
    {
        public int urlId { get; set; }
        public string url { get; set; }

        //Reference to URL specific actions and xPaths
        public List<ActionModel>? actions { get; set; }

        public List<XPathModel>? xPaths { get; set; }
    }
}