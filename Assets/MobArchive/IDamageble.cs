namespace MobArchive
{
    public interface IDamageble
    {
        void ApplyDamage(DamageInfo damageInfo);
        bool IsDead();
    }
}