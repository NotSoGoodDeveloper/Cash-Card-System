﻿Public Class frmremainingload

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmMain.dgvorders.Rows.Clear()
        Me.Close()
    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frmremainingload_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class