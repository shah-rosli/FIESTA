using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_USER_DELEGATE_HI
    {
        public decimal CFG_USER_DELEGATE_HIS_ID { get; set; }
        public string CFG_USER_DELEGATE_HIS_USERNAME { get; set; } = null!;
        public string? CFG_USER_DELEGATE_HIS_DELEGATE { get; set; }
        public decimal? CFG_USER_DELEGATE_ID { get; set; }
        public string? USERNAME { get; set; }
        public string? DELEGATEE_USERNAME { get; set; }
        public DateTimeOffset? START_DATETIME { get; set; }
        public DateTimeOffset? END_DATETIME { get; set; }
        public string? ACTIVE { get; set; }
        public DateTimeOffset? INITIATE_DATE { get; set; }
        public string? DELEGATOR_REMARK { get; set; }
        public string? USER_ID { get; set; }
        public string? DELEGATEE_USER_ID { get; set; }
        public string? CFG_USER_DELEGATE_HIS_USER_ID { get; set; }
    }
}
