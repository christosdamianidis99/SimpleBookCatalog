using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Property)]
public class IsForFormAttribute : Attribute
{
    public bool IsForForm { get; }

    public IsForFormAttribute(bool isForForm = true)
    {
        IsForForm = isForForm;
    }
}
