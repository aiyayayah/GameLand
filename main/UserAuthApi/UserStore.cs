using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using UserAuthApi.Models;

namespace UserAuthApi.Data
{
    public class UserStore
    {
        private readonly string filePath = "users.json";

        public async Task<List<User>> LoadUsersAsync()
        {
            if (!File.Exists(filePath))
                return new List<User>();

            string json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public async Task SaveUsersAsync(List<User> users)
        {
            string json = JsonSerializer.Serialize(users);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
