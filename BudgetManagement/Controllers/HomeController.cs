// <copyright file="HomeController.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BudgetManagement.Controllers
{
    using System.Diagnostics;
    using BudgetManagement.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Interface logger.
        /// </summary>
        private readonly ILogger<HomeController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">Interface logger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}