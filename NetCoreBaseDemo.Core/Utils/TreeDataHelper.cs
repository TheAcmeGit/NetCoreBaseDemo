using NetCoreBaseDemo.DTOEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreBaseDemo.Core.Utils
{
    public static class TreeDataHelper
    {
        public static SysNavMenuDto GetNavMenuTreeData(this IEnumerable<SysNavMenuDto> data, string parentId = "")
        {
            var dic = data.Distinct().ToDictionary(key => key.Id, val => val);
            foreach (var item in dic.Values)
            {
                if (dic.ContainsKey(item.ParentId))
                {
                    dic[item.ParentId].Children.Add(item);
                }
            }
            return dic[parentId];
        }
    }
}
