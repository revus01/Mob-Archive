namespace MobArchive
{
    public class SkillManager
    {
        private static SkillManager _instance;

        public static SkillManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SkillManager();
                }
                return _instance;
            }
        }

        public void ExecuteSkill()
        {
            
        }
        
    }
}