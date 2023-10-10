using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaranKerjaOnline.Model;

public class User
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
}
