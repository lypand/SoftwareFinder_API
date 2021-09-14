using System.Collections.Generic;
using Emergent_Software_Version_Software_Api.Models;

namespace Emergent_Software_Version_Software_Api.Interfaces
{
    public interface ISoftwareManager
    {
        IEnumerable<Software> GetHigherVersion(string version); 
    }
}
