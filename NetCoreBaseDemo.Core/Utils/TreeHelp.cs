//using OneCard.Core.DataModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace OneCard.Core.Helper
//{
//    public static class TreeHelp
//    {
//        ///// <summary>
//        ///// 列表生成树形节点
//        ///// </summary>
//        ///// <typeparam name="T">集合对象的类型</typeparam>
//        ///// <typeparam name="K">父节点的类型</typeparam>
//        ///// <param name="collection">集合</param>
//        ///// <param name="idSelector">主键ID</param>
//        ///// <param name="parentIdSelector">父节点</param>
//        ///// <param name="rootId">根节点</param>
//        ///// <returns>列表生成树形节点</returns>
//        //public static IEnumerable<TreeItem<T>> GenerateTree<T, K>(
//        //    this IEnumerable<T> collection,
//        //    Func<T, K> idSelector,
//        //    Func<T, K> parentIdSelector,
//        //    K rootId = default(K))
//        //{
//        //    foreach (var c in collection.Where(u =>
//        //    {
//        //        var selector = parentIdSelector(u);
//        //        return (rootId == null && selector == null)
//        //        || (rootId != null && rootId.Equals(selector));
//        //    }))
//        //    {
//        //        yield return new TreeItem<T>
//        //        {
//        //            Item = c,
//        //            Children = collection.GenerateTree(idSelector, parentIdSelector, idSelector(c))
//        //        };
//        //    }
//        //}


//        public static IEnumerable<TreeData> GenerateTree(this IEnumerable<TreeData> ls, string parentId)
//        {

//            Dictionary<string, TreeData> dic = ls.ToDictionary(f => f.Id, f => f);

//            foreach (var item in dic.Values)
//            {
//                if (dic.ContainsKey(item.ParentId))
//                {
//                    if (dic[item.ParentId].children == null) dic[item.ParentId].children = new List<TreeData>();
//                    dic[item.ParentId].children.Add(item);
//                }
//            }
//            var resultData = dic.Values.Where(x => x.ParentId == parentId).ToList();
//            return resultData;
//        }




//        /// <summary>
//        /// 生成菜单树 
//        /// </summary>
//        /// <param name="ls"></param>
//        /// <param name="parentId"></param>
//        /// <returns></returns>
//        public static IEnumerable<LayuiMenu> GenerateMenuTree(this IEnumerable<LayuiMenu> ls, string parentId)
//        {

//            Dictionary<string, LayuiMenu> dic = ls.ToDictionary(f => f.Id, f => f);

//            foreach (var item in dic.Values)
//            {
//                if (dic.ContainsKey(item.ParentId))
//                { 
//                    if (dic[item.ParentId].List == null) dic[item.ParentId].List = new List<LayuiMenu>();
//                    dic[item.ParentId].List.Add(item);
//                }
//            }
//            var resultData = dic.Values.Where(x => x.ParentId == parentId).ToList();
//            return resultData;
//        }
//    }
//}
