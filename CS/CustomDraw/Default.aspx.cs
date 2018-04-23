using System;
using System.Drawing;
using DevExpress.XtraGauges.Core.Primitive;

namespace CustomDraw {
    public partial class _Default : System.Web.UI.Page {
        bool handleCustomDraw;
        protected void Page_Init(object sender, EventArgs e) {
            arcScale.CustomDrawElement += arcScale_CustomDrawElement;
            arcScaleNeedle.CustomDrawElement += arcScaleNeedle_CustomDrawElement;
            arcScaleBackgroundLayer.CustomDrawElement += arcScaleBackgroundLayer_CustomDrawElement;
        }
        protected void Page_Load(object sender, EventArgs e) {
            handleCustomDraw = ASPxCheckBox1.Checked;
            arcScale.Value = (float)value.Number;
        }
        void arcScale_CustomDrawElement(object sender, CustomDrawElementEventArgs e) {
            if(!handleCustomDraw) return;
            e.Handled = true;
        }
        void arcScaleBackgroundLayer_CustomDrawElement(object sender, CustomDrawElementEventArgs e) {
            if(!handleCustomDraw) return;
            RectangleF bounds = RectangleF.Inflate(e.Info.BoundBox, -15, -15);
            e.Context.Graphics.FillEllipse(Brushes.Black, bounds);
            bounds.Inflate(-2, -2);
            e.Context.Graphics.SetClip(new RectangleF(bounds.Left + bounds.Width * 0.5f, bounds.Top, bounds.Width * 0.5f, bounds.Height));
            e.Context.Graphics.FillEllipse(Brushes.White, bounds);
            e.Context.Graphics.ResetClip();
            e.Context.Graphics.FillEllipse(Brushes.White, new RectangleF(
                bounds.Left + bounds.Width * 0.25f, bounds.Top,
                bounds.Width * 0.5f, bounds.Height * 0.5f));
            e.Context.Graphics.FillEllipse(Brushes.Black, new RectangleF(
                bounds.Left + bounds.Width * 0.25f, bounds.Top + bounds.Height * 0.5f,
                bounds.Width * 0.5f, bounds.Height * 0.5f));
            e.Handled = true;
        }
        void arcScaleNeedle_CustomDrawElement(object sender, CustomDrawElementEventArgs e) {
            if(!handleCustomDraw) return;
            e.Context.Graphics.FillEllipse(Brushes.White, new RectangleF(50, 112.5f, 25, 25));
            e.Context.Graphics.FillEllipse(Brushes.Black, new RectangleF(175, 112.5f, 25, 25));
            e.Handled = true;
        }
    }
}