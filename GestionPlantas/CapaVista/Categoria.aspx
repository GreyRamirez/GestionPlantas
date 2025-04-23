<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="GestionPlantas.CapaVista.Categoria" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Categorías</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Css/Estilo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <ul>
                <li><a href="Inicio.aspx">Inicio</a></li>
                <li><a href="Plantas.aspx">Plantas</a></li>
                <li><a href="Categoria.aspx">Categoría</a></li>
            </ul>

            <h1>Gestión de Categorías</h1>

            <!-- GridView para mostrar las categorías -->
            <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="false" OnRowCommand="gvCategorias_RowCommand" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                    <asp:BoundField DataField="NombreCategoria" HeaderText="Nombre Categoría" SortExpression="NombreCategoria" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <!-- Botón de Modificar -->
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CommandName="Modificar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            <!-- Botón de Eliminar -->
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />

            <asp:Label Text="Nombre de la categoría:" runat="server" AssociatedControlID="txtNombreCategoria" />
            <br />
            <asp:TextBox ID="txtNombreCategoria" runat="server" />
            <br /><br />

            <asp:Button ID="btnAgregarCategoria" runat="server" Text="Agregar Categoría" OnClick="btnAgregarCategoria_Click" />
        </div>
    </form>
</body>
</html>
