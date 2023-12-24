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
        public void AddURL(string URLName, string URL, int shopId);
        public void DeleteURL(int URLId);
        public void ChangeURL(int URLId, string newURL);

    }
}
