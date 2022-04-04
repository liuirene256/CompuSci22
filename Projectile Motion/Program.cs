//namespace ProjectileMotion
//{
//    using Utility;
//    public partial class ProjectileMotion
//    {
//        static int mass = 4;
//        static int startingVel = 5;
//        static double angle = Math.PI / 4;
//        static double dT = 0.001;
//        static double gravity = -9.8;

//        public static void Main()
//        {
           
//            Level1();
//            // Level2();
//            //Lvl3();
//        }

//        public static void solve(double C)
//        {
//            var pos = new Vector(0, 0, 0);
//            var vel = new Vector(Math.Acos(angle) * startingVel, 0, Math.Asin(angle) * startingVel);
//            var accel = new Vector(0, 0, gravity);
//            using var file = File.CreateText(@"C:\Users\liuir\OneDrive\Documents\Visual Studio 2022\Homeworks\output.txt");

//            file.WriteLine("Time \t x \t y \t z \t Distance \t vx\t vy\t vz\t Speed \t ax\t ay\t az\t Acceleration");
//            double time = 0;
//            while (pos.Z >= 0)
//            {
//                file.WriteLine(time + "\t" + pos + "\t" + vel + "\t" + accel);

//                accel = -C / mass * vel.Magnitude * vel.UnitVector();
//                accel.Z += gravity;


//                vel += accel * dT;

//                pos += vel * dT;
                
//                time += dT;

//            }

//            file.WriteLine(time + "\t" + pos + "\t" + vel + "\t" + accel);
//        }
//        public static void Lvl3()
//        {
//            int dist = 2;
//            var pos = new Vector(0, 0, 0);
//            var vel = new Vector(Math.Acos(angle) * startingVel, 0, Math.Asin(angle) * startingVel);
//            var accel = new Vector(0, 0, gravity);
//            var spring = new Vector(0, 0, 0);
//            double C = 0.5;
//            double k = 8;
//            double force = 0;
//            using var file = File.CreateText(@"C:\Users\liuir\OneDrive\Documents\Visual Studio 2022\Homeworks\output.txt");
//            file.WriteLine("Time \t x \t y \t z \t Distance \t vx\t vy\t vz\t Speed\t ax\t ay\t az\t Acceleration");

//            for (double time = 0; time <= 20; time += dT)
//            {

//                force = k * (dist - pos.Magnitude);
//                spring = pos / pos.Magnitude;

//                file.WriteLine(time + "\t" + pos + "\t" + vel + "\t" + accel);

//                accel = (force * spring / mass )+ -C / mass * vel.Magnitude * vel.UnitVector();
//                accel.Z += gravity;

//                vel += accel * dT;

//                pos += vel * dT;

//                time += dT;

                
//            }
//        }
        
       

//        public static void Level1()
//        {
//            solve(0); //no airresistance
//        }
//        public static void Level2()
//        {
//            solve(0.5);
//        }
//        //public static void Level3()
//        //{
//        //    int dist = 2;
//        //    double[] pos = { -1, 1, -1, Math.Sqrt(3) }; //posX, posY, posZ, posMag
//        //    double[] spring = { pos[0] * dist / pos[3], pos[1] * dist / pos[3], pos[2] * dist / pos[3] };
//        //    double[] vel = { 5, -1, 3, Math.Sqrt(5 * 5 + 1 + 3 * 3) };
//        //    double[] accel = { 0, 0, gravity, Math.Sqrt(gravity * gravity) };
//        //    double C = 0.5;
//        //    double k = 8;
//        //    double force = 0;
//        //    using var file = File.CreateText(@"C:\Users\liuir\OneDrive\Documents\Visual Studio 2022\Homeworks\output.txt");
//        //    file.WriteLine("Time \t x \t y \t z \t Distance \t vx\t vy\t vz\t Speed\t ax\t ay\t az\t Acceleration");

//        //    for (double time = 0; time <= 20; time += dT)
//        //    {
//        //        file.Write(time);
//        //        for (int i = 0; i < 4; i++)
//        //        {
//        //            file.Write("\t" + pos[i]);
//        //        }
//        //        for (int i = 0; i < 4; i++)
//        //        {
//        //            file.Write("\t" + vel[i]);
//        //        }
//        //        for (int i = 0; i < 4; i++)
//        //        {
//        //            file.Write("\t" + accel[i]);
//        //        }
//        //        file.WriteLine();
//        //        force = k * (dist - pos[3]);
//        //        spring[0] = pos[0] / pos[3];
//        //        spring[1] = pos[1] / pos[3];
//        //        spring[2] = pos[2] / pos[3];

//        //        accel[0] = force *(spring[0])/ mass - (C / mass) * vel[3] * vel[3] * vel[0] / vel[3]; //spring accel + airresist
//        //        accel[1] = force *(spring[1]) / mass - (C / mass) * vel[3] * vel[3] * vel[1] / vel[3];
//        //        accel[2] = force * (spring[2]) / mass - (C / mass) * vel[3] * vel[3] * vel[2] / vel[3] + gravity;
//        //        accel[3] = Math.Sqrt(accel[0] * accel[0] + accel[1] * accel[1] + accel[2] * accel[2]);

//        //        vel[0] += accel[0] * dT;
//        //        vel[1] += accel[1] * dT;
//        //        vel[2] += accel[2] * dT;
//        //        vel[3] = Math.Sqrt(vel[0] * vel[0] + vel[1] * vel[1] + vel[2] * vel[2]);

//        //        pos[0] += vel[0] * dT;
//        //        pos[1] += vel[1] * dT;
//        //        pos[2] += vel[2] * dT;
//        //        pos[3] = Math.Sqrt(pos[0] * pos[0] + pos[1] * pos[1] + pos[2] * pos[2]);
//        //    }
//        //}
//        //public static void solve2(double C)
//        //{
//        //    double[] pos = { 0, 0, 0, 0 }; //posX, posY, posZ, posMag
//        //    double[] vel = { Math.Acos(angle) * startingVel, 0, Math.Asin(angle) * startingVel, startingVel };
//        //    double[] accel = { 0, 0, gravity, Math.Sqrt(gravity * gravity) };
//        //    using var file = File.CreateText(@"C:\Users\liuir\OneDrive\Documents\Visual Studio 2022\Homeworks\output.txt");

//        //    file.WriteLine("Time \t x \t y \t z \t Distance \t vx\t vy\t vz\t Speed \t ax\t ay\t az\t Acceleration");
//        //    double time = 0;
//        //    while (pos[2] >= 0)
//        //    {
//        //        file.Write(time);
//        //        for (int i = 0; i < 4; i++)
//        //        {
//        //            file.Write("\t" + pos[i]);
//        //        }
//        //        for (int i = 0; i < 4; i++)
//        //        {
//        //            file.Write("\t" + vel[i]);
//        //        }
//        //        for (int i = 0; i < 4; i++)
//        //        {
//        //            file.Write("\t" + accel[i]);
//        //        }
//        //        file.WriteLine();

//        //        accel[0] = -(C / mass) * vel[3] * vel[3] * vel[0] / vel[3]; //air resistance is opp of direction of velocity
//        //        accel[1] = -(C / mass) * vel[3] * vel[3] * vel[1] / vel[3];
//        //        accel[2] = (-(C / mass) * vel[3] * vel[3] * vel[2] / vel[3]) + gravity; //gravity only for z direction
//        //        accel[3] = Math.Sqrt(accel[0] * accel[0] + accel[1] * accel[1] + accel[2] * accel[2]);

//        //        vel[0] += accel[0] * dT;
//        //        vel[1] += accel[1] * dT;
//        //        vel[2] += accel[2] * dT;
//        //        vel[3] = Math.Sqrt(vel[0] * vel[0] + vel[1] * vel[1] + vel[2] * vel[2]);

//        //        pos[0] += vel[0] * dT;
//        //        pos[1] += vel[1] * dT;
//        //        pos[2] += vel[2] * dT;
//        //        pos[3] = Math.Sqrt(pos[0] * pos[0] + pos[1] * pos[1] + pos[2] * pos[2]);
//        //        time += dT;

//        //    }
//        //    file.Write(time);
//        //    for (int i = 0; i < 4; i++)
//        //    {
//        //        file.Write("\t" + pos[i]);
//        //    }
//        //    for (int i = 0; i < 4; i++)
//        //    {
//        //        file.Write("\t" + vel[i]);
//        //    }
//        //    for (int i = 0; i < 4; i++)
//        //    {
//        //        file.Write("\t" + accel[i]);
//        //    }
//        //    file.WriteLine();
//        // }
        
//    }
//}

