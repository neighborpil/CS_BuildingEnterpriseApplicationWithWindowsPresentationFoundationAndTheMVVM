using System;
using System.ComponentModel.DataAnnotations;

namespace CH03_CRM.Domain.Base
{
    /// <summary>
    /// 기본 도메인 객체
    /// </summary>
    public abstract class DomainObject
    {
        /// <summary>
        /// Primary key를 get 또는 set 한다
        /// </summary>
        [Required(ErrorMessage = "Primary Key는 null이거나 비어있을 수 없습니다.")]
        public Guid PrimaryKey { get; set; }
    }
}