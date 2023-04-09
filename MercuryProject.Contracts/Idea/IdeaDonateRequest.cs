using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Contracts.Idea
{
    public record IdeaDonateRequest(string Id, decimal Donate);
}
