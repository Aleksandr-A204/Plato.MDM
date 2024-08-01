using System.Runtime.Serialization;

namespace Plato.MDM.Models;

[DataContract]
public partial class MdmDirectoryVersion
{
    [DataMember(Name = "id")]
    public Guid Id { get; }

    [DataMember(Name = "directoryId")]
    public Guid? DirectoryId { get; }

    [DataMember(Name = "dataSourceName")]
    public string DataSourceName { get; set; } = null!;

    [DataMember(Name = "dataSourceDate")]
    public string DataSourceDate { get; set; } = null!;

    [DataMember(Name = "dataSourceUrl")]
    public string DataSourceUrl { get; set; } = null!;

    [DataMember(Name = "version")]
    public string Version { get; set; } = null!;

    [DataMember(Name = "versionDate")]
    public DateOnly VersionDate { get; }

    [DataMember(Name = "versionDescription")]
    public string VersionDescription { get; set; } = null!;

    [DataMember(Name = "tableName")]
    public string? TableName { get; set; }

    [DataMember(Name = "directory")]
    public MdmDirectory? Directory { get; set; }
}
