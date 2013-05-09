using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Powergrid.Intranet.Model;

namespace Com.Powergrid.Intranet.Model
{
    public class Employee
    {
        public String EmpNo { get; set; }
        public String EmpNameEn { get; set; }
        public String EmpNameHi { get; set; }
        public String Designation { get; set; }
        public String Grade { get; set; }

        public String Region { get; set; }
        public String Location { get; set; }
        public Regions IRegion { get; set; }

        public String Department { get; set; }
        public bool IsActive { get; set; }
        public DateTime? Dob { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public String Religion { get; set; }
        public String EmpState { get; set; }
        public String BloodGroup { get; set; }
        public String Discipline { get; set; }
        public String PgEmail { get; set; }
        public String ExtEmail { get; set; }
        public String CellNo { get; set; }
        //public String OfficePhoneNo { get; set; }
        public String OfficeRaxNo { get; set; }
        public String ResidenceAddress { get; set; }
        public Languages Language { get; set; }

        public DateTime PasswordChangedAt { get; set; }
        public String ReportingOfficer { get; set; }
        public String ReviewingOfficer { get; set; }
        public String ResidenceCity { get; set; }
        public String OrganizationalUnit { get; set; }
        public DateTime? DOJ { get; set; }
        public String OfficeSeat { get; set; }
        public String HomeTown { get; set; }

        //public List<Roles> Roles { get; set; }
        public List<EmployeePermissions> EPermissions { get; set; }

    }
}
