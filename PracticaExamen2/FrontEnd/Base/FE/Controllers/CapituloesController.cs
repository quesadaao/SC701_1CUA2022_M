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
    public class CapituloesController : Controller
    {
        private readonly IAnimesServices animesServices;
        private readonly ITemporadasServices temporadasServices;
        private readonly ICapituloesServices capituloesServices;

        public CapituloesController(IAnimesServices animesServices, ITemporadasServices temporadasServices, ICapituloesServices capituloesServices)
        {
            this.animesServices = animesServices;
            this.temporadasServices = temporadasServices;
            this.capituloesServices = capituloesServices;
        }

        // GET: Capituloes
        public async Task<IActionResult> Index()
        {
            //var akiraToriyamaContext = _context.Capitulo.Include(c => c.IdAnimeNavigation).Include(c => c.IdTemporadaNavigation);
            return View(await capituloesServices.GetAllAsync());
        }

        // GET: Capituloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitulo = await capituloesServices.GetOneByIdAsync((int)id);
            if (capitulo == null)
            {
                return NotFound();
            }

            return View(capitulo);
        }

        // GET: Capituloes/Create
        public IActionResult Create()
        {
            ViewData["IdAnime"] = new SelectList(animesServices.GetAll(), "Id", "Id");
            ViewData["IdTemporada"] = new SelectList(temporadasServices.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Capituloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Creacion,Modificacion,ModificadoPor,IdTemporada,IdAnime")] Capitulo capitulo)
        {
            if (ModelState.IsValid)
            {
                capituloesServices.Insert(capitulo);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAnime"] = new SelectList(animesServices.GetAll(), "Id", "Id", capitulo.IdAnime);
            ViewData["IdTemporada"] = new SelectList(temporadasServices.GetAll(), "Id", "Id", capitulo.IdTemporada);
            return View(capitulo);
        }

        // GET: Capituloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitulo = capituloesServices.GetOneById((int)id);
            if (capitulo == null)
            {
                return NotFound();
            }
            ViewData["IdAnime"] = new SelectList(animesServices.GetAll(), "Id", "Id", capitulo.IdAnime);
            ViewData["IdTemporada"] = new SelectList(temporadasServices.GetAll(), "Id", "Id", capitulo.IdTemporada);
            return View(capitulo);
        }

        // POST: Capituloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Creacion,Modificacion,ModificadoPor,IdTemporada,IdAnime")] Capitulo capitulo)
        {
            if (id != capitulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    capituloesServices.Update(capitulo);
                }
                catch (Exception ee)
                {
                    if (!CapituloExists(capitulo.Id))
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
            ViewData["IdAnime"] = new SelectList(animesServices.GetAll(), "Id", "Id", capitulo.IdAnime);
            ViewData["IdTemporada"] = new SelectList(temporadasServices.GetAll(), "Id", "Id", capitulo.IdTemporada);
            return View(capitulo);
        }

        // GET: Capituloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitulo = capituloesServices.GetOneByIdAsync((int)id);
            if (capitulo == null)
            {
                return NotFound();
            }

            return View(capitulo);
        }

        // POST: Capituloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var capitulo = capituloesServices.GetOneById((int)id);
            capituloesServices.Delete(capitulo);
            return RedirectToAction(nameof(Index));
        }

        private bool CapituloExists(int id)
        {
            return (capituloesServices.GetOneById((int)id))!=null;
        }
    }
}
