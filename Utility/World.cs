namespace Utility
{
    public class World
    {
        public double gravity { get; set; }
        public double C { get; set; }
        public double time { get; set; }
        public double ground { get; set; }
        public List<Projectile> projectiles { get; set; }
        public Vector force = new Vector(0, 0, 0);
        private bool touchedGround = false;
        public bool spring { get; set; }
        public double k { get; set; }
        public double springLength { get; set; }
        public bool stopAtGround { get; set; }
        public Projectile centerOfMass { get; set; }
        public int first;
        public int second; 
        

        public World(double C, double gravity)
        {
            stopAtGround = true;
            ground = 0;
            this.C = C;
            projectiles = new List<Projectile>();
            this.gravity = gravity;
            time = 0;
            spring = false;
            k = 0;
            springLength = 0;
            first = 0;
            second = 0;
            if(projectiles.Count > 1)
            {
                Vector temp = ((projectiles[0].mass * projectiles[0].position + projectiles[1].mass * projectiles[1].position) / (projectiles[0].mass + projectiles[1].mass));
                centerOfMass = new Projectile(0, temp.X, temp.Y, temp.Z, 0, 0, 0);

            }
            else
            {
                centerOfMass = new Projectile(0, 0, 0, 0, 0, 0, 0);

            }

        }
        public void applyForce(double dT)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                var proj = projectiles[i];
                force = -C * (projectiles[i].velocity).Magnitude * (projectiles[i].velocity).Magnitude * (proj.velocity).UnitVector() / proj.mass;
                force.Z += gravity;
                if (spring)
                {
                    Vector distVec = proj.position;
                    if (i > 0)
                    {
                        distVec -= projectiles[i-1].position;
                    }
                    force += (k/proj.mass * (springLength - distVec.Magnitude) * (distVec.UnitVector()));
                }
                projectiles[i].updatePosition(dT, force);
                if (projectiles[i].position.Z <= ground)
                {
                    touchedGround = true;
                }
                if(projectiles[i].velocity.Magnitude>=1)
                {
                    //using var file = File.CreateText(@"C:\Users\liuir\OneDrive\Documents\Visual Studio 2022\Homeworks\last.txt");

                    //file.WriteLine(time);
                }
            }



        }
        public void incrementTime(double dT)
        {
            this.time += dT; 
        }
        public bool call(double dT)
        {
            incrementTime(dT);
            applyForce(dT);

            Vector pastPos = centerOfMass.position;
            centerOfMass.position = ((projectiles[first].mass * projectiles[first].position + projectiles[second].mass * projectiles[second].position) / (projectiles[first].mass + projectiles[second].mass));
            Vector pastVel = centerOfMass.velocity;
            centerOfMass.velocity = (pastPos - centerOfMass.position) / dT;
            centerOfMass.acceleration = (pastVel - centerOfMass.velocity) / dT;

            if (stopAtGround && touchedGround)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void simulate(double totalTime, double dT) // keeps simulating until projectile touches ground
        {
            //var file = File.CreateText(@"C:\Users\liuir\OneDrive\Documents\Visual Studio 2022\Homeworks\output.txt");

            //file.WriteLine("Time \t x \t y \t z \t Distance \t vx\t vy\t vz\t Speed \t ax\t ay\t az\t Acceleration");

            for (double i =0;i<totalTime;i+=dT)
            {
                /*
                foreach (Projectile proj in projectiles)
                {
                    file.WriteLine(time + "\t" + proj.position + "\t" + proj.position.Magnitude + "\t" + proj.velocity + "\t" + proj.velocity.Magnitude + "\t" + proj.acceleration + "\t" + proj.acceleration.Magnitude);

                }
                */
                call(dT);
                

            }
        }
       

    }
}
