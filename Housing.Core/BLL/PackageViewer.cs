using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Housing.Data;
using Housing.Entities.ViewModels;

namespace Housing.BLL
{
    /// <summary>
    /// Business class for handling viewing of package view models
    /// </summary>
    public class PackageViewer
    {
        private readonly PackageDAO _packageDAO;

        public PackageViewer()
        {
            _packageDAO = new PackageDAO();
        }

        /// <summary>
        /// Returns view models of all package by building
        /// </summary>
        public IList<PackageViewModel> GetPackage(string Firstname, string Lastname)
        {
            return _packageDAO.GetPackages(Firstname, Lastname);
        }


    }
}
