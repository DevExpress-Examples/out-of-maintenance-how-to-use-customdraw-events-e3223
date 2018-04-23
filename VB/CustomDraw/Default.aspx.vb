Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports DevExpress.XtraGauges.Core.Primitive

Namespace CustomDraw
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Private handleCustomDraw As Boolean
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			AddHandler arcScale.CustomDrawElement, AddressOf arcScale_CustomDrawElement
			AddHandler arcScaleNeedle.CustomDrawElement, AddressOf arcScaleNeedle_CustomDrawElement
			AddHandler arcScaleBackgroundLayer.CustomDrawElement, AddressOf arcScaleBackgroundLayer_CustomDrawElement
		End Sub
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			handleCustomDraw = ASPxCheckBox1.Checked
			arcScale.Value = CSng(value.Number)
		End Sub
		Private Sub arcScale_CustomDrawElement(ByVal sender As Object, ByVal e As CustomDrawElementEventArgs)
			If (Not handleCustomDraw) Then
				Return
			End If
			e.Handled = True
		End Sub
		Private Sub arcScaleBackgroundLayer_CustomDrawElement(ByVal sender As Object, ByVal e As CustomDrawElementEventArgs)
			If (Not handleCustomDraw) Then
				Return
			End If
			Dim bounds As RectangleF = RectangleF.Inflate(e.Info.BoundBox, -15, -15)
			e.Context.Graphics.FillEllipse(Brushes.Black, bounds)
			bounds.Inflate(-2, -2)
			e.Context.Graphics.SetClip(New RectangleF(bounds.Left + bounds.Width * 0.5f, bounds.Top, bounds.Width * 0.5f, bounds.Height))
			e.Context.Graphics.FillEllipse(Brushes.White, bounds)
			e.Context.Graphics.ResetClip()
			e.Context.Graphics.FillEllipse(Brushes.White, New RectangleF(bounds.Left + bounds.Width * 0.25f, bounds.Top, bounds.Width * 0.5f, bounds.Height * 0.5f))
			e.Context.Graphics.FillEllipse(Brushes.Black, New RectangleF(bounds.Left + bounds.Width * 0.25f, bounds.Top + bounds.Height * 0.5f, bounds.Width * 0.5f, bounds.Height * 0.5f))
			e.Handled = True
		End Sub
		Private Sub arcScaleNeedle_CustomDrawElement(ByVal sender As Object, ByVal e As CustomDrawElementEventArgs)
			If (Not handleCustomDraw) Then
				Return
			End If
			e.Context.Graphics.FillEllipse(Brushes.White, New RectangleF(50, 112.5f, 25, 25))
			e.Context.Graphics.FillEllipse(Brushes.Black, New RectangleF(175, 112.5f, 25, 25))
			e.Handled = True
		End Sub
	End Class
End Namespace