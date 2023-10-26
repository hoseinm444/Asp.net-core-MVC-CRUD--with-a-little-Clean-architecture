using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSubsystem.Domain.AggregatesModel.Company
{
    public class CompanyDto : ICompany
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string CompanyCode { get; set; }

        public string EconomicCode { get; set; }

        public string CompanyAddress { get; set; }

        public string CompanyPhoneNumber { get; set; }
    }
}
