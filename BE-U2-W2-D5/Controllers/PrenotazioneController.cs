using Microsoft.AspNetCore.Mvc;

using BE_U2_W2_D5.Services;
using BE_U2_W2_D5.Models.Entities;
using Microsoft.AspNetCore.Authorization;
namespace BE_U2_W2_D5.Controllers
{

    [Authorize(Roles = "Admin,User")]
    public class PrenotazioneController : Controller
    {    
        private readonly ICameraServices _cameraServices;
        private readonly IClienteServices _clienteServices;
        private readonly IPrenotazioneServices _prenotazioneServices;

        public PrenotazioneController(ICameraServices cameraServices, IClienteServices clienteServices, IPrenotazioneServices prenotazioneServices)
        {
            _cameraServices = cameraServices;
            _clienteServices = clienteServices;
            _prenotazioneServices = prenotazioneServices;
        }

        public async Task<IActionResult> Index()
        {
            var prenotazioni = await _prenotazioneServices.GetAllAsync();
            return View(prenotazioni);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Prenotazione prenotazione)
        {            
            prenotazione.Cliente = await _clienteServices.GetByIdAsync(prenotazione.ClienteId);
            prenotazione.Camera = await _cameraServices.GetByIdAsync(prenotazione.CameraId);

            prenotazione.IdPrenotazione = Guid.NewGuid();

            await _prenotazioneServices.CreateAsync(prenotazione);

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Register()
        {
            ViewBag.Camere = await  _cameraServices.GetAllAsync();
            ViewBag.Clienti = await _clienteServices.GetAllAsync();
            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var prenotazione = await _prenotazioneServices.GetByIdAsync(id);
            if (prenotazione != null)
            {
                await _prenotazioneServices.DeleteAsync(prenotazione);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<IActionResult> Update( Guid id)
        {
            ViewBag.Camere = await _cameraServices.GetAllAsync();
            ViewBag.Clienti = await _clienteServices.GetAllAsync();
            var prenotazione = await _prenotazioneServices.GetByIdAsync(id);
            if(prenotazione == null)
                return NotFound();

            ViewBag.Prenotazione = prenotazione;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Update(Prenotazione prenotazione)
        {
            //prenotazione.Cliente = await _clienteServices.GetByIdAsync(prenotazione.ClienteId);
            //prenotazione.Camera = await _cameraServices.GetByIdAsync(prenotazione.CameraId);
            var existingPrenotazione = await _prenotazioneServices.GetByIdAsync(prenotazione.IdPrenotazione);
            if (existingPrenotazione == null)
            {
                return NotFound();
            }
            existingPrenotazione.Stato = prenotazione.Stato;
            existingPrenotazione.DataInizio = prenotazione.DataInizio;
            existingPrenotazione.DataFine = prenotazione.DataFine;
            existingPrenotazione.ClienteId = prenotazione.ClienteId;
            existingPrenotazione.CameraId = prenotazione.CameraId;
            await _prenotazioneServices.UpdateAsync(existingPrenotazione);
            return RedirectToAction("Index");
        }
    }
}
