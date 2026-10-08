using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_USER_USER_GROUP_MAP
{
    public string USER_ID { get; set; } = null!;

    public decimal CFG_USER_GROUP_ID { get; set; }
}
