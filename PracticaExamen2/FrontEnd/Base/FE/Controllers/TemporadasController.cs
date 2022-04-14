using FE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FE.Models;


namespace FE.Controllers
{
    public class TemporadasController : Controller
    {
        private readonly IAnimesServices animesServices;
        private readonly ITemporadasServices temporadasServices;

        public TemporadasController(ITemporadasServices temporadasServices, IAnimesServices animesServices)
        {
            this.temporadasServices = temporadasServices;
            this.animesServices = animesServices;
        }

        // GET: Temporadas
        public async Task<IActionResult> Index()
        {
            //var akiraToriyamaContext = _context.Temporada.Include(t => t.IdAnimeNavigation);
            return View(await temporadasServices.GetAllAsync());
        }

        // GET: Temporadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporada = await temporadasServices.GetOneByIdAsync((int)id);


            if (temporada == null)
            {
                return NotFound();
            }

            return View(temporada);
        }

        // GET: Temporadas/Create
        public IActionResult Create()
        {
            ViewData["IdAnime"] = new SelectList(animesServices.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Temporadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,CantidadCapitulos,Creacion,Modificacion,ModificadoPor,IdAnime")] Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                temporadasServices.Insert(temporada);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAnime"] = new SelectList(animesServices.GetAll(), "Id", "Id", temporada.IdAnime);
            return View(temporada);
        }

        // GET: Temporadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporada = temporadasServices.GetOneById((int)id);
            if (temporada == null)
            {
                return NotFound();
            }
            ViewData["IdAnime"] = new SelectList(animesServices.GetAll(), "Id", "Id", temporada.IdAnime);
            return View(temporada);
        }

        // POST: Temporadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,CantidadCapitulos,Creacion,Modificacion,ModificadoPor,IdAnime")] Temporada temporada)
        {
            if (id != temporada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    temporadasServices.Update(temporada);
                }
                catch (Exception ee)
                {
                    if (!TemporadaExists(temporada.Id))
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
            ViewData["IdAnime"] = new SelectList(animesServices.GetAll(), "Id", "Id", temporada.IdAnime);
            return View(temporada);
        }

        // GET: Temporadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporada = temporadasServices.GetOneByIdAsync((int)id);
            if (temporada == null)
            {
                return NotFound();
            }

            return View(temporada);
        }

        // POST: Temporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temporada = temporadasServices.GetOneById((int)id);
            temporadasServices.Update(temporada);
            return RedirectToAction(nameof(Index));
        }

        private bool TemporadaExists(int id)
        {
            return (temporadasServices.GetOneById((int)id) != null);
        }
    }
}
