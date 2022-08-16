using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DomainApp.Entities;
using DomainApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_app.teste.claranet.Models;

namespace web_app.teste.claranet.Controllers
{
    [Authorize]
    public class CadastroController : Controller
    {
        private readonly IBusinessServiceCadastro _businessServiceCadastro;
        private MapperConfiguration mapperConfiguration;
        private IMapper mapper;

        private List<Estado> ListaEstados()
        {
            List<Estado> listaEstados = new List<Estado>()
            {
                new Estado(){ Sigla="AL", Descricao="Alagoas"},
                new Estado(){ Sigla="BA", Descricao="Bahia"},
                new Estado(){ Sigla="CE", Descricao="Ceará"},
                new Estado(){ Sigla="DF", Descricao="Distrito Federal"},
                new Estado(){ Sigla="ES", Descricao="Espirito Santo"},
                new Estado(){ Sigla="GO", Descricao="Goiás"},
                new Estado(){ Sigla="MG", Descricao="Minas Gerais"},
                new Estado(){ Sigla="PR", Descricao="Paraná"},
                new Estado(){ Sigla="RS", Descricao="Rio Grande do Sul"},
                new Estado(){ Sigla="SP", Descricao="São Paulo"},
                new Estado(){ Sigla="TO", Descricao="Tocantins"}
            };

            return listaEstados;
        }

        private List<SelectListItem> SelectListEstados()
        {
            List<SelectListItem> dropdownEstados = new List<SelectListItem>();
            foreach (var item in ListaEstados())
            {
                dropdownEstados.Add(new SelectListItem { Value = item.Sigla, Text = item.Descricao });
            }

            return dropdownEstados;
        }
        public CadastroController(IBusinessServiceCadastro businessServiceCadastro)
        {
            _businessServiceCadastro = businessServiceCadastro;

            mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Cadastro, CadastroViewModel>();
                cfg.CreateMap<CadastroViewModel, Cadastro>();
            });

            mapper = mapperConfiguration.CreateMapper();
        }

        // GET: Cadastro
        public async Task<IActionResult> Index()
        {

            List<CadastroViewModel> listCadastro = new List<CadastroViewModel>();

            if (_businessServiceCadastro != null)
            {
                var cad = await _businessServiceCadastro.GetAll();
                listCadastro = mapper.Map<List<Cadastro>, List<CadastroViewModel>>(cad.ToList());
            }

            return _businessServiceCadastro != null ? 
                View(listCadastro) :
                Problem("Entity set 'businessServiceCadastro'  is null.");
        }

        // GET: Cadastro/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            CadastroViewModel cadastroViewModel = new CadastroViewModel();

            if (id == null || _businessServiceCadastro == null)
            {
                return NotFound();
            }

            var cadastro = await _businessServiceCadastro.GetById(id);


            if (cadastro == null)
            {
                return NotFound();
            }

            cadastroViewModel = mapper.Map<Cadastro, CadastroViewModel>(cadastro);

            return View(cadastroViewModel);
        }

        // GET: Cadastro/Create
        public IActionResult Create()
        {

            ViewBag.Estados = SelectListEstados();
            return View();
        }

        // POST: Cadastro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cnpj,RazaoSocial,NomeFantasia,Email,Telefone,TelefoneComercial,Celular,Logradouro,Num,Complemento,Bairro,Cidade,Estado,Cep,NomeContato")] CadastroViewModel cadastroViewModel)
        {
            Cadastro cadastro = new Cadastro();

            if (ModelState.IsValid)
            {
                cadastro = mapper.Map<CadastroViewModel, Cadastro>(cadastroViewModel);
                await _businessServiceCadastro.Add(cadastro);
                await _businessServiceCadastro.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(cadastroViewModel);
        }

        // GET: Cadastro/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            CadastroViewModel cadastroViewModel = new CadastroViewModel();

            if (id == null || _businessServiceCadastro == null)
            {
                return NotFound();
            }

            var cadastro = await _businessServiceCadastro.GetById(id);
            if (cadastro == null)
            {
                return NotFound();
            }

            cadastroViewModel = mapper.Map<Cadastro, CadastroViewModel>(cadastro);

            ViewBag.Estados = SelectListEstados();
            return View(cadastroViewModel);
        }

        // POST: Cadastro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Cnpj,RazaoSocial,NomeFantasia,Email,Telefone,TelefoneComercial,Celular,Logradouro,Num,Complemento,Bairro,Cidade,Estado,Cep,NomeContato")] CadastroViewModel cadastroViewModel)
        {
            Cadastro cadastro = new Cadastro();

            if (id != cadastroViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cadastro = mapper.Map<CadastroViewModel, Cadastro>(cadastroViewModel);

                    _businessServiceCadastro.Update(cadastro);
                    await _businessServiceCadastro.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool existe = await CadastroExists(id);

                    if (!existe)
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
            return View(cadastroViewModel);
        }

        // GET: Cadastro/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            CadastroViewModel cadastroViewModel = new CadastroViewModel();

            if (id == null || _businessServiceCadastro == null)
            {
                return NotFound();
            }
            var cadastro = await _businessServiceCadastro.GetById(id);

            if (cadastro == null)
            {
                return NotFound();
            }

            cadastroViewModel = mapper.Map<Cadastro, CadastroViewModel>(cadastro);

            return View(cadastroViewModel);
        }

        // POST: Cadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_businessServiceCadastro == null)
            {
                return Problem("Entity set 'WebApplication1Context.Cadastro'  is null.");
            }
            var cadastro = await _businessServiceCadastro.GetById(id);
            if (cadastro != null)
            {
                await _businessServiceCadastro.Remove(cadastro);
            }
            
            await _businessServiceCadastro.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CadastroExists(long id)
        {
            var cadastro = await  _businessServiceCadastro.GetById(id);
            
            return (cadastro != null);
        }
    }
}
