Imports OpenTK
Imports OpenTK.Graphics
Public Class Form1
    Private nRedByte As Byte
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nRedByte = 0
        AddHandler Application.Idle, AddressOf Me.Application_Idle
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        nRedByte += 1
        GlControl1.Invalidate()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandler Application.Idle, AddressOf Me.Application_Idle
    End Sub

    Private Sub GlControl1_Paint(sender As Object, e As PaintEventArgs) Handles GlControl1.Paint
        Dim glColor = Color.FromArgb(nRedByte, 0, 0)
        GL.ClearColor(glColor)
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.StencilBufferBit)
        GL.ClearDepth(0)
        GlControl1.SwapBuffers()
    End Sub
    Private Sub Application_Idle(sender As Object, e As EventArgs)
        nRedByte += 1
        Invalidate()
    End Sub

End Class
