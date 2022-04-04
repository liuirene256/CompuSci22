namespace ProjectileMotion
{
    using Utility; 
    public partial class ProjectileMotion
    {
        static int mass = 4;
        static int startingVel = 5;
        static double angle = Math.PI / 4;
        static double dT = 0.001;
        static double gravity = -9.8;
        public static void Main()
        {

            Level1();
            //Level2();
            //Level3();
        }
        public static void Level1()
        {
            var w = new World(0, gravity);
            Projectile ball = new Projectile(mass, 0, 0, 0, Math.Acos(angle) * startingVel, 0, Math.Asin(angle) * startingVel);
            (w.projectiles).Add(ball);
            w.spring = false;
            w.k = 0;
            w.simulate(50,dT);
        }
        public static void Level2()
        {
            var w = new World(0.5, gravity);
            Projectile ball = new Projectile(mass, 0, 0, 0, Math.Acos(angle) * startingVel, 0, Math.Asin(angle) * startingVel);
            (w.projectiles).Add(ball);
            w.spring = false;
            w.k = 0;
            w.simulate(50,dT);
        }
        public static void Level3()
        {
            var w = new World(0.5, gravity);
            Projectile ball = new Projectile(mass, -1, 1, -1, 5, -1, 3);
            (w.projectiles).Add(ball);
            w.spring = true;
            w.k = 8;
            w.springLength = 2;
            w.stopAtGround = false;
            w.simulate(50,dT);
        }
        public static void Challenge()
        {

        }
    }

}
