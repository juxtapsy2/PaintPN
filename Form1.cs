using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using _21110603_Paint.View;
using _21110603_Paint.Shapes;
using _21110603_Paint.Utilities;
using _21110603_Paint.Presenter;
using _21110603_Paint.Presenter.Alter;
using _21110603_Paint.Presenter.Updates;
using _21110603_Paint.Presenter.Draws;

namespace _21110603_Paint
{
    public partial class formPaint : Form, ViewPaint
    {
        public Color color;
        int size;
        private PresenterDraw presenterDraw;

        private PresenterAlter presenterAlter;

        private PresenterUpdate presenterUpdate;

        private Graphics gr;
        public formPaint()
        {
            InitializeComponent();
            this.Board_PB.SetDoubleBuffered();
            color = Color.Black;
            picCurColor.BackgroundImage = picBlack.BackgroundImage;
            size = 4;
            trackbarSize.Value = size;
            initComponents();
            gr = Board_PB.CreateGraphics();
        }
        private void formPaint_Load(object sender, EventArgs e)
        {

        }

        private void initComponents()
        {
            presenterDraw = new PresenterDrawImp(this);
            presenterAlter = new PresenterAlterImp(this);
            presenterUpdate = new PresenterUpdateImp(this);
            presenterUpdate.onClickSelectColor(picCurColor.BackColor, gr);
            presenterUpdate.onClickSelectSize(trackbarSize.Value + 1);
        }
        void Board_PB_MouseDown(object sender, MouseEventArgs e)
        {
            presenterDraw.onClickMouseDown(e.Location);
        }
        void Board_PB_MouseMove(object sender, MouseEventArgs e)
        {
            presenterDraw.onClickMouseMove(e.Location);
        }
        void Board_PB_MouseUp(object sender, MouseEventArgs e)
        {
            presenterDraw.onClickMouseUp();
        }
        public void setCursor(System.Windows.Forms.Cursor cursor)
        {
            Board_PB.Cursor = cursor;
        }
        public void setDrawingLineSelected(Shape shape, Brush brush, Graphics g)
        {
            g.FillRectangle(brush, new System.Drawing.Rectangle(shape.pointHead.X - 4, shape.pointHead.Y - 4, 8, 8));
            g.FillRectangle(brush, new System.Drawing.Rectangle(shape.pointTail.X - 4, shape.pointTail.Y - 4, 8, 8));
        }
        public void refreshDrawing()
        {
            Board_PB.Invalidate();
        }
        private void Board_PB_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            presenterDraw.getDrawing(e.Graphics);
        }
        public void setDrawing(Shape shape, Graphics g)
        {
            shape.drawShape(g);
        }
        public void setDrawingRegionRectangle(Pen p, Rectangle rectangle, Graphics g)
        {
            g.DrawRectangle(p, rectangle);
        }
        public void movingShape(Shape shape, Point distance)
        {
            shape.moveShape(distance);
            refreshDrawing();
        }
        public void movingControlPoint(Shape shape, Point pointCurrent, Point previous, int indexPoint)
        {
            shape.moveControlPoint(pointCurrent, previous, indexPoint);
            refreshDrawing();
        }
        private void trackbarSize_Scroll(object sender, EventArgs e)
        {
            presenterUpdate.onClickSelectSize(trackbarSize.Value + 1);
        }

        private void picLine_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawLine();
        }

        private void picRectangle_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawRectangle();
        }

        private void picEllipse_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawEllipse();
        }

        private void picPolygon_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawPolygon();
        }

        public void setDrawingCurveSelected(List<Point> points, Brush brush, Graphics g)
        {
            for (int i = 0; i < points.Count; ++i)
            {
                g.FillRectangle(brush, new System.Drawing.Rectangle(points[i].X - 4, points[i].Y - 4, 8, 8));
            }
        }
        private void picArc_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawBezier();
        }

        private void picSelect_Click(object sender, EventArgs e)
        {
            presenterUpdate.onClickSelectMode();
        }

        private void picGroup_Click(object sender, EventArgs e)
        {
            presenterAlter.onClickDrawGroup();
        }
        private void picUngroup_Click(object sender, EventArgs e)
        {
            presenterAlter.onClickDrawUnGroup();
        }
        private void picClear_Click(object sender, EventArgs e)
        {
            presenterAlter.onClickDeleteShape();
        }

        private void picFill_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            presenterUpdate.onClickSelectFill(pic, gr);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenterAlter.onClickSaveImage(Board_PB);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenterAlter.onClickOpenImage(Board_PB);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenterAlter.onClickNewImage(Board_PB);
        }
        public void setColor(PictureBox pic, Color color)
        {
            pic.BackColor = color;
        }
        public void setColor(Color color)
        {
            picCurColor.BackColor = color;
        }
        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            PictureBox ptb = sender as PictureBox;
            picCurColor.BackColor = ptb.BackColor;
            presenterUpdate.onClickSelectColor(ptb.BackColor, gr);
        }
        private void formPaint_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            presenterDraw.getDrawing(e.Graphics);
        }

        private void picPencil_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawPen();
        }

        private void picPen_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawPen();
        }

        private void picEraser_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawEraser();
        }

        private void Board_PB_MouseClick(object sender, MouseEventArgs e)
        {
            presenterDraw.onClickStopDrawing(e.Button);
        }
    }
}
