using System.Collections.Generic;
using Emergent_Software_Version_Software_Api.Models;

namespace Emergent_Software_Version_Software_Api.Interfaces
{
    public interface ISoftwareRepository
    {
        IEnumerable<Software> GetAllSoftware(); 
    }
}
