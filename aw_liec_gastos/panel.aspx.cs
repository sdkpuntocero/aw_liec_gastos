using Microsoft.Reporting.WebForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aw_liec_gastos
{
    public partial class panel : System.Web.UI.Page
    {
        static Guid guid_iduser, guid_fnegocio;
        static int int_idtipousuario, int_tipousuario, int_accion_usuario, int_accion_rubro, int_accion_gasto, int_accion_caja, int_accion_email_envio, int_accion_email_recepcion;


        #region panel
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    inf_user();
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
        private void inf_user()
        {

            guid_iduser = (Guid)(Session["ss_id_user"]);


            using (db_liecEntities m_usuario = new db_liecEntities())
            {
                var i_usuario = (from i_u in m_usuario.inf_usuarios
                                 join i_tu in m_usuario.fact_tipo_usuario on i_u.id_tipo_usuario equals i_tu.id_tipo_usuario
                                 join i_c in m_usuario.inf_empresa on i_u.id_empresa equals i_c.id_empresa

                                 where i_u.id_usuario == guid_iduser
                                 select new
                                 {
                                     i_u.nombres,
                                     i_u.a_paterno,
                                     i_u.a_materno,
                                     i_tu.desc_tipo_usuario,
                                     i_tu.id_tipo_usuario,
                                     i_c.razon_social,
                                     i_c.id_empresa

                                 }).FirstOrDefault();

                lbl_edita_usuariof.Text = i_usuario.nombres + " " + i_usuario.a_paterno + " " + i_usuario.a_materno;
                lbl_ftipousuario.Text = i_usuario.desc_tipo_usuario;
                int_idtipousuario = i_usuario.id_tipo_usuario;
                lbl_ffnegocio.Text = i_usuario.razon_social;
                guid_fnegocio = i_usuario.id_empresa;
            }
            switch (int_idtipousuario)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    //lkb_resumen.Visible = false;
                    //i_resumen.Visible = false;
                    //lbl_resumen.Visible = false;

                    //lkb_rubro.Visible = false;
                    //i_rubro.Visible = false;
                    //lbl_rubro.Visible = false;

                    lkb_correos.Visible = false;
                    i_correos.Visible = false;
                    lbl_correos.Visible = false;

                    chkb_administrador.Visible = false;

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:


                    break;
                case 7:

                    break;
                case 8:

                    break;
                case 9:

                    break;
                case 10:

                    break;
                case 11:

                    break;
                case 12:

                    break;
                case 13:

                    break;
                case 14:

                    break;
                default:

                    break;
            }

        }
        protected void lkb_edita_usuariof_Click(object sender, EventArgs e)
        {
            filtra_panel(1);
        }
        protected void lkb_fnegocio_Click(object sender, EventArgs e)
        {
            filtra_panel(2);
        }
        protected void lkb_resumen_Click(object sender, EventArgs e)
        {
            filtra_panel(3);
        }
        protected void lkb_gastos_Click(object sender, EventArgs e)
        {
            filtra_panel(4);
        }
        protected void lkb_caja_Click(object sender, EventArgs e)
        {
            filtra_panel(5);
        }

        protected void lkb_rubro_Click(object sender, EventArgs e)
        {
            filtra_panel(6);
        }

        protected void lkb_usuarios_Click(object sender, EventArgs e)
        {
            filtra_panel(7);
        }
        protected void lkb_correos_Click(object sender, EventArgs e)
        {
            filtra_panel(8);
        }

        protected void lkb_salir_Click(object sender, EventArgs e)
        {
            filtra_panel(9);

        }
        private void filtra_panel(int int_idpanel)
        {

            switch (int_idpanel)
            {
                case 1:

                    chkbox_edita_fusuario.Checked = false;
                    pnl_usuariof.Visible = true;
                    pnl_fnegocio.Visible = false;
                    pnl_rpt.Visible = false;
                    pnl_gasto.Visible = false;
                    pnl_caja.Visible = false;
                    pnl_rubros.Visible = false;
                    pnl_email_envio.Visible = false;
                    pnl_email_recepcion.Visible = false;
                    pnl_usuarios.Visible = false;

                    i_edita_usuariof.Attributes["style"] = "color:#B9005C";
                    i_editafnegocio.Attributes["style"] = "color:#e34d0d";

                    i_resumen.Attributes["style"] = "color:#e34d0d";
                    i_gastos.Attributes["style"] = "color:#e34d0d";
                    i_caja.Attributes["style"] = "color:#e34d0d";
                    i_rubro.Attributes["style"] = "color:#e34d0d";

                    i_correos.Attributes["style"] = "color:#e34d0d";
                    i_usuarios.Attributes["style"] = "color:#e34d0d";
                    i_salir.Attributes["style"] = "color:#e34d0d";

                    limpia_txt_fusuario();

                    try
                    {

                        using (db_liecEntities m_fusuario = new db_liecEntities())
                        {
                            var i_fusuario = (from i_c in m_fusuario.inf_usuarios
                                              where i_c.id_usuario == guid_iduser
                                              select new
                                              {

                                                  i_c.nombres,
                                                  i_c.a_paterno,
                                                  i_c.a_materno,
                                                  i_c.fecha_nacimiento,
                                                  i_c.codigo_usuario,
                                                  i_c.clave,

                                              }).FirstOrDefault();


                            txt_nombres_fusuario.Text = i_fusuario.nombres;
                            txt_apaterno_fusuario.Text = i_fusuario.a_paterno;
                            txt_amaterno_fusuario.Text = i_fusuario.a_materno;
                            txt_usuario_fusuario.Text = i_fusuario.codigo_usuario;
                            txt_clave_fusuario.Text = i_fusuario.clave;

                        }
                    }
                    catch
                    {

                    }



                    break;
                case 2:
                    chkbox_edita_fnegocio.Checked = false;
                    pnl_usuariof.Visible = false;
                    pnl_fnegocio.Visible = true;
                    pnl_rpt.Visible = false;
                    pnl_gasto.Visible = false;
                    pnl_caja.Visible = false;
                    pnl_rubros.Visible = false;
                    pnl_email_envio.Visible = false;
                    pnl_email_recepcion.Visible = false;
                    pnl_usuarios.Visible = false;

                    i_edita_usuariof.Attributes["style"] = "color:#e34d0d";
                    i_editafnegocio.Attributes["style"] = "color:#B9005C";


                    i_resumen.Attributes["style"] = "color:#e34d0d";
                    i_gastos.Attributes["style"] = "color:#e34d0d";
                    i_caja.Attributes["style"] = "color:#e34d0d";
                    i_rubro.Attributes["style"] = "color:#e34d0d";

                    i_correos.Attributes["style"] = "color:#e34d0d";
                    i_usuarios.Attributes["style"] = "color:#e34d0d";
                    i_salir.Attributes["style"] = "color:#e34d0d";

                    limpia_txt_fnegocio();

                    using (db_liecEntities data_user = new db_liecEntities())
                    {
                        var inf_user = (from i_u in data_user.inf_empresa
                                        where i_u.id_empresa == guid_fnegocio
                                        select new
                                        {

                                            i_u.razon_social,
                                            i_u.telefono,
                                            i_u.email,
                                            i_u.callenum,
                                            i_u.id_codigo,


                                        }).FirstOrDefault();


                        txt_nombre_empresa.Text = inf_user.razon_social;
                        txt_telefono_empresa.Text = inf_user.telefono;
                        txt_email_empresa.Text = inf_user.email;
                        txt_callenum_empresa.Text = inf_user.callenum;



                        using (db_liecEntities db_sepomex = new db_liecEntities())
                        {
                            var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                               where c.id_codigo == inf_user.id_codigo
                                               select c).ToList();
                            ddl_colonia_empresa.DataSource = tbl_sepomex;
                            ddl_colonia_empresa.DataTextField = "d_asenta";
                            ddl_colonia_empresa.DataValueField = "id_asenta_cpcons";
                            ddl_colonia_empresa.DataBind();
                            ddl_colonia_empresa.SelectedValue = tbl_sepomex[0].id_asenta_cpcons.ToString();


                            txt_cp_empresa.Text = tbl_sepomex[0].d_codigo;
                            txt_municipio_empresa.Text = tbl_sepomex[0].d_mnpio;
                            txt_estado_empresa.Text = tbl_sepomex[0].d_estado;
                        }

                    }
                    break;
                case 3:

                    pnl_usuariof.Visible = false;
                    pnl_fnegocio.Visible = false;
                    pnl_rpt.Visible = true;
                    pnl_gasto.Visible = false;
                    pnl_caja.Visible = false;
                    pnl_rubros.Visible = false;
                    pnl_email_envio.Visible = false;
                    pnl_email_recepcion.Visible = false;
                    pnl_usuarios.Visible = false;

                    i_edita_usuariof.Attributes["style"] = "color:#e34d0d";
                    i_editafnegocio.Attributes["style"] = "color:#e34d0d";


                    i_resumen.Attributes["style"] = "color:#e34d0d";
                    i_gastos.Attributes["style"] = "color:#e34d0d";
                    i_caja.Attributes["style"] = "color:#e34d0d";
                    i_rubro.Attributes["style"] = "color:#e34d0d";

                    i_correos.Attributes["style"] = "color:#e34d0d";
                    i_usuarios.Attributes["style"] = "color:#e34d0d";
                    i_salir.Attributes["style"] = "color:#e34d0d";

                    default_rpt();
                    Mensaje("Construyendo");

                    break;
                case 4:
                    int_accion_gasto = 0;
                    lbl_pfijo_gasto.Text = null;
                    pnl_usuariof.Visible = false;
                    pnl_fnegocio.Visible = false;
                    pnl_rpt.Visible = false;
                    pnl_gasto.Visible = true;
                    pnl_caja.Visible = false;
                    pnl_rubros.Visible = false;
                    pnl_email_envio.Visible = false;
                    pnl_email_recepcion.Visible = false;
                    pnl_usuarios.Visible = false;

                    i_edita_usuariof.Attributes["style"] = "color:#e34d0d";
                    i_editafnegocio.Attributes["style"] = "color:#e34d0d";

                    i_resumen.Attributes["style"] = "color:#e34d0d";
                    i_gastos.Attributes["style"] = "color:#B9005C";
                    i_caja.Attributes["style"] = "color:#e34d0d";
                    i_rubro.Attributes["style"] = "color:#e34d0d";

                    i_correos.Attributes["style"] = "color:#e34d0d";
                    i_usuarios.Attributes["style"] = "color:#e34d0d";
                    i_salir.Attributes["style"] = "color:#e34d0d";

                    limpia_txt_gastos();


                    txt_buscar_gasto.Visible = false;
                    txt_buscar_gasto.Text = null;
                    btn_buscar_gasto.Visible = false;
                    chkb_estatus_gasto.Visible = false;
                    chkb_estatus_gasto.Checked = false;

                    gv_gasto.Visible = false;
                    break;
                case 5:
                    int_accion_caja = 0;

                    pnl_usuariof.Visible = false;
                    pnl_fnegocio.Visible = false;
                    pnl_rpt.Visible = false;
                    pnl_gasto.Visible = false;
                    pnl_caja.Visible = true;
                    pnl_rubros.Visible = false;
                    pnl_email_envio.Visible = false;
                    pnl_email_recepcion.Visible = false;
                    pnl_usuarios.Visible = false;

                    i_edita_usuariof.Attributes["style"] = "color:#e34d0d";
                    i_editafnegocio.Attributes["style"] = "color:#e34d0d";

                    i_resumen.Attributes["style"] = "color:#e34d0d";
                    i_gastos.Attributes["style"] = "color:#e34d0d";
                    i_caja.Attributes["style"] = "color:#B9005C";
                    i_rubro.Attributes["style"] = "color:#e34d0d";

                    i_correos.Attributes["style"] = "color:#e34d0d";
                    i_usuarios.Attributes["style"] = "color:#e34d0d";
                    i_salir.Attributes["style"] = "color:#e34d0d";

                    limpia_txt_caja();


                    double dml_caja, dml_monto;

                    using (db_liecEntities edm_rubro = new db_liecEntities())
                    {
                        var i_rubro = (from u in edm_rubro.inf_gastos
                                       where u.id_tipo_rubro == 4
                                       select new
                                       {
                                           u.monto

                                       }).ToList();

                        if (i_rubro.Count == 0)
                        {
                            dml_monto = double.Parse(i_rubro.Count.ToString());
                        }
                        else
                        {
                            dml_monto = double.Parse(i_rubro.Sum(x => x.monto).ToString());
                        }
                    }

                    using (db_liecEntities edm_gastos = new db_liecEntities())
                    {
                        var i_gastos = (from i_g in edm_gastos.inf_caja


                                        select new
                                        {
                                            i_g.monto,

                                        }).ToList();

                        if (i_gastos.Count == 0)
                        {
                            dml_caja = i_gastos.Count;

                        }
                        else
                        {
                            dml_caja = double.Parse(i_gastos.Sum(x => x.monto).ToString());

                        }

                    }
                    lbl_tcaja.Text = "MONTO: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_monto) * 100.0) / 100.0)) + " GASTOS: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_caja) * 100.0) / 100.0)) + " BALANCE: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_monto - dml_caja) * 100.0) / 100.0));

                    break;
                case 6:

                    int_accion_rubro = 0;

                    pnl_usuariof.Visible = false;
                    pnl_fnegocio.Visible = false;
                    pnl_rpt.Visible = false;
                    pnl_gasto.Visible = false;
                    pnl_caja.Visible = false;
                    pnl_rubros.Visible = true;
                    pnl_email_envio.Visible = false;
                    pnl_email_recepcion.Visible = false;
                    pnl_usuarios.Visible = false;

                    i_edita_usuariof.Attributes["style"] = "color:#e34d0d";
                    i_editafnegocio.Attributes["style"] = "color:#e34d0d";

                    i_resumen.Attributes["style"] = "color:#e34d0d";
                    i_gastos.Attributes["style"] = "color:#e34d0d";
                    i_caja.Attributes["style"] = "color:#e34d0d";
                    i_rubro.Attributes["style"] = "color:#B9005C";

                    i_correos.Attributes["style"] = "color:#e34d0d";
                    i_usuarios.Attributes["style"] = "color:#e34d0d";
                    i_salir.Attributes["style"] = "color:#e34d0d";

                    limpia_txt_rubros();

                    txt_buscar_rubros.Visible = false;
                    txt_buscar_rubros.Text = null;
                    btn_buscar_rubros.Visible = false;

                    txt_pextra_rubro.Enabled = false;
                    gv_rubros.Visible = false;




                    break;
                case 7:
                    int_accion_usuario = 0;

                    pnl_usuariof.Visible = false;
                    pnl_fnegocio.Visible = false;
                    pnl_rpt.Visible = false;
                    pnl_gasto.Visible = false;
                    pnl_caja.Visible = false;
                    pnl_rubros.Visible = false;
                    pnl_email_envio.Visible = false;
                    pnl_email_recepcion.Visible = false;
                    pnl_usuarios.Visible = true;

                    i_edita_usuariof.Attributes["style"] = "color:#e34d0d";
                    i_editafnegocio.Attributes["style"] = "color:#e34d0d";

                    i_resumen.Attributes["style"] = "color:#e34d0d";
                    i_gastos.Attributes["style"] = "color:#e34d0d";
                    i_caja.Attributes["style"] = "color:#e34d0d";
                    i_rubro.Attributes["style"] = "color:#e34d0d";

                    i_correos.Attributes["style"] = "color:#e34d0d";
                    i_usuarios.Attributes["style"] = "color:#B9005C";
                    i_salir.Attributes["style"] = "color:#e34d0d";

                    limpia_txt_usuarios();


                    break;
                case 8:

                    int_accion_email_envio = 0;
                    int_accion_email_recepcion = 0;

                    pnl_usuariof.Visible = false;
                    pnl_fnegocio.Visible = false;
                    pnl_rpt.Visible = false;
                    pnl_gasto.Visible = false;
                    pnl_caja.Visible = false;
                    pnl_rubros.Visible = false;
                    pnl_email_envio.Visible = true;
                    pnl_email_recepcion.Visible = true;
                    pnl_usuarios.Visible = false;

                    limpia_txt_correos();


                    i_edita_usuariof.Attributes["style"] = "color:#e34d0d";
                    i_editafnegocio.Attributes["style"] = "color:#e34d0d";
                    i_resumen.Attributes["style"] = "color:#e34d0d";
                    i_gastos.Attributes["style"] = "color:#e34d0d";
                    i_caja.Attributes["style"] = "color:#e34d0d";
                    i_rubro.Attributes["style"] = "color:#e34d0d";
                    i_gastos.Attributes["style"] = "color:#e34d0d";

                    i_usuarios.Attributes["style"] = "color:#e34d0d";
                    i_correos.Attributes["style"] = "color:#B9005C";
                    i_salir.Attributes["style"] = "color:#e34d0d";

                    gv_correo_recepcion.Visible = false;
                    txt_correo_recepcion.Text = null;

                    using (var edm_email = new db_liecEntities())
                    {
                        var i_email = (from c in edm_email.inf_email_envio
                                       select c).ToList();

                        if (i_email.Count == 0)
                        {
                            Mensaje("Sin datos de correo para envio, favor de agregar uno");
                            chkbox_editar_ce.Enabled = false;

                        }
                        else
                        {
                            chkbox_editar_ce.Enabled = true;


                            txt_correo_envio.Text = i_email[0].email;
                            txt_usuario_envio.Text = i_email[0].usuario;
                            txt_clave_envio.Text = i_email[0].clave;
                            txt_asunto_envio.Text = i_email[0].asunto;
                            txt_servidor_smtp.Text = i_email[0].servidor_smtp;
                            txt_puerto_envio.Text = i_email[0].puerto.ToString();
                        }
                    }
                    break;
                case 9:

                    Session.Abandon();
                    Response.Redirect("acceso.aspx");
                    //Server.Transfer("acceso.aspx", true);

                    break;
                default:

                    break;
            }
        }


        private void default_rpt()
        {


            pnl_rpt.Visible = true;
            DateTime.Now.ToShortDateString().Replace("/", "");
            DataTable dt_rpt = new DataTable();
            //using (imEntities data_user = new imEntities())
            //{
            //	var inf_user = (from a in data_user.rpt
            //					select a).ToList();
            //}


            string str_date = DateTime.Now.ToShortDateString().Replace("/", "");
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpt_liec.rdl");
            System.Data.DataSet ds = new System.Data.DataSet();

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(@"SELECT  [dia_mes]
      ,[mes]
      ,[año]
      ,[dia]
      ,[etiqueta_rubro]
      ,[desc_tipo_rubro]
      ,[rubro]
      ,[monto]
      ,[desc_gasto]
  FROM [db_liec].[dbo].[v_rpt01]
	order by dia_mes asc;");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = new SqlConnection(cn.cn_SQL);
            da.SelectCommand = cmd;

            da.Fill(ds, "DataSet1");
            ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.DisplayName = "rpt_" + str_date + "";
            ReportViewer1.LocalReport.Refresh();
        }

        private void limpia_txt_gastos()
        {
            ddl_tipogasto_rubro.Items.Clear();
            using (db_liecEntities m_genero = new db_liecEntities())
            {
                var i_genero = (from f_tr in m_genero.fact_tipo_rubro

                                select f_tr).ToList();

                ddl_tipogasto_rubro.DataSource = i_genero;
                ddl_tipogasto_rubro.DataTextField = "desc_tipo_rubro";
                ddl_tipogasto_rubro.DataValueField = "id_tipo_rubro";
                ddl_tipogasto_rubro.DataBind();
            }
            ddl_tipogasto_rubro.Items.Insert(0, new ListItem("Seleccionar", "0"));


            ddl_descgasto_rubro.Items.Clear();
            ddl_descgasto_rubro.Items.Insert(0, new ListItem("Seleccionar", "0"));

            txt_monto_gasto.Text = null;
            txt_desc_gasto.Text = null;
            txt_desc_caja.Text = null;
        }

        private void limpia_txt_caja()
        {
            ddl_tipocaja_rubro.Items.Clear();
            ddl_desccaja_rubro.Items.Clear();
            using (db_liecEntities m_genero = new db_liecEntities())
            {
                var i_genero = (from f_tr in m_genero.fact_tipo_rubro
                                where f_tr.id_tipo_rubro != 4
                                select f_tr).ToList();

                ddl_tipocaja_rubro.DataSource = i_genero;
                ddl_tipocaja_rubro.DataTextField = "desc_tipo_rubro";
                ddl_tipocaja_rubro.DataValueField = "id_tipo_rubro";
                ddl_tipocaja_rubro.DataBind();
            }
            ddl_tipocaja_rubro.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddl_desccaja_rubro.Items.Insert(0, new ListItem("Seleccionar", "0"));

            txt_monto_caja.Text = null;
            txt_desc_caja.Text = null;
        }

        private void limpia_txt_rubros()
        {
            ddl_tipo_rubro.Items.Clear();
            using (db_liecEntities m_genero = new db_liecEntities())
            {
                var i_genero = (from f_tr in m_genero.fact_tipo_rubro

                                select f_tr).ToList();

                ddl_tipo_rubro.DataSource = i_genero;
                ddl_tipo_rubro.DataTextField = "desc_tipo_rubro";
                ddl_tipo_rubro.DataValueField = "id_tipo_rubro";
                ddl_tipo_rubro.DataBind();
            }
            ddl_tipo_rubro.Items.Insert(0, new ListItem("Seleccionar", "0"));

            txt_desc_rubro.Text = null;
            txt_pfijo_rubro.Text = null;
            txt_pextra_rubro.Text = null;
            txt_vgasto.Text = null;
            txt_etiqueta_r.Text = null;

        }


        #endregion

        #region usuariof

        private void limpia_txt_fusuario()
        {
            ddl_colonia_empresa.Items.Insert(0, new ListItem("Seleccionar", "0"));

            txt_nombres_fusuario.Text = null;
            txt_apaterno_fusuario.Text = null;
            txt_amaterno_fusuario.Text = null;
            txt_usuario_fusuario.Text = null;
            txt_clave_fusuario.Text = null;


        }
        protected void chkbox_edita_fusuario_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_edita_fusuario.Checked)
            {
                rfv_nombres_fusuario.Enabled = true;
                rfv_apaterno_fusuario.Enabled = true;
                rfv_amaterno_fusuario.Enabled = true;
                rfv_usuario_fusuario.Enabled = true;
                rfv_clave_fusuario.Enabled = true;
                try
                {

                    using (db_liecEntities m_fusuario = new db_liecEntities())
                    {
                        var i_fusuario = (from i_c in m_fusuario.inf_usuarios
                                          where i_c.id_usuario == guid_iduser
                                          select new
                                          {

                                              i_c.nombres,
                                              i_c.a_paterno,
                                              i_c.a_materno,
                                              i_c.fecha_nacimiento,
                                              i_c.codigo_usuario,
                                              i_c.clave,

                                          }).FirstOrDefault();


                        txt_nombres_fusuario.Text = i_fusuario.nombres;
                        txt_apaterno_fusuario.Text = i_fusuario.a_paterno;
                        txt_amaterno_fusuario.Text = i_fusuario.a_materno;
                        txt_usuario_fusuario.Text = i_fusuario.codigo_usuario;
                        txt_clave_fusuario.Text = i_fusuario.clave;

                    }
                }
                catch
                {

                }
            }
            else
            {
                rfv_nombres_fusuario.Enabled = false;
                rfv_apaterno_fusuario.Enabled = false;
                rfv_amaterno_fusuario.Enabled = false;
                rfv_usuario_fusuario.Enabled = false;
                rfv_clave_fusuario.Enabled = false;
            }

        }
        protected void btn_guarda_fusuario_Click(object sender, EventArgs e)
        {
            if (chkbox_edita_fusuario.Checked)
            {
                string str_nombres = txt_nombres_fusuario.Text.ToUpper();
                string str_apaterno = txt_apaterno_fusuario.Text.ToUpper();
                string str_amaterno = txt_amaterno_fusuario.Text.ToUpper();

                string str_codigousuario = txt_usuario_fusuario.Text;
                string str_password = encriptar.Encrypt(txt_clave_fusuario.Text);

                using (var m_fusuario = new db_liecEntities())
                {
                    var i_fusuario = (from c in m_fusuario.inf_usuarios
                                      where c.codigo_usuario == str_codigousuario
                                      select c).ToList();

                    if (i_fusuario.Count == 0)
                    {
                        using (var m_fusuariof = new db_liecEntities())
                        {
                            var i_fusuariof = (from c in m_fusuariof.inf_usuarios
                                               where c.codigo_usuario == str_codigousuario
                                               select c).ToList();

                            if (i_fusuariof.Count == 0)
                            {
                                using (var m_fusuarioff = new db_liecEntities())
                                {
                                    var i_fusuarioff = (from c in m_fusuarioff.inf_usuarios
                                                        where c.id_usuario == guid_iduser
                                                        select c).FirstOrDefault();


                                    i_fusuarioff.nombres = str_nombres;
                                    i_fusuarioff.a_paterno = str_apaterno;
                                    i_fusuarioff.a_materno = str_amaterno;

                                    i_fusuarioff.codigo_usuario = str_codigousuario;
                                    i_fusuarioff.clave = str_password;

                                    m_fusuarioff.SaveChanges();

                                    limpia_txt_fusuario();
                                    Mensaje("Datos de Usuario actualizados con éxito.");

                                }
                            }
                            else
                            {
                                txt_usuario_fusuario.Text = null;
                                Mensaje("Código de usuario ya existe en la base de datos, favor de reintentar.");

                            }
                        }
                    }
                    else
                    {

                        i_fusuario[0].nombres = str_nombres;
                        i_fusuario[0].a_paterno = str_apaterno;
                        i_fusuario[0].a_materno = str_amaterno;

                        i_fusuario[0].codigo_usuario = str_codigousuario;
                        i_fusuario[0].clave = str_password;

                        m_fusuario.SaveChanges();

                        limpia_txt_fusuario();
                        Mensaje("Datos de Usuario actualizados con éxito.");

                    }
                }

            }
            else
            {
                Mensaje("Favor de activar la edición de los campos.");
            }
        }

        #endregion

        #region negociof

        protected void btn_guarda_fnegocio_Click(object sender, EventArgs e)
        {

            guarda_fnegocio();
        }

        private void guarda_fnegocio()
        {
            if (chkbox_edita_fnegocio.Checked)
            {
                Guid guid_nfnegocio = Guid.NewGuid();
                string str_corporativo = txt_nombre_empresa.Text.ToUpper();

                string str_telefono = txt_telefono_empresa.Text;
                string str_email = txt_email_empresa.Text;
                string str_callenum = txt_callenum_empresa.Text.ToUpper();
                string str_cp = txt_cp_empresa.Text;
                int int_colony = Convert.ToInt32(ddl_colonia_empresa.SelectedValue);
                int int_idcodigocp;

                using (db_liecEntities db_sepomex = new db_liecEntities())
                {
                    var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                       where c.d_codigo == str_cp
                                       where c.id_asenta_cpcons == int_colony
                                       select c).ToList();

                    int_idcodigocp = tbl_sepomex[0].id_codigo;
                }

                using (var m_fempresa = new db_liecEntities())
                {
                    var i_fempresa = (from c in m_fempresa.inf_empresa
                                      where c.id_empresa == guid_fnegocio
                                      select c).FirstOrDefault();


                    i_fempresa.razon_social = str_corporativo;
                    i_fempresa.telefono = str_telefono;
                    i_fempresa.email = str_email;
                    i_fempresa.callenum = str_callenum;
                    i_fempresa.id_codigo = int_idcodigocp;

                    m_fempresa.SaveChanges();
                }

                limpia_txt_fnegocio();

                Mensaje("Datos de Empresa actualizados con éxito");
            }
            else
            {
                Mensaje("Favor de activar la edición de los campos.");
            }
        }


        protected void txt_nombre_empresa_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nombre_empresa.Text))
            {
                rfv_callenum_empresa.Enabled = false;

            }
            else
            {
                rfv_callenum_empresa.Enabled = true;

            }
        }

        protected void txt_callenum_empresa_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_callenum_empresa.Text))
            { }
            else
            {

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

                    txt_cp_empresa.Focus();
                }
                if (tbl_sepomex.Count > 1)
                {

                    ddl_colonia_empresa.Items.Insert(0, new ListItem("Seleccionar", "0"));

                    txt_municipio_empresa.Text = tbl_sepomex[0].d_mnpio;
                    txt_estado_empresa.Text = tbl_sepomex[0].d_estado;
                    rfv_colonia_empresa.Enabled = true;

                    txt_cp_empresa.Focus();
                }
                else if (tbl_sepomex.Count == 0)
                {

                    ddl_colonia_empresa.Items.Clear();
                    ddl_colonia_empresa.Items.Insert(0, new ListItem("Seleccionar", "0"));
                    txt_municipio_empresa.Text = null;
                    txt_estado_empresa.Text = null;
                    rfv_colonia_empresa.Enabled = false;

                    txt_cp_empresa.Focus();
                }
            }
        }
        private void limpia_txt_fnegocio()
        {
            ddl_colonia_empresa.Items.Clear();



            ddl_colonia_empresa.Items.Insert(0, new ListItem("Seleccionar", "0"));
            txt_nombre_empresa.Text = null;
            txt_telefono_empresa.Text = null;
            txt_email_empresa.Text = null;
            txt_callenum_empresa.Text = null;
            txt_cp_empresa.Text = null;
            txt_municipio_empresa.Text = null;
            txt_estado_empresa.Text = null;
        }

        protected void chkbox_edita_fnegocio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_edita_fnegocio.Checked)
            {
                using (db_liecEntities data_user = new db_liecEntities())
                {
                    var inf_user = (from i_u in data_user.inf_empresa
                                    where i_u.id_empresa == guid_fnegocio
                                    select new
                                    {

                                        i_u.razon_social,
                                        i_u.telefono,
                                        i_u.email,
                                        i_u.callenum,
                                        i_u.id_codigo,


                                    }).FirstOrDefault();


                    txt_nombre_empresa.Text = inf_user.razon_social;
                    txt_telefono_empresa.Text = inf_user.telefono;
                    txt_email_empresa.Text = inf_user.email;
                    txt_callenum_empresa.Text = inf_user.callenum;



                    using (db_liecEntities db_sepomex = new db_liecEntities())
                    {
                        var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                           where c.id_codigo == inf_user.id_codigo
                                           select c).ToList();

                        ddl_colonia_empresa.DataSource = tbl_sepomex;
                        ddl_colonia_empresa.DataTextField = "d_asenta";
                        ddl_colonia_empresa.DataValueField = "id_asenta_cpcons";
                        ddl_colonia_empresa.DataBind();

                        txt_cp_empresa.Text = tbl_sepomex[0].d_codigo;
                        txt_municipio_empresa.Text = tbl_sepomex[0].d_mnpio;
                        txt_estado_empresa.Text = tbl_sepomex[0].d_estado;
                    }

                    rfv_nombre_empresa.Enabled = true;
                    rfv_callenum_empresa.Enabled = true;
                    rfv_cp_empresa.Enabled = true;
                    rfv_colonia_empresa.Enabled = true;

                }
            }
            else
            {
                rfv_nombre_empresa.Enabled = false;
                rfv_callenum_empresa.Enabled = false;
                rfv_cp_empresa.Enabled = false;
                rfv_colonia_empresa.Enabled = false;
            }
        }
        #endregion

        #region gasto

        protected void btn_guardar_gasto_Click(object sender, EventArgs e)
        {
            if (int_accion_gasto == 0)
            {
                Mensaje("Favor de seleccionar una acción.");
            }
            else
            {
                Guid guid_idgasto;
                Guid guid_ngasto = Guid.NewGuid();
                int int_tiporubro = int.Parse(ddl_tipogasto_rubro.SelectedValue);
                Guid guid_descrubro = Guid.Parse(ddl_descgasto_rubro.SelectedValue);
                double dbl_monto = double.Parse(txt_monto_gasto.Text);
                string str_desgasto = txt_desc_gasto.Text.ToUpper();
                string str_codigogasto;

                if (int_accion_gasto == 1)
                {
                    using (db_liecEntities data_user = new db_liecEntities())
                    {
                        var items_user = (from c in data_user.inf_gastos
                                          select c).ToList();

                        if (items_user.Count == 0)
                        {
                            str_codigogasto = "liec_g" + string.Format("{0:000}", items_user.Count + 1);

                            using (var m_usuario = new db_liecEntities())
                            {
                                var i_usuario = new inf_gastos
                                {
                                    id_gasto = guid_ngasto,
                                    codigo_gasto = str_codigogasto,
                                    id_estatus = 1,
                                    id_rubro = guid_descrubro,
                                    id_tipo_rubro = int_tiporubro,
                                    monto = dbl_monto,
                                    desc_gasto = str_desgasto,
                                    fecha_registro = DateTime.Now,
                                    id_empresa = guid_fnegocio,
                                    id_estatus_operacion = 1

                                };

                                m_usuario.inf_gastos.Add(i_usuario);
                                m_usuario.SaveChanges();
                            }

                            notifica_gastos(1, dbl_monto, guid_descrubro, int_tiporubro, guid_ngasto);
                        }
                        else
                        {
                            str_codigogasto = "liec_g" + string.Format("{0:000}", items_user.Count + 1);

                            using (var m_usuario = new db_liecEntities())
                            {
                                var i_usuario = new inf_gastos
                                {
                                    id_gasto = guid_ngasto,
                                    codigo_gasto = str_codigogasto,
                                    id_estatus = 1,
                                    id_tipo_rubro = int_tiporubro,
                                    id_rubro = guid_descrubro,
                                    monto = dbl_monto,
                                    desc_gasto = str_desgasto,
                                    fecha_registro = DateTime.Now,
                                    id_empresa = guid_fnegocio,
                                    id_estatus_operacion = 1
                                };

                                m_usuario.inf_gastos.Add(i_usuario);
                                m_usuario.SaveChanges();
                            }



                            using (db_liecEntities edm_gastos = new db_liecEntities())
                            {
                                var i_gastos = (from i_g in edm_gastos.inf_gastos
                                                where i_g.id_rubro == guid_descrubro
                                                where i_g.id_tipo_rubro == int_tiporubro
                                                select new
                                                {
                                                    i_g.monto,

                                                }).ToList();

                                if (i_gastos.Count == 0)
                                {
                                    dbl_monto = i_gastos.Count;
                                    //lbl_fgastos.Text = string.Format("{0:C}", i_gastos.Count);
                                }
                                else
                                {
                                    dbl_monto = double.Parse(i_gastos.Sum(x => x.monto).ToString());
                                    //lbl_fgastos.Text = string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_gastos) * 100.0) / 100.0));
                                }

                            }

                            using (db_liecEntities edm_gastosd = new db_liecEntities())
                            {
                                var i_gastosd = (from c in edm_gastosd.inf_gastos_dep
                                                 where c.id_rubro == guid_descrubro
                                                 where c.id_tipo_rubro == int_tiporubro
                                                 where c.id_estatus_montos == 2
                                                 select c).ToList();

                                if (i_gastosd.Count == 1)
                                {
                                    limpia_txt_gastos();
                                    Mensaje("Datos agregados con éxito.");

                                }
                                else
                                {
                                    using (db_liecEntities edm_fgastosd = new db_liecEntities())
                                    {
                                        var i_fgastosd = (from c in edm_fgastosd.inf_gastos_dep
                                                          where c.id_rubro == guid_descrubro
                                                          where c.id_tipo_rubro == int_tiporubro
                                                          where c.id_estatus_montos == 1
                                                          select c).ToList();

                                        if (i_fgastosd.Count == 0)
                                        {
                                            notifica_gastos(1, dbl_monto, guid_descrubro, int_tiporubro, guid_ngasto);
                                        }
                                        else
                                        {
                                            notifica_gastos(2, dbl_monto, guid_descrubro, int_tiporubro, guid_ngasto);
                                        }
                                    }
                                }
                            }
                        }
                    }


                }
                else if (int_accion_gasto == 2)
                {
                    foreach (GridViewRow row in gv_gasto.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chk_gasto") as CheckBox);
                            if (chkRow.Checked)
                            {
                                row.BackColor = Color.FromArgb(224, 153, 123);
                                string codeuser = row.Cells[1].Text;

                                using (db_liecEntities data_user = new db_liecEntities())
                                {
                                    var items_user = (from c in data_user.inf_gastos
                                                      where c.codigo_gasto == codeuser
                                                      select c).FirstOrDefault();

                                    guid_idgasto = items_user.id_gasto;
                                }


                                int int_estatusgasto;

                                if (chkb_estatus_gasto.Checked == true)
                                {
                                    int_estatusgasto = 3;
                                }
                                else
                                {
                                    int_estatusgasto = 1;
                                }



                                using (var m_fempresa = new db_liecEntities())
                                {
                                    var i_fempresa = (from c in m_fempresa.inf_gastos
                                                      where c.id_gasto == guid_idgasto
                                                      select c).FirstOrDefault();


                                    i_fempresa.id_estatus = int_estatusgasto;
                                    i_fempresa.id_tipo_rubro = int_tiporubro;
                                    i_fempresa.id_rubro = guid_descrubro;
                                    i_fempresa.monto = dbl_monto;
                                    i_fempresa.desc_gasto = str_desgasto;

                                    m_fempresa.SaveChanges();
                                }

                                limpia_txt_rubros();

                                using (db_liecEntities data_user = new db_liecEntities())
                                {
                                    var inf_user = (from i_r in data_user.inf_gastos
                                                    join r_e in data_user.fact_estatus on i_r.id_estatus equals r_e.id_estatus
                                                    join t_tr in data_user.fact_tipo_rubro on i_r.id_tipo_rubro equals t_tr.id_tipo_rubro
                                                    join t_r in data_user.inf_rubro on i_r.id_rubro equals t_r.id_rubro
                                                    select new
                                                    {
                                                        i_r.codigo_gasto,
                                                        r_e.desc_estatus,
                                                        t_tr.tipo_rubro,
                                                        t_r.rubro,
                                                        i_r.desc_gasto,
                                                        i_r.fecha_registro

                                                    }).ToList();

                                    gv_gasto.DataSource = inf_user;
                                    gv_gasto.DataBind();
                                    gv_gasto.Visible = true;
                                }
                                Mensaje("Datos actualizados con éxito.");
                            }
                            else
                            {
                                row.BackColor = Color.White;
                            }
                        }
                    }
                }
            }
        }

        private void notifica_gastos(int tipo_envio, double dbl_monto, Guid guid_descrubro, int int_tiporubro,Guid guid_ngasto)
        {
            if (tipo_envio == 1)
            {
                double dml_gastos;

                using (db_liecEntities edm_gastos = new db_liecEntities())
                {
                    var i_gastos = (from i_g in edm_gastos.inf_rubro
                                    where i_g.id_rubro == guid_descrubro
                                    where i_g.id_tipo_rubro == int_tiporubro
                                    select new
                                    {
                                        i_g.presupuesto,
                                        i_g.minimo,
                                        i_g.maximo

                                    }).ToList();

                    double total = 0;

                    double ocupadad = 0;


                    double.TryParse(i_gastos[0].presupuesto.ToString(), out total);

                    double.TryParse(i_gastos[0].minimo.ToString(), out ocupadad);

                    dml_gastos = (total * (ocupadad / 100));


                    if (dbl_monto >= dml_gastos)
                    {
                        string fcorreo_e = null, fusuario_e = null, clave_e = null, asunto_e = null, detalle_e = null, smtp_e = null, correo_r = null, trubro_e = null, desc_rubro_e = null, rubro_e = null, monto_e = null, usuario_reg = null;
                        int puerto_e = 0;
                        DateTime registro_e = DateTime.Now;

                        using (db_liecEntities edm_email = new db_liecEntities())
                        {
                            var i_email = (from c in edm_email.inf_email_envio
                                           select c).ToList();
                            if (i_email.Count == 0)
                            {

                            }
                            else
                            {
                                fcorreo_e = i_email[0].email;
                                fusuario_e = i_email[0].usuario;
                                clave_e = encriptar.Decrypt(i_email[0].clave);
                                asunto_e = i_email[0].asunto;
                                smtp_e = i_email[0].servidor_smtp;
                                puerto_e = int.Parse(i_email[0].puerto.ToString());


                            }
                        }

                        using (db_liecEntities edm_email_e = new db_liecEntities())
                        {
                            var i_email_e = (from c in edm_email_e.inf_email_recepcion
                                             select c).ToList();
                            if (i_email_e.Count == 0)
                            {

                            }
                            else
                            {

                                foreach (var item in i_email_e)
                                {
                                    correo_r = item.email_recepcion;
                                    detalle_e = "MONTO DE GASTO IGUAL O MAYOR AL 25 % DEL PRESUPUESTO FIJO";
                                    trubro_e = ddl_tipogasto_rubro.SelectedItem.Text;
                                    rubro_e = ddl_descgasto_rubro.SelectedItem.Text;

                                    monto_e = string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dbl_monto) * 100.0) / 100.0));
                                    usuario_reg = lbl_edita_usuariof.Text;
                                    registro_e = DateTime.Now;

                                    enviarcorreo(fcorreo_e, fusuario_e, clave_e, asunto_e, detalle_e, smtp_e, puerto_e, registro_e, correo_r, trubro_e, rubro_e, monto_e, usuario_reg);

                                }
                            }
                        }

                        using (db_liecEntities data_user = new db_liecEntities())
                        {
                            var items_user = (from c in data_user.inf_gastos_dep
                                              where c.id_rubro == guid_descrubro
                                              where c.id_tipo_rubro == int_tiporubro
                                              select c).ToList();

                            if (items_user.Count == 0)
                            {
                                using (var m_usuario = new db_liecEntities())
                                {
                                    var i_usuario = new inf_gastos_dep
                                    {
                                        id_rubro = guid_descrubro,
                                        id_tipo_rubro = int_tiporubro,
                                        id_estatus_montos = 1,
                                        id_gasto = guid_ngasto
                                    };

                                    m_usuario.inf_gastos_dep.Add(i_usuario);
                                    m_usuario.SaveChanges();
                                }
                            }
                        }

                        limpia_txt_gastos();
                        Mensaje("Datos agregados con éxito.");
                    }
                    else
                    {
                        limpia_txt_gastos();
                        lblModalTitle.Text = "LIEC";
                        Mensaje("Datos agregados con éxito.");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                        upModal.Update();
                    }

                }
            }
            else if (tipo_envio == 2)
            {

                double dml_gastos;

                using (db_liecEntities edm_gastos = new db_liecEntities())
                {
                    var i_gastos = (from i_g in edm_gastos.inf_rubro
                                    where i_g.id_rubro == guid_descrubro
                                    where i_g.id_tipo_rubro == int_tiporubro
                                    select new
                                    {
                                        i_g.presupuesto,
                                        i_g.minimo,
                                        i_g.maximo

                                    }).ToList();

                    double total = 0;

                    double ocupadad = 0;


                    double.TryParse(i_gastos[0].presupuesto.ToString(), out total);

                    double.TryParse(i_gastos[0].maximo.ToString(), out ocupadad);

                    dml_gastos = (total * (ocupadad / 100));


                    if (dbl_monto >= dml_gastos)
                    {
                        string fcorreo_e = null, fusuario_e = null, clave_e = null, asunto_e = null, detalle_e = null, smtp_e = null, correo_r = null, trubro_e = null, desc_rubro_e = null, rubro_e = null, monto_e = null, usuario_reg = null;
                        int puerto_e = 0;
                        DateTime registro_e = DateTime.Now;

                        using (db_liecEntities edm_email = new db_liecEntities())
                        {
                            var i_email = (from c in edm_email.inf_email_envio
                                           select c).ToList();
                            if (i_email.Count == 0)
                            {

                            }
                            else
                            {
                                fcorreo_e = i_email[0].email;
                                fusuario_e = i_email[0].usuario;
                                clave_e = encriptar.Decrypt(i_email[0].clave);
                                asunto_e = i_email[0].asunto;
                                smtp_e = i_email[0].servidor_smtp;
                                puerto_e = int.Parse(i_email[0].puerto.ToString());


                            }
                        }

                        using (db_liecEntities edm_email_e = new db_liecEntities())
                        {
                            var i_email_e = (from c in edm_email_e.inf_email_recepcion
                                             select c).ToList();
                            if (i_email_e.Count == 0)
                            {

                            }
                            else
                            {

                                foreach (var item in i_email_e)
                                {
                                    correo_r = item.email_recepcion;
                                    detalle_e = "MONTO DE GASTO IGUAL O MAYOR AL 75 % DEL PRESUPUESTO FIJO";
                                    trubro_e = ddl_tipogasto_rubro.SelectedItem.Text;
                                    rubro_e = ddl_descgasto_rubro.SelectedItem.Text;

                                    monto_e = string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dbl_monto) * 100.0) / 100.0));
                                    usuario_reg = lbl_edita_usuariof.Text;
                                    registro_e = DateTime.Now;

                                    enviarcorreo(fcorreo_e, fusuario_e, clave_e, asunto_e, detalle_e, smtp_e, puerto_e, registro_e, correo_r, trubro_e, rubro_e, monto_e, usuario_reg);

                                }
                            }
                        }

                        using (db_liecEntities data_user = new db_liecEntities())
                        {
                            var items_user = (from c in data_user.inf_gastos_dep
                                              where c.id_rubro == guid_descrubro
                                              where c.id_tipo_rubro == int_tiporubro
                                              where c.id_estatus_montos == 1
                                              select c).ToList();

                            if (items_user.Count == 1)
                            {
                                items_user[0].id_estatus_montos = 2;
                                data_user.SaveChanges();
                            }
                        }

                        limpia_txt_gastos();
                        Mensaje("Datos agregados con éxito.");
                    }
                    else
                    {
                        limpia_txt_gastos();
                        Mensaje("Datos agregados con éxito.");
                    }
                }
            }
        }
        protected void chkbox_agregar_g_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_agregar_g.Checked)
            {
                int_accion_gasto = 1;

                txt_buscar_gasto.Visible = false;
                btn_buscar_gasto.Visible = false;
                chkb_estatus_gasto.Visible = false;

                gv_gasto.Visible = false;
                lbl_pfijo_gasto.Text = null;
                limpia_txt_gastos();

                chkbox_editar_g.Checked = false;

                rfv_tipogasto_rubro.Enabled = true;
                rfv_descgasto_rubro.Enabled = true;
                rfv_monto_gasto.Enabled = true;
                rfv_desc_gasto.Enabled = true;
            }
            else
            {
                int_accion_gasto = 0;

                chkbox_editar_g.Checked = false;

                rfv_tipogasto_rubro.Enabled = false;
                rfv_descgasto_rubro.Enabled = false;
                rfv_monto_gasto.Enabled = false;
                rfv_desc_gasto.Enabled = false;
            }
        }
        protected void txt_buscar_gasto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_buscar_gasto.Text))
            {
                rfv_tipogasto_rubro.Enabled = false;
                rfv_descgasto_rubro.Enabled = false;
                rfv_monto_gasto.Enabled = false;
                rfv_desc_gasto.Enabled = false;
                rfv_buscar_gasto.Enabled = true;
            }
            else
            {
                rfv_tipogasto_rubro.Enabled = false;
                rfv_descgasto_rubro.Enabled = false;
                rfv_monto_gasto.Enabled = false;
                rfv_desc_gasto.Enabled = false;
                rfv_buscar_gasto.Enabled = false;
            }

        }
        protected void chkbox_editar_g_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_editar_g.Checked)
            {
                int_accion_gasto = 2;

                txt_buscar_gasto.Visible = true;
                btn_buscar_gasto.Visible = true;
                chkb_estatus_gasto.Visible = true;
                chkbox_agregar_g.Checked = false;

                rfv_tipogasto_rubro.Enabled = true;
                rfv_descgasto_rubro.Enabled = true;
                rfv_monto_gasto.Enabled = true;
                rfv_desc_gasto.Enabled = true;


                using (db_liecEntities data_user = new db_liecEntities())
                {
                    var inf_user = (from i_r in data_user.inf_gastos
                                    join r_e in data_user.fact_estatus on i_r.id_estatus equals r_e.id_estatus
                                    join t_tr in data_user.fact_tipo_rubro on i_r.id_tipo_rubro equals t_tr.id_tipo_rubro
                                    join t_r in data_user.inf_rubro on i_r.id_rubro equals t_r.id_rubro
                                    select new
                                    {
                                        i_r.codigo_gasto,
                                        r_e.desc_estatus,
                                        t_tr.tipo_rubro,
                                        t_r.rubro,
                                        i_r.desc_gasto,
                                        i_r.fecha_registro

                                    }).ToList();

                    gv_gasto.DataSource = inf_user;
                    gv_gasto.DataBind();
                    gv_gasto.Visible = true;
                }
            }
            else
            {
                int_accion_gasto = 0;

          
                chkbox_agregar_g.Checked = false;

                rfv_tipogasto_rubro.Enabled = false;
                rfv_descgasto_rubro.Enabled = false;
                rfv_monto_gasto.Enabled = false;
                rfv_desc_gasto.Enabled = false;
            }
        }
       
        protected void btn_buscar_gasto_Click(object sender, EventArgs e)
        {
            string str_userb = txt_buscar_gasto.Text.ToUpper();
            using (db_liecEntities data_user = new db_liecEntities())
            {
                var inf_user = (from i_r in data_user.inf_gastos
                                join r_e in data_user.fact_estatus on i_r.id_estatus equals r_e.id_estatus
                                join t_tr in data_user.fact_tipo_rubro on i_r.id_tipo_rubro equals t_tr.id_tipo_rubro
                                join t_r in data_user.inf_rubro on i_r.id_rubro equals t_r.id_rubro
                                where i_r.desc_gasto.Contains(str_userb)
                                select new
                                {
                                    i_r.codigo_gasto,
                                    r_e.desc_estatus,
                                    t_tr.tipo_rubro,
                                    t_r.rubro,
                                    i_r.desc_gasto,
                                    i_r.fecha_registro

                                }).ToList();
                if (inf_user.Count == 0)
                {
                    gv_gasto.DataSource = inf_user;
                    gv_gasto.DataBind();
                    gv_gasto.Visible = true;

                    Mensaje("Gasto no encontrado.");
                }
                else
                {
                    gv_gasto.DataSource = inf_user;
                    gv_gasto.DataBind();
                    gv_gasto.Visible = true;
                }

            }
        }

        protected void chk_gasto_CheckedChanged(object sender, EventArgs e)
        {
            Guid guid_idgasto;

            foreach (GridViewRow row in gv_gasto.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_gasto") as CheckBox);
                    if (chkRow.Checked)
                    {
                        row.BackColor = Color.FromArgb(224, 153, 123);
                        string codeuser = row.Cells[1].Text;

                        using (db_liecEntities data_user = new db_liecEntities())
                        {
                            var items_user = (from c in data_user.inf_gastos
                                              where c.codigo_gasto == codeuser
                                              select c).FirstOrDefault();

                            guid_idgasto = items_user.id_gasto;
                        }

                        using (db_liecEntities data_user = new db_liecEntities())
                        {
                            var inf_user = (from u in data_user.inf_gastos
                                            where u.id_gasto == guid_idgasto
                                            select new
                                            {
                                                u.id_tipo_rubro,
                                                u.id_rubro,

                                                u.desc_gasto,
                                                u.monto

                                            }).FirstOrDefault();

                            ddl_tipogasto_rubro.SelectedValue = inf_user.id_tipo_rubro.ToString();

                            int int_idtiporubro = int.Parse(ddl_tipogasto_rubro.SelectedValue);
                            try
                            {
                                ddl_descgasto_rubro.Items.Clear();
                                using (db_liecEntities m_genero = new db_liecEntities())
                                {
                                    var i_genero = (from f_tr in m_genero.inf_rubro
                                                    where f_tr.id_tipo_rubro == int_idtiporubro
                                                    select f_tr).ToList();

                                    ddl_descgasto_rubro.DataSource = i_genero;
                                    ddl_descgasto_rubro.DataTextField = "etiqueta_rubro";
                                    ddl_descgasto_rubro.DataValueField = "id_rubro";
                                    ddl_descgasto_rubro.DataBind();
                                }

                                //ddl_descgasto_rubro.SelectedValue = inf_user.id_rubro.ToString();
                                txt_desc_gasto.Text = inf_user.desc_gasto;
                                txt_monto_gasto.Text = string.Format("{0:n2}", (Math.Truncate(Convert.ToDouble(inf_user.monto) * 100.0) / 100.0));
                            }
                            catch
                            { }
                        }
                    }
                    else
                    {
                        row.BackColor = Color.White;
                    }
                }
            }
        }

        protected void ddl_tipogasto_rubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int int_idtiporubro = int.Parse(ddl_tipogasto_rubro.SelectedValue);

            ddl_descgasto_rubro.Items.Clear();
            using (db_liecEntities m_genero = new db_liecEntities())
            {
                var i_genero = (from f_tr in m_genero.inf_rubro
                                where f_tr.id_tipo_rubro == int_idtiporubro
                                select f_tr).ToList();

                ddl_descgasto_rubro.DataSource = i_genero;
                ddl_descgasto_rubro.DataTextField = "etiqueta_rubro";
                ddl_descgasto_rubro.DataValueField = "id_rubro";
                ddl_descgasto_rubro.DataBind();
            }
            ddl_descgasto_rubro.Items.Insert(0, new ListItem("Seleccionar", "0"));

            lbl_pfijo_gasto.Text = null;
        }

        protected void ddl_descgasto_rubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int int_idtiporubro = int.Parse(ddl_tipogasto_rubro.SelectedValue);
            Guid guid_descgastorubro = Guid.Parse(ddl_descgasto_rubro.SelectedValue);
            double dbl_pfijo;

            using (db_liecEntities data_user = new db_liecEntities())
            {
                var inf_user = (from u in data_user.inf_rubro
                                where u.id_tipo_rubro == int_idtiporubro
                                where u.id_rubro == guid_descgastorubro
                                select new
                                {
                                    u.rubro,
                                    u.presupuesto,

                                }).FirstOrDefault();

                dbl_pfijo = double.Parse(inf_user.presupuesto.ToString());
            }

            lbl_pfijo_gasto.Text = "PRESUPUESTO FIJO: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dbl_pfijo) * 100.0) / 100.0));
        }
        protected void gv_gasto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_gasto.PageIndex = e.NewPageIndex;


            using (db_liecEntities data_user = new db_liecEntities())
            {
                var inf_user = (from i_r in data_user.inf_gastos
                                join r_e in data_user.fact_estatus on i_r.id_estatus equals r_e.id_estatus
                                join t_tr in data_user.fact_tipo_rubro on i_r.id_tipo_rubro equals t_tr.id_tipo_rubro
                                join t_r in data_user.inf_rubro on i_r.id_rubro equals t_r.id_rubro
                                select new
                                {
                                    i_r.codigo_gasto,
                                    r_e.desc_estatus,
                                    t_tr.tipo_rubro,
                                    t_r.rubro,
                                    i_r.desc_gasto,
                                    i_r.fecha_registro

                                }).ToList();

                gv_gasto.DataSource = inf_user;
                gv_gasto.DataBind();
                gv_gasto.Visible = true;
            }
        }
        #endregion

        #region caja

        protected void txt_buscar_caja_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_buscar_caja.Text))
            {
                rfv_buscar_caja.Enabled = false;
            }
            else
            {
                rfv_buscar_caja.Enabled = true;
                rfv_desc_caja.Enabled = false;
                rfv_monto_caja.Enabled = false;
                rfv_tipocaja_rubro.Enabled = false;
                rfv_desccaja_rubro.Enabled = false;
            }
        }

        protected void chkbox_agregar_c_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_agregar_c.Checked)
            {
                int_accion_caja = 1;

                txt_buscar_caja.Visible = false;
                btn_buscar_caja.Visible = false;

                txt_pextra_rubro.Enabled = false;
                gv_caja.Visible = false;
                chkb_estatus_caja.Visible = false;
                limpia_txt_caja();
                chkbox_editar_c.Checked = false;
                rfv_buscar_caja.Enabled = false;
                rfv_desc_caja.Enabled = true;
                rfv_monto_caja.Enabled = true;
                rfv_tipocaja_rubro.Enabled = true;
                rfv_desccaja_rubro.Enabled = true;
            }
            else
            {
                int_accion_caja = 0;
                chkbox_editar_c.Checked = false;
                rfv_buscar_caja.Enabled = false;
                rfv_desc_caja.Enabled = false;
                rfv_monto_caja.Enabled = false;
                rfv_tipocaja_rubro.Enabled = false;
                rfv_desccaja_rubro.Enabled = false;

            }
        }

        protected void chkbox_editar_c_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_editar_c.Checked)
            {
                chkbox_agregar_c.Checked = false;
                int_accion_caja = 2;

                txt_buscar_caja.Visible = true;
                btn_buscar_caja.Visible = true;
                chkb_estatus_caja.Visible = true;

                limpia_txt_caja();

                using (db_liecEntities data_user = new db_liecEntities())
                {
                    var inf_user = (from i_r in data_user.inf_caja
                                    join r_e in data_user.fact_estatus on i_r.id_estatus equals r_e.id_estatus
                                    join t_r in data_user.fact_tipo_rubro on i_r.id_tipo_rubro equals t_r.id_tipo_rubro
                                    join i_dr in data_user.inf_rubro on i_r.id_rubro equals i_dr.id_rubro
                                    select new
                                    {
                                        i_r.codigo_caja,
                                        r_e.desc_estatus,
                                        t_r.tipo_rubro,
                                        i_dr.rubro,
                                        i_r.desc_caja,
                                        i_r.fecha_registro

                                    }).ToList();

                    gv_caja.DataSource = inf_user;
                    gv_caja.DataBind();
                    gv_caja.Visible = true;
                }
                rfv_buscar_caja.Enabled = false;
                rfv_desc_caja.Enabled = true;
                rfv_monto_caja.Enabled = true;
                rfv_tipocaja_rubro.Enabled = true;
                rfv_desccaja_rubro.Enabled = true;
            }
            else
            {
                int_accion_caja = 0;
                chkbox_agregar_c.Checked = false;

                int_accion_caja = 0;
                chkbox_editar_c.Checked = false;
                rfv_buscar_caja.Enabled = false;
                rfv_desc_caja.Enabled = false;
                rfv_monto_caja.Enabled = false;
                rfv_tipocaja_rubro.Enabled = false;
                rfv_desccaja_rubro.Enabled = false;
            }
        }

        protected void btn_guardar_caja_Click(object sender, EventArgs e)
        {
            if (int_accion_caja == 0)
            {
                Mensaje("FAvor de seleccionar una acción");
            }
            else
            {
                Guid guid_idcaja;
                Guid guid_ncaja = Guid.NewGuid();
                int int_tiporubro = int.Parse(ddl_tipocaja_rubro.SelectedValue);
                Guid guid_descrubro = Guid.Parse(ddl_desccaja_rubro.SelectedValue);
                double dbl_monto = double.Parse(txt_monto_caja.Text);
                string str_descaja = txt_desc_caja.Text.ToUpper();
                string str_codigocaja;

                if (int_accion_caja == 1)
                {


                    using (db_liecEntities data_user = new db_liecEntities())
                    {
                        var items_user = (from c in data_user.inf_caja
                                          select c).ToList();

                        if (items_user.Count == 0)
                        {
                            str_codigocaja = "liec_c" + string.Format("{0:000}", items_user.Count + 1);

                            using (var m_usuario = new db_liecEntities())
                            {
                                var i_usuario = new inf_caja
                                {
                                    id_caja = guid_ncaja,
                                    codigo_caja = str_codigocaja,
                                    id_estatus = 1,
                                    id_tipo_rubro = int_tiporubro,
                                    id_rubro = guid_descrubro,
                                    monto = dbl_monto,
                                    desc_caja = str_descaja,
                                    fecha_registro = DateTime.Now,
                                    id_empresa = guid_fnegocio
                                };

                                m_usuario.inf_caja.Add(i_usuario);
                                m_usuario.SaveChanges();
                            }

                            limpia_txt_caja();

                            Mensaje("Datos agregados con éxito.");

                        }
                        else
                        {
                            str_codigocaja = "liec_c" + string.Format("{0:000}", items_user.Count + 1);

                            using (var m_usuario = new db_liecEntities())
                            {
                                var i_usuario = new inf_caja
                                {
                                    id_caja = guid_ncaja,
                                    codigo_caja = str_codigocaja,
                                    id_estatus = 1,
                                    id_tipo_rubro = int_tiporubro,
                                    id_rubro = guid_descrubro,
                                    monto = dbl_monto,
                                    desc_caja = str_descaja,
                                    fecha_registro = DateTime.Now,
                                    id_empresa = guid_fnegocio
                                };

                                m_usuario.inf_caja.Add(i_usuario);
                                m_usuario.SaveChanges();
                            }

                            limpia_txt_caja();


                            double dml_caja, dml_monto;

                            using (db_liecEntities edm_rubro = new db_liecEntities())
                            {
                                var i_rubro = (from u in edm_rubro.inf_gastos
                                               where u.id_tipo_rubro == 4
                                               select new
                                               {
                                                   u.monto

                                               }).ToList();

                                if (i_rubro.Count == 0)
                                {
                                    dml_monto = double.Parse(i_rubro.Count.ToString());
                                }
                                else
                                {
                                    dml_monto = double.Parse(i_rubro.Sum(x => x.monto).ToString());
                                }
                            }

                            using (db_liecEntities edm_gastos = new db_liecEntities())
                            {
                                var i_gastos = (from i_g in edm_gastos.inf_caja


                                                select new
                                                {
                                                    i_g.monto,

                                                }).ToList();

                                if (i_gastos.Count == 0)
                                {
                                    dml_caja = i_gastos.Count;

                                }
                                else
                                {
                                    dml_caja = double.Parse(i_gastos.Sum(x => x.monto).ToString());

                                }

                            }
                            lbl_tcaja.Text = "MONTO: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_monto) * 100.0) / 100.0)) + " GASTOS: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_caja) * 100.0) / 100.0)) + " BALANCE: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_monto - dml_caja) * 100.0) / 100.0));
                            up_caja.Update();
                            Mensaje("Datos agregados con éxito.");
                        }
                    }


                }
                else if (int_accion_caja == 2)
                {
                    foreach (GridViewRow row in gv_caja.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chk_caja") as CheckBox);
                            if (chkRow.Checked)
                            {
                                row.BackColor = Color.FromArgb(224, 153, 123);
                                string codeuser = row.Cells[1].Text;

                                using (db_liecEntities data_user = new db_liecEntities())
                                {
                                    var items_user = (from c in data_user.inf_caja
                                                      where c.codigo_caja == codeuser
                                                      select c).FirstOrDefault();

                                    guid_idcaja = items_user.id_caja;
                                }


                                int int_estatuscaja;

                                if (chkb_estatus_caja.Checked == true)
                                {
                                    int_estatuscaja = 3;
                                }
                                else
                                {
                                    int_estatuscaja = 1;
                                }



                                using (var m_fempresa = new db_liecEntities())
                                {
                                    var i_fempresa = (from c in m_fempresa.inf_caja
                                                      where c.id_caja == guid_idcaja
                                                      select c).FirstOrDefault();


                                    i_fempresa.id_estatus = int_estatuscaja;
                                    i_fempresa.id_tipo_rubro = int_tiporubro;
                                    i_fempresa.id_rubro = guid_descrubro;
                                    i_fempresa.monto = dbl_monto;
                                    i_fempresa.desc_caja = str_descaja;

                                    m_fempresa.SaveChanges();
                                }

                                limpia_txt_rubros();


                                double dml_caja, dml_monto;

                                using (db_liecEntities edm_rubro = new db_liecEntities())
                                {
                                    var i_rubro = (from u in edm_rubro.inf_gastos
                                                   where u.id_tipo_rubro == 4
                                                   select new
                                                   {
                                                       u.monto

                                                   }).ToList();

                                    if (i_rubro.Count == 0)
                                    {
                                        dml_monto = double.Parse(i_rubro.Count.ToString());
                                    }
                                    else
                                    {
                                        dml_monto = double.Parse(i_rubro.Sum(x => x.monto).ToString());
                                    }
                                }

                                using (db_liecEntities edm_gastos = new db_liecEntities())
                                {
                                    var i_gastos = (from i_g in edm_gastos.inf_caja


                                                    select new
                                                    {
                                                        i_g.monto,

                                                    }).ToList();

                                    if (i_gastos.Count == 0)
                                    {
                                        dml_caja = i_gastos.Count;

                                    }
                                    else
                                    {
                                        dml_caja = double.Parse(i_gastos.Sum(x => x.monto).ToString());

                                    }

                                }
                                lbl_tcaja.Text = "MONTO: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_monto) * 100.0) / 100.0)) + " GASTOS: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_caja) * 100.0) / 100.0)) + " BALANCE: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_monto - dml_caja) * 100.0) / 100.0));

                                using (db_liecEntities data_user = new db_liecEntities())
                                {
                                    var inf_user = (from i_r in data_user.inf_caja
                                                    join r_e in data_user.fact_estatus on i_r.id_estatus equals r_e.id_estatus
                                                    join t_r in data_user.fact_tipo_rubro on i_r.id_tipo_rubro equals t_r.id_tipo_rubro
                                                    select new
                                                    {
                                                        i_r.codigo_caja,
                                                        r_e.desc_estatus,
                                                        t_r.tipo_rubro,
                                                        i_r.rubro,
                                                        i_r.desc_caja,
                                                        i_r.fecha_registro

                                                    }).ToList();

                                    gv_caja.DataSource = inf_user;
                                    gv_caja.DataBind();
                                    gv_caja.Visible = true;
                                }





                                using (db_liecEntities edm_rubro = new db_liecEntities())
                                {
                                    var i_rubro = (from u in edm_rubro.inf_gastos
                                                   where u.id_tipo_rubro == 4
                                                   select new
                                                   {
                                                       u.monto

                                                   }).ToList();

                                    if (i_rubro.Count == 0)
                                    {
                                        dml_monto = double.Parse(i_rubro.Count.ToString());
                                    }
                                    else
                                    {
                                        dml_monto = double.Parse(i_rubro.Sum(x => x.monto).ToString());
                                    }
                                }

                                using (db_liecEntities edm_gastos = new db_liecEntities())
                                {
                                    var i_gastos = (from i_g in edm_gastos.inf_caja


                                                    select new
                                                    {
                                                        i_g.monto,

                                                    }).ToList();

                                    if (i_gastos.Count == 0)
                                    {
                                        dml_caja = i_gastos.Count;

                                    }
                                    else
                                    {
                                        dml_caja = double.Parse(i_gastos.Sum(x => x.monto).ToString());

                                    }

                                }
                                lbl_tcaja.Text = "MONTO: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_monto) * 100.0) / 100.0)) + " GASTOS: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_caja) * 100.0) / 100.0)) + " BALANCE: " + string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_monto - dml_caja) * 100.0) / 100.0));

                                Mensaje("Datos actualizados con éxito.");

                            }
                            else
                            {
                                row.BackColor = Color.White;
                            }
                        }
                    }
                }

            }
        }



        protected void ddl_tipocaja_rubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int int_idtiporubro = int.Parse(ddl_tipocaja_rubro.SelectedValue);

            ddl_desccaja_rubro.Items.Clear();
            using (db_liecEntities m_genero = new db_liecEntities())
            {
                var i_genero = (from f_tr in m_genero.inf_rubro
                                where f_tr.id_tipo_rubro == int_idtiporubro
                                select f_tr).ToList();

                ddl_desccaja_rubro.DataSource = i_genero;
                ddl_desccaja_rubro.DataTextField = "etiqueta_rubro";
                ddl_desccaja_rubro.DataValueField = "id_rubro";
                ddl_desccaja_rubro.DataBind();
            }
            ddl_desccaja_rubro.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        protected void btn_buscar_caja_Click(object sender, EventArgs e)
        {

            string str_userb = txt_buscar_caja.Text.ToUpper();

            using (db_liecEntities data_user = new db_liecEntities())
            {
                var inf_user = (from i_r in data_user.inf_caja
                                join r_e in data_user.fact_estatus on i_r.id_estatus equals r_e.id_estatus
                                join t_r in data_user.fact_tipo_rubro on i_r.id_tipo_rubro equals t_r.id_tipo_rubro
                                join i_dr in data_user.inf_rubro on i_r.id_rubro equals i_dr.id_rubro
                                where i_r.desc_caja.Contains(str_userb)
                                select new
                                {
                                    i_r.codigo_caja,
                                    r_e.desc_estatus,
                                    t_r.tipo_rubro,
                                    i_dr.rubro,
                                    i_r.desc_caja,
                                    i_r.fecha_registro

                                }).ToList();

                if (inf_user.Count == 0)
                {
                    gv_caja.DataSource = inf_user;
                    gv_caja.DataBind();
                    gv_caja.Visible = true;

                    Mensaje("gasto no encontrado.");

                }
                else
                {
                    gv_caja.DataSource = inf_user;
                    gv_caja.DataBind();
                    gv_caja.Visible = true;
                }

            }
        }
        protected void chk_caja_CheckedChanged(object sender, EventArgs e)
        {
            Guid guid_idcaja;

            foreach (GridViewRow row in gv_caja.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_caja") as CheckBox);
                    if (chkRow.Checked)
                    {
                        row.BackColor = Color.FromArgb(224, 153, 123);
                        string codeuser = row.Cells[1].Text;

                        using (db_liecEntities data_user = new db_liecEntities())
                        {
                            var items_user = (from c in data_user.inf_caja
                                              where c.codigo_caja == codeuser
                                              select c).FirstOrDefault();

                            guid_idcaja = items_user.id_caja;
                        }

                        using (db_liecEntities data_user = new db_liecEntities())
                        {
                            var inf_user = (from u in data_user.inf_caja
                                            where u.id_caja == guid_idcaja
                                            select new
                                            {
                                                u.id_tipo_rubro,
                                                u.id_rubro,
                                                u.desc_caja,
                                                u.monto

                                            }).FirstOrDefault();

                            ddl_tipocaja_rubro.SelectedValue = inf_user.id_tipo_rubro.ToString();
                            using (db_liecEntities m_genero = new db_liecEntities())
                            {
                                var i_genero = (from f_tr in m_genero.inf_rubro
                                                where f_tr.id_rubro == inf_user.id_rubro
                                                select f_tr).ToList();

                                ddl_desccaja_rubro.DataSource = i_genero;
                                ddl_desccaja_rubro.DataTextField = "etiqueta_rubro";
                                ddl_desccaja_rubro.DataValueField = "id_rubro";
                                ddl_desccaja_rubro.DataBind();
                            }

                            txt_desc_caja.Text = inf_user.desc_caja;
                            txt_monto_caja.Text = string.Format("{0:n2}", (Math.Truncate(Convert.ToDouble(inf_user.monto) * 100.0) / 100.0));

                            rfv_buscar_caja.Enabled = false;
                            rfv_desc_caja.Enabled = true;
                            rfv_monto_caja.Enabled = true;
                            rfv_tipocaja_rubro.Enabled = true;
                            rfv_desccaja_rubro.Enabled = true;
                        }
                    }
                    else
                    {
                        row.BackColor = Color.White;
                    }
                }
            }
        }
        protected void gv_caja_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_caja.PageIndex = e.NewPageIndex;

            using (db_liecEntities data_user = new db_liecEntities())
            {
                var inf_user = (from i_r in data_user.inf_caja
                                join r_e in data_user.fact_estatus on i_r.id_estatus equals r_e.id_estatus
                                join t_r in data_user.fact_tipo_rubro on i_r.id_tipo_rubro equals t_r.id_tipo_rubro
                                join i_dr in data_user.inf_rubro on i_r.id_rubro equals i_dr.id_rubro
                                select new
                                {
                                    i_r.codigo_caja,
                                    r_e.desc_estatus,
                                    t_r.tipo_rubro,
                                    i_dr.rubro,
                                    i_r.desc_caja,
                                    i_r.fecha_registro

                                }).ToList();

                gv_caja.DataSource = inf_user;
                gv_caja.DataBind();
                gv_caja.Visible = true;
            }
        }
        #endregion


        #region rubros

        protected void txt_minimo_rubro_TextChanged(object sender, EventArgs e)
        {
            lbl_minimo_rubro.Text = "*Minimo: % " + txt_minimo_rubro.Text;
        }

        protected void txt_maximo_rubro_TextChanged(object sender, EventArgs e)
        {
            lbl_maximo_rubro.Text = "*Máximo: % " + txt_maximo_rubro.Text;
        }

        protected void chkbox_agregar_r_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_agregar_r.Checked)
            {
                int_accion_rubro = 1;

                lbl_buscar_rubros.Visible = false;
                txt_buscar_rubros.Visible = false;
                btn_buscar_rubros.Visible = false;
                gv_rubros.Visible = false;

                txt_pextra_rubro.Enabled = false;

                limpia_txt_rubros();

                chkbox_editar_r.Checked = false;

                rfv_etiqueta_r.Enabled = true;
                rfv_desc_rubro.Enabled = true;
                rfv_tipo_rubro.Enabled = true;
                rfv_pfijo_rubro.Enabled = true;
                rfv_minimo_rubro.Enabled = true;
                rfv_maximo_rubro.Enabled = true;
                rfv_pextra_rubro.Enabled = false;

            }
            else
            {
                chkbox_editar_r.Checked = false;

                rfv_etiqueta_r.Enabled = false;
                rfv_desc_rubro.Enabled = false;
                rfv_tipo_rubro.Enabled = false;
                rfv_pfijo_rubro.Enabled = false;
                rfv_minimo_rubro.Enabled = false;
                rfv_maximo_rubro.Enabled = false;
                rfv_pextra_rubro.Enabled = false;
            }
        }

        protected void chkbox_editar_r_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_editar_r.Checked)
            {
                int_accion_rubro = 2;

                lbl_buscar_rubros.Visible = true;
                txt_buscar_rubros.Visible = true;
                btn_buscar_rubros.Visible = true;
                txt_buscar_rubros.Text = null;

                using (db_liecEntities data_user = new db_liecEntities())
                {
                    var inf_user = (from i_r in data_user.inf_rubro
                                    join r_e in data_user.fact_estatus on i_r.id_estatus equals r_e.id_estatus
                                    join t_r in data_user.fact_tipo_rubro on i_r.id_tipo_rubro equals t_r.id_tipo_rubro
                                    select new
                                    {
                                        i_r.codigo_rubro,
                                        i_r.etiqueta_rubro,
                                        r_e.desc_estatus,
                                        t_r.tipo_rubro,
                                        i_r.rubro,
                                        i_r.fecha_registro

                                    }).ToList();

                    gv_rubros.DataSource = inf_user;
                    gv_rubros.DataBind();
                    gv_rubros.Visible = true;
                }


                if (int_idtipousuario == 2)
                {
                    txt_pextra_rubro.Enabled = true;
                    rfv_pextra_rubro.Enabled = true;
                }
                else
                {
                    txt_pextra_rubro.Enabled = false;
                    rfv_pextra_rubro.Enabled = false;
                }



                limpia_txt_rubros();

                chkbox_agregar_r.Checked = false;

                rfv_etiqueta_r.Enabled = true;
                rfv_desc_rubro.Enabled = true;
                rfv_tipo_rubro.Enabled = true;
                rfv_pfijo_rubro.Enabled = true;
                rfv_minimo_rubro.Enabled = true;
                rfv_minimo_rubro.Enabled = true;

            }
            else
            {
                chkbox_agregar_r.Checked = false;

                rfv_etiqueta_r.Enabled = false;
                rfv_desc_rubro.Enabled = false;
                rfv_tipo_rubro.Enabled = false;
                rfv_pfijo_rubro.Enabled = false;
                rfv_minimo_rubro.Enabled = false;
                rfv_minimo_rubro.Enabled = false;

            }
        }


        protected void btn_buscar_rubros_Click(object sender, EventArgs e)
        {
            string str_userb = txt_buscar_rubros.Text.ToUpper();
            using (db_liecEntities data_user = new db_liecEntities())
            {
                var inf_user = (from i_r in data_user.inf_rubro
                                join r_e in data_user.fact_estatus on i_r.id_estatus equals r_e.id_estatus
                                join t_r in data_user.fact_tipo_rubro on i_r.id_tipo_rubro equals t_r.id_tipo_rubro
                                where i_r.etiqueta_rubro.Contains(str_userb)
                                select new
                                {
                                    i_r.codigo_rubro,
                                    r_e.desc_estatus,
                                    t_r.tipo_rubro,
                                    i_r.etiqueta_rubro,
                                    i_r.rubro,
                                    i_r.fecha_registro

                                }).ToList();

                if (inf_user.Count == 0)
                {
                    gv_rubros.DataSource = inf_user;
                    gv_rubros.DataBind();
                    gv_rubros.Visible = true;

                    Mensaje("Rubro no encontrado.");
                }
                else
                {
                    gv_rubros.DataSource = inf_user;
                    gv_rubros.DataBind();
                    gv_rubros.Visible = true;
                }

            }

        }
        protected void txt_buscar_rubros_TextChanged(object sender, EventArgs e)
        {
            rfv_etiqueta_r.Enabled = false;
            rfv_desc_rubro.Enabled = false;
            rfv_tipo_rubro.Enabled = false;
            rfv_pfijo_rubro.Enabled = false;
            rfv_minimo_rubro.Enabled = false;
            rfv_minimo_rubro.Enabled = false;
            rfv_pextra_rubro.Enabled = false;
        }
        protected void chk_rubros_CheckedChanged(object sender, EventArgs e)
        {
            Guid guid_idrubro;

            foreach (GridViewRow row in gv_rubros.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_rubros") as CheckBox);
                    if (chkRow.Checked)
                    {
                        row.BackColor = Color.FromArgb(224, 153, 123);
                        string codeuser = row.Cells[1].Text;

                        using (db_liecEntities data_user = new db_liecEntities())
                        {
                            var items_user = (from c in data_user.inf_rubro
                                              where c.codigo_rubro == codeuser
                                              select c).FirstOrDefault();

                            guid_idrubro = items_user.id_rubro;
                        }

                        using (db_liecEntities data_user = new db_liecEntities())
                        {
                            var inf_user = (from u in data_user.inf_rubro
                                            where u.id_rubro == guid_idrubro
                                            select new
                                            {
                                                u.etiqueta_rubro,
                                                u.id_tipo_rubro,
                                                u.rubro,
                                                u.presupuesto,
                                                u.presupuesto_extra,
                                                u.minimo,
                                                u.maximo

                                            }).FirstOrDefault();

                            txt_etiqueta_r.Text = inf_user.etiqueta_rubro;
                            ddl_tipo_rubro.SelectedValue = inf_user.id_tipo_rubro.ToString();
                            txt_desc_rubro.Text = inf_user.rubro;
                            txt_pfijo_rubro.Text = string.Format("{0:n2}", (Math.Truncate(Convert.ToDouble(inf_user.presupuesto) * 100.0) / 100.0));
                            txt_pextra_rubro.Text = string.Format("{0:n2}", (Math.Truncate(Convert.ToDouble(inf_user.presupuesto_extra) * 100.0) / 100.0));
                            txt_minimo_rubro.Text = inf_user.minimo.ToString();
                            txt_maximo_rubro.Text = inf_user.maximo.ToString();
                            lbl_maximo_rubro.Text = "Máximo: % " + inf_user.maximo.ToString();
                            lbl_minimo_rubro.Text = "Minimo: % " + inf_user.minimo.ToString();
                        }

                        double dml_gastos, dml_caja;

                        using (db_liecEntities edm_gastos = new db_liecEntities())
                        {
                            var i_gastos = (from i_g in edm_gastos.inf_gastos
                                            where i_g.id_rubro == guid_idrubro

                                            select new
                                            {
                                                i_g.monto,

                                            }).ToList();

                            if (i_gastos.Count == 0)
                            {
                                dml_gastos = i_gastos.Count;
                                txt_vgasto.Text = string.Format("{0:C}", i_gastos.Count);
                            }
                            else
                            {
                                dml_gastos = double.Parse(i_gastos.Sum(x => x.monto).ToString());

                            }

                        }

                        using (db_liecEntities edm_gastos = new db_liecEntities())
                        {
                            var i_gastos = (from i_g in edm_gastos.inf_caja
                                            where i_g.id_rubro == guid_idrubro

                                            select new
                                            {
                                                i_g.monto,

                                            }).ToList();

                            if (i_gastos.Count == 0)
                            {
                                dml_caja = i_gastos.Count;
                                txt_vgasto.Text = string.Format("{0:C}", i_gastos.Count);
                            }
                            else
                            {
                                dml_caja = double.Parse(i_gastos.Sum(x => x.monto).ToString());

                            }

                        }

                        txt_vgasto.Text = string.Format("{0:C}", (Math.Truncate(Convert.ToDouble(dml_gastos + dml_caja) * 100.0) / 100.0));


                        if (int_idtipousuario == 2)
                        {
                            txt_pextra_rubro.Enabled = true;
                            rfv_pextra_rubro.Enabled = true;
                        }
                        else
                        {
                            txt_pextra_rubro.Enabled = false;
                            rfv_pextra_rubro.Enabled = false;
                        }
                        rfv_etiqueta_r.Enabled = true;
                        rfv_desc_rubro.Enabled = true;
                        rfv_tipo_rubro.Enabled = true;
                        rfv_pfijo_rubro.Enabled = true;
                        rfv_minimo_rubro.Enabled = true;
                        rfv_minimo_rubro.Enabled = true;
                        
                    }
                    else
                    {
                        row.BackColor = Color.White;
                    }
                }
            }
        }

        protected void btn_guardar_rubros_Click(object sender, EventArgs e)
        {
            if (int_accion_rubro == 0)
            {
                Mensaje("Favor de seleccionar una acción.");
            }
            else
            {
                Guid guid_idrubro;
                Guid guid_nrubro = Guid.NewGuid();
                int int_tiporubro = int.Parse(ddl_tipo_rubro.SelectedValue);
                string str_etiqueta = txt_etiqueta_r.Text.ToUpper();
                string str_descrubro = txt_desc_rubro.Text.ToUpper();
                double dbl_pfijo = double.Parse(txt_pfijo_rubro.Text);
                int in_minimo = int.Parse(txt_minimo_rubro.Text);
                int int_maximo = int.Parse(txt_maximo_rubro.Text);
                string str_codigorubro;

                if (int_accion_rubro == 1)
                {



                    using (db_liecEntities data_user = new db_liecEntities())
                    {
                        var items_user = (from c in data_user.inf_rubro
                                          select c).ToList();

                        if (items_user.Count == 0)
                        {
                            str_codigorubro = "liec_r" + string.Format("{0:000}", items_user.Count + 1);

                            using (var m_usuario = new db_liecEntities())
                            {
                                var i_usuario = new inf_rubro
                                {
                                    id_rubro = guid_nrubro,
                                    id_estatus = 1,
                                    codigo_rubro = str_codigorubro,
                                    id_tipo_rubro = int_tiporubro,
                                    etiqueta_rubro = str_etiqueta,
                                    rubro = str_descrubro,
                                    presupuesto = dbl_pfijo,
                                    minimo = in_minimo,
                                    maximo = int_maximo,
                                    presupuesto_extra = 0,
                                    fecha_registro = DateTime.Now,
                                    id_empresa = guid_fnegocio
                                };

                                m_usuario.inf_rubro.Add(i_usuario);
                                m_usuario.SaveChanges();
                            }

                            using (db_liecEntities edm_ctrl_montos = new db_liecEntities())
                            {
                                var i_ctrl_montos = (from c in edm_ctrl_montos.inf_rubro
                                                     where c.id_rubro == guid_nrubro
                                                     select c).ToList();

                                Guid guid_ctrl_montos = Guid.NewGuid();

                                if (i_ctrl_montos.Count == 0)
                                {
                                    using (var edm_ctrl_montosf = new db_liecEntities())
                                    {
                                        var i_ctrl_montosf = new inf_control_montos
                                        {
                                            id_control_monto = guid_ctrl_montos,
                                            id_rubro = guid_nrubro,
                                            id_tipo_rubro = int_tiporubro,
                                            monto = dbl_pfijo,
                                            fecha_registro = DateTime.Now,
                                        };

                                        edm_ctrl_montosf.inf_control_montos.Add(i_ctrl_montosf);
                                        edm_ctrl_montosf.SaveChanges();
                                    }
                                }
                                else
                                {
                                    using (var edm_ctrl_montosf = new db_liecEntities())
                                    {
                                        var i_ctrl_montosf = new inf_control_montos
                                        {
                                            id_control_monto = guid_ctrl_montos,
                                            id_rubro = guid_nrubro,
                                            id_tipo_rubro = int_tiporubro,
                                            monto = dbl_pfijo,
                                            fecha_registro = DateTime.Now,
                                        };

                                        edm_ctrl_montosf.inf_control_montos.Add(i_ctrl_montosf);
                                        edm_ctrl_montosf.SaveChanges();
                                    }

                                }
                            }


                            limpia_txt_rubros();
                            Mensaje("Datos agregados con éxito.");
                        }
                        else
                        {
                            str_codigorubro = "liec_r" + string.Format("{0:000}", items_user.Count + 1);

                            using (var m_usuario = new db_liecEntities())
                            {
                                var i_usuario = new inf_rubro
                                {
                                    id_rubro = guid_nrubro,
                                    id_estatus = 1,
                                    codigo_rubro = str_codigorubro,
                                    id_tipo_rubro = int_tiporubro,
                                    etiqueta_rubro = str_etiqueta,
                                    rubro = str_descrubro,
                                    presupuesto = dbl_pfijo,
                                    minimo = in_minimo,
                                    maximo = int_maximo,
                                    presupuesto_extra = 0,
                                    fecha_registro = DateTime.Now,
                                    id_empresa = guid_fnegocio
                                };

                                m_usuario.inf_rubro.Add(i_usuario);
                                m_usuario.SaveChanges();
                            }

                            using (db_liecEntities edm_ctrl_montos = new db_liecEntities())
                            {
                                var i_ctrl_montos = (from c in edm_ctrl_montos.inf_rubro
                                                     where c.id_rubro == guid_nrubro
                                                     select c).ToList();

                                Guid guid_ctrl_montos = Guid.NewGuid();

                                if (i_ctrl_montos.Count == 0)
                                {
                                    using (var edm_ctrl_montosf = new db_liecEntities())
                                    {
                                        var i_ctrl_montosf = new inf_control_montos
                                        {
                                            id_control_monto = guid_ctrl_montos,
                                            id_rubro = guid_nrubro,
                                            id_tipo_rubro = int_tiporubro,
                                            monto = dbl_pfijo,
                                            fecha_registro = DateTime.Now,
                                        };

                                        edm_ctrl_montosf.inf_control_montos.Add(i_ctrl_montosf);
                                        edm_ctrl_montosf.SaveChanges();
                                    }
                                }
                                else
                                {
                                    using (var edm_ctrl_montosf = new db_liecEntities())
                                    {
                                        var i_ctrl_montosf = new inf_control_montos
                                        {
                                            id_control_monto = guid_ctrl_montos,
                                            id_tipo_rubro = int_tiporubro,
                                            id_rubro = guid_nrubro,
                                            monto = dbl_pfijo,
                                            fecha_registro = DateTime.Now,
                                        };

                                        edm_ctrl_montosf.inf_control_montos.Add(i_ctrl_montosf);
                                        edm_ctrl_montosf.SaveChanges();
                                    }

                                }
                            }

                            limpia_txt_rubros();

                            Mensaje("Datos agregados con éxito.");

                        }
                    }
                }
                else if (int_accion_rubro == 2)
                {
                    foreach (GridViewRow row in gv_rubros.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chk_rubros") as CheckBox);
                            if (chkRow.Checked)
                            {
                                row.BackColor = Color.FromArgb(224, 153, 123);
                                string codeuser = row.Cells[1].Text;

                                using (db_liecEntities data_user = new db_liecEntities())
                                {
                                    var items_user = (from c in data_user.inf_rubro
                                                      where c.codigo_rubro == codeuser
                                                      select c).FirstOrDefault();

                                    guid_idrubro = items_user.id_rubro;
                                }

                                double dbl_pextra = double.Parse(txt_pextra_rubro.Text);




                                using (var m_fempresa = new db_liecEntities())
                                {
                                    var i_fempresa = (from c in m_fempresa.inf_rubro
                                                      where c.id_rubro == guid_idrubro
                                                      select c).FirstOrDefault();


                                    //i_fempresa.id_estatus = int_estatusrubro;
                                    i_fempresa.id_tipo_rubro = int_tiporubro;
                                    i_fempresa.rubro = str_descrubro;
                                    i_fempresa.presupuesto = dbl_pfijo;
                                    i_fempresa.presupuesto_extra = dbl_pextra;
                                    i_fempresa.minimo = in_minimo;
                                    i_fempresa.maximo = int_maximo;
                                    m_fempresa.SaveChanges();
                                }


                                if (dbl_pextra == 0)
                                {
                                    using (var m_fempresa = new db_liecEntities())
                                    {
                                        var i_fempresa = (from c in m_fempresa.inf_control_montos
                                                          where c.id_rubro == guid_idrubro
                                                          select c).FirstOrDefault();


                                        
                                        i_fempresa.monto = dbl_pfijo;
                                      
                                        m_fempresa.SaveChanges();
                                    }
                                }
                                else
                                {
                                    using (var m_fempresa = new db_liecEntities())
                                    {
                                        var i_fempresa = (from c in m_fempresa.inf_rubro
                                                          where c.id_rubro == guid_idrubro
                                                          select c).FirstOrDefault();



                                        i_fempresa.presupuesto = dbl_pfijo;
                                        i_fempresa.presupuesto_extra = dbl_pextra;

                                        m_fempresa.SaveChanges();
                                    }
                                    
                                }


                                limpia_txt_rubros();

                                using (db_liecEntities data_user = new db_liecEntities())
                                {
                                    var inf_user = (from i_r in data_user.inf_rubro
                                                    join r_e in data_user.fact_estatus on i_r.id_estatus equals r_e.id_estatus
                                                    join t_r in data_user.fact_tipo_rubro on i_r.id_tipo_rubro equals t_r.id_tipo_rubro
                                                    select new
                                                    {
                                                        i_r.codigo_rubro,
                                                        r_e.desc_estatus,
                                                        t_r.tipo_rubro,
                                                        i_r.etiqueta_rubro,
                                                        i_r.rubro,
                                                        i_r.fecha_registro

                                                    }).ToList();

                                    gv_rubros.DataSource = inf_user;
                                    gv_rubros.DataBind();
                                    gv_rubros.Visible = true;
                                }
                                Mensaje("Datos actualizados con éxito.");
                            }
                            else
                            {
                                row.BackColor = Color.White;
                            }
                        }
                    }



                }
                else if (int_accion_rubro == 3)
                {

                }

            }
        }

        protected void gv_rubros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_rubros.PageIndex = e.NewPageIndex;

            using (db_liecEntities data_user = new db_liecEntities())
            {
                var inf_user = (from i_r in data_user.inf_rubro
                                join r_e in data_user.fact_estatus on i_r.id_estatus equals r_e.id_estatus
                                join t_r in data_user.fact_tipo_rubro on i_r.id_tipo_rubro equals t_r.id_tipo_rubro
                                select new
                                {
                                    i_r.codigo_rubro,
                                    i_r.etiqueta_rubro,
                                    r_e.desc_estatus,
                                    t_r.tipo_rubro,
                                    i_r.rubro,
                                    i_r.fecha_registro

                                }).ToList();

                gv_rubros.DataSource = inf_user;
                gv_rubros.DataBind();
                gv_rubros.Visible = true;
            }
        }
        #endregion

        #region usuarios
        protected void chkbox_agregar_u_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_agregar_u.Checked)
            {
                int_accion_usuario = 1;

                limpia_txt_usuarios();

                chkbox_editar_u.Checked = false;

                gv_usuarios.Visible = false;

                ddl_perfil.Enabled = false;
                chkb_activar_usuario.Enabled = false;


            }
            else
            {
                int_accion_usuario = 0;
                chkbox_editar_u.Checked = false;

                rfv_nombres_usuario.Enabled = false;
                rfv_apaterno_usuario.Enabled = false;
                rfv_amaterno_usuario.Enabled = false;
                rfv_usuario_usuario.Enabled = false;
                rfv_clave_usuario.Enabled = false;
            }
        }

        protected void chkbox_editar_u_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_editar_u.Checked)
            {
                int_accion_usuario = 2;


                limpia_txt_usuarios();

                chkbox_agregar_u.Checked = false;

                gv_usuarios.Visible = false;
                ddl_perfil.Enabled = true;
                chkb_activar_usuario.Enabled = true;


            }
            else
            {
                int_accion_usuario = 0;
                chkbox_agregar_u.Checked = false;

                rfv_nombres_usuario.Enabled = false;
                rfv_apaterno_usuario.Enabled = false;
                rfv_amaterno_usuario.Enabled = false;
                rfv_usuario_usuario.Enabled = false;
                rfv_clave_usuario.Enabled = false;
            }
        }


        protected void chkb_administrador_CheckedChanged(object sender, EventArgs e)
        {
            if (chkb_administrador.Checked == true)
            {

                rfv_nombres_usuario.Enabled = true;
                rfv_apaterno_usuario.Enabled = true;
                rfv_amaterno_usuario.Enabled = true;
                rfv_usuario_usuario.Enabled = true;
                rfv_clave_usuario.Enabled = true;

                chkb_ejecutivo.Checked = false;
                chkb_invitado.Checked = false;

                if (filtro_usuario() == 0)
                {
                    Mensaje("Favor de seleccionar un perfil.");
                }
                else
                {
                    if (int_accion_usuario == 2)
                    {
                        grid_usuarios(int_tipousuario);


                        ddl_perfil.Items.Clear();
                        using (db_liecEntities m_genero = new db_liecEntities())
                        {
                            var i_genero = (from f_tr in m_genero.fact_tipo_usuario
                                            where f_tr.id_tipo_usuario != 1
                                            where f_tr.id_tipo_usuario != 2
                                            select f_tr).ToList();

                            ddl_perfil.DataSource = i_genero;
                            ddl_perfil.DataTextField = "desc_tipo_usuario";
                            ddl_perfil.DataValueField = "id_tipo_usuario";
                            ddl_perfil.DataBind();
                        }
                        ddl_perfil.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
                    }

                }
            }
            else
            {
                limpia_txt_usuarios();
            }

        }
        protected void chkb_ejecutivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkb_ejecutivo.Checked == true)
            {
                rfv_nombres_usuario.Enabled = true;
                rfv_apaterno_usuario.Enabled = true;
                rfv_amaterno_usuario.Enabled = true;
                rfv_usuario_usuario.Enabled = true;
                rfv_clave_usuario.Enabled = true;

                chkb_administrador.Checked = false;
                chkb_invitado.Checked = false;

                if (filtro_usuario() == 0)
                {
                    Mensaje("Favor de seleccionar perfil.");

                }
                else
                {

                    if (int_accion_usuario == 2)
                    {
                        grid_usuarios(int_tipousuario);
                        ddl_perfil.Items.Clear();
                        using (db_liecEntities m_genero = new db_liecEntities())
                        {
                            var i_genero = (from f_tr in m_genero.fact_tipo_usuario
                                            where f_tr.id_tipo_usuario != 1
                                            where f_tr.id_tipo_usuario != 3
                                            select f_tr).ToList();

                            ddl_perfil.DataSource = i_genero;
                            ddl_perfil.DataTextField = "desc_tipo_usuario";
                            ddl_perfil.DataValueField = "id_tipo_usuario";
                            ddl_perfil.DataBind();
                        }
                        ddl_perfil.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
                    }
                }
            }
            else
            {
                limpia_txt_usuarios();
            }

        }
        protected void chkb_invitado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkb_invitado.Checked == true)
            {
                rfv_nombres_usuario.Enabled = true;
                rfv_apaterno_usuario.Enabled = true;
                rfv_amaterno_usuario.Enabled = true;
                rfv_usuario_usuario.Enabled = true;
                rfv_clave_usuario.Enabled = true;

                chkb_administrador.Checked = false;
                chkb_ejecutivo.Checked = false;

                if (filtro_usuario() == 0)
                {
                    Mensaje("Favor de seleccionar perfil.");
                }
                else
                {

                    if (int_accion_usuario == 2)
                    {
                        grid_usuarios(int_tipousuario);
                        ddl_perfil.Items.Clear();
                        using (db_liecEntities m_genero = new db_liecEntities())
                        {
                            var i_genero = (from f_tr in m_genero.fact_tipo_usuario
                                            where f_tr.id_tipo_usuario != 1
                                            where f_tr.id_tipo_usuario != 4
                                            select f_tr).ToList();

                            ddl_perfil.DataSource = i_genero;
                            ddl_perfil.DataTextField = "desc_tipo_usuario";
                            ddl_perfil.DataValueField = "id_tipo_usuario";
                            ddl_perfil.DataBind();
                        }
                        ddl_perfil.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
                    }
                }
            }
            else
            {
                limpia_txt_usuarios();
            }
        }
        protected void btn_guardar_usuario_Click(object sender, EventArgs e)
        {
            if (int_accion_usuario == 0)
            {
                Mensaje("Favor de seleccionar un acción.");
            }
            else
            {
                if (filtro_usuario() == 0)
                {
                    Mensaje("Favor de seleccionar un perfil.");
                }
                else
                {

                    guarda_registro_usuario();
                }
            }
        }

        protected void gv_usuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_usuarios.PageIndex = e.NewPageIndex;
            grid_usuarios(int_tipousuario);
        }



        protected void chk_usuario_CheckedChanged(object sender, EventArgs e)
        {
            Guid id_fuser;
            foreach (GridViewRow row in gv_usuarios.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_usuario") as CheckBox);
                    if (chkRow.Checked)
                    {
                        row.BackColor = Color.FromArgb(224, 153, 123);
                        string codeuser = row.Cells[1].Text;

                        using (db_liecEntities data_user = new db_liecEntities())
                        {
                            var items_user = (from c in data_user.inf_usuarios
                                              where c.codigo_usuario == codeuser
                                              select c).FirstOrDefault();

                            id_fuser = items_user.id_usuario;
                        }

                        using (db_liecEntities data_user = new db_liecEntities())
                        {
                            var inf_user = (from u in data_user.inf_usuarios
                                            where u.id_usuario == id_fuser
                                            select new
                                            {

                                                u.nombres,
                                                u.a_paterno,
                                                u.a_materno,

                                                u.fecha_nacimiento,
                                                u.codigo_usuario,
                                                u.clave

                                            }).FirstOrDefault();


                            txt_nombres_usuario.Text = inf_user.nombres;
                            txt_apaterno_usuario.Text = inf_user.a_paterno;
                            txt_amaterno_usuario.Text = inf_user.a_materno;


                            txt_usuario_usuario.Text = inf_user.codigo_usuario;
                            txt_clave_usuario.Text = inf_user.clave;
                        }

                    }
                    else
                    {
                        row.BackColor = Color.White;
                    }
                }
            }
        }
        private void grid_usuarios(int idtipousuario)
        {
            using (db_liecEntities data_user = new db_liecEntities())
            {
                var inf_user = (from i_u in data_user.inf_usuarios
                                join i_e in data_user.fact_estatus on i_u.id_estatus equals i_e.id_estatus
                                where i_u.id_tipo_usuario == idtipousuario
                                where i_u.id_usuario != guid_iduser


                                select new
                                {
                                    i_u.codigo_usuario,
                                    i_e.desc_estatus,

                                    i_u.nombres,
                                    i_u.a_paterno,
                                    i_u.a_materno,
                                    i_u.fecha_registro

                                }).ToList();

                gv_usuarios.DataSource = inf_user;
                gv_usuarios.DataBind();
                gv_usuarios.Visible = true;
            }
        }
        protected void btn_genera_usuario_Click(object sender, EventArgs e)
        {
            if (int_tipousuario == 0)
            {
                Mensaje("Favor de seleccionar perfil.");
            }
            else
            {

                genera_usuario();

            }


        }

        protected void chk_correo_recepcion_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gv_correo_recepcion.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_correo_recepcion") as CheckBox);
                    if (chkRow.Checked)
                    {
                        row.BackColor = Color.FromArgb(224, 153, 123);
                        string codeuser = row.Cells[1].Text;


                        using (db_liecEntities data_user = new db_liecEntities())
                        {
                            var inf_user = (from u in data_user.inf_email_recepcion
                                            where u.email_recepcion == codeuser
                                            select new
                                            {
                                                u.email_recepcion

                                            }).FirstOrDefault();


                            txt_correo_recepcion.Text = inf_user.email_recepcion;
                        }
                    }
                    else
                    {
                        row.BackColor = Color.White;
                    }
                }
            }
        }

        private void guarda_registro_usuario()
        {
            Guid guid_fusuario;
            Guid guid_nusuario = Guid.NewGuid();

            string str_nombres = txt_nombres_usuario.Text.ToUpper();
            string str_apaterno = txt_apaterno_usuario.Text.ToUpper();
            string str_amaterno = txt_amaterno_usuario.Text.ToUpper();

            string str_usuario = txt_usuario_usuario.Text;
            string str_password = encriptar.Encrypt(txt_clave_usuario.Text);

            if (int_accion_usuario == 1)
            {
                using (db_liecEntities data_user = new db_liecEntities())
                {
                    var items_user = (from c in data_user.inf_usuarios
                                      where c.codigo_usuario == str_usuario
                                      select c).ToList();

                    if (items_user.Count == 0)
                    {

                        using (var m_usuario = new db_liecEntities())
                        {
                            var i_usuario = new inf_usuarios
                            {
                                id_usuario = guid_nusuario,

                                id_estatus = 1,

                                id_tipo_usuario = int_tipousuario,
                                nombres = str_nombres,
                                a_paterno = str_apaterno,
                                a_materno = str_amaterno,
                                codigo_usuario = str_usuario,
                                clave = str_password,
                                fecha_registro = DateTime.Now,
                                id_empresa = guid_fnegocio
                            };
                            m_usuario.inf_usuarios.Add(i_usuario);
                            m_usuario.SaveChanges();
                        }


                        int_accion_usuario = 0;
                        limpia_txt_usuarios();


                        Mensaje("Datos agregados con éxito.");
                        lblModalTitle.Text = "LIEC";
                        lblModalBody.Text = "Datos de usuario agregados con éxito";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                        upModal.Update();
                    }
                    else
                    {
                        Mensaje("Usuario ya existe en la base de datos, favor de reintentar.");

                    }
                }

            }
            else if (int_accion_usuario == 2)
            {
                int int_perfil;


                if (ddl_perfil.SelectedValue == "0")
                {

                    using (db_liecEntities data_user = new db_liecEntities())
                    {
                        var items_user = (from c in data_user.inf_usuarios
                                          where c.codigo_usuario == str_usuario
                                          select c).ToList();

                        int_perfil = int.Parse(items_user[0].id_tipo_usuario.ToString());
                    }
                }
                else
                {
                    int_perfil = int.Parse(ddl_perfil.SelectedValue);
                }

                int int_activar;

                if (chkb_activar_usuario.Checked == true)
                {
                    int_activar = 3;
                }
                else
                {
                    int_activar = 1;
                }
                foreach (GridViewRow row in gv_usuarios.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chk_usuario") as CheckBox);
                        if (chkRow.Checked)
                        {
                            row.BackColor = Color.FromArgb(224, 153, 123);
                            string codeuser = row.Cells[1].Text;

                            if (codeuser == str_usuario)
                            {
                                using (db_liecEntities data_user = new db_liecEntities())
                                {
                                    var items_user = (from c in data_user.inf_usuarios
                                                      where c.codigo_usuario == codeuser
                                                      select c).FirstOrDefault();

                                    guid_fusuario = items_user.id_usuario;
                                }
                                using (var data_user = new db_liecEntities())
                                {
                                    var items_user = (from c in data_user.inf_usuarios
                                                      where c.id_usuario == guid_fusuario
                                                      select c).FirstOrDefault();

                                    items_user.id_estatus = int_activar;

                                    items_user.nombres = str_nombres;
                                    items_user.a_paterno = str_apaterno;
                                    items_user.a_materno = str_amaterno;

                                    items_user.id_tipo_usuario = int_perfil;
                                    items_user.codigo_usuario = str_usuario;
                                    items_user.clave = str_password;

                                    data_user.SaveChanges();
                                }

                                limpia_txt_usuarios();


                                Mensaje("Datos actualizados con éxito.");
                            }
                            else
                            {
                                using (db_liecEntities data_user = new db_liecEntities())
                                {
                                    var items_user = (from c in data_user.inf_usuarios
                                                      where c.codigo_usuario == str_usuario
                                                      select c).ToList();

                                    if (items_user.Count == 0)
                                    {
                                        using (db_liecEntities data_userf = new db_liecEntities())
                                        {
                                            var items_userf = (from c in data_userf.inf_usuarios
                                                               where c.codigo_usuario == codeuser
                                                               select c).FirstOrDefault();

                                            guid_fusuario = items_userf.id_usuario;
                                        }
                                        using (var data_userff = new db_liecEntities())
                                        {
                                            var items_userff = (from c in data_userff.inf_usuarios
                                                                where c.id_usuario == guid_fusuario
                                                                select c).FirstOrDefault();

                                            items_userff.nombres = str_nombres;
                                            items_userff.a_paterno = str_apaterno;
                                            items_userff.a_materno = str_amaterno;
                                            items_userff.id_tipo_usuario = int_tipousuario;
                                            items_userff.codigo_usuario = str_usuario;
                                            items_userff.clave = str_password;
                                            data_userff.SaveChanges();
                                        }

                                        limpia_txt_usuarios();


                                        Mensaje("Usuario ya existe en la base de datos, favor de reintentar.");

                                    }
                                    else
                                    {
                                        Mensaje("Datos agregados con éxito.");

                                    }
                                }
                            }


                        }
                        else
                        {
                            row.BackColor = Color.White;
                        }
                    }
                }
            }
            else if (int_accion_usuario == 3)
            {
                foreach (GridViewRow row in gv_usuarios.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chk_usuario") as CheckBox);
                        if (chkRow.Checked)
                        {
                            row.BackColor = Color.FromArgb(224, 153, 123);
                            string codeuser = row.Cells[1].Text;

                            using (db_liecEntities data_user = new db_liecEntities())
                            {
                                var items_user = (from c in data_user.inf_usuarios
                                                  where c.codigo_usuario == codeuser
                                                  select c).FirstOrDefault();

                                guid_fusuario = items_user.id_usuario;
                            }
                            using (var data_user = new db_liecEntities())
                            {
                                var items_user = (from c in data_user.inf_usuarios
                                                  where c.id_usuario == guid_fusuario
                                                  select c).FirstOrDefault();

                                items_user.id_estatus = 3;

                                data_user.SaveChanges();
                            }
                            int_accion_usuario = 0;
                            limpia_txt_usuarios();

                            grid_usuarios(int_tipousuario);



                            Mensaje("Usuario dado de baja con éxito.");

                        }
                        else
                        {
                            row.BackColor = Color.White;
                        }
                    }
                }
            }
        }




        private void genera_usuario()
        {
            try
            {
                int nombres_count = txt_nombres_usuario.Text.Split(' ').Count();
                string str_nombres = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_nombres_usuario.Text.ToLower()));
                string[] separados;

                separados = str_nombres.Split(" ".ToArray());
                int count = separados.Count();

                string str_apaterno = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_apaterno_usuario.Text.ToLower()));
                string str_amaterno = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_amaterno_usuario.Text.ToLower()));

                string codigo_usuario = str_nombres + "_" + left_right_mid.left(str_apaterno, 2) + left_right_mid.left(str_amaterno, 2);
                txt_usuario_usuario.Text = codigo_usuario;
            }
            catch
            {
                Mensaje("Se requiere minimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario.");
            }
        }



        public int filtro_usuario()
        {
            if (chkb_administrador.Checked)
            {
                int_tipousuario = 2;
                return 2;
            }

            else if (chkb_ejecutivo.Checked)
            {
                int_tipousuario = 3;
                return 3;
            }
            else if (chkb_invitado.Checked)
            {
                int_tipousuario = 4;
                return 3;
            }
            else
            {
                return 0;
            }
        }

        private void limpia_txt_usuarios()
        {


            ddl_perfil.Items.Clear();
            using (db_liecEntities m_genero = new db_liecEntities())
            {
                var i_genero = (from f_tr in m_genero.fact_tipo_usuario
                                where f_tr.id_tipo_usuario != 1

                                select f_tr).ToList();

                ddl_perfil.DataSource = i_genero;
                ddl_perfil.DataTextField = "desc_tipo_usuario";
                ddl_perfil.DataValueField = "id_tipo_usuario";
                ddl_perfil.DataBind();
            }
            ddl_perfil.Items.Insert(0, new ListItem("SELECCIONAR", "0"));

            txt_nombres_usuario.Text = null;
            txt_apaterno_usuario.Text = null;
            txt_amaterno_usuario.Text = null;
            txt_usuario_usuario.Text = null;
            txt_clave_usuario.Text = null;


            gv_usuarios.Visible = false;

            chkb_administrador.Checked = false;

            chkb_ejecutivo.Checked = false;

            chkb_invitado.Checked = false;

            chkb_activar_usuario.Checked = false;


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
        #endregion

        #region correos
        protected void chkbox_agregar_ce_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_agregar_ce.Checked)
            {
                chkbox_editar_ce.Checked = false;


                rfv_correo_envio.Enabled = true;
                rfv_asunto_envio.Enabled = true;
                rfv_usuario_envio.Enabled = true;
                rfv_servidor_smtp.Enabled = true;
                rfv_clave_envio.Enabled = true;
                rfv_puerto_envio.Enabled = true;

                int_accion_email_envio = 1;


            }
            else
            {
                chkbox_editar_ce.Checked = false;


                rfv_correo_envio.Enabled = false;
                rfv_asunto_envio.Enabled = false;
                rfv_usuario_envio.Enabled = false;
                rfv_servidor_smtp.Enabled = false;
                rfv_clave_envio.Enabled = false;
                rfv_puerto_envio.Enabled = false;
            }
        }

 
        protected void chkbox_editar_ce_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_editar_ce.Checked)
            {
                chkbox_agregar_ce.Checked = false;


                rfv_correo_envio.Enabled = true;
                rfv_asunto_envio.Enabled = true;
                rfv_usuario_envio.Enabled = true;
                rfv_servidor_smtp.Enabled = true;
                rfv_clave_envio.Enabled = true;
                rfv_puerto_envio.Enabled = true;

                int_accion_email_envio = 2;

                using (db_liecEntities edm_email = new db_liecEntities())
                {
                    var i_email = (from c in edm_email.inf_email_envio
                                   select c).ToList();
                    if (i_email.Count == 0)
                    {

                    }
                    else
                    {
                        txt_correo_envio.Text = i_email[0].email;
                        txt_usuario_envio.Text = i_email[0].usuario;
                        txt_clave_envio.Text = i_email[0].clave;
                        txt_asunto_envio.Text = i_email[0].asunto;
                        txt_servidor_smtp.Text = i_email[0].servidor_smtp;
                        txt_puerto_envio.Text = i_email[0].puerto.ToString();
                    }
                }
            }
            else
            {
                chkbox_agregar_ce.Checked = false;


                rfv_correo_envio.Enabled = false;
                rfv_asunto_envio.Enabled = false;
                rfv_usuario_envio.Enabled = false;
                rfv_servidor_smtp.Enabled = false;
                rfv_clave_envio.Enabled = false;
                rfv_puerto_envio.Enabled = false;
            }
        }
        private void limpia_txt_correos()
        {
            txt_correo_envio.Text = null;
            txt_usuario_envio.Text = null;
            txt_clave_envio.Text = null;
            txt_asunto_envio.Text = null;
            txt_servidor_smtp.Text = null;
            txt_puerto_envio.Text = null;
        }
        protected void btn_guardar_envio_Click(object sender, EventArgs e)
        {
            if (chkbox_agregar_ce.Checked || chkbox_editar_ce.Checked)
            {
                Guid guid_ncorreoenvio = Guid.NewGuid();
                string str_correoenvio = txt_correo_envio.Text;
                string str_usuarioenvio = txt_usuario_envio.Text;
                string str_claveenvio = encriptar.Encrypt(txt_clave_envio.Text);
                string str_asunto = txt_asunto_envio.Text;
                string str_svrsmtp = txt_servidor_smtp.Text;
                int str_puertoenvio = int.Parse(txt_puerto_envio.Text);

                Guid guid_fcorreoenvio;

                if (int_accion_email_envio == 1)
                {
                    using (db_liecEntities data_user = new db_liecEntities())
                    {
                        var items_user = (from c in data_user.inf_email_envio
                                          where c.email == str_correoenvio
                                          select c).ToList();

                        if (items_user.Count == 0)
                        {
                            using (var m_usuario = new db_liecEntities())
                            {
                                var i_usuario = new inf_email_envio
                                {
                                    id_email_envio = guid_ncorreoenvio,
                                    id_estatus = 1,
                                    email = str_correoenvio,
                                    usuario = str_usuarioenvio,
                                    clave = str_claveenvio,
                                    asunto = str_asunto,
                                    servidor_smtp = str_svrsmtp,
                                    puerto = str_puertoenvio,
                                    fecha_registro = DateTime.Now,
                                    id_empresa = guid_fnegocio
                                };

                                m_usuario.inf_email_envio.Add(i_usuario);
                                m_usuario.SaveChanges();
                            }

                            int_accion_email_envio = 1;

                            limpia_txt_correos();
                            Mensaje("Datos agregados con éxito");

                        }
                        else
                        {
                            Mensaje("Correo ya existe en la base de datos, favor de reintentar o editar información");
                        }
                    }
                }
                else if (int_accion_email_envio == 2)
                {
                    using (var m_fusuarioff = new db_liecEntities())
                    {
                        var i_fusuarioff = (from c in m_fusuarioff.inf_email_envio
                                            select c).FirstOrDefault();

                        guid_fcorreoenvio = i_fusuarioff.id_email_envio;
                    }

                    using (var m_fusuarioff = new db_liecEntities())
                    {
                        var i_fusuarioff = (from c in m_fusuarioff.inf_email_envio
                                            where c.id_email_envio == guid_fcorreoenvio
                                            select c).FirstOrDefault();

                        i_fusuarioff.email = str_correoenvio;
                        i_fusuarioff.usuario = str_usuarioenvio;
                        i_fusuarioff.clave = str_claveenvio;
                        i_fusuarioff.asunto = str_asunto;
                        i_fusuarioff.servidor_smtp = str_svrsmtp;
                        i_fusuarioff.puerto = str_puertoenvio;

                        m_fusuarioff.SaveChanges();

                    }
                    Mensaje("Datos actualizados con éxito");
                }
                else if (int_accion_email_envio == 3)
                {
                    using (var m_fusuarioff = new db_liecEntities())
                    {
                        var i_fusuarioff = (from c in m_fusuarioff.inf_email_envio
                                            select c).FirstOrDefault();

                        guid_fcorreoenvio = i_fusuarioff.id_email_envio;
                    }

                    using (var m_fusuarioff = new db_liecEntities())
                    {
                        var i_fusuarioff = (from c in m_fusuarioff.inf_email_envio
                                            where c.id_email_envio == guid_fcorreoenvio
                                            select c).FirstOrDefault();

                        i_fusuarioff.id_estatus = 3;

                        m_fusuarioff.SaveChanges();
                    }
                    Mensaje("Datos de baja con éxito");
                }
            }
            else
            {
                Mensaje("Favor de activar la edición de los datos");
            }


        }
        protected void chkbox_agregar_cr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_agregar_cr.Checked)
            {
                int_accion_email_recepcion = 1;

                chkbox_editar_cr.Checked = false;
                chkb_estatus_recepcion.Visible = false;
                gv_correo_recepcion.Visible = false;
                txt_correo_recepcion.Text = null;

                rfv_correo_recepcion.Enabled = true;
            }
            else
            {
                chkbox_editar_cr.Checked = false;
                rfv_correo_recepcion.Enabled = false;
            }

        }

        protected void chkbox_editar_cr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_editar_cr.Checked)
            {
                chkbox_agregar_cr.Checked = false;
                using (var edm_email = new db_liecEntities())
                {
                    var i_email = (from c in edm_email.inf_email_recepcion
                                   select c).ToList();

                    if (i_email.Count == 0)
                    {
                        Mensaje("Sin datos de correo para recepción, favor de agregar");
                        rfv_correo_recepcion.Enabled = false;

                    }
                    else
                    {
                        int_accion_email_recepcion = 2;

                        chkbox_agregar_cr.Checked = false;
                        chkb_estatus_recepcion.Visible = true;
                        txt_correo_recepcion.Text = null;

                        using (db_liecEntities data_user = new db_liecEntities())
                        {
                            var inf_user = (from u in data_user.inf_email_recepcion
                                            join i_tu in data_user.fact_estatus on u.id_estatus equals i_tu.id_estatus
                                            select new
                                            {
                                                u.email_recepcion,
                                                i_tu.desc_estatus,
                                                u.fecha_registro

                                            }).ToList();

                            gv_correo_recepcion.DataSource = inf_user;
                            gv_correo_recepcion.DataBind();
                            gv_correo_recepcion.Visible = true;
                        }
                        rfv_correo_recepcion.Enabled = true;
                    }
                }
            }
            else
            {
                chkbox_agregar_cr.Checked = false;
                chkb_estatus_recepcion.Visible = false;
                chkb_estatus_recepcion.Checked = false;
                gv_correo_recepcion.Visible = false;
                txt_correo_recepcion.Text = null;

                rfv_correo_recepcion.Enabled = false;
            }
        }

        protected void btn_guardar_recepcion_Click(object sender, EventArgs e)
        {
            Guid guid_ncorreorecepcion = Guid.NewGuid();
            string str_correorecepcion = txt_correo_recepcion.Text;

            if (int_accion_email_recepcion == 0)
            {
                Mensaje("Favor de activar la edición de los datos");
            }
            else
            {
                if (int_accion_email_recepcion == 1)
                {
                    using (db_liecEntities data_user = new db_liecEntities())
                    {
                        var items_user = (from c in data_user.inf_email_recepcion
                                          where c.email_recepcion == str_correorecepcion
                                          select c).ToList();

                        if (items_user.Count == 0)
                        {
                            using (var m_usuario = new db_liecEntities())
                            {
                                var i_usuario = new inf_email_recepcion
                                {
                                    id_email_recepcion = guid_ncorreorecepcion,
                                    id_estatus = 1,
                                    email_recepcion = str_correorecepcion,
                                    fecha_registro = DateTime.Now,
                                    id_empresa = guid_fnegocio
                                };

                                m_usuario.inf_email_recepcion.Add(i_usuario);
                                m_usuario.SaveChanges();
                            }

                            int_accion_email_envio = 1;

                            txt_correo_recepcion.Text = null;

                            Mensaje("Datos agregados con éxito");
                        }
                        else
                        {
                            Mensaje("Correo ya existe en la base de datos, favor de reintentar o editar información");
                        }
                    }
                }
                else if (int_accion_email_recepcion == 2)
                {

                    int int_estatus_recepcion;

                    if (chkb_estatus_recepcion.Checked == true)
                    {
                        int_estatus_recepcion = 3;
                    }
                    else
                    {
                        int_estatus_recepcion = 1;
                    }

                    foreach (GridViewRow row in gv_correo_recepcion.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chk_correo_recepcion") as CheckBox);
                            if (chkRow.Checked)
                            {
                                row.BackColor = Color.FromArgb(224, 153, 123);
                                string codeuser = row.Cells[1].Text;


                                using (var m_fusuarioff = new db_liecEntities())
                                {
                                    var i_fusuarioff = (from c in m_fusuarioff.inf_email_recepcion
                                                        where c.email_recepcion == codeuser
                                                        select c).FirstOrDefault();

                                    i_fusuarioff.email_recepcion = str_correorecepcion;
                                    i_fusuarioff.id_estatus = int_estatus_recepcion;
                                    m_fusuarioff.SaveChanges();

                                }

                                using (db_liecEntities data_user = new db_liecEntities())
                                {
                                    var inf_user = (from u in data_user.inf_email_recepcion
                                                    join i_tu in data_user.fact_estatus on u.id_estatus equals i_tu.id_estatus
                                                    select new
                                                    {
                                                        u.email_recepcion,
                                                        i_tu.desc_estatus,
                                                        u.fecha_registro

                                                    }).ToList();

                                    gv_correo_recepcion.DataSource = inf_user;
                                    gv_correo_recepcion.DataBind();
                                    gv_correo_recepcion.Visible = true;
                                }

                                txt_correo_recepcion.Text = null;
                                Mensaje("Datos actualizados con éxito");
                            }
                            else
                            {
                                row.BackColor = Color.White;
                            }
                        }
                    }
                }
                else if (int_accion_email_recepcion == 3)
                {
                    foreach (GridViewRow row in gv_correo_recepcion.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chk_correo_recepcion") as CheckBox);
                            if (chkRow.Checked)
                            {
                                row.BackColor = Color.FromArgb(224, 153, 123);
                                string codeuser = row.Cells[1].Text;


                                using (var m_fusuarioff = new db_liecEntities())
                                {
                                    var i_fusuarioff = (from c in m_fusuarioff.inf_email_recepcion
                                                        where c.email_recepcion == codeuser
                                                        select c).FirstOrDefault();

                                    i_fusuarioff.id_estatus = 3;
                                    m_fusuarioff.SaveChanges();

                                }

                                using (db_liecEntities data_user = new db_liecEntities())
                                {
                                    var inf_user = (from u in data_user.inf_email_recepcion

                                                    select new
                                                    {
                                                        u.email_recepcion,
                                                        u.fecha_registro

                                                    }).ToList();

                                    gv_correo_recepcion.DataSource = inf_user;
                                    gv_correo_recepcion.DataBind();
                                    gv_correo_recepcion.Visible = true;
                                }

                                txt_correo_recepcion.Text = null;
                                Mensaje("Datos de baja con éxito");
                            }
                            else
                            {
                                row.BackColor = Color.White;
                            }
                        }
                    }
                }


            }
        }
        #endregion


        private void enviarcorreo(string correo_e, string usuario_e, string clave_e, string asunto_e, string detale_e, string smtp_e, int puerto_e, DateTime registro_e, string correo_r, string trubro_e, string rubro_e, string monto_e, string usuario_reg)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(correo_r);


            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = asunto_e;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("destinatariocopia@servidordominio.com"); //Opcional

            //Cuerpo del Mensaje


            string str_table = @"
DETALLE: " + detale_e + @"
TIPO RUBRO: " + trubro_e + @"
RUBRO: " + rubro_e + @"
MONTO ASIGNADO: " + monto_e + @"
USUARIO REGISTRADO: " + usuario_reg + @"
FECHA: " + registro_e.ToShortDateString() + "";

            mmsg.Body = str_table;

            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress(correo_e);

            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential(usuario_e, clave_e);

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail

            cliente.Port = puerto_e;
            cliente.EnableSsl = true;

            cliente.Host = smtp_e; //Para Gmail "smtp.gmail.com";

            /*-------------------------ENVIO DE CORREO----------------------*/
            try
            {
                cliente.Send(mmsg);
                cliente.Dispose();
                Mensaje("Corre electrónico fue enviado satisfactoriamente.");
            }
            catch (Exception ex)
            {
                Mensaje("Error enviando correo electrónico: " + ex.Message);
            }

            //Enviamos el mensaje      
        


            
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