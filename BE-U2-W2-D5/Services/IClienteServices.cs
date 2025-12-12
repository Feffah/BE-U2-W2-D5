using BE_U2_W2_D5.Models.Entities;

namespace BE_U2_W2_D5.Services
{
    public interface IClienteServices
    {
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Cliente cliente);
        Task<bool> UpdateAsync(Cliente cliente);
        Task<bool> DeleteAsync(Cliente cliente);

    }
}
