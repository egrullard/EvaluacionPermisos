<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarPermisos.aspx.cs" Inherits="UIPermisos.Formularios.ConsultarPermisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <div class="card">
  <div class="card-body">
  <div class="row">
    <div class="col-10">
        <input class="form-control" id="txtBuscar" type="text" placeholder="Buscar">
            <small id="emailHelp" class="form-text text-muted">Filtros para la busqueda<b> nombre</b>, <b>apellido</b> y <b>tipo permiso</b>.</small>
    </div>

  </div>
      <br />
   <div class ="row">
       <div class ="col-12">
                  <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Registro" PostBackUrl="~/Formularios/RegistroPermisos.aspx" CssClass ="btn btn-success" />
           <br />
           <asp:GridView ID="GridPermisos" runat="server" CssClass ="table table-striped" AutoGenerateColumns="False" ClientIDMode="Static" OnRowCommand="GridPermisos_RowCommand" >
               <Columns>
                   <asp:BoundField DataField="Id" HeaderText="Codigo" />
                   <asp:BoundField DataField="NombreEmpleado" HeaderText="Nombre del Empleado" />
                   <asp:BoundField DataField="ApellidosEmpleado" HeaderText="Apellido del Empleado" />
<%--                   <asp:BoundField DataField="TipoPermiso.Descripcion" HeaderText="Tipo de Permisos" />--%>
                   <asp:BoundField DataField="FechaPermiso" HeaderText="Fecha de Permisos" />
                   <asp:TemplateField ShowHeader="False">
                       <ItemTemplate>
                             <asp:Button Text="Actualizar" ID="btnActualizar" runat="server" CssClass="btn btn-primary" 
                                                    CommandName="Actualizar" 
                                                    CommandArgument='<%#Eval("Id")%>' />
                       </ItemTemplate>
                   </asp:TemplateField>

                         <asp:TemplateField ShowHeader="False">
                       <ItemTemplate>
                             <asp:Button Text="Eliminar" ID="btnEliminar" runat="server" CssClass="btn btn-danger" 
                                                    CommandName="Eliminar" 
                                 OnClientClick="return confirm('Esta seguro de eliminar este registro?');"
                                                    CommandArgument='<%#Eval("Id")%>' />
                       </ItemTemplate>
                   </asp:TemplateField>
               </Columns>
           </asp:GridView>
       </div>
   </div>
  </div>
</div>
    <script>
        $(document).ready(function(){
            $("#txtBuscar").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("#GridPermisos tr").filter(function () {
              $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
          });
        });
    </script>
</asp:Content>
