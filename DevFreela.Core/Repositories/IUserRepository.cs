using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        //Task<User?> GetById(int id);
        //Task<int> Add(User user);
        //Task PostSkills(UserSkill skill);
        //Task PostProfilePicture();

        Task<User> GetByIdAsync(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
