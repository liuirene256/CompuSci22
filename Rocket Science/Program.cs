namespace RocketScience {
    using Utility;
    public partial class RocketScience
    {
        static int payload = 123136; //kg
        static double goalHeight = 3.5e17;
        static double burnRate = 240; //kg/s
        static double maxForce = 1.2e7;
        static double earthRadius = 6371000;
        static double G = 6.67428e-11; // m^3 / (kg*s^2)
        static double earthMass = 5.9722e24; //kg
        static double dT = 0.01;
        public static void Main()
        {

            Level1();
            //Level2();
            //Level3();
        }
        public static void Level1()
        {
            Vector RocketPos = new Vector(0,0,earthRadius);
            Vector RocketVec = new Vector(0,0,0);
            Vector RocketAccel = new Vector(0,0,0);
            double t = Simulate(100000000, RocketPos, RocketVec, RocketAccel);
            //Console.WriteLine(Optimize(RocketPos, RocketVec, RocketAccel));


        }
        public static double Optimize(Vector initialPos, Vector initialVel, Vector initialAccel)
        {
            double minTime = 3.5 * 10e7;
            double optFuel = 0;
            for (double mass = 1000; mass< 100000000;mass+=100)
            {
                double t = Simulate(mass, initialPos, initialVel, initialAccel);
                if (t==-1)
                {
                    continue;
                }
                else if(t<minTime)
                {
                    minTime = t;
                    optFuel = mass;
                }
            }
            return optFuel;
        }
        public static double Simulate(double fuelAmt, Vector pos, Vector vel, Vector accel)
        {
            double time = 0;
            double mass = payload + fuelAmt;
            while(pos.Z<goalHeight)
            {
                double forceGravity = G * (earthMass * mass) / (pos.Z * pos.Z ); 
                accel.Z = -forceGravity;
                if (fuelAmt-burnRate*dT>=0)
                {
                    accel.Z += maxForce;
                    fuelAmt -= burnRate*dT;
                }
                accel /= mass;
                vel += accel * dT;
                if(vel.Z<0)
                {
                    break;
                }
                pos += vel * dT;
                time += dT;
                mass = payload + fuelAmt;

            }
            if (pos.Z>=goalHeight)
            {
                return time;
            }
            else
            {
                return -1;
            }
        }
    }
}