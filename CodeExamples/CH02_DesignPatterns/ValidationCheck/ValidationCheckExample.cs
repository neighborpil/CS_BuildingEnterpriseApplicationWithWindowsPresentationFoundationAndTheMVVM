using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CH02_DesignPatterns.Model;

namespace CH02_DesignPatterns.ValidationCheck
{
    public abstract class BaseValidator<T>
    {
        /// <summary>
        /// 엔티티의 유효성 여부 판단
        /// </summary>
        /// <param name="entity">엔티티</param>
        /// <returns>엔티티가 유효한 경우 true, 아닐경우 false를 반환</returns>
        public abstract bool IsValid(T entity);

        /// <summary>
        /// 에러를 Get 또는 Set한다.
        /// </summary>
        /// <value>에러</value>
        protected IList<ValidationResult> Errors { get; set; }
    }

    public sealed class EmployeeValidator : BaseValidator<Employee>
    {
        /// <summary>
        /// 엔티티의 유효성 여부 판단
        /// </summary>
        /// <param name="entity">엔티티</param>
        /// <returns>엔티티가 유효한 경우 true, 아닐경우 false를 반환</returns>
        public override bool IsValid(Employee entity)
        {
            var result = true;
            this.Errors = new List<ValidationResult>();
            if (entity.FirstName.Length < 10)
            {
                this.Errors.Add(new ValidationResult("이름은 10자 이상이어야 합니다"));
                result = false;
            }

            if (entity.LastName.Length < 10)
            {
                this.Errors.Add(new ValidationResult("성은 10자 이상이어야 합니다"));
                result = false;
            }

            return result;
        }


    }
}