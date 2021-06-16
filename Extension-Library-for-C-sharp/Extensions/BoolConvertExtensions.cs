namespace Hinzberg.Extensions.Bool
{
    public static partial class Bool
    {
        public static bool TryValue(this bool? selfBool)
        {
            if (selfBool == null)
                return false;

            return selfBool.Value;
        }
    }
}
