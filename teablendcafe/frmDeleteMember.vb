﻿Imports MySql.Data.MySqlClient
Public Class frmDeleteMember

    Dim Command As New MySqlCommand
    Dim Connect As New MySqlConnection
    Dim str As String

    Public SelectedMember As String


    Private Sub deletemem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Dim reader As MySqlDataReader
        With Command
            .Connection = Connect
            .CommandText = "SELECT password FROM tbladministrators WHERE username = 'admin'"
        End With
        reader = Command.ExecuteReader
        If reader.HasRows Then
            reader.Read()
            If txtPass.Text = reader.Item(0).ToString Then
                reader.Close()

                With Command
                    .Connection = Connect
                    .CommandText = "UPDATE tblcustomers SET status='Inactive' WHERE cus_no = '" & SelectedMember & "'"
                    .ExecuteNonQuery()
                End With
                frmMain.membersDGV()
                MsgBox("Member " + SelectedMember + " successfully voided!", vbOKOnly + vbInformation, "Message")

            End If
        End If
        reader.Close()
        Me.Close()
    End Sub

    Private Sub admispasswordcancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class