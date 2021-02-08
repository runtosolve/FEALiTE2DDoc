﻿using CSparse.Double;
using System;
using System.Collections.Generic;
using System.Text;

namespace FEALiTE2D.Loads
{
    /// <summary>
    /// Represent a class for Nodal loads in Global or local coordinates system.
    /// </summary>
    public class NodalLoad : ILoad
    {
        /// <summary>
        /// Creates a new class of <see cref="NodalLoad"/>.
        /// </summary>
        public NodalLoad()
        {
        }

        /// <summary>
        /// Creates a new class of <see cref="NodalLoad"/>
        /// </summary>
        /// <param name="Fx">force parallel to Global X direction.</param>
        /// <param name="Fy">force parallel to Global Y direction.</param>
        /// <param name="Mz">Moment parallel to Global Z direction.</param>
        /// <param name="direction">load direction.</param>
        /// <param name="loadCase">load case.</param>
        public NodalLoad(double fx, double fy, double mz, LoadDirection direction, LoadCase loadCase)
            : this()
        {
            this.Fx = fx;
            this.Fy = fy;
            this.Mz = mz;
            this.LoadCase = loadCase;
        }


        /// <summary>
        /// Force in X-Direction.
        /// </summary>
        public double Fx { get; set; }

        /// <summary>
        /// Force in Y-Direction.
        /// </summary>
        public double Fy { get; set; }

        /// <summary>
        /// Moment in Z-Direction.
        /// </summary>
        public double  Mz { get; set; }

        public LoadDirection LoadDirection { get; set; }

        public LoadType LoadType => LoadType.NodalForces;

        public LoadCase LoadCase { get; set; }

        public double[] GetGlobalFixedEndForces()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (obj.GetType() != typeof(NodalLoad))
            {
                return false;
            }
            NodalLoad nl = obj as NodalLoad;
            if (Fx != nl.Fx || Fy != nl.Fy  || Mz != nl.Mz || LoadCase != nl.LoadCase)
            {
                return false;
            }
            return true;
        }

        public static bool operator ==(NodalLoad nl1, NodalLoad nl2)
        {
            if (nl1 is null)
            {
                return false;
            }
            return nl1.Equals(nl2);
        }

        public static bool operator !=(NodalLoad nl1, NodalLoad nl2)
        {
            if (ReferenceEquals(nl1, null))
            {
                return false;
            }
            return !nl1.Equals(nl2);
        }

        public override int GetHashCode()
        {
            int result = 0;
            result += (Fx + 1e-10).GetHashCode();
            result += (Fy + 2e-10).GetHashCode();
            result += (Mz + 6e-10).GetHashCode();
            result += LoadCase.GetHashCode();
            return result;
        }
    }
}
