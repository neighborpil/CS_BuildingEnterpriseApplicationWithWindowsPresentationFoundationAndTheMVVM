using System;
using System.ComponentModel.DataAnnotations;
using CH03_CRM.Domain.Base;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace CH03_CRM.Domain.Domain
{
    public abstract class Person : DomainObject
    {
        /// <summary>
        /// 이름을 get 또는 set 한다
        /// </summary>
        [Required(ErrorMessage = "이름은 null이거나 비어있을 수 없습니다.")]
        [StringLengthValidator(50, ErrorMessage = "The first name length cannot be greater than 50 characters")]
        public string FirstName { get; set; }

        /// <summary>
        /// 성을 get 또는 set 한다
        /// </summary>
        [Required(ErrorMessage = "성은 null이거나 비어있을 수 없습니다.")]
        [StringLengthValidator(50, ErrorMessage = "The last name length cannot be greater than 50 characters")]
        public string LastName { get; set; }


        /// <summary>
        /// 전체 이름을 get한다
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// 제목을 get 또는 set 한다
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 이름을 get 또는 set 한다
        /// </summary>
        [Required(ErrorMessage = "The birthday cannot be null or empty")]
        [RelativeDateTimeValidator(18, DateTimeUnit.Year, 100, DateTimeUnit.Year, 
            ErrorMessage = "The birthdate can't be lower than 18 years")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating where this instance is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}