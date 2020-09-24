using System;
using System.Collections.Generic;
using System.Text;

namespace xSystem.Core.Helpers
{
    public static class TypeHelper
    {
        public static Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type == null)
            {
                foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
                {
                    type = a.GetType(typeName);
                    if (type != null)
                        return type;
                }
            }
            return type;
        }
    }
}
