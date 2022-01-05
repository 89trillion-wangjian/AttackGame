using View;

namespace Model
{
    public class ArcheryModel
    {
        public delegate void OnValueChange(int val, Role role);

        public OnValueChange OnRoleHpChange;

        //单例
        private static ArcheryModel singleton = null;

        private int enemyHp = 0;
        
        private int playerHp = 0;

        public static ArcheryModel CreateInstance()
        {
            return singleton ?? (singleton = new ArcheryModel());
        }

        public int EnemyHp
        {
            get
            {
                return enemyHp;
            }
            set
            {
                enemyHp = value;
                OnRoleHpChange?.Invoke(enemyHp, Role.Enemy);
            }
        }

        public int PlayerHp
        {
            get
            {
                return playerHp;
            }
            set
            {
                playerHp = value;
                OnRoleHpChange?.Invoke(playerHp, Role.Player);
            }
        }
    }
}