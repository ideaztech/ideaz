using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Solum.App_Code
{
    public class NewToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            //var btn = e.Item as ToolStripButton;
            //if (btn != null && btn.CheckOnClick && btn.Checked)
            //{
            //    Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
            //    e.Graphics.FillRectangle(Brushes.Olive, bounds);
            //    //Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
            //    //e.Graphics.FillRectangle(Brushes.Transparent, rectangle);
            //    //e.Graphics.DrawRectangle(Pens.Transparent, rectangle);
            //}
            //else base.OnRenderButtonBackground(e);

            if (!e.Item.Selected)
            {
                base.OnRenderButtonBackground(e);
            }
            else
            {
                try
                {
                    Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width, e.Item.Size.Height);
                    e.Graphics.FillRectangle(Brushes.Transparent, rectangle);
                    e.Graphics.DrawRectangle(Pens.Transparent, rectangle);
                    e.Graphics.DrawImage(e.Item.BackgroundImage, rectangle);
                }
                catch { }

            }

        }
        
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }
        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.ToolStrip.LayoutStyle == ToolStripLayoutStyle.VerticalStackWithOverflow)
            {
                Rectangle rect = new Rectangle(0, 0, 75, 12);

                e.Graphics.DrawImage(Properties.Resources.MoreWide, rect);
            }
            else if (e.ToolStrip.LayoutStyle == ToolStripLayoutStyle.HorizontalStackWithOverflow)
            {
                Rectangle rect = new Rectangle(0, 0, 12, 75);

                e.Graphics.DrawImage(Properties.Resources.MoreTall, rect);
            }
            else
            {
                base.OnRenderOverflowButtonBackground(e);
            }


        }

    }
}
