using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.ViewModels
{
    public class EditViewCheeseModel:AddCheeseViewModel
    {
        [HiddenInput]
        public int CheeseId { get; set; }
    }
}
