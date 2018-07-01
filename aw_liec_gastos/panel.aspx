<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="panel.aspx.cs" Inherits="aw_liec_gastos.panel" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="page-content">
        <div class="row">
            <div class="col-lg-12">
                <div class="sidebar content-box" style="display: block;">
                    <div class="text-right">
                        <p class="text-right">
                            <asp:Label CssClass="buttonClass" ID="lbl_bienvenida" runat="server" Text="BIENVENIDO@: "></asp:Label>
                            <asp:LinkButton CssClass="buttonClass" ID="lkb_edita_usuariof" runat="server" OnClick="lkb_edita_usuariof_Click">
                                <asp:Label CssClass="buttonClass" ID="lbl_edita_usuariof" runat="server" Text=""></asp:Label>&nbsp;<i class="glyphicon glyphicon-barcode" id="i_edita_usuariof" runat="server"></i>
                            </asp:LinkButton>
                            <br />
                            <asp:Label CssClass="buttonClass" ID="lbl_tipousuario" runat="server" Text="PERFIL: "></asp:Label>
                            <asp:Label CssClass="buttonClass" ID="lbl_ftipousuario" runat="server" Text=""></asp:Label>
                            <br />
                            <asp:Label CssClass="buttonClass" ID="lbl_fnegocio" runat="server" Text="EMPRESA: "></asp:Label>
                            <asp:LinkButton CssClass="buttonClass" ID="lkb_fnegocio" runat="server" OnClick="lkb_fnegocio_Click">
                                <asp:Label CssClass="buttonClass" ID="lbl_ffnegocio" runat="server" Text=""></asp:Label>&nbsp;<i class="glyphicon glyphicon-briefcase" id="i_editafnegocio" runat="server"></i>
                            </asp:LinkButton>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="sidebar-nav">
                    <div class="navbar-default" role="navigation">
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-navbar-collapse"><span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                            <span class="visible-xs navbar-brand">Menú</span>
                        </div>
                        <div class="navbar-collapse collapse sidebar-navbar-collapse">
                            <br />
                            <div class="sidebar content-box " style="display: block;">
                                <ul class="nav">
                                    <li>
                                        <asp:LinkButton CssClass="buttonClass" ID="lkb_resumen" runat="server" OnClick="lkb_resumen_Click">
                                            <i class="glyphicon glyphicon-equalizer" id="i_resumen" runat="server"></i>
                                            <asp:Label CssClass="buttonClass" ID="lbl_resumen" runat="server" Text="RESUMEN"> </asp:Label>
                                        </asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton CssClass="buttonClass" ID="lkb_gastos" runat="server" OnClick="lkb_gastos_Click">
                                            <i class="glyphicon glyphicon-tags" id="i_gastos" runat="server"></i>
                                            <asp:Label CssClass="buttonClass" ID="lbl_gastos" runat="server" Text="GASTOS"> </asp:Label>
                                        </asp:LinkButton>
                                    </li>

                                    <li>
                                        <asp:LinkButton CssClass="buttonClass" ID="lkb_caja" runat="server" OnClick="lkb_caja_Click">
                                            <i class="glyphicon glyphicon-inbox" id="i_caja" runat="server"></i>
                                            <asp:Label CssClass="buttonClass" ID="lbl_caja" runat="server" Text="CAJA"> </asp:Label>
                                        </asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton CssClass="buttonClass" ID="lkb_rubro" runat="server" OnClick="lkb_rubro_Click">
                                            <i class="glyphicon glyphicon-indent-left" id="i_rubro" runat="server"></i>
                                            <asp:Label CssClass="buttonClass" ID="lbl_rubro" runat="server" Text="RUBROS"> </asp:Label>
                                        </asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton CssClass="buttonClass" ID="lkb_usuarios" runat="server" OnClick="lkb_usuarios_Click">
                                            <i class="glyphicon glyphicon-user" id="i_usuarios" runat="server"></i>
                                            <asp:Label CssClass="buttonClass" ID="lbl_usuarios" runat="server" Text="USUARIOS"></asp:Label>
                                        </asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton CssClass="buttonClass" ID="lkb_correos" runat="server" OnClick="lkb_correos_Click">
                                            <i class="glyphicon glyphicon-envelope" id="i_correos" runat="server"></i>
                                            <asp:Label CssClass="buttonClass" ID="lbl_correos" runat="server" Text="CORREOS"> </asp:Label>
                                        </asp:LinkButton>
                                    </li>
                                    <br />
                                    <li>
                                        <asp:LinkButton CssClass="buttonClass" ID="lkb_salir" runat="server" OnClick="lkb_salir_Click">
                                            <i class="glyphicon glyphicon-off" id="i_salir" runat="server"></i>
                                            <asp:Label CssClass="buttonClass" ID="lbl_salir" runat="server" Text="SALIR"></asp:Label>
                                        </asp:LinkButton>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <!--/.nav-collapse -->
                </div>
            </div>
            <div class="col-lg-10">
                <div class="form-group has-error">
                    <asp:UpdatePanel ID="up_usuariof" runat="server">
                        <ContentTemplate>
                            <div class="panel panel-default" id="pnl_usuariof" runat="server" visible="false">
                                <div class="panel-heading">
                                    <h3 class="panel-title text-left">Datos de Administrador</h3>
                                    <h3 class="panel-title text-right">
                                        <asp:CheckBox ID="chkbox_edita_fusuario" runat="server" OnCheckedChanged="chkbox_edita_fusuario_CheckedChanged" AutoPostBack="true" Text="Editar" />
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_nombres_fusuario" runat="server" Text="*Nombre(s)"></asp:Label>
                                                </h5>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_nombres_fusuario" runat="server" placeholder="Capturar nombre(s)"></asp:TextBox>
                                                <div class="text-right">
                                                    <asp:RequiredFieldValidator ID="rfv_nombres_fusuario" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_nombres_fusuario" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_apaterno_fusuario" runat="server" Text="*Apellido Paterno"></asp:Label>
                                                </h5>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_apaterno_fusuario" runat="server" placeholder="Capturar apellido paterno"></asp:TextBox>
                                                <div class="text-right">
                                                    <asp:RequiredFieldValidator ID="rfv_apaterno_fusuario" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_apaterno_fusuario" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_amaterno_fusuario" runat="server" Text="*Apellido Materno"></asp:Label>
                                                </h5>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_amaterno_fusuario" runat="server" placeholder="Capturar apellido materno"></asp:TextBox>
                                                <div class="text-right">
                                                    <asp:RequiredFieldValidator ID="rfv_amaterno_fusuario" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_amaterno_fusuario" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_usuario_fusuario" runat="server" Text="*Usuario"></asp:Label>
                                                </h5>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_usuario_fusuario" runat="server" placeholder="Capturar usuario"></asp:TextBox>
                                                <div class="text-right">
                                                    <asp:RequiredFieldValidator ID="rfv_usuario_fusuario" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usuario_fusuario" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_clave_fusuario" runat="server" Text="*Contraseña"></asp:Label>
                                                </h5>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_clave_fusuario" runat="server" TextMode="Password" placeholder="Capturar contraseña"></asp:TextBox>
                                                <div class="text-right">
                                                    <asp:RequiredFieldValidator ID="rfv_clave_fusuario" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_clave_fusuario" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="text-right">
                                                    <br />
                                                    <asp:Button CssClass="btn" ID="btn_guarda_fusuario" runat="server" Text="GUARDAR" OnClick="btn_guarda_fusuario_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_fnegocio" runat="server">
                        <ContentTemplate>
                            <div class="panel panel-default" id="pnl_fnegocio" runat="server" visible="false">
                                <div class="panel-heading">
                                    <h3 class="panel-title text-left">Datos de Empresa</h3>
                                    <h3 class="panel-title text-right">
                                        <asp:CheckBox ID="chkbox_edita_fnegocio" runat="server" OnCheckedChanged="chkbox_edita_fnegocio_CheckedChanged" AutoPostBack="true" Text="Editar" />
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_nombre_empresa" runat="server" Text="*Nombre de Empresa"></asp:Label>
                                                </h5>
                                                <asp:TextBox CssClass="form-control" ID="txt_nombre_empresa" runat="server" placeholder="Capturar nombre de empresa" OnTextChanged="txt_nombre_empresa_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <div class="text-right">
                                                    <asp:RequiredFieldValidator ID="rfv_nombre_empresa" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_nombre_empresa" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_telefono_empresa" runat="server" Text="Teléfono"></asp:Label>
                                                </h5>
                                                <asp:TextBox CssClass="form-control" ID="txt_telefono_empresa" runat="server" placeholder="Capturar Teléfono" TextMode="Phone"></asp:TextBox>
                                                <br />
                                            </div>
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_email_empresa" runat="server" Text="e-mail"></asp:Label>
                                                </h5>
                                                <asp:TextBox CssClass="form-control" ID="txt_email_empresa" runat="server" placeholder="Capturar e-mail" TextMode="Email"></asp:TextBox>
                                                <br />
                                            </div>
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_callenum_empresa" runat="server" Text="Calle ý número"></asp:Label>
                                                </h5>
                                                <asp:TextBox CssClass="form-control" ID="txt_callenum_empresa" runat="server" placeholder="Captura Calle ý número" OnTextChanged="txt_callenum_empresa_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <div class="text-right">
                                                    <asp:RequiredFieldValidator ID="rfv_callenum_empresa" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_callenum_empresa" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_cp_empresa" runat="server" Text="Código Postal"></asp:Label>
                                                </h5>

                                                <asp:TextBox CssClass="form-control" ID="txt_cp_empresa" runat="server" placeholder="Capturar Código Postal" MaxLength="5" OnTextChanged="txt_cp_empresa_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="mee_cp_empresa" runat="server" TargetControlID="txt_cp_empresa" Mask="99999" />

                                                <div class="text-right">
                                                    <asp:RequiredFieldValidator ID="rfv_cp_empresa" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_cp_empresa" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_colonia_empresa" runat="server" Text="Colonia"></asp:Label>
                                                </h5>
                                                <asp:DropDownList CssClass="form-control" ID="ddl_colonia_empresa" runat="server"></asp:DropDownList>
                                                <div class="text-right">
                                                    <asp:RequiredFieldValidator ID="rfv_colonia_empresa" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="ddl_colonia_empresa" InitialValue="0" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_municipio_empresa" runat="server" Text="Municipio"></asp:Label>
                                                </h5>
                                                <asp:TextBox CssClass="form-control" ID="txt_municipio_empresa" runat="server" placeholder="Captura Municipio" Enabled="false"></asp:TextBox>
                                                <br />
                                            </div>
                                            <div class="form-group text-left">
                                                <h5>
                                                    <asp:Label CssClass="control-label" ID="lbl_estado_empresa" runat="server" Text="Estado"></asp:Label>
                                                </h5>
                                                <asp:TextBox CssClass="form-control" ID="txt_estado_empresa" runat="server" placeholder="Captura Estado" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-12 text-right">
                                            <div class="form-group">
                                                <br />
                                                <asp:Button CssClass="btn" ID="btn_guarda_fnegocio" runat="server" Text="GUARDAR" OnClick="btn_guarda_fnegocio_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_rpt" runat="server">
                        <ContentTemplate>
                            <div class="panel panel-default" id="pnl_rpt" runat="server" visible="false">
                                <div class="panel-heading">
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-1 ">
                                        </div>
                                        <div class="col-lg-8 text-center">
                                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="800px" waitmessagefont-names="Verdana" waitmessagefont-size="14pt" Width="1024px" ShowBackButton="False" ShowFindControls="False" ShowPageNavigationControls="False" AsyncRendering="true">
                                            </rsweb:ReportViewer>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_gasto" runat="server">
                        <ContentTemplate>
                            <div class="panel panel-default" id="pnl_gasto" runat="server" visible="false">
                                <div class="panel-heading">
                                    <h3 class="panel-title text-left">CONTROL DE GASTO</h3>
                                    <h3 class="panel-title text-right">
                                        <div class="btn-group">
                                            <asp:LinkButton CssClass="btn btn-default" ID="lkbtn_nuevo_gasto" runat="server" OnClick="lkbtn_nuevo_gasto_Click">
                                                <i class="glyphicon glyphicon-plus-sign" id="i_agrega_gasto" runat="server"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-default" ID="lkbtn_edita_gasto" runat="server" OnClick="lkbtn_edita_gasto_Click">
                                                <i class="glyphicon glyphicon-edit" id="i_edita_gasto" runat="server"></i>
                                            </asp:LinkButton>
                                        </div>
                                        <div class="text-right">
                                            <br />
                                            <asp:Label CssClass="buttonClass" ID="lbl_pfijo_gasto" runat="server"> </asp:Label>
                                        </div>
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <asp:TextBox CssClass="form-control  input-xs" ID="txt_buscar_gasto" runat="server" placeholder="BUSCAR" Visible="false"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:Button CssClass="btn" ID="btn_buscar_gasto" runat="server" Text="Ir" Visible="false" OnClick="btn_buscar_gasto_Click" />
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4"></div>
                                    </div>
                                    <div class="col-lg-12">
                                        <asp:GridView CssClass="table" ID="gv_gasto" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gv_gasto_PageIndexChanging" PageSize="15">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk_gasto" runat="server" onclick="CheckOne(this)" AutoPostBack="true" OnCheckedChanged="chk_gasto_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="codigo_gasto" HeaderText="ID" SortExpression="codigo_gasto" Visible="true" />
                                                <asp:BoundField DataField="desc_estatus" HeaderText="ESTATUS" SortExpression="desc_estatus" Visible="true" />
                                                <asp:BoundField DataField="tipo_rubro" HeaderText="TIPO RUBRO" SortExpression="tipo_rubro" />
                                                <asp:BoundField DataField="rubro" HeaderText="RUBRO" SortExpression="rubro" />
                                                <asp:BoundField DataField="desc_gasto" HeaderText="GASTO" SortExpression="desc_gasto" />
                                                <asp:BoundField DataField="fecha_registro" HeaderText="FECHA DE REGISTRO" SortExpression="fecha_registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                            </Columns>
                                        </asp:GridView>
                                        <br />
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label class="control-label">*TIPO RUBRO</label>
                                            <asp:DropDownList CssClass="form-control  input-xs" ID="ddl_tipogasto_rubro" runat="server" OnSelectedIndexChanged="ddl_tipogasto_rubro_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">*DESCRIPICIÓN RUBRO</label>
                                            <asp:DropDownList CssClass="form-control  input-xs" ID="ddl_descgasto_rubro" runat="server" OnSelectedIndexChanged="ddl_descgasto_rubro_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label class="control-label">*MONTO</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-usd"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_monto_gasto" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <ajaxToolkit:MaskedEditExtender
                                            ID="mee_costo_gasto"
                                            runat="server"
                                            TargetControlID="txt_monto_gasto"
                                            Mask="999,999.99"
                                            MessageValidatorTip="true"
                                            OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError"
                                            MaskType="Number"
                                            InputDirection="RightToLeft"
                                            AcceptNegative="Left"
                                            DisplayMoney="Left"
                                            ErrorTooltipEnabled="True" />
                                        <div class="form-group">
                                            <br />
                                            <asp:CheckBox ID="chkb_estatus_gasto" runat="server" Text="Desactivar" Visible="false" />
                                        </div>

                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label class="control-label">*DESCRIPCIÓN GASTO</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-th-list"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_desc_gasto" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 text-right">
                                        <div class="form-group">
                                            <br />
                                            <asp:Button CssClass="btn" ID="btn_guardar_gasto" runat="server" Text="GUARDAR" OnClick="btn_guardar_gasto_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_caja" runat="server">
                        <ContentTemplate>
                            <div class="panel panel-default" id="pnl_caja" runat="server" visible="false">
                                <div class="panel-heading">
                                    <h3 class="panel-title text-left">CONTROL DE CAJA</h3>
                                    <h3 class="panel-title text-right">
                                        <div class="btn-group">
                                            <asp:LinkButton CssClass="btn btn-default" ID="lkbtn_nuevo_caja" runat="server" OnClick="lkbtn_nuevo_caja_Click">
                                                <i class="glyphicon glyphicon-plus-sign" id="i_agrega_caja" runat="server"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-default" ID="lkbtn_edita_caja" runat="server" OnClick="lkbtn_edita_caja_Click">
                                                <i class="glyphicon glyphicon-edit" id="i_edita_caja" runat="server"></i>
                                            </asp:LinkButton>
                                        </div>
                                        <div class="text-right">
                                            <br />
                                            <asp:Label CssClass="buttonClass" ID="lbl_tcaja" runat="server"> </asp:Label>
                                        </div>
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <asp:TextBox CssClass="form-control  input-xs" ID="txt_buscar_caja" runat="server" placeholder="BUSCAR" Visible="false"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:Button CssClass="btn" ID="btn_buscar_caja" runat="server" Text="Ir" Visible="false" OnClick="btn_buscar_caja_Click" />
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4"></div>
                                    </div>
                                    <div class="col-lg-12">
                                        <asp:GridView CssClass="table" ID="gv_caja" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gv_caja_PageIndexChanging" PageSize="5">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk_caja" runat="server" onclick="CheckOne(this)" AutoPostBack="true" OnCheckedChanged="chk_caja_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="codigo_caja" HeaderText="ID" SortExpression="codigo_caja" Visible="true" />
                                                <asp:BoundField DataField="desc_estatus" HeaderText="ESTATUS" SortExpression="desc_estatus" Visible="true" />
                                                <asp:BoundField DataField="tipo_rubro" HeaderText="TIPO RUBRO" SortExpression="tipo_rubro" />
                                                <asp:BoundField DataField="rubro" HeaderText="RUBRO" SortExpression="rubro" />
                                                <asp:BoundField DataField="desc_caja" HeaderText="DESCRIPCIÓN CAJA" SortExpression="desc_caja" />
                                                <asp:BoundField DataField="fecha_registro" HeaderText="FECHA DE REGISTRO" SortExpression="fecha_registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                            </Columns>
                                        </asp:GridView>
                                        <br />
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label class="control-label">*TIPO RUBRO</label>
                                            <asp:DropDownList CssClass="form-control  input-xs" ID="ddl_tipocaja_rubro" runat="server" OnSelectedIndexChanged="ddl_tipocaja_rubro_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label class="control-label">*RUBRO</label>
                                            <asp:DropDownList CssClass="form-control  input-xs" ID="ddl_desccaja_rubro" runat="server" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label class="control-label">*DESCRIPCIÓN</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-th-list"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_desc_caja" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label class="control-label">*MONTO</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-usd"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_monto_caja" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <ajaxToolkit:MaskedEditExtender
                                            ID="mee_costo_caja"
                                            runat="server"
                                            TargetControlID="txt_monto_caja"
                                            Mask="999,999.99"
                                            MessageValidatorTip="true"
                                            OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError"
                                            MaskType="Number"
                                            InputDirection="RightToLeft"
                                            AcceptNegative="Left"
                                            DisplayMoney="Left"
                                            ErrorTooltipEnabled="True" />

                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <br />
                                            <asp:CheckBox ID="chkb_estatus_caja" runat="server" Text="Desactivar" Visible="false" />
                                        </div>
                                    </div>
                                    <div class="col-lg-12 text-right">
                                        <div class="form-group">
                                            <br />
                                            <asp:Button CssClass="btn" ID="btn_guardar_caja" runat="server" Text="GUARDAR" OnClick="btn_guardar_caja_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_rubros" runat="server">
                        <ContentTemplate>
                            <div class="panel panel-default" id="pnl_rubros" runat="server" visible="false">
                                <div class="panel-heading">

                                    <h3 class="panel-title text-left">CONTROL DE RUBROS Y PRESUPUESTOS</h3>
                                    <h3 class="panel-title text-right">
                                        <div class="btn-group">
                                            <asp:LinkButton CssClass="btn btn-default" ID="lkbtn_nuevo_rubros" runat="server" OnClick="lkbtn_nuevo_rubros_Click">
                                                <i class="glyphicon glyphicon-plus-sign" id="i_agrega_rubros" runat="server"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-default" ID="lkbtn_edita_rubros" runat="server" OnClick="lkbtn_edita_rubros_Click">
                                                <i class="glyphicon glyphicon-edit" id="i_edita_rubros" runat="server"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-4">

                                            <div class="form-group">
                                                <div class="input-group">
                                                    <asp:TextBox CssClass="form-control  input-xs" ID="txt_buscar_rubros" runat="server" placeholder="BUSCAR" Visible="false"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:Button CssClass="btn" ID="btn_buscar_rubros" runat="server" Text="Ir" Visible="false" OnClick="btn_buscar_rubros_Click" />
                                                    </span>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-lg-4"></div>
                                    </div>
                                    <div class="col-lg-12">
                                        <asp:GridView CssClass="table" ID="gv_rubros" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_rubros_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk_rubros" runat="server" onclick="CheckOne(this)" AutoPostBack="true" OnCheckedChanged="chk_rubros_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="codigo_rubro" HeaderText="ID" SortExpression="codigo_rubro" Visible="true" />
                                                <asp:BoundField DataField="desc_estatus" HeaderText="ESTATUS" SortExpression="desc_estatus" Visible="true" />
                                                <asp:BoundField DataField="tipo_rubro" HeaderText="TIPO RUBRO" SortExpression="tipo_rubro" />
                                                <asp:BoundField DataField="rubro" HeaderText="RUBRO" SortExpression="rubro" />
                                                <asp:BoundField DataField="fecha_registro" HeaderText="FECHA DE REGISTRO" SortExpression="fecha_registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                            </Columns>
                                        </asp:GridView>
                                        <br />
                                    </div>
                                    <div class="col-lg-8">

                                        <div class="form-group">
                                            <label class="control-label">DESCRIPCIÓN</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-th-list"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_desc_rubro" runat="server"></asp:TextBox>
                                            </div>

                                        </div>

                                    </div>
                                    <div class="col-lg-4">

                                        <div class="form-group">
                                            <label class="control-label">TIPO DE RUBRO</label>
                                            <asp:DropDownList CssClass="form-control  input-xs" ID="ddl_tipo_rubro" runat="server"></asp:DropDownList>


                                        </div>

                                    </div>
                                    <div class="col-lg-2">

                                        <div class="form-group">
                                            <label class="control-label">FIJO</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-usd"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_pfijo_rubro" runat="server"></asp:TextBox>
                                            </div>

                                            <ajaxToolkit:MaskedEditExtender
                                                ID="mee_costo_rubros"
                                                runat="server"
                                                TargetControlID="txt_pfijo_rubro"
                                                Mask="999,999.99"
                                                MessageValidatorTip="true"
                                                OnFocusCssClass="MaskedEditFocus"
                                                OnInvalidCssClass="MaskedEditError"
                                                MaskType="Number"
                                                InputDirection="RightToLeft"
                                                AcceptNegative="Left"
                                                DisplayMoney="Left"
                                                ErrorTooltipEnabled="True" />
                                        </div>

                                    </div>
                                    <div class="col-lg-2">

                                        <div class="form-group">
                                            <label class="control-label">MINIMO</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-object-align-left"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_minimo_rubro" runat="server" Text="% 25" Enabled="false"></asp:TextBox>
                                            </div>

                                        </div>

                                    </div>
                                    <div class="col-lg-2">

                                        <div class="form-group">
                                            <label class="control-label">MAXIMO</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-object-align-right"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_maximo_rubro" runat="server" Text="% 75" Enabled="false"></asp:TextBox>
                                            </div>

                                        </div>

                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label class="control-label">EXTRA</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-usd"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_pextra_rubro" runat="server" Enabled="false"></asp:TextBox>
                                            </div>

                                            <ajaxToolkit:MaskedEditExtender
                                                ID="MaskedEditExtender3"
                                                runat="server"
                                                TargetControlID="txt_pextra_rubro"
                                                Mask="999,999.99"
                                                MessageValidatorTip="true"
                                                OnFocusCssClass="MaskedEditFocus"
                                                OnInvalidCssClass="MaskedEditError"
                                                MaskType="Number"
                                                InputDirection="RightToLeft"
                                                AcceptNegative="Left"
                                                DisplayMoney="Left"
                                                ErrorTooltipEnabled="True" />
                                        </div>

                                    </div>
                                    <div class="col-lg-2">

                                        <div class="form-group">
                                            <label class="control-label">GASTO</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-usd"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_vgasto" runat="server" Enabled="false"></asp:TextBox>
                                            </div>

                                            <ajaxToolkit:MaskedEditExtender
                                                ID="MaskedEditExtender4"
                                                runat="server"
                                                TargetControlID="txt_vgasto"
                                                Mask="999,999.99"
                                                MessageValidatorTip="true"
                                                OnFocusCssClass="MaskedEditFocus"
                                                OnInvalidCssClass="MaskedEditError"
                                                MaskType="Number"
                                                InputDirection="RightToLeft"
                                                AcceptNegative="Left"
                                                DisplayMoney="Left"
                                                ErrorTooltipEnabled="True" />
                                        </div>

                                    </div>

                                    <div class="col-lg-10"></div>
                                    <div class="col-lg-2 text-right">
                                        <asp:Button CssClass="btn" ID="btn_guardar_rubros" runat="server" Text="GUARDAR" OnClick="btn_guardar_rubros_Click" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_usuarios" runat="server">
                        <ContentTemplate>
                            <div class="panel panel-default" id="pnl_usuarios" runat="server" visible="false">
                                <div class="panel-heading">

                                    <h3 class="panel-title text-left">CONTROL DE USUARIOS</h3>
                                    <h3 class="panel-title text-right">
                                        <div class="btn-group">
                                            <asp:LinkButton CssClass="btn btn-default" ID="lkbtn_nuevo_usuario" runat="server" OnClick="lkbtn_nuevo_usuario_Click">
                                                <i class="glyphicon glyphicon-plus-sign" id="i_agrega_usuario" runat="server" title="AGREGAR"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-default" ID="lkbtn_edita_usuario" runat="server" OnClick="lkbtn_edita_usuario_Click">
                                                <i class="glyphicon glyphicon-edit" id="i_edita_usuario" runat="server" title="EDITAR"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </h3>
                                </div>

                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <asp:CheckBox ID="chkb_administrador" runat="server" Text="ADMINISTRADOR" OnCheckedChanged="chkb_administrador_CheckedChanged" AutoPostBack="true" />
                                            <br />
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:CheckBox ID="chkb_ejecutivo" runat="server" Text="EJECUTIVO" OnCheckedChanged="chkb_ejecutivo_CheckedChanged" AutoPostBack="true" />
                                            <br />
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:CheckBox ID="chkb_invitado" runat="server" Text="INVITADO" OnCheckedChanged="chkb_invitado_CheckedChanged" AutoPostBack="true" />
                                            <br />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <asp:TextBox CssClass="form-control  input-xs" ID="txt_buscar_usuario" runat="server" placeholder="BUSCAR" Visible="false"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:Button CssClass="btn" ID="btn_busca_usuario" runat="server" Text="IR" Visible="false" OnClick="btn_busca_usuario_Click" />
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4"></div>
                                    </div>
                                    <br />
                                    <div class="col-lg-12">
                                        <asp:GridView CssClass="table" ID="gv_usuarios" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gv_usuarios_PageIndexChanging" PageSize="5">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk_usuario" runat="server" onclick="CheckOne(this)" AutoPostBack="true" OnCheckedChanged="chk_usuario_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="codigo_usuario" HeaderText="CÓDIGO" SortExpression="codigo_usuario" Visible="true" />
                                                <asp:BoundField DataField="desc_estatus" HeaderText="ESTATUS" SortExpression="desc_estatus" />
                                                <asp:BoundField DataField="nombres" HeaderText="NOMBRE(S)" SortExpression="nombres" />
                                                <asp:BoundField DataField="a_paterno" HeaderText="APELLIDO PATERNO" SortExpression="a_paterno" />
                                                <asp:BoundField DataField="a_materno" HeaderText="APELLIDO MATERNO" SortExpression="a_materno" />
                                                <asp:BoundField DataField="fecha_registro" HeaderText="FECHA DE REGISTRO" SortExpression="fecha_registro" DataFormatString="{0:dd/MM/yyyy}" />
                                            </Columns>
                                        </asp:GridView>
                                        <br />
                                    </div>
                                    <div class="col-lg-6">

                                        <div class="form-group">
                                            <label class="control-label">*NOMBRE(S)</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_nombres_usuario" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">*APELLIDO PATERNO</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_apaterno_usuario" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">*APELLIDO MATERNO</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_amaterno_usuario" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label class="control-label">*USUARIO</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-barcode"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_usuario_usuario" runat="server"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <asp:Button CssClass="btn" ID="btn_genera_usuario" runat="server" Text="+" OnClick="btn_genera_usuario_Click" />
                                                </span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">PERFIL</label>
                                            <asp:DropDownList CssClass="form-control input-xs" ID="ddl_perfil" runat="server" enable="false"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label class="control-label">*CONTRASEÑA</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-qrcode"></i></span>
                                                <asp:TextBox CssClass="form-control  input-xs" ID="txt_clave_usuario" runat="server" TextMode="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <br />
                                            <asp:CheckBox ID="chkb_activar_usuario" runat="server" Text="Desactivar" enable="false" />
                                        </div>
                                    </div>

                                    <div class="col-lg-12 text-right">
                                        <div class="form-group">
                                            <br />
                                            <asp:Button CssClass="btn" ID="btn_guardar_usuario" runat="server" Text="GUARDAR" OnClick="btn_guardar_usuario_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_email" runat="server">
                        <ContentTemplate>
                            <div class="col-lg-12">
                                <asp:UpdatePanel ID="up_email_envio" runat="server">
                                    <ContentTemplate>
                                        <div class="panel panel-default" id="pnl_email_envio" runat="server" visible="false">

                                            <div class="panel-heading">

                                                <h3 class="panel-title text-left">CONTROL DE CORREO PARA ENVIO</h3>
                                                <h3 class="panel-title text-right">
                                                    <div class="btn-group">
                                                        <asp:LinkButton CssClass="btn btn-default" ID="lkbtn_nuevo_email_envio" runat="server" OnClick="lkbtn_nuevo_email_envio_Click">
                                                            <i class="glyphicon glyphicon-plus-sign" id="i_agrega_email_envio" runat="server" title="AGREGAR"></i>
                                                        </asp:LinkButton>
                                                        <asp:LinkButton CssClass="btn btn-default" ID="lkbtn_edita_email_envio" runat="server" OnClick="lkbtn_edita_email_envio_Click">
                                                            <i class="glyphicon glyphicon-edit" id="i_edita_email_envio" runat="server" title="EDITAR"></i>
                                                        </asp:LinkButton>
                                                    </div>
                                                </h3>
                                            </div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="control-label">*CORREO</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                                                            <asp:TextBox CssClass="form-control  input-xs" ID="txt_correo_envio" runat="server" TextMode="Email"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label">*ASUNTO</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>
                                                            <asp:TextBox CssClass="form-control  input-xs" ID="txt_asunto_envio" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="control-label">*USUARIO</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="glyphicon glyphicon-barcode"></i></span>
                                                            <asp:TextBox CssClass="form-control  input-xs" ID="txt_usuario_envio" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label">*SERVIDOR SMTP</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="glyphicon glyphicon-th-list"></i></span>
                                                            <asp:TextBox CssClass="form-control  input-xs" ID="txt_servidor_smtp" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="control-label">*CONTRASEÑA</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="glyphicon glyphicon-qrcode"></i></span>
                                                            <asp:TextBox CssClass="form-control  input-xs" ID="txt_clave_envio" runat="server" TextMode="Password"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label">*PUERTO</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="glyphicon glyphicon-share"></i></span>
                                                            <asp:TextBox CssClass="form-control  input-xs" ID="txt_puerto_envio" runat="server"></asp:TextBox>
                                                        </div>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_puerto_envio" Mask="99999" />
                                                    </div>
                                                </div>

                                                <div class="col-lg-12 text-right">
                                                    <div class="form-group">

                                                        <br />
                                                        <asp:Button CssClass="btn" ID="btn_guardar_envio" runat="server" Text="GUARDAR" OnClick="btn_guardar_envio_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-12">
                                <asp:UpdatePanel ID="up_email_recepcion" runat="server">
                                    <ContentTemplate>
                                        <div class="panel panel-default" id="pnl_email_recepcion" runat="server" visible="false">
                                            <div class="panel-heading">

                                                <h3 class="panel-title text-left">CONTROL DE CORREO PARA RECEPCIÓN</h3>
                                                <h3 class="panel-title text-right">
                                                    <div class="btn-group">
                                                        <asp:LinkButton CssClass="btn btn-default" ID="lkbtn_nuevo_email_recepcion" runat="server" OnClick="lkbtn_nuevo_email_recepcion_Click">
                                                            <i class="glyphicon glyphicon-plus-sign" id="i_agrega_email_recepcion" runat="server"></i>
                                                        </asp:LinkButton>
                                                        <asp:LinkButton CssClass="btn btn-default" ID="lkbtn_edita_email_recepcion" runat="server" OnClick="lkbtn_edita_email_recepcion_Click">
                                                            <i class="glyphicon glyphicon-edit" id="i_edita_email_recepcion" runat="server"></i>
                                                        </asp:LinkButton>
                                                    </div>
                                                </h3>
                                            </div>

                                            <div class="panel-body">
                                                <div class="col-lg-12">
                                                    <asp:GridView CssClass="table" ID="gv_correo_recepcion" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="5">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chk_correo_recepcion" runat="server" onclick="CheckOne(this)" AutoPostBack="true" OnCheckedChanged="chk_correo_recepcion_CheckedChanged" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="email_recepcion" HeaderText="CORREO" SortExpression="email_recepcion" />
                                                            <asp:BoundField DataField="desc_estatus" HeaderText="ESTATUS" SortExpression="desc_estatus" />
                                                            <asp:BoundField DataField="fecha_registro" HeaderText="REGISTRO" SortExpression="fecha_registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="control-label">*CORREO</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                                                            <asp:TextBox CssClass="form-control  input-xs" ID="txt_correo_recepcion" runat="server" TextMode="Email"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:CheckBox ID="chkb_estatus_recepcion" runat="server" Text="DESACTIVAR" Visible="false" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-2 text-right">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:Button CssClass="btn" ID="btn_guardar_recepcion" runat="server" Text="GUARDAR" OnClick="btn_guardar_recepcion_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button class="btn" data-dismiss="modal" aria-hidden="true">Ok</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
