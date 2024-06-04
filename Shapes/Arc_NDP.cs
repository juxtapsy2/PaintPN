using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21110603_Paint.Shapes
{
    public class Arc_NDP : Shape
    {
        public List<Point> points;

        public Arc_NDP()
        {
            name = "Curve";
            points = new List<Point>();
        }

        public Arc_NDP(Color color)
        {
            name = "Curve";
            this.color = color;
            points = new List<Point>();
        }

        public override object Clone()
        {
            Arc_NDP curve = new Arc_NDP
            {
                pointHead = pointHead,
                pointTail = pointTail,
                isSelected = isSelected,
                name = name,
                color = color,
                contourWidth = contourWidth
            };
            points.ForEach(point => curve.points.Add(point));
            return curve;
        }

        public override void drawShape(System.Drawing.Graphics g)
        {
            using (GraphicsPath path = graphicsPath)
            {
                using (Pen pen = new Pen(color, contourWidth))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        public override bool isHit(System.Drawing.Point p)
        {
            bool inside = false;
            using (GraphicsPath path = graphicsPath)
            {
                using (Pen pen = new Pen(color, contourWidth+3))
                {
                    inside = path.IsOutlineVisible(p, pen);
                }
            }
            return inside;
        }

        protected override System.Drawing.Drawing2D.GraphicsPath graphicsPath
        {
            get
            {

                GraphicsPath path = new GraphicsPath();
                path.AddCurve(points.ToArray());

                return path;
            }
        }

        public override void moveShape(Point distance)
        {
            base.moveShape(distance);
            for (int i = 0; i < points.Count; i++)
            {
                points[i] = new Point(points[i].X + distance.X, points[i].Y + distance.Y);
            }
        }

        public override int isHitControlsPoint(System.Drawing.Point p)
        {
            for (int i = 0; i < points.Count; i++)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(new Rectangle(points[i].X - 4, points[i].Y - 4, 8, 8));
                if (path.IsVisible(p)) return i;
            }
            return -1;
        }

        public override void moveControlPoint(Point pointCurrent, Point previous, int index)
        {
            int deltaX = pointCurrent.X - previous.X;
            int deltaY = pointCurrent.Y - previous.Y;
            points[index] = new Point(points[index].X + deltaX, points[index].Y + deltaY);

        }
    }
}
