using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aw_liec_gastos
{
    public partial class registro_inicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    load_ddl();

                }
                else
                {

                }
            }
            catch
            {
                Response.Redirect("acceso.aspx");
            }
        }

        private void load_ddl()
        {

            ddl_colonia_empresa.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
        private void guarda_registro()
        {
            try
            {
                Guid guid_nempresa = Guid.NewGuid();
                string str_rs = txt_nombre_empresa.Text.ToUpper();
                string str_telefono = txt_telefono_empresa.Text;
                string str_email = txt_email_empresa.Text;
                string str_callenum = txt_callenum_empresa.Text.ToUpper();
                string str_cp = txt_cp_empresa.Text;
                int int_colony = Convert.ToInt32(ddl_colonia_empresa.SelectedValue);
                int int_idcodigocp = 0;
                Guid guid_nusuario = Guid.NewGuid();

                string str_nombres = txt_nombres_admin.Text.ToUpper();
                string str_apaterno = txt_apaterno_admin.Text.ToUpper();
                string str_amaterno = txt_amaterno_admin.Text.ToUpper();
                string str_usuairo = txt_usuario_admin.Text;
                string str_password = encriptar.Encrypt(txt_clave_admin.Text);

                using (db_liecEntities db_sepomex = new db_liecEntities())
                {
                    var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                       where c.d_codigo == str_cp
                                       where c.id_asenta_cpcons == int_colony
                                       select c).ToList();

                    int_idcodigocp = tbl_sepomex[0].id_codigo;
                }

                using (var m_empresa = new db_liecEntities())
                {
                    var i_empresa = new inf_empresa

                    {
                        id_empresa = guid_nempresa,
                        id_estatus = 1,
                        razon_social = str_rs,
                        telefono = str_telefono,
                        email = str_email,
                        callenum = str_callenum,
                        id_codigo = int_idcodigocp,
                        fecha_registro = DateTime.Now,
                    };

                    m_empresa.inf_empresa.Add(i_empresa);
                    m_empresa.SaveChanges();
                }

                using (var m_usuario = new db_liecEntities())
                {
                    var i_usuario = new inf_usuarios
                    {
                        id_usuario = guid_nusuario,
                        id_estatus = 1,
                        id_tipo_usuario = 2,
                        nombres = str_nombres,
                        a_paterno = str_apaterno,
                        a_materno = str_amaterno,
                        codigo_usuario = str_usuairo,
                        clave = str_password,
                        fecha_registro = DateTime.Now,
                        id_empresa = guid_nempresa
                    };
                    m_usuario.inf_usuarios.Add(i_usuario);
                    m_usuario.SaveChanges();
                }

                limpiar_textbox();
                Mensaje("Datos de Empresa y Administrador agregados con éxito.");

            }
            catch
            { }
        }



        private void limpiar_textbox()
        {

            ddl_colonia_empresa.Items.Insert(0, new ListItem("Seleccionar", "0"));


            txt_nombre_empresa.Text = null;
            txt_telefono_empresa.Text = null;
            txt_email_empresa.Text = null;
            txt_callenum_empresa.Text = null;
            txt_cp_empresa.Text = null;

            txt_municipio_empresa.Text = null;
            txt_estado_empresa.Text = null;


            txt_nombres_admin.Text = null;
            txt_apaterno_admin.Text = null;
            txt_amaterno_admin.Text = null;

            txt_usuario_admin.Text = null;
            txt_clave_admin.Text = null;
        }

        private string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, @"[^0-9A-Za-z]", "", RegexOptions.None);
        }
        public static string RemoveAccentsWithRegEx(string inputString)
        {
            Regex replace_a_Accents = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
            inputString = replace_a_Accents.Replace(inputString, "a");
            inputString = replace_e_Accents.Replace(inputString, "e");
            inputString = replace_i_Accents.Replace(inputString, "i");
            inputString = replace_o_Accents.Replace(inputString, "o");
            inputString = replace_u_Accents.Replace(inputString, "u");
            return inputString;
        }


        private void genera_usuario()
        {
            try
            {
                string str_nombres = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_nombres_admin.Text.ToLower()));
                string[] separados;

                separados = str_nombres.Split(" ".ToCharArray());


                string str_apaterno = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_apaterno_admin.Text.ToLower()));
                string str_amaterno = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_amaterno_admin.Text.ToLower()));

                string codigo_usuario = str_nombres + "_" + left_right_mid.left(str_apaterno, 2) + left_right_mid.left(str_amaterno, 2);
                txt_usuario_admin.Text = codigo_usuario;
            }
            catch
            {
                Mensaje("Se requiere minimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario.");
            }

        }

        protected void btn_salir_admin_Click(object sender, EventArgs e)
        {
            Response.Redirect("acceso.aspx");
        }

        protected void btn_guardar_admin_Click(object sender, EventArgs e)
        {

            guarda_registro();

        }
        private void Mensaje(string contenido)
        {
            lblModalTitle.Text = "LIEC";
            lblModalBody.Text = contenido;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }

        protected void txt_nombre_empresa_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nombre_empresa.Text))
            {
                rfv_nombres_admin.Enabled = false;
                rfv_apaterno_admin.Enabled = false;
                rfv_amaterno_admin.Enabled = false;

            }
            else
            {
                rfv_nombres_admin.Enabled = true;
                rfv_apaterno_admin.Enabled = true;
                rfv_amaterno_admin.Enabled = true;

            }
        }

        protected void txt_amaterno_admin_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_amaterno_admin.Text))
            {
                rfv_usuario_admin.Enabled = false;

                rfv_clave_admin.Enabled = false;
            }
            else
            {
                genera_usuario();
                rfv_usuario_admin.Enabled = true;
                txt_usuario_admin.Focus();
                rfv_clave_admin.Enabled = true;
            }
        }



        protected void txt_callenum_empresa_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_callenum_empresa.Text))
            { }
            else
            {
                rfv_nombres_admin.Enabled = false;
                rfv_apaterno_admin.Enabled = false;
                rfv_amaterno_admin.Enabled = false;
                rfv_callenum_empresa.Enabled = true;
                rfv_cp_empresa.Enabled = true;
                rfv_colonia_empresa.Enabled = true;
                txt_cp_empresa.Focus();
            }
        }

        protected void txt_cp_empresa_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_cp_empresa.Text))
            {
            }
            else
            {
                string str_codigo = txt_cp_empresa.Text;

                datos_sepomex(str_codigo);
            }
        }

        private void datos_sepomex(string str_codigo)
        {
            using (db_liecEntities db_sepomex = new db_liecEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                   where c.d_codigo == str_codigo
                                   select c).ToList();

                ddl_colonia_empresa.DataSource = tbl_sepomex;
                ddl_colonia_empresa.DataTextField = "d_asenta";
                ddl_colonia_empresa.DataValueField = "id_asenta_cpcons";
                ddl_colonia_empresa.DataBind();

                if (tbl_sepomex.Count == 1)
                {


                    txt_municipio_empresa.Text = tbl_sepomex[0].d_mnpio;
                    txt_estado_empresa.Text = tbl_sepomex[0].d_estado;
                    rfv_colonia_empresa.Enabled = true;
                    rfv_nombres_admin.Enabled = true;
                    rfv_apaterno_admin.Enabled = true;
                    rfv_amaterno_admin.Enabled = true;
                    txt_cp_empresa.Focus();
                }
                if (tbl_sepomex.Count > 1)
                {

                    ddl_colonia_empresa.Items.Insert(0, new ListItem("Seleccionar", "0"));

                    txt_municipio_empresa.Text = tbl_sepomex[0].d_mnpio;
                    txt_estado_empresa.Text = tbl_sepomex[0].d_estado;
                    rfv_colonia_empresa.Enabled = true;
                    rfv_nombres_admin.Enabled = true;
                    rfv_apaterno_admin.Enabled = true;
                    rfv_amaterno_admin.Enabled = true;
                    txt_cp_empresa.Focus();
                }
                else if (tbl_sepomex.Count == 0)
                {

                    ddl_colonia_empresa.Items.Clear();
                    ddl_colonia_empresa.Items.Insert(0, new ListItem("Seleccionar", "0"));
                    txt_municipio_empresa.Text = null;
                    txt_estado_empresa.Text = null;
                    rfv_colonia_empresa.Enabled = false;
                    rfv_nombres_admin.Enabled = false;
                    rfv_apaterno_admin.Enabled = false;
                    rfv_amaterno_admin.Enabled = false;
                    txt_cp_empresa.Focus();
                }
            }
        }
    }
}