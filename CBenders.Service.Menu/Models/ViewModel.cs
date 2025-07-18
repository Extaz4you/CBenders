﻿using System.ComponentModel.DataAnnotations;

namespace CBenders.Service.Menu.Models;

public class ViewModel
{
    public string Name { get; set; }
    public double Price { get; set; }

    public ViewModel(MenuItems menu)
    {
        this.Name = menu.Name;
        this.Price = menu.Price;
    }
}
