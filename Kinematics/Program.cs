namespace Kinematics
{
    public partial class Kinematics
    {
        static int startingVel = 5;
        static decimal gravity = -9.8m;
        static decimal dT = 0.1m;
        static decimal C = 0.5m;
        static int mass = 4;
        public static void Main()
        {
            CalcPos();
            posAccel();
            posResist2();
            spring();
        }
        public static void CalcPos()
        {
            decimal pos = 0;
            decimal vel = startingVel;
            Console.WriteLine("Time(s) \t Position(m) \t Velocity(m / s)");
            for (decimal t = 0; t <= 100; t+=dT)
            {
                Console.WriteLine(t +"\t" +pos + "\t"+vel);
                pos += vel * dT;
            }
        }
        public static void posAccel()
        {
            decimal pos = 0;
            decimal vel = startingVel;
            Console.WriteLine("Time(s) \t Position(m) \t Velocity(m / s) \t Acceleration (m / s^2)");
            for (decimal t = 0; t <= 100; t += dT)
            {
                Console.WriteLine(t + "\t" + pos + "\t" + vel + "\t" + gravity);

                vel += gravity * dT;
                pos += vel * dT;
            }
        }
        public static void posResist2()
        {
            decimal airResistance = (C / mass) * startingVel * startingVel;
            decimal pos = 0;
            decimal vel = startingVel;
            decimal newAccel = gravity + airResistance;
            Console.WriteLine("Time(s) \t Position(m) \t Velocity(m / s) \t Acceleration (m / s^2)");
            for (decimal t = 0; t <= 100; t += 0.1m)
            {
                Console.WriteLine(t + "\t" + pos + "\t" + vel + "\t" + newAccel);

                newAccel = gravity + airResistance;
                vel += newAccel * dT;
                pos += vel * dT;
                airResistance = (C / mass) * vel * vel;
            }
        }
        
        public static void spring()
        {
            decimal displacement = 1;
            decimal airResistance = (C /mass) * startingVel * startingVel;
            decimal newAccel = gravity + airResistance;
            decimal vel = startingVel;
            Console.WriteLine("Time(s) \t Position(m) \t Velocity(m / s) \t Acceleration (m / s^2)");
            for (decimal t = 0; t <= 100; t += 0.1m)
            {
                Console.WriteLine(t + "\t" + (2- displacement) + "\t" + vel + "\t" + newAccel);

                newAccel = gravity + airResistance;
                vel += newAccel * dT;                                                                                                                                                                                                                                                  
                displacement = (newAccel * mass / -8);
                airResistance = (C/mass ) * vel * vel;
            }
        }
    }
}