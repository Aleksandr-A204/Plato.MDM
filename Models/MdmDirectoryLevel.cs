using System.Runtime.Serialization;

namespace Plato.MDM.Models;

[DataContract]
public partial class MdmDirectoryLevel
{
    [DataMember(Name = "id")]
    public Guid Id { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; } = null!;

    [DataMember(Name = "mdmDirectories")]
    public virtual ICollection<MdmDirectory> MdmDirectories { get; set; } = new List<MdmDirectory>();
}
