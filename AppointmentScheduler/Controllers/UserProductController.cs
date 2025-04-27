﻿using Microsoft.AspNetCore.Mvc;
using Optik.Models;

namespace AppointmentScheduler.Controllers;

public class UserProductController : Controller
{
    private readonly ApplicationDbContext _context;

    public UserProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }
}
