﻿Imports MySql.Data.MySqlClient
Public Class frmMemberEdit
    Dim SelectedMember As String
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub frmmemberedit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        SelectedMember = frmMain.dgv_members.Item(0, frmMain.dgv_members.CurrentRow.Index).Value


        With Command
            .Connection = Connect
            .CommandText = " UPDATE tblcustomers SET cus_name = '" & tbcusnewname.Text & "' WHERE cus_no = '" & SelectedMember & "'"
            .ExecuteNonQuery()
        End With
        frmMain.membersDGV()
        MsgBox("Member " & SelectedMember & "has successfully been updated!", vbOKOnly + vbInformation, "Message")
        Me.Close()

        frmMembersEditChoices.Hide()

    End Sub


End Class