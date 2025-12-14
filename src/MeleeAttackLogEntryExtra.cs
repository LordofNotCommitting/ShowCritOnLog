
using MGSC;
using System.Runtime.CompilerServices;

public static class MeleeAttackLogEntryExtra
{
    private class ExtraData
    {
        public bool wasCrit;
    }

    private static readonly ConditionalWeakTable<MeleeAttackLogEntry, ExtraData> data = new ConditionalWeakTable<MeleeAttackLogEntry, ExtraData>();

    public static void SetExtras(this MeleeAttackLogEntry log, bool a)
    {
        var d = data.GetOrCreateValue(log);
        d.wasCrit = a;
    }

    public static bool TryGetExtras(this MeleeAttackLogEntry log, out bool a)
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
