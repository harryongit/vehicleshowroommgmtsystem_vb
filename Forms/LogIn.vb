﻿Imports System.Data.OleDb

Public Class LogIn

    Dim con As New OleDbConnection
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If ask() = True Then
            Main_Form.Show()
            Me.Hide()

        Else
            MessageBox.Show("Invalid Username or Password!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LogIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Downloads\CAR_RENTAL_SYSTEM_IN_VB.NET_WITH_SOURCE_CODE\Car Rental System VB.NET\CarRentalSystem\FinalCarRentalSystem\CarRentalSystem1.mdb"

    End Sub
    Public Function ask()

        Dim dt As New DataTable
        Dim ds As New DataSet
        ds.Tables.Add(dt)
        con.Open()
        Dim da As New OleDbDataAdapter("select * from Admin", con)
        da.Fill(dt)

        For Each datarow In dt.Rows

            If UsernameTextBox.Text = datarow.item(1) And PasswordTextBox.Text = datarow(2) Then
                con.Close()
                Return True
            End If
        Next

        con.Close()
        Return False

    End Function


End Class
