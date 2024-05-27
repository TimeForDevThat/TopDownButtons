using System;
using System.Collections.Generic;

public class CommmandAttribute : Attribute
{
    public CommmandAttribute() { }
    public CommmandAttribute(params Type[] _ParamsTypes) {
        if(ParamsTypes != null)
            this.ParamsTypes.AddRange(_ParamsTypes);
    }
    public List<Type> ParamsTypes = new List<Type>();
}
