namespace Utility
{
    public class Projectile
    {
        public double mass { get; set; }
        public Vector position { get; set; }
        public Vector velocity { get; set; }
        public Vector acceleration { get; set; }
        public Projectile(double m, double startX, double startY, double startZ, double velX, double velY, double velZ)
        {
            mass = m;
            position = new Vector(startX, startY, startZ);
            velocity = new Vector(velX, velY, velZ);
            acceleration = new Vector(0, 0, 0);
        }
        public void updatePosition(double dT, Vector force)
        {
            acceleration = force;
            velocity += acceleration * dT;
            position+=velocity * dT;
        }
    }
}
