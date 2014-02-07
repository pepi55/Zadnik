using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class PublicClasses : MonoBehaviour {
	/*--- INTERFACES ---*/
	public interface IHasNeighbours<N> {
		IEnumerable<N> Neighbours {
			get;
		}
	}
	/*--- END INTERFACES ---*/

	/*--- STRUCTS ---*/
	public struct Point {
		public int X, Y;

		public Point (int x, int y) {
			X = x;
			Y = y;
		}
	}
	/*--- END STRUCTS ---*/

	/*--- CLASSES ---*/
	public abstract class GridObject {
		public Point Location;

		public int X {
			get {
				return Location.X;
			}
		}

		public int Y {
			get {
				return Location.Y;
			}
		}

		public GridObject (Point location) {
			Location = location;
		}

		public GridObject (int x, int y) : this(new Point(x, y)) {}

		public override string ToString () {
			return string.Format ("({0}, {1})", X, Y);
		}
	}

/*	public class Tile : GridObject, IHasNeighbours<Tile> {
		public bool passable;

		public Tile (int x, int y) : base(x, y) {
			passable = true;
		}

		public IEnumerable allNeighbours {
			get;
			set;
		}

		public IEnumerable neighbours {
			get {
				return allNeighbours.Where(o => o.passable);
			}
		}
	}*/

	public class Path<N> : IEnumerable<N> {
		public N LastStep {
			get;
			private set;
		}

		public Path<N> PrevSteps {
			get;
			private set;
		}

		public double TotalCost {
			get;
			private set;
		}

		public Path(N start) : this(start, null, 0) {}

		public Path<N> addStep (N step, double stepCost) {
			return new Path<N> (step, this, TotalCost + stepCost);
		}

		public IEnumerator<N> GetEnumerator () {
			for (Path<N> p = this; p != null; p = p.PrevSteps) {
				yield return p.LastStep;
			}
		}

		private Path(N lastStep, Path<N> prevSteps, double totalCost) {
			LastStep = lastStep;
			PrevSteps = prevSteps;
			TotalCost = totalCost;
		}

		IEnumerator IEnumerable.GetEnumerator () {
			return this.GetEnumerator();
		}
	}
	/*--- END CLASSES ---*/
}