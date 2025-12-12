using BE_U2_W2_D5.Models.Entities;

namespace BE_U2_W2_D5.Services
{
    public interface ICameraServices
    {
        Task<List<Camera>> GetAllAsync();
        Task<Camera> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Camera camera);
        Task<bool> UpdateAsync(Camera camera);
        Task<bool> DeleteAsync(Camera camera);

    }
}
