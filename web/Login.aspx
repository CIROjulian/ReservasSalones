<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ReservasSalones.web.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <br />
            <br />
            ingrese su Usuario:<br />
            <asp:TextBox ID="TextBox1" runat="server" style="width: 168px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator 
                ID="rfvUsuario" 
                runat="server" 
                ControlToValidate="TextBox1" 
                InitialValue="" 
                ErrorMessage="Por favor ingrese su usuario con el correo." 
                ForeColor="Red" />
            <br />
            <br />
            ingrese su contraseña:<br />
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator 
                ID="rfvContrasena" 
                runat="server" 
                ControlToValidate="TextBox2" 
                InitialValue="" 
                ErrorMessage="Por favor ingrese su contraseña." 
                ForeColor="Red" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="ingresar" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
