using System;

namespace DMS.Core.Models
{
    public class Info
    {
        public string Architecture { get; set; }
        public string ClusterStore { get; set; }
        public string CgroupDriver { get; set; }
        public int Containers { get; set; }
        public int ContainersRunning { get; set; }
        public int ContainersStopped { get; set; }
        public int ContainersPaused { get; set; }
        public bool CpuCfsPeriod { get; set; }
        public bool CpuCfsQuota { get; set; }
        public bool Debug { get; set; }
        public string DockerRootDir { get; set; }
        public string Driver { get; set; }
        public string[][] DriverStatus { get; set; }
        public string ExecutionDriver { get; set; }
        public bool ExperimentalBuild { get; set; }
        public string HttpProxy { get; set; }
        public string HttpsProxy { get; set; }
        public string ID { get; set; }
        public bool IPv4Forwarding { get; set; }
        public int Images { get; set; }
        public string IndexServerAddress { get; set; }
        public string InitPath { get; set; }
        public string InitSha1 { get; set; }
        public bool KernelMemory { get; set; }
        public string KernelVersion { get; set; }
        public string[] Labels { get; set; }
        public long MemTotal { get; set; }
        public bool MemoryLimit { get; set; }
        public int NCPU { get; set; }
        public int NEventsListener { get; set; }
        public int NFd { get; set; }
        public int NGoroutines { get; set; }
        public string Name { get; set; }
        public string NoProxy { get; set; }
        public bool OomKillDisable { get; set; }
        public string OSType { get; set; }
        public string OperatingSystem { get; set; }
        public Plugins Plugins { get; set; }
        public Registryconfig RegistryConfig { get; set; }
        public string ServerVersion { get; set; }
        public bool SwapLimit { get; set; }
        public string[][] SystemStatus { get; set; }
        public string SystemTime { get; set; }
    }

    public class Plugins
    {
        public string[] Volume { get; set; }
        public string[] Network { get; set; }
    }

    public class Registryconfig
    {
        public Indexconfigs IndexConfigs { get; set; }
        public string[] InsecureRegistryCIDRs { get; set; }
    }

    public class Indexconfigs
    {
        public DockerIo dockerio { get; set; }
    }

    public class DockerIo
    {
        public object Mirrors { get; set; }
        public string Name { get; set; }
        public bool Official { get; set; }
        public bool Secure { get; set; }
    }
}
