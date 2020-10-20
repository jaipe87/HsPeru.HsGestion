<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPreciosUnidad
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgDetallePrecios = New System.Windows.Forms.DataGridView()
        Me.colcodsuc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDessuc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colcoduni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDes_uni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colprecio_publi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colprec_distri = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colprecio_min = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colpublicod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coldistrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colpmind = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEsMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgDetallePrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgDetallePrecios
        '
        Me.dgDetallePrecios.AllowUserToAddRows = False
        Me.dgDetallePrecios.AllowUserToDeleteRows = False
        Me.dgDetallePrecios.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgDetallePrecios.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDetallePrecios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDetallePrecios.ColumnHeadersHeight = 30
        Me.dgDetallePrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDetallePrecios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colcodsuc, Me.colDessuc, Me.colcoduni, Me.colDes_uni, Me.colprecio_publi, Me.colprec_distri, Me.colprecio_min, Me.colpublicod, Me.coldistrid, Me.colpmind, Me.colEsMin})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDetallePrecios.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgDetallePrecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDetallePrecios.EnableHeadersVisualStyles = False
        Me.dgDetallePrecios.Location = New System.Drawing.Point(0, 0)
        Me.dgDetallePrecios.MultiSelect = False
        Me.dgDetallePrecios.Name = "dgDetallePrecios"
        Me.dgDetallePrecios.ReadOnly = True
        Me.dgDetallePrecios.RowHeadersVisible = False
        Me.dgDetallePrecios.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDetallePrecios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDetallePrecios.Size = New System.Drawing.Size(367, 174)
        Me.dgDetallePrecios.TabIndex = 72
        '
        'colcodsuc
        '
        Me.colcodsuc.HeaderText = "Cod.Suc"
        Me.colcodsuc.Name = "colcodsuc"
        Me.colcodsuc.ReadOnly = True
        Me.colcodsuc.Visible = False
        '
        'colDessuc
        '
        Me.colDessuc.HeaderText = "Sucursal"
        Me.colDessuc.Name = "colDessuc"
        Me.colDessuc.ReadOnly = True
        Me.colDessuc.Visible = False
        '
        'colcoduni
        '
        Me.colcoduni.HeaderText = "Cod.Uni"
        Me.colcoduni.Name = "colcoduni"
        Me.colcoduni.ReadOnly = True
        Me.colcoduni.Visible = False
        '
        'colDes_uni
        '
        Me.colDes_uni.DataPropertyName = "DESUNI"
        Me.colDes_uni.HeaderText = "UDM"
        Me.colDes_uni.Name = "colDes_uni"
        Me.colDes_uni.ReadOnly = True
        Me.colDes_uni.Width = 150
        '
        'colprecio_publi
        '
        Me.colprecio_publi.DataPropertyName = "PRECIO_PUBLI"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightYellow
        Me.colprecio_publi.DefaultCellStyle = DataGridViewCellStyle2
        Me.colprecio_publi.HeaderText = "P.Publi S/"
        Me.colprecio_publi.Name = "colprecio_publi"
        Me.colprecio_publi.ReadOnly = True
        Me.colprecio_publi.Width = 70
        '
        'colprec_distri
        '
        Me.colprec_distri.DataPropertyName = "PRECIO_DISTRI"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightYellow
        Me.colprec_distri.DefaultCellStyle = DataGridViewCellStyle3
        Me.colprec_distri.HeaderText = "P.Distri S/"
        Me.colprec_distri.Name = "colprec_distri"
        Me.colprec_distri.ReadOnly = True
        Me.colprec_distri.Width = 70
        '
        'colprecio_min
        '
        Me.colprecio_min.DataPropertyName = "PRECIO_MIN"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightYellow
        Me.colprecio_min.DefaultCellStyle = DataGridViewCellStyle4
        Me.colprecio_min.HeaderText = "P.Míni S/"
        Me.colprecio_min.Name = "colprecio_min"
        Me.colprecio_min.ReadOnly = True
        Me.colprecio_min.Width = 70
        '
        'colpublicod
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle5.Format = "0.00"
        Me.colpublicod.DefaultCellStyle = DataGridViewCellStyle5
        Me.colpublicod.HeaderText = "P.Publi US$"
        Me.colpublicod.Name = "colpublicod"
        Me.colpublicod.ReadOnly = True
        Me.colpublicod.Visible = False
        Me.colpublicod.Width = 70
        '
        'coldistrid
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle6.Format = "0.00"
        Me.coldistrid.DefaultCellStyle = DataGridViewCellStyle6
        Me.coldistrid.HeaderText = "P.Distri US$"
        Me.coldistrid.Name = "coldistrid"
        Me.coldistrid.ReadOnly = True
        Me.coldistrid.Visible = False
        Me.coldistrid.Width = 70
        '
        'colpmind
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle7.Format = "0.00"
        Me.colpmind.DefaultCellStyle = DataGridViewCellStyle7
        Me.colpmind.HeaderText = "P.Mini US$"
        Me.colpmind.Name = "colpmind"
        Me.colpmind.ReadOnly = True
        Me.colpmind.Visible = False
        Me.colpmind.Width = 70
        '
        'colEsMin
        '
        Me.colEsMin.DataPropertyName = "ESMIN"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colEsMin.DefaultCellStyle = DataGridViewCellStyle8
        Me.colEsMin.HeaderText = ""
        Me.colEsMin.MinimumWidth = 2
        Me.colEsMin.Name = "colEsMin"
        Me.colEsMin.ReadOnly = True
        Me.colEsMin.Width = 2
        '
        'FrmPreciosUnidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 174)
        Me.Controls.Add(Me.dgDetallePrecios)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPreciosUnidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precio por Unidad de Medida"
        CType(Me.dgDetallePrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgDetallePrecios As DataGridView
    Friend WithEvents colcodsuc As DataGridViewTextBoxColumn
    Friend WithEvents colDessuc As DataGridViewTextBoxColumn
    Friend WithEvents colcoduni As DataGridViewTextBoxColumn
    Friend WithEvents colDes_uni As DataGridViewTextBoxColumn
    Friend WithEvents colprecio_publi As DataGridViewTextBoxColumn
    Friend WithEvents colprec_distri As DataGridViewTextBoxColumn
    Friend WithEvents colprecio_min As DataGridViewTextBoxColumn
    Friend WithEvents colpublicod As DataGridViewTextBoxColumn
    Friend WithEvents coldistrid As DataGridViewTextBoxColumn
    Friend WithEvents colpmind As DataGridViewTextBoxColumn
    Friend WithEvents colEsMin As DataGridViewTextBoxColumn
End Class
