
using MGSC;
using System.Runtime.CompilerServices;

public static class RangeAttackLogEntryExtra
{
    private class ExtraData
    {
        public bool wasCrit;
    }

    private static readonly ConditionalWeakTable<RangeAttackLogEntry, ExtraData> data = new ConditionalWeakTable<RangeAttackLogEntry, ExtraData>();

    public static void SetExtras(this RangeAttackLogEntry log, bool a)
    {
        var d = data.GetOrCreateValue(log);
        d.wasCrit = a;
    }

    public static bool TryGetExtras(this RangeAttackLogEntry log, out bool a)
    {
        if (data.TryGetValue(log, out var d))
        {
            a = d.wasCrit;
            return true;
        }
        a = default;
        return false;
    }
}
