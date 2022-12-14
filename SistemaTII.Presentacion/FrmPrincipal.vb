Imports System.Windows.Forms

Public Class FrmPrincipal
    Private _IdUsuario As String
    Private _IdRol As String
    Private _Rol As String
    Private _Nombre As String
    Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripButton.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Public Property IdUsuario As String
        Get
            Return _IdUsuario
        End Get
        Set(value As String)
            _IdUsuario = value
        End Set
    End Property

    Public Property IdRol As String
        Get
            Return _IdRol
        End Get
        Set(value As String)
            _IdRol = value
        End Set
    End Property

    Public Property Rol As String
        Get
            Return _Rol
        End Get
        Set(value As String)
            _Rol = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Private Sub CategoriasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriasToolStripMenuItem.Click
        Dim frm As New FrmCategoria
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArtículosToolStripMenuItem.Click
        Dim frm As New FrmArticulo
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RolesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RolesToolStripMenuItem.Click
        Dim frm As New FrmRol
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.Click
        Dim frm As New FrmUsuario
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TsBarrainferior.Text = "Usuario:" & Me.Nombre
        MsgBox("Bienvenido " & Nombre, vbOKOnly + vbInformation, "Bienvenido al Sistema")
        If (Me.Rol = "Superadmin") Then
            MnuAlmacen.Enabled = True
            MnuIngresos.Enabled = True
            MnuVentas.Enabled = True
            MnuAcceso.Enabled = True
            MnuConsultas.Enabled = True
            MnuBackup.Enabled = True
        ElseIf (Me.Rol = "Administrador") Then
            MnuAlmacen.Enabled = True
            MnuIngresos.Enabled = True
            MnuVentas.Enabled = True
            MnuAcceso.Enabled = True
            MnuConsultas.Enabled = True
            MnuBackup.Enabled = True
        ElseIf (Me.Rol = "Almacenero") Then
            MnuAlmacen.Enabled = False
            MnuIngresos.Enabled = True
            MnuVentas.Enabled = False
            MnuAcceso.Enabled = False
            MnuConsultas.Enabled = False
            MnuBackup.Enabled = False
        ElseIf (Me.Rol = "Vendedor") Then
            MnuAlmacen.Enabled = False
            MnuIngresos.Enabled = False
            MnuVentas.Enabled = True
            MnuAcceso.Enabled = False
            MnuConsultas.Enabled = False
            MnuBackup.Enabled = False
        Else
            MnuAlmacen.Enabled = False
            MnuIngresos.Enabled = False
            MnuVentas.Enabled = False
            MnuAcceso.Enabled = False
            MnuConsultas.Enabled = False
            MnuBackup.Enabled = False
        End If
    End Sub

    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles MnuSalir.Click
        If (MsgBox("Estas seguro de salir del sistema?", vbYesNo + vbQuestion, "Sistema") = vbYes) Then
            End
        End If
    End Sub

    Private Sub FrmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        Dim frm As New FrmProveedor
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim frm As New FrmCliente
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem.Click
        Dim frm As New FrmIngreso
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub VentasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem1.Click
        Dim frm As New FrmVenta
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ConsultaVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaVentasToolStripMenuItem.Click
        Dim frm As New FrmConsultaVentas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub MisVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MisVentasToolStripMenuItem.Click
        Dim frm As New FrmConsultaVentas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MnuBackup.Click
        Dim frm As New FrmBackup
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class
