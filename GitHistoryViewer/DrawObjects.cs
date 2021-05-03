using System.Drawing;

namespace GitHistoryViewer
{
    public class DrawObjects
    {
        private Pen p;
        private Font font1;
        public int x { set ; get; }
        private int y = 200;
        private int width = 50;
        
        public DrawObjects()
        {
            this.x = 10;
            this.p = new Pen(Brushes.Black, 5);
            this.font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel);
        }

        public void drawCommit(Graphics g)
        {
            g.DrawEllipse(p, x,y,width,width);
        }

        public void drawLine(Graphics g)
        {
            g.DrawLine(p, this.x+ (width*2), this.y + (width/2), this.x+width, this.y + (width/2));
        }
        public void drawString(Graphics g, string msg)
        {
            g.DrawString(msg,font1,Brushes.Black, this.x-10,this.y + width +25);
        }

        public void drawBranch(Graphics g, string BranchName)
        {
            RectangleF rectF1 = new RectangleF(x, y-70, 70, 50);
            g.DrawString(BranchName, font1, Brushes.Black, rectF1);
            g.DrawRectangle(Pens.Black, Rectangle.Round(rectF1));
        }

        public void updateX()
        {
            this.x += width*2;
        }
    }
}