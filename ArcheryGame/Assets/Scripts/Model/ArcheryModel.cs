using View;

namespace Model
{
    public class ArcheryModel
    {
        public delegate void OnValueChange<T>(int val, Role role);

        public OnValueChange<int> OnRoleHpChange;

        //单例
        private static ArcheryModel Singleton = null;

        private int enemyHp = 0;
        private int playerHp = 0;

        public static ArcheryModel CreateInstance()
        {
            return Singleton ?? (Singleton = new ArcheryModel());
        }

        public int EnemyHp
        {
            get { return enemyHp; }
            set
            {
                enemyHp = value;
                OnRoleHpChange?.Invoke(enemyHp, Role.Enemy);
            }
        }

        public int PlayerHp
        {
            get { return playerHp; }
            set
            {
                playerHp = value;
                OnRoleHpChange?.Invoke(playerHp, Role.Player);
            }
        }
    }
}