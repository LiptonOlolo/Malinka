using System;
using System.Linq;

namespace Malinka.Core.Helpers.ChangeProps
{
    public static class ChangeAllProperties
    {
        public static void SetAllProperties<T>(this T source, T newObject)
        {
            if (source == null || newObject == null)
                return;

            var props = source.GetType().GetProperties().OrderBy(x => x.Name);
            var newProps = newObject.GetType().GetProperties().OrderBy(x => x.Name);

            var properties = props.Zip(newProps, (e1, e2) => new { source = e1, target = e2 });

            foreach (var item in properties)
            {
                if (Attribute.IsDefined(item.source, typeof(ChangeIgnoreAttribute)))
                    continue;

                item.source.SetValue(source, item.target.GetValue(newObject));
            }
        }
    }
}
