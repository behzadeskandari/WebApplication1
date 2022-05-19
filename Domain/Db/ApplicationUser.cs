using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Common;
using Common.Attributes;

namespace Domain.Db
{
    public class ApplicationUser : IdentityUser
    {
        public int? ImageID { get; set; }

        [Display(Name = "نام")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(100, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        public string Family { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(100)]
        public string Province { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(300)]
        //[DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string PostalCode { get; set; }

        [NotMapped]
        [CheckFile(false, 256, "image/jpg,image/jpeg")]
        public IFormFile ProfileImage { get; set; }
        //public string Password { get; set; }

        //public bool IsActive { get; set; }
        //public DateTime Registered { get; set; }

        public virtual ICollection<TblProducts> TblProducts { get; set; }
        public virtual ICollection<TblRaiting> TblRaiting { get; set; }
        public virtual ICollection<TblNoti> TblNoti { get; set; }
        public virtual ICollection<TblNewsLetter> TblNewsLetter { get; set; }
        public virtual ICollection<TblShopingCart> TblShopingCart { get; set; }
        public virtual ICollection<TblBoon> TblBoon { get; set; }
        public virtual ICollection<TblLoginHistory> TblLoginHistory { get; set; }
        public virtual ICollection<TblComments> TblComments { get; set; }
        public virtual ICollection<TblOrders> TblOrders { get; set; }
        public virtual ICollection<TblAsks> TblAsks { get; set; }

        public virtual ICollection<TblFavo> TblFavo { get; set; }

        //[InverseProperty("TblUserAdmin")]
        public virtual ICollection<TblMessages> TblMessagesAdmin { get; set; }
        //[InverseProperty("TblUserClaint")]
        public virtual ICollection<TblMessages> TblMessagesClaint { get; set; }

        public virtual ICollection<TblUserAccess> TblUserAccess { get; set; }

        [ForeignKey(nameof(ImageID))]
        public virtual TblImage TblImageProfile { get; set; }


        //public async Task<IdentityResult> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //  ApplicationUser appuser = new ApplicationUser()
        //  {
        //    Name = Name,
        //    Password = Password,
        //    PasswordHash = PasswordHash,
        //    IsActive = IsActive,
        //    Registered = DateTime.Now,
        //  };
        //  // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //  var userIdentity = await manager.CreateAsync(appuser);
        //  // Add custom user claims here
        //  return userIdentity;
        //}



    }

}
