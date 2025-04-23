using System;
using System.Web.UI;
using GestionPlantas.CapaLogica;
using GestionPlantas.CapaDatos;

namespace GestionPlantas.CapaVista
{
    public partial class Plantas : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                CargarPlantas();
            }
        }

        // Cargar las categorías en el DropdownList
        private void CargarCategorias()
        {
            var categorias = CategoriaLogica.ObtenerCategorias();
            ddlCategorias.DataSource = categorias;
            ddlCategorias.DataTextField = "NombreCategoria";
            ddlCategorias.DataValueField = "Id";
            ddlCategorias.DataBind();
        }

        // Cargar las plantas en el GridView
        private void CargarPlantas()
        {
            gvPlantas.DataSource = PlantaLogica.ObtenerPlantas();
            gvPlantas.DataBind();
        }

        // Método para agregar una nueva planta
        protected void btnAgregarPlanta_Click(object sender, EventArgs e)
        {
            string nombrePlanta = txtNombrePlanta.Text;
            int categoriaId = int.Parse(ddlCategorias.SelectedValue);

            if (!string.IsNullOrEmpty(nombrePlanta) && categoriaId > 0)
            {
                // Crear un nuevo objeto Planta y asignar el nombre y la categoría
                Plantas nuevaPlanta = new Plantas
                {
                    Nombre = nombrePlanta,
                    CategoriaId = categoriaId
                };

                // Insertar la planta usando la lógica
                bool exito = PlantaLogica.InsertarPlanta(nuevaPlanta);
                if (exito)
                {
                    txtNombrePlanta.Text = "";  // Limpiar el campo de texto
                    CargarPlantas();  // Recargar las plantas
                }
                else
                {
                    // Mostrar mensaje de error
                    Response.Write("Hubo un error al agregar la planta.");
                }
            }
        }

        // Manejar los eventos de los botones en el GridView (Eliminar, etc.)
        protected void gvPlantas_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            // Aquí puedes manejar las acciones de modificar o eliminar una planta
            if (e.CommandName == "Eliminar")
            {
                // Obtener el ID de la planta seleccionada y eliminarla
                int plantaId = Convert.ToInt32(gvPlantas.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                // Implementar la eliminación
            }
        }
    }
}
