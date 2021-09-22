using System;
using System.Collections.Generic;
using System.Linq;
using Emergent_Software_Version_Software_Api.Interfaces;
using Emergent_Software_Version_Software_Api.Models;

namespace Emergent_Software_Version_Software_Api.Managers
{
    public class SoftwareManager : ISoftwareManager
    {
        private readonly ISoftwareRepository softwareRepository;
        public SoftwareManager(ISoftwareRepository softwareRepository)
        {
            this.softwareRepository = softwareRepository;
        }

        public IEnumerable<Software> GetHigherVersion(string version)
        {
            var filteredSoftware = new List<Software>();
            var allSoftware = softwareRepository.GetAllSoftware();

            var inputVersions = Array.ConvertAll(version.Split('.'), int.Parse);

            foreach (var software in allSoftware)
            {
                var softwareVersion = Array.ConvertAll(software.Version.Split('.'), int.Parse);

                if (IsHigherVersion(softwareVersion, inputVersions))
                {
                    filteredSoftware.Add(software); 
                }
            }

            return filteredSoftware;
        }

        private bool IsHigherVersion(int[] version, int[] comparedVersion)
        {
            if (comparedVersion.ElementAtOrDefault(0) < version.ElementAtOrDefault(0))
            {
                return true; 
            }
            else if (comparedVersion.ElementAtOrDefault(0) == version.ElementAtOrDefault(0))
            {
                if (comparedVersion.ElementAtOrDefault(1) < version.ElementAtOrDefault(1))
                {
                    return true; 
                }
                else if (comparedVersion.ElementAtOrDefault(1) == version.ElementAtOrDefault(1))
                {
                    if (comparedVersion.ElementAtOrDefault(2) < version.ElementAtOrDefault(2))
                    {
                        return true; 
                    }
                }
            }

            return false; 
        }
    }
}
