﻿using AutoMapper;
using BikeShop.Database;
using BikeShop.Domain;
using BikeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    // Replace var's
    // Move logic to Service class
    public class BikeController : Controller
    {
        private readonly IBikeDatabase _bikeDatabase;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IMapper _mapper;
        public BikeController(IBikeDatabase bikeDatabase, IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _bikeDatabase = bikeDatabase;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;   
        }

        public IActionResult Index()
        {
            var vm = _bikeDatabase.GetBikes().Select(x => new BikeListViewModel
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Year = x.Year
            });

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new BikeCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create([FromForm] BikeCreateViewModel vm)
        {
            if (TryValidateModel(vm))
            {
                var bike = new Bike()
                {
                    Manufacturer = vm.Manufacturer,
                    Model = vm.Model,
                    Type = vm.Type,
                    Year = vm.Year,
                    Price = vm.Price
                };

                if (vm.Photo != null)
                {
                    string fileName = UploadPhoto(vm.Photo, bike);
                    bike.PhotoUrl = Path.Combine("/photos", fileName);
                }

                _bikeDatabase.Insert(bike);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Detail([FromRoute] int id)
        {
            var bike = _bikeDatabase.GetBike(id);
            BikeDetailViewModel vm = _mapper.Map<BikeDetailViewModel>(bike);

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var bike = _bikeDatabase.GetBike(id);
            BikeEditViewModel vm = _mapper.Map<BikeEditViewModel>(bike);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, [FromForm] BikeEditViewModel vm)
        {
            if (TryValidateModel(vm))
            {
                Bike bike = new Bike();
                bike = _mapper.Map<Bike>(vm);

                var bikeFromDb = _bikeDatabase.GetBike(id); 

                if (vm.Photo == null)
                {
                    bike.PhotoUrl = bikeFromDb.PhotoUrl;
                }
                else
                {
                    if (!string.IsNullOrEmpty(bikeFromDb.PhotoUrl))
                    {
                        DeletePhoto(bikeFromDb.PhotoUrl);
                    }

                    string fileName = UploadPhoto(vm.Photo, bike);
                    bike.PhotoUrl = Path.Combine("/photos", fileName);
                }

                _bikeDatabase.Update(id, bike);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var bike = _bikeDatabase.GetBike(id);
            BikeDeleteViewModel vm = _mapper.Map<BikeDeleteViewModel>(bike);

            return View(vm);
        }

        [HttpPost]
        public IActionResult ConfirmDelete([FromRoute] int id)
        {
            _bikeDatabase.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private string UploadPhoto(IFormFile photo, Bike bike)
        {
            string fileName = bike.Manufacturer + bike.Model + bike.Year.ToString() + Path.GetExtension(photo.FileName);
            string pathName = Path.Combine(_hostEnvironment.WebRootPath, "Photos");
            string fileNameWithPath = Path.Combine(pathName, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                photo.CopyTo(stream);
            }

            return fileName;
        }

        private void DeletePhoto(string photoUrl)
        {
            string path = Path.Combine(_hostEnvironment.WebRootPath, photoUrl.Substring(1));
            System.IO.File.Delete(path);
        }
    }
}
