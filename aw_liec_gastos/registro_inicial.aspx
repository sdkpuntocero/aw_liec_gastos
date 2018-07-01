<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="registro_inicial.aspx.cs" Inherits="aw_liec_gastos.registro_inicial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="section">
                <div class="container">
                    <div class="form-group">
                        <div class="row">
                            <br />
                            <div class="panel panel-default" id="pnl_empresa" runat="server" visible="true">
                                <div class="panel-heading">
                                    <h3 class="text-center">Registro de Empresa y Administrador</h3>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="form-group has-error">
                                            <div class="col-lg-3">
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
                                                        <asp:RequiredFieldValidator ID="rfv_callenum_empresa" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_callenum_empresa" ForeColor="DarkRed" ></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
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
                                                    <asp:DropDownList CssClass="form-control" ID="ddl_colonia_empresa" runat="server" ></asp:DropDownList>
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
                                            <div class="col-lg-3">
                                                <div class="form-group text-left">
                                                    <h5>
                                                        <asp:Label CssClass="control-label" ID="lbl_nombres_admin" runat="server" Text="*Nombre(s)"></asp:Label>
                                                    </h5>
                                                    <asp:TextBox CssClass="form-control" ID="txt_nombres_admin" runat="server" placeholder="Captura Nombre(s)"></asp:TextBox>
                                                    <div class="text-right">
                                                        <asp:RequiredFieldValidator ID="rfv_nombres_admin" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_nombres_admin" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group text-left">
                                                    <h5>
                                                        <asp:Label CssClass="control-label" ID="lbl_apaterno_admin" runat="server" Text="*Apellido Paterno"></asp:Label>
                                                    </h5>
                                                    <asp:TextBox CssClass="form-control" ID="txt_apaterno_admin" runat="server" placeholder="Captura Apellido Paterno"></asp:TextBox>
                                                    <div class="text-right">
                                                        <asp:RequiredFieldValidator ID="rfv_apaterno_admin" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_apaterno_admin" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group text-left">
                                                    <h5>
                                                        <asp:Label CssClass="control-label" ID="lbl_amaterno_admin" runat="server" Text="*Apellido Materno"></asp:Label>
                                                    </h5>
                                                    <asp:TextBox CssClass="form-control" ID="txt_amaterno_admin" runat="server" placeholder="Captura Apellido Materno" OnTextChanged="txt_amaterno_admin_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    <div class="text-right">
                                                        <asp:RequiredFieldValidator ID="rfv_amaterno_admin" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_amaterno_admin" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group text-left">
                                                    <h5>
                                                        <asp:Label CssClass="control-label" ID="lbl_usuario_admin" runat="server" Text="*Usuario"></asp:Label>
                                                    </h5>
                                        
                                                        <asp:TextBox CssClass="form-control" ID="txt_usuario_admin" runat="server" placeholder="Captura Usuario"></asp:TextBox>
                                                
                                              
                                                    <div class="text-right">
                                                        <asp:RequiredFieldValidator ID="rfv_usuario_admin" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usuario_admin" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group text-left">
                                                    <h5>
                                                        <asp:Label CssClass="control-label" ID="lbl_clave_admin" runat="server" Text="*Contraseña"></asp:Label>
                                                    </h5>
                                                    <asp:TextBox CssClass="form-control" ID="txt_clave_admin" runat="server" placeholder="Capturar Contraseña" TextMode="Password"></asp:TextBox>
                                                    <div class="text-right">
                                                        <asp:RequiredFieldValidator ID="rfv_clave_admin" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_clave_admin" ForeColor="DarkRed" Enabled="false"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="text-right">
                                               <br />
                                                    <asp:Button CssClass="btn" ID="btn_salir_admin" runat="server" Text="Salir" OnClick="btn_salir_admin_Click" />
                                                    <asp:Button CssClass="btn" ID="btn_guardar_admin" runat="server" Text="Guardar" OnClick="btn_guardar_admin_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true" onclick="window.location.href='/acceso.aspx'">x</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button class="btn" data-dismiss="modal" aria-hidden="true" onclick="window.location.href='/acceso.aspx'">Ok </button>
                        </div>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
