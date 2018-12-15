using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voter.Services.UserAPI.Repositories
{
	public interface IRepository <T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> Get(int ID);
		Task<T> GetByName(string name);
		Task Create(T t);
		Task<bool> Update(T game);
		Task<bool> Delete(int ID);
	}
}
