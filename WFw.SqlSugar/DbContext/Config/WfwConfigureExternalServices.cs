using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace WFw.SqlSugar.DbContext.Config
{
    internal class WFwEntityColumnInfoCache
    {
        readonly Dictionary<string, WFwEntityColumnInfoCacheItem> items = new Dictionary<string, WFwEntityColumnInfoCacheItem>();


        internal WFwEntityColumnInfoCacheItem GetOrCreate(PropertyInfo property)
        {
            string key = $"{property.ReflectedType.Name}-{property.Name}";

            if (items.ContainsKey(key))
            {
                return items[key];
            }
            var item = new WFwEntityColumnInfoCacheItem(property);
            items.Add(key, item);
            return item;
        }

    }

    internal class WFwEntityColumnInfoCacheItem
    {
        public bool IsEmpty { get; set; } = true;
        public bool IsIgnore { get; }
        public bool IsPrimarykey { get; }
        public bool IsNullable { get; } = true;
        public bool IsIdentity { get; }
        public string DbColumnName { get; }
        public string DataType { get; }
        public int DecimalDigits { get; }
        public int Length { get; }

        public WFwEntityColumnInfoCacheItem(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(true);

            foreach (var a in attributes)
            {
                if (a is NotMappedAttribute)
                {
                    IsEmpty = false;
                    IsIgnore = true;
                    return;
                }

                if (a is ColumnAttribute ca)
                {
                    IsEmpty = false;
                    DbColumnName = ca.Name;
                    if (!string.IsNullOrWhiteSpace(ca.TypeName))
                    {
                        if (property.PropertyType.Name == "Decimal")
                        {
                            var tmp = ca.TypeName.Substring(8, ca.TypeName.Length - 9).Split(',');
                            if (int.TryParse(tmp[0], out int length))
                            {
                                Length = length;
                            }
                            if (int.TryParse(tmp[1], out int d))
                            {
                                DecimalDigits = d;
                            }
                        }
                        else
                        {
                            DataType = ca.TypeName;
                        }
                    }
                }
                if (a is KeyAttribute)
                {
                    IsEmpty = false;
                    IsPrimarykey = true;
                    IsNullable = false;
                 
                    continue;
                }
                if (a is DatabaseGeneratedAttribute dga)
                {
                    IsEmpty = false;
                    switch (dga.DatabaseGeneratedOption)
                    {
                        case DatabaseGeneratedOption.None: break;
                        case DatabaseGeneratedOption.Identity:
                            IsIdentity = true;
                            break;
                        case DatabaseGeneratedOption.Computed:
                            IsIdentity = true;
                            break;
                    }
                    //if(dga.DatabaseGeneratedOption== )
                    //
                    //IsIdentity = true;
                }

                if (a is RequiredAttribute)
                {
                    IsEmpty = false;
                    IsNullable = false;
                }
                else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    // If it is NULLABLE, then get the underlying type. eg if "Nullable<int>" then this will return just "int"
                    IsEmpty = false;
                    IsNullable = true;
                }
                //Comment
                //if(property.)
            }
        }
    }




    internal class WfwConfigureExternalServices : ConfigureExternalServices
    {
        readonly WFwEntityColumnInfoCache columnInfoCache = new WFwEntityColumnInfoCache();
        readonly WFw.DbContext.DbOptions options;
        public WfwConfigureExternalServices(WFw.DbContext.DbOptions dbOptions)
        {
            options = dbOptions;

            EntityService = HandleEntityColumn;
            EntityNameService = HandleEntity;
        }


        private void HandleEntityColumn(PropertyInfo property, EntityColumnInfo column)
        {
            if (column.IsIgnore)
            {
                return;
            }

            var co = columnInfoCache.GetOrCreate(property);
            if (co.IsEmpty)
            {
                return;
            }
            if (co.IsIgnore)
            {
                column.IsIgnore = true;
                return;
            }
            column.IsNullable = co.IsNullable;
            if (string.IsNullOrWhiteSpace(column.DbColumnName))
            {
                column.DbColumnName = co.DbColumnName;
            }
            if (string.IsNullOrWhiteSpace(column.DataType))
            {
                column.DataType = co.DataType;
            }
            if (!column.IsPrimarykey)
            {
                column.IsPrimarykey = co.IsPrimarykey;
            }
            if (!column.IsIdentity)
            {
                column.IsIdentity = co.IsIdentity;
            }
            if (column.DecimalDigits == 0)
            {
                column.DecimalDigits = co.DecimalDigits;
            }
            if (column.Length == 0)
            {
                column.Length = co.Length;
            }
        }

        private void HandleEntity(Type type, EntityInfo entity)
        {
            var attributes = type.GetCustomAttributes(true);
            if (attributes.Any(it => it is TableAttribute))
            {
                entity.DbTableName = (attributes.First(it => it is TableAttribute) as TableAttribute).Name;
            }
        }
    }
}
