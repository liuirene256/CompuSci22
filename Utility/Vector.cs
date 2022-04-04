namespace Utility
{
    public struct Vector : IEquatable<Vector>
    {

        public double X { get; set; }
        public double Y { get; set; }   
        public double Z { get; set; }

        public Vector(double x, double y, double z) 
        {
            X = x;
            Y = y;
            Z = z;

        }
        
        public static Vector operator+(Vector v1, Vector v2)
        {
            return new Vector(
                v1.X + v2.X
                , v1.Y + v2.Y
                , v1.Z + v2.Z
                );
        }
        public static Vector operator*(Vector v1, double scalar)
        {
            return new Vector(v1.X * scalar, v1.Y * scalar, v1.Z * scalar);
        }
        public static Vector operator /(Vector v1, double scalar)
        {
            
            if (scalar == 0)
            {
                throw new ArithmeticException("Vector attempted to divide by zero.");
            }
            else
            {
                return v1 * (1 / scalar);
            }
        }
        public static Vector operator*(double scalar, Vector v1)
        {
            return v1 * scalar;
        }
        public static Vector operator-(Vector v1)
        {
            return -1 * v1;
        }
        public static Vector operator-(Vector v1, Vector v2)
        {
            return v1+-v2;
        }
        public static bool operator==(Vector v1, Vector v2)
        {
            return v1.X==v2.X && v1.Y==v2.Y && v1.Z==v2.Z;
           
        }
        public static bool operator!=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }
        public override String ToString()
        {
            return X +"\t" +Y + "\t"+ Z;
        }
        public double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z);
        public Vector UnitVector()
        {
            return new Vector(X/ Magnitude, Y/Magnitude, Z/Magnitude);
        }
        public double DotProduct(Vector v2)
        {
            return this.X * v2.X + this.Y * v2.Y + this.Z * v2.Z;
        }

        public Vector Round()
        {
            Vector v1 = this;
            return new Vector(Math.Round(v1.X,5), Math.Round(v1.Y,5), Math.Round(v1.Z,5));
        } 

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public bool Equals(Vector other)
        {
            return other == this;
        }

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool Equals(object obj)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        {
            if(obj == null)
            {
                return false;
            }
            return obj is Vector && Equals((Vector)obj);
        }
    }
}