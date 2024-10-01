namespace MobArchive
{
    public record State;

    public record NormalAttack() : State;

    public record UseSkill() : State;

    public record Reload() : State;
    
    public record Die() : State;


}