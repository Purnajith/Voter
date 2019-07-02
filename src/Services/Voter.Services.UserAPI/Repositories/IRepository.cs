using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voter.Services.UserAPI.Repositories
{
	public interface IRepository <T>
	{
		Task<IEnumerable<T>> GetAll();

		Task<T> GetByEmail(string email);

		Task Create(T t);

		Task<bool> Update(T game);

		Task<bool> Delete(string email);
	}
}
