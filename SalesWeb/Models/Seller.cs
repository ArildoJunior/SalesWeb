using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWeb.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Name required")]
        [StringLength(60, MinimumLength =3, ErrorMessage = "Name size should be between 3 and 60")]
        public string Name { get; set; }

        [DataType (DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Display (Name = "Birth Date")]
        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Birth Date required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Base Salary")]
        [Range(100.0, 50000.0, ErrorMessage = "Base Salary must be from 100.0 to 50000.0")]
        [Display (Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}