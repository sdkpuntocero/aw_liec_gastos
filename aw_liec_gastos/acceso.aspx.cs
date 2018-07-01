using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aw_liec_gastos
{
    public partial class acceso : System.Web.UI.Page
    {
        static Guid guid_idusuario, guid_idempresa;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                inf_user();
            }
            else
            {

            }
        }

        private void inf_user()
        {
            try
            {
                if (valida_inicio() == true)
                {
                    rfv_usuario.Enabled = true;
                    rfv_clave.Enabled = true;
                    lkb_registro.Visible = false;
                }
                else
                {
                    rfv_usuario.Enabled = false;
                    rfv_clave.Enabled = false;
                    lkb_registro.Visible = true;
                    Mensaje("No existe administrador ni tribunal en la aplicación, favor de registrarlos.");
                }
            }
            catch
            {
                Mensaje("Sin conexión a base de datos, contactar al administrador.");
            }

        }

        protected void lkb_registro_Click(object sender, EventArgs e)
        {
            Response.Redirect("registro_inicial.aspx");
        }

        protected void lbtn_acceso_Click(object sender, EventArgs e)
        {

            string str_codigousuario, str_clave, str_valida_clave;
            int int_idtypeuser, int_iduserstatus;

            str_codigousuario = txt_usuario.Text;
            str_clave = encriptar.Encrypt(txt_clave.Text);

            try
            {
                using (db_liecEntities m_usuariof = new db_liecEntities())
                {
                    var i_usuariof = (from c in m_usuariof.inf_usuarios
                                      where c.codigo_usuario == str_codigousuario
                                      select c).FirstOrDefault();

                    guid_idusuario = i_usuariof.id_usuario;
                    guid_idempresa = Guid.Parse(i_usuariof.id_empresa.ToString());
                    str_valida_clave = i_usuariof.clave;
                    int_idtypeuser = int.Parse(i_usuariof.id_tipo_usuario.ToString());
                    int_iduserstatus = int.Parse(i_usuariof.id_estatus.ToString());

                    if (str_valida_clave == str_clave && int_iduserstatus == 1)
                    {
                        Session["ss_id_user"] = guid_idusuario;
                        Session["ss_id_center"] = guid_idempresa;
                        Response.Redirect("panel.aspx");
                    }
                    else
                    {
                        Mensaje("Contraseña incorrecta, favor de contactar al Administrador.");
                    }
                }
            }
            catch
            {
                Mensaje("Usuario incorrecto, favor de contactar al Administrador.");
            }
        }

        public bool valida_inicio()
        {
            int int_fusuarios, int_fempresa;

            using (db_liecEntities edm_usuarios = new db_liecEntities())
            {
                var i_usuarios = (from c in edm_usuarios.inf_usuarios
                                  where c.id_tipo_usuario == 2
                                  select c).ToList();
                if (i_usuarios.Count == 0)
                {
                    int_fusuarios = 0;
                }
                else
                {
                    int_fusuarios = 1;
                }
            }

            using (db_liecEntities edm_empresa = new db_liecEntities())
            {
                var i_empresa = (from c in edm_empresa.inf_empresa
                                 select c).ToList();

                if (i_empresa.Count == 0)
                {
                    int_fempresa = 0;
                }
                else
                {
                    int_fempresa = 1;
                }
            }

            if (int_fusuarios == 1 && int_fempresa == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Mensaje(string contenido)
        {
            lblModalTitle.Text = "LIEC";
            lblModalBody.Text = contenido;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
    }
}