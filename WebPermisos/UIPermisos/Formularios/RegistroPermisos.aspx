<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroPermisos.aspx.cs" Inherits="UIPermisos.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <asp:UpdatePanel runat="server" ID="UpdatePanelPermiso" UpdateMode ="Conditional">
        <ContentTemplate>

            <div class="form-group">
                <label for="">Codigo</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" Width="150" ReadOnly="true" Text ="NUEVO"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="">Nombre Empleado</label>
                <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="">Apellido Empleado</label>
                <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="">Tipo Permiso</label>
                <asp:DropDownList ID="droTipoPermisos" runat="server" CssClass ="form-control"></asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="">Fecha Permiso</label>
                <asp:TextBox ID="txtFechaPermiso" runat="server" CssClass="form-control" Width="200" ></asp:TextBox>
            </div>

            <div class="alert alert-success" role="alert"  id ="AlertSuccess" runat ="server" visible ="false">
              
            </div>

            <div class="alert alert-danger" role="alert" id ="AlertDanger" runat ="server"  visible ="false">
                
            </div>
            <hr />

            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" CssClass ="btn btn-primary" />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass ="btn btn-success"  />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  CssClass ="btn btn-danger" Enabled="false" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnSalir" runat="server" Text="Consultar Registros" PostBackUrl="~/Formularios/ConsultarPermisos.aspx"  CssClass ="btn btn-info" />

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
