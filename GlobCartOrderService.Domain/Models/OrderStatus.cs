using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Domain.Models
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Sent,
        Delivered,
        Canceled
    }
}
