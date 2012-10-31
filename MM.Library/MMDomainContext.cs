using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;       
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using MM.Library.Migrations;

namespace MM.Library

{
    public class MMDomainContext : DbContext
    {
        public MMDomainContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
           
        }
    
        public DbSet<RenterAccount> RenterAccounts { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<PartyType> PartyTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PartyAddresses> PartyAddresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<ContactInfoItem> ContactInfoItems { get; set; }
        public DbSet<PartyContactInfoItems> PartyContactInfoItems { get; set; } 
        public DbSet<ContactInfoType> ContactInfoTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RenterAccount>().HasRequired(p => p.Renter);
            modelBuilder.Entity<Renter>().HasRequired(p => p.Party);
            modelBuilder.Entity<Party>().HasRequired(p => p.PartyType);

        }
        
    }

    public class RenterAccount
    {
        /// <summary>
        /// This is the ID
        /// </summary>
        /// <remarks>Hey baby!</remarks>
        /// <value>int</value>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserID { get; set; }
        public string AccountNumber { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
        public Renter Renter { get; set; }      
    }

    public class Renter
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RenterID { get; set; }  
        public Party Party { get; set; }

    }

    
    public class Transaction
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TransactionID { get; set; }
        [Required]
        public virtual RenterAccount Parent { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        [Required]
        public virtual TransactionType TransactionType { get; set; }

    }

    public class TransactionType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TransactionTypeID { get; set; }
        public string TypeDescription { get; set; }       
    }

    public class Party
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PartyID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public  PartyType PartyType { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public virtual List<ContactInfoItem> ContactItems { get; set; }
     }

    public class PartyType
    {   
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PartyTypeID { get; set; }
         [Display(Name = "Type Party")]
        public string TypeDescription { get; set; }                
    }

    public class Address
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }
        [Required]
        public AddressType AddressType { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string LineThree { get; set; }
        public string CityTown { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }            
    }

    public class PartyAddresses
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PartyAddressID { get; set; }
        [Required]
        public Party Party { get; set; }
        [Required]
        public Address Address { get; set; }
    
    }

    public class AddressType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AddressTypeID { get; set; }
        public string TypeDescription { get; set; }

    }

    public class PartyContactInfoItems
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PartyContactInfoItemID { get; set; }
        [Required]
        public Party Party { get; set; }
        [Required]
        public ContactInfoItem ContactItem { get; set; }

    
    }
    
    public class ContactInfoItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ContactItemID { get; set; }
        public string ContactItemValue { get; set; }
        [Required]
        public virtual ContactInfoType ContactItemType { get; set; }

    }

    public class ContactInfoType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ContactTypeID { get; set; }
        public string TypeDescription { get; set; }
    }


}