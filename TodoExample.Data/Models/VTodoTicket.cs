﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TodoExample.Data.Models
{
    public partial class VTodoTicket
    {
        public string TodoTicketId { get; set; }
        public string TodoName { get; set; }
        public string TodoDescription { get; set; }
        public string TodoStatusId { get; set; }
        public string TodoStatusName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}