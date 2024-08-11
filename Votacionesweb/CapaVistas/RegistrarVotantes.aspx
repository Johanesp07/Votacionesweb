<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarVotantes.aspx.cs" Inherits="Votacionesweb.CapaVistas.RegistrarVotantes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div class="d-flex justify-content-center">
            <div class="card" style="width: 400px;">
                <div class="card-header text-center p-2">
                    <h4 class="mb-0">Registro</h4>
                </div>
                <div class="card-body p-3">
                    <div class="mb-2">
                        <asp:Label runat="server" AssociatedControlID="txtNombre" CssClass="form-label">Nombre</asp:Label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control form-control-sm" required="required" />
                    </div>
                    <div class="mb-2">
                        <asp:Label runat="server" AssociatedControlID="txtApellido" CssClass="form-label">Apellido</asp:Label>
                        <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control form-control-sm" required="required" />
                    </div>
                    <div class="mb-2">
                        <asp:Label runat="server" AssociatedControlID="txtCorreo" CssClass="form-label">Correo</asp:Label>
                        <asp:TextBox runat="server" ID="txtCorreo" TextMode="Email" CssClass="form-control form-control-sm" required="required" />
                    </div>
                    <div class="mb-2">
                        <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="form-label">Contraseña</asp:Label>
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control form-control-sm" required="required" />
                    </div>
                    <div class="d-grid gap-2 mt-3">
                        <asp:Button ID="btnRegistrar" CssClass="btn btn-success" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" />
                        <asp:LinkButton runat="server" PostBackUrl="~/CapaVistas/Login.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                    </div>
                    <br />
                    <div class="card-footer text-center py-3" style="background-color:aliceblue;">
                        <div class="small"><a href="Login.aspx">Iniciar Sesion</a></div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
