﻿ using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SpillTracker.Models;
using SpillTracker.Utilities;

namespace SpillTracker.Controllers
{
    public class ChemicalsController : Controller
    {
        private readonly SpillTrackerDbContext _context;

        public ChemicalsController(SpillTrackerDbContext context)
        {
            _context = context;
        }

        // GET: Chemicals
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            /*return View(await _context.Chemicals.ToListAsync());*/
            return View(await _context.Chemicals.OrderBy(x => x.Name).ToListAsync());
        }

        [AllowAnonymous]
        public IActionResult ByFirstLetter(string l)
        {
            //var list = new List<string> "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            var list = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z".Split(" ").ToList();
            var all = _context.Chemicals.OrderBy(x => x.Name).ToList();
            var letter = new List<Chemical>();
            var hashtag = new List<Chemical>();
            letter = _context.Chemicals.Where(c => c.Name.Substring(0, 1).Contains(l)).OrderBy(x => x.Name).ToList();
            hashtag = _context.Chemicals.Where(c => !list.Contains(c.Name.Substring(0, 1))).OrderBy(x => x.Name).ToList();
            //_logger.LogInformation(sort.letterInput);(x => x.Name).ToList();

            if (l == null)
            {
                return View("Index", all);
            }
            else if (l.Length > 1)
            {
                letter = _context.Chemicals.Where(c => c.Name.Substring(0, l.Length).Contains(l)).OrderBy(x => x.Name).ToList();
                return View("Index", letter);
            }
            else if (l != "#")
            {
                return View("Index", letter);
            }
            else if (l == "#")
            {
                return View("Index", hashtag); //needs adjustment
            }
            else
            {
                return View("Index", all);
            }
        }

        [AllowAnonymous]
        // GET: Chemicals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chemical = await _context.Chemicals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chemical == null)
            {
                return NotFound();
            }

            ExtraChemData extraData = GetCIDMolWeightFromPUGRest(chemical.CasNum);

            return View(chemical);
        }


        // GET: Chemicals/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }

        // // POST: Chemicals/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Name,CasNum,PubChemCid,ReportableQuantity,ReportableQuantityUnits,Density,DensityUnits,MolecularWeight,MolecularWeightUnits,VaporPressure,VaporPressureUnits,CerclaChem,EpcraChem")] Chemical chemical)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(chemical);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(chemical);
        // }

        //GET: Chemicals/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chemical = await _context.Chemicals.FindAsync(id);
            if (chemical == null)
            {
                return NotFound();
            }
            return View(chemical);
        }

        //  POST: Chemicals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CasNum,PubChemCid,ReportableQuantity,ReportableQuantityUnits,Density,DensityUnits,MolecularWeight,MolecularWeightUnits,VaporPressure,VaporPressureUnits,CerclaChem,EpcraChem")] Chemical chemical)
        {
            if (id != chemical.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chemical);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChemicalExists(chemical.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(chemical);
        }

        // GET: Chemicals/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var chemical = await _context.Chemicals
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (chemical == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(chemical);
        // }

        // // POST: Chemicals/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var chemical = await _context.Chemicals.FindAsync(id);
        //     _context.Chemicals.Remove(chemical);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        private bool ChemicalExists(int id)
        {
            return _context.Chemicals.Any(e => e.Id == id);
        }




        //Attempt to get CID and Molecular weight from the Pug REst API
        public ExtraChemData GetCIDMolWeightFromPUGRest(string casNumber)
        {
            string url;
            PugAPI pug = new PugAPI();
            ExtraChemData currentData = new ExtraChemData() { CAS = casNumber };

            url = $"https://pubchem.ncbi.nlm.nih.gov/rest/pug/compound/name/{casNumber}/property/MolecularWeight/json";

            currentData = pug.GitCIDAndMolWeight(url);

            //If there is no cid number found by the API send back and empty extraChemData object 
            if (currentData.CID != 0)
            {
                currentData = pug.GetDensVapPresFromPUGView(currentData);
                if (_context.Chemicals.Where(a => a.CasNum == casNumber).Select(x => x.PubChemCid).FirstOrDefault() == null)
                {
                    Chemical chem = _context.Chemicals.Where(a => a.CasNum == casNumber).First();
                    chem.PubChemCid = currentData.CID;
                    _context.SaveChanges();
                }

                if (_context.Chemicals.Where(a => a.CasNum == casNumber).Select(x => x.MolecularWeight).FirstOrDefault() == null)
                {
                    Chemical chem = _context.Chemicals.Where(a => a.CasNum == casNumber).First();
                    chem.MolecularWeight = currentData.MolecularWeight;
                    _context.SaveChanges();
                }

                if (_context.Chemicals.Where(a => a.CasNum == casNumber).Select(x => x.Density).FirstOrDefault() == null)
                {
                    Chemical chem = _context.Chemicals.Where(a => a.CasNum == casNumber).First();
                    chem.Density = currentData.Density;
                    _context.SaveChanges();
                }
                if (_context.Chemicals.Where(a => a.CasNum == casNumber).Select(x => x.VaporPressure).FirstOrDefault() == null)
                {
                    Chemical chem = _context.Chemicals.Where(a => a.CasNum == casNumber).First();
                    chem.VaporPressure = currentData.VaporPressure;
                    _context.SaveChanges();
                }
            }

            return currentData;
        }
    }
}
