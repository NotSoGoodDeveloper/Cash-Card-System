﻿Imports MySql.Data.MySqlClient

Public Class frmLogs

    Dim Connect As New MySqlConnection
    Public user As String

    Private Sub frmLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()

        lblUser.Text = "Logs for: " & user
        updateDGV()
    End Sub

    Private Sub updateDGV()

        Dim cmd As New MySqlCommand
        Dim reader As MySqlDataReader
        With cmd
            .Connection = Connect
            .CommandText = "SELECT time, description FROM tbltimeintimeout WHERE user = '" & user & "'"
        End With
        reader = cmd.ExecuteReader
        dgv.Rows.Clear()
        If reader.HasRows Then
            While reader.Read()
                dgv.Rows.Add(reader.Item(0), reader.Item(1))
            End While
        End If

        reader.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class