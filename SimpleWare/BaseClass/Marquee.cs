using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWare.BaseClass
{
    class Marquee : PictureBox
    {
        int X = 0;
        String DrawText = String.Empty;
        Bitmap OrgBmp = null;
        delegate void SetImage(Image NewImage);

        public void Start(Control Parent, String Text, Point Location, Size RectSize)
        {
            this.Parent = Parent;
            this.DrawText = Text;
            this.Location = Location;
            this.Size = RectSize;
            X = RectSize.Width;
            this.Visible = true;
            this.Image = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            Graphics G = Graphics.FromImage(this.Image);
            G.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);
            G.Dispose();
            OrgBmp = new Bitmap(this.Image);
            Thread T = new Thread(new ThreadStart(DoDraw));
            T.Start();
        }

        public void Stop()
        {
            this.Visible = false;
        }

        void DoDraw()
        {
            while (this.Visible)
            {
                Bitmap CacheBmp = new Bitmap(OrgBmp);
                Graphics G = Graphics.FromImage(CacheBmp);
                G.DrawString(DrawText, new Font("宋体", 11), new SolidBrush(Color.Black), new PointF(X = X-- < 0 ? this.Size.Width : X,0));
                G.Dispose();
                this.Invoke(new SetImage(DoSetImage), new Object[] { CacheBmp });
                Thread.Sleep(50);
            }
        }

        void DoSetImage(Image NewImage)
        {
            this.Image = NewImage;
        }
    }
}
