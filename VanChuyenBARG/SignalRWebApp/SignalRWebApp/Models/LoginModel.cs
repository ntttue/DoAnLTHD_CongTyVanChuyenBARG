﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SignalRWebApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter user name.")]
        [Display(Name = "User Name")]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(10)]
        public string Password { get; set; }

    }
}