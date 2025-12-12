using BE_U2_W2_D5.Models.Entities;

namespace BE_U2_W2_D5.Services
{
    public interface IPrenotazioneServices
    {
        Task<List<Prenotazione>> GetAllAsync();
        Task<Prenotazione> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Prenotazione prenotazione);
        Task<bool> UpdateAsync(Prenotazione prenotazione);
        Task<bool> DeleteAsync(Prenotazione prenotazione);
    }
}
