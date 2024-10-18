namespace MobArchive
{
    public interface ICombatable
    {
        void NormalAttack(IDamageble target);
        void UseSkill(IDamageble target);
        void Reload();
        void Die();
    }
}