using System;
using System.Collections.Generic;

namespace Plato.MDM.Models;

public partial class MdmDirectoryDomain
{
    public Guid Id { get; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MdmDirectory> MdmDirectories { get; set; } = new List<MdmDirectory>();
}
