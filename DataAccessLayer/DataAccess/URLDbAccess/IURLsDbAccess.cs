using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.URLDbAccess
{
    public interface IURLsDbAccess
    {
        public Task<List<URLModel>> GetURLs();
        public Task AddURL(string URLName, string URL, int shopId, bool multipaged);
        public Task DeleteURL(int URLId);
        public Task ChangeURL(int URLId, string newURL);

    }
}
