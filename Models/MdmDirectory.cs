﻿using System.Runtime.Serialization;

namespace Plato.MDM.Models;

[DataContract]
public partial class MdmDirectory
{
    [DataMember(Name = "id")]
    public Guid Id { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; } = null!;

    [DataMember(Name = "description")]
    public string? Description { get; set; }

    [DataMember(Name = "directoryDomainId")]
    public Guid? DirectoryDomainId { get; set; }

    [DataMember(Name = "directoryLevelId")]
    public Guid? DirectoryLevelId { get; set; }

    [DataMember(Name = "directoryDomain")]
    public MdmDirectoryDomain? DirectoryDomain { get; set; }

    [DataMember(Name = "directoryLevel")]
    public MdmDirectoryLevel? DirectoryLevel { get; set; }

    [DataMember(Name = "mdmDirectoryVersions")]
    public ICollection<MdmDirectoryVersion> MdmDirectoryVersions { get; set; } = new List<MdmDirectoryVersion>();
}
