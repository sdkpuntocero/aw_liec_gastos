<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="acceso.aspx.cs" Inherits="aw_liec_gastos.acceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          <div class="container">
                    <div class="col-lg-12 text-center">
                        <!-- Login Form -->
                        <div class="nb-login">
                            <asp:Image CssClass="center-block img-responsive img-thumbnail" ID="Image1" runat="server" ImageUrl="~/img/logo_liec256.png" Width="128" Height="128" />
                            <br />
                            <h5 class="scenter">Control de Acceso</h5>
                            <div class="form-group text-left">
                                <h5>
                                    <asp:Label CssClass="control-label" ID="lbl_usuario" runat="server" Text="*Usuario"></asp:Label>
                                </h5>
                                <asp:TextBox CssClass="form-control" ID="txt_usuario" runat="server" TabIndex="1" placeholder="Capturar Usuario"></asp:TextBox>
                                <div class="text-right">
                                    <asp:RequiredFieldValidator ID="rfv_usuario" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_usuario" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group text-left">
                                <h5>
                                    <asp:Label CssClass="control-label" ID="lbl_clave" runat="server" Text="*Contraseña"></asp:Label>

                                </h5>
                                <asp:TextBox CssClass="form-control" ID="txt_clave" runat="server" TabIndex="2" placeholder="Capturar Contraseña" TextMode="Password"></asp:TextBox>
                                <div class="text-right">
                                    <asp:RequiredFieldValidator ID="rfv_clave" runat="server" ErrorMessage="*Campo Obligatorio" ControlToValidate="txt_clave" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                 <h5>
                                <asp:LinkButton CssClass="text-left" ID="lkb_registro" runat="server" Visible="false" Text="Registrar" OnClick="lkb_registro_Click"></asp:LinkButton>
                                     </h5>
                            </div>
                            <asp:Button CssClass="btn btn-block" ID="lbtn_acceso" runat="server" Text="Entrar" TabIndex="3" OnClick="lbtn_acceso_Click" />
         
                            <%-- <div class="center or">OR</div>
                    <h3 class="center">Sign In Using</h3>
                    <div class="social">
                        <a href="#" class="facebook"><i class="fa fa-facebook"></i>&nbsp; Login with Facebook</a>
                        <a href="#" class="twitter"><i class="fa fa-twitter"></i>&nbsp; Login with Twitter</a>
                        <a href="#" class="google-plus"><i class="fa fa-google-plus"></i>&nbsp; Login with Google Plus</a>
                    </div>--%>
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
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button class="btn" data-dismiss="modal" aria-hidden="true">Ok </button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
