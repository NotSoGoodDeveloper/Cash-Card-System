﻿Imports MySql.Data.MySqlClient
Public Class frmviewloadtransactions
    Dim Connect As New MySqlConnection

    Private Sub frmviewloadtransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dgvloadtransaction'
        Connect = ConnectionModule.getConnection()

        updateDGV()
    End Sub

    Private Sub updateDGV()

        Dim cmd As New MySqlCommand
        Dim reader As MySqlDataReader
        With cmd
            .Connection = Connect
            .CommandText = "SELECT * FROM tblloadtransactions"
        End With
        reader = cmd.ExecuteReader()
        dgvloadtransaction.Rows.Clear()
        If reader.HasRows Then
            While reader.Read()
                dgvloadtransaction.Rows.Add(reader.Item(0), reader.Item(1), reader.Item(2), reader.Item(3))
            End While
        End If

        reader.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub


End Class