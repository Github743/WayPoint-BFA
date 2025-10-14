using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayPoint.Model;

namespace WayPoint_Infrastructure.Interfaces
{
    public interface IVesselRepository
    {
        Task<IReadOnlyList<Vessel>> GetVessels(string clientSearch, CancellationToken ct = default);
    }
}
