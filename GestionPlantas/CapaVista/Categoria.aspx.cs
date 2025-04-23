using System;
using System.Web.UI;
using GestionPlantas.CapaLogica;
using GestionPlantas.CapaDatos;
using System.Web.UI.WebControls;

namespace GestionPlantas.CapaVista
{
    public partial class Categoria : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }

        // Método para cargar las categorías en el GridView
        private void CargarCategorias()
        {
            gvCategorias.DataSource = CategoriaLogica.ObtenerCategorias();  // Llama al método de la lógica
            gvCategorias.DataBind();  // Llama a DataBind para mostrar las categorías
        }

        // Método para agregar una nueva categoría
        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            string nombreCategoria = txtNombreCategoria.Text;

            if (!string.IsNullOrEmpty(nombreCategoria))
            {
                // Crea un nuevo objeto de Categorias y asigna el nombre
                Categorias nuevaCategoria = new Categorias
                {
                    NombreCategoria = nombreCategoria
                };

                // Inserta la categoría usando la lógica
                bool exito = CategoriaLogica.InsertarCategoria(nuevaCategoria);
                if (exito)
                {
                    txtNombreCategoria.Text = "";  // Limpiar el campo de texto
                    CargarCategorias();  // Recargar las categorías
                }
                else
                {
                    // Puedes agregar un mensaje de error si no se inserta correctamente
                    Response.Write("Hubo un error al agregar la categoría.");
                }
            }
        }

        // Evento para manejar los comandos de fila (Modificar y Eliminar)
        protected void gvCategorias_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                // Obtener el índice de la fila seleccionada
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvCategorias.Rows[index];

                // Obtener el ID de la categoría de la fila
                int categoriaId = Convert.ToInt32(gvCategorias.DataKeys[row.RowIndex].Value);

                // Cargar los datos para la modificación
                txtNombreCategoria.Text = row.Cells[1].Text;  // Asumiendo que el nombre está en la columna 1

                // Guardar el ID de la categoría en el ViewState para usarlo al actualizar
                ViewState["CategoriaId"] = categoriaId;
            }
            else if (e.CommandName == "Eliminar")
            {
                // Obtener el índice de la fila seleccionada
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvCategorias.Rows[index];

                // Obtener el ID de la categoría de la fila
                int categoriaId = Convert.ToInt32(gvCategorias.DataKeys[row.RowIndex].Value);

                // Llamar al método de eliminación
                bool exito = CategoriaLogica.EliminarCategoria(categoriaId);
                if (exito)
                {
                    // Recargar las categorías
                    CargarCategorias();
                }
                else
                {
                    Response.Write("Hubo un error al eliminar la categoría.");
                }
            }
        }
    }
}

