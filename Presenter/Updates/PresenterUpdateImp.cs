using _21110603_Paint.Shapes;
using _21110603_Paint.Utilities;
using _21110603_Paint.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110603_Paint.Presenter.Updates
{
    class PresenterUpdateImp : PresenterUpdate
    {
        ViewPaint viewPaint;

        DataManager dataManager;

        public PresenterUpdateImp(ViewPaint viewPaint)
        {
            this.viewPaint = viewPaint;
            dataManager = DataManager.getInstance();
        }

        public void onClickSelectMode()
        {
            dataManager.offAllShapeSelected();
            viewPaint.refreshDrawing();
            dataManager.currentShape = CurrentShapeStatus.Void;
            viewPaint.setCursor(Cursors.Default);
        }

        public void onClickSelectColor(System.Drawing.Color color, Graphics g)
        {
            dataManager.colorCurrent = color;
            viewPaint.setColor(color);
            foreach (Shape item in dataManager.shapeList)
            {
                if (item.isSelected)
                {
                    item.color = color;
                    viewPaint.setDrawing(item, g);
                }
            }
        }

        public void onClickSelectSize(int size)
        {
            dataManager.lineSize = size;
        }

        public void onClickSelectFill(PictureBox pic, Graphics g)
        {
            dataManager.isFill = !dataManager.isFill;
            if (pic.BackColor.Equals(Color.DarkGray))
                viewPaint.setColor(pic, SystemColors.Control);
            else
                viewPaint.setColor(pic, Color.DarkGray);
        }
    }
}
