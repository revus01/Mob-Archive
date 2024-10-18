namespace MobArchive
{
    public enum AttackType
    {
        None,
        Explosion,
        Penetration,
        Mystical,
    }
    public class DamageInfo
    {
        public int Value;
        public AttackType Type;

        public DamageInfo(int damage, AttackType attackType)
        {
            Value = damage;
            Type = attackType;
        }
    }
}