namespace SimpleBookCatalog.Components.ReusableComponents
{
    public class CommonMechanics
    {

        public static bool SearchGeneric(object? obj, string search)
        {
            if (obj is not null)
            {
                var properties = obj.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                foreach (var property in properties)
                {
                    var value = property.GetValue(obj, null);
                    string valueStr = Convert.ToString(value) ?? string.Empty;
                    bool result = valueStr.Contains(search, StringComparison.OrdinalIgnoreCase);
                    if (result)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


    }
}
