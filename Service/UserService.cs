using LamaranKerjaOnline.Model;
using SQLite;

namespace LamaranKerjaOnline.Service;

public class UserService
{
	string _dbPath;
	public string StatusMessage { get; set; }
	private SQLiteAsyncConnection conn;

	private List<User> _users = new();
    public UserService(string dbPath)
    {
		_dbPath = dbPath;
        
	}

	private async Task InitAsync()
	{
		// Don't Create database if it exists
		if (conn != null)
			return;
		// Create database and User Table
		conn = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
		await conn.CreateTableAsync<User>();
	}
	public async Task<List<User>> GetUserAsync()
	{
		await InitAsync();
		return await conn.Table<User>().ToListAsync();
	}
	public async Task<User> CreateUserAsync(
		User paramUser)
	{
		// Insert
		await conn.InsertAsync(paramUser);
		// return the object with the
		// auto incremented Id populated
		return paramUser;
	}
	public async Task<User> UpdateUserAsync(
		User paramUser)
	{
		// Update
		await conn.UpdateAsync(paramUser);
		// Return the updated object
		return paramUser;
	}
	public async Task<User> DeleteUserAsync(
		User paramUser)
	{
		// Delete
		await conn.DeleteAsync(paramUser);
		return paramUser;
	}

    public static char GetLetter()
    {
        string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
        Random rand = new Random();
        int num = rand.Next(0, chars.Length);
        return chars[num];
    }
    public async IAsyncEnumerable<User> GetUserStream()
    {
		var rnd = new Random();
        for (int i = 0; i < 100; i++)
        {
            _users.Add(new User { Id = rnd.Next(), FirstName = GetLetter().ToString(), LastName = GetLetter().ToString() });
        }
        await Task.Delay(10000);
		foreach (var user in _users)
		{
			yield return user;
		}
		
        
    }
}
