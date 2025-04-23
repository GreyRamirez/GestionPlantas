<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlantasPage.aspx.cs" Inherits="GestionPlantas.CapaVista.PlantasPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Plantas</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/Estilo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="Inicio.aspx">Inicio</a></li>
                <li><a href="Plantas.aspx">Plantas</a></li>
                <li><a href="Categoria.aspx">Categoría</a></li>
            </ul>

            <h1>Gestión de Plantas</h1>

            <!-- Dropdown para seleccionar la categoría -->
            <asp:Label Text="Selecciona una categoría:" runat="server" AssociatedControlID="ddlCategorias" />
            <br />
            <asp:DropDownList ID="ddlCategorias" runat="server">
                <asp:ListItem Text="Seleccione una categoría" Value="0" />
            </asp:DropDownList>
            <br />

            <asp:Label Text="Nombre de la planta:" runat="server" AssociatedControlID="txtNombrePlanta" />
            <br />
            <asp:TextBox ID="txtNombrePlanta" runat="server" />
            <br /><br />

            <asp:Button ID="btnAgregarPlanta" runat="server" Text="Agregar Planta" OnClick="btnAgregarPlanta_Click" />
            <br />

            <!-- GridView para mostrar las plantas -->
            <asp:GridView ID="gvPlantas" runat="server" AutoGenerateColumns="false" OnRowCommand="gvPlantas_RowCommand" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre Planta" SortExpression="Nombre" />
                    <asp:BoundField DataField="CategoriaId" HeaderText="ID Categoría" SortExpression="CategoriaId" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <!-- Botón de Eliminar -->
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
