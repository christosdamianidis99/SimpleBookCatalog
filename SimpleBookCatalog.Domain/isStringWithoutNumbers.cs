using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Property)]
public class isStringWithoutNumbers : Attribute
{
    public bool IsStringWithoutNumbers { get; }

    public isStringWithoutNumbers(bool isStringWithoutNumbersBool = true)
    {
        IsStringWithoutNumbers = isStringWithoutNumbersBool;
    }
}
