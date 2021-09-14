using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

            var inputVersions = Array.ConvertAll(version.Split('.'), int.Parse).ToList();

            foreach (var software in allSoftware)
            {
                var currentSoftwareVersions = Array.ConvertAll(software.Version.Split('.'), int.Parse).ToList();


                if (currentSoftwareVersions.Equals(inputVersions))
                {
                    continue; 
                }

                if (inputVersions.ElementAtOrDefault(0) < currentSoftwareVersions.ElementAtOrDefault(0))
                {
                    filteredSoftware.Add(software);
                }else if (inputVersions.ElementAtOrDefault(0) == currentSoftwareVersions.ElementAtOrDefault(0))
                {
                    if (inputVersions.ElementAtOrDefault(1) < currentSoftwareVersions.ElementAtOrDefault(1))
                    {
                        filteredSoftware.Add(software);
                    }else if (inputVersions.ElementAtOrDefault(1) == currentSoftwareVersions.ElementAtOrDefault(1))
                    {
                        if (inputVersions.ElementAtOrDefault(2) < currentSoftwareVersions.ElementAtOrDefault(2))
                        {
                            filteredSoftware.Add(software);
                        }
                    }
                }
            }

            return filteredSoftware;
        }
    }
}
