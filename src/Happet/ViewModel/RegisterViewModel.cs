using Happet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.ViewModel
{
    public record RegisterViewModel
    {
        public ETypePeople TypePeople { get; set; }

        #region Adopter
        public string FullName { get; set; }
        public int RG { get; set; }
        public int CPF { get; set; }
        public DateTime BirthDate { get; set; }
        #endregion Adopter

        #region Ngo
        public string FantasyName { get; set; }
        public int CNPJ { get; set; }
        #endregion Ngo

        public string AccupationArea { get; set; }
        public int CellPhone { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CEP { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
    }
}