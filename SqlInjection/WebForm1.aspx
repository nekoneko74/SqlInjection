<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SqlInjection.WebForm1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>SQLインジェクション</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            SELECT * FROM [MyTable] WHERE [StringData] = '
            <asp:TextBox ID="Where_TextBox" runat="server"></asp:TextBox>'<br />
            <asp:Button ID="Button_StringEdit" runat="server" Text="文字列編集" OnClick="Button_StringEdit_Click" />
            <asp:Button ID="Button_Parameter" runat="server" Text="パラメータクエリ" OnClick="Button_Parameter_Click" /><br />
            実行されたSQL：<asp:Label ID="Label_SQL" runat="server" Text="Label">未実行</asp:Label><br />
            <hr />
            実行されたSQLにより取得されたレコード
            <asp:GridView ID="Result_GridView" runat="server" EmptyDataText="（選択されたレコードはありません）" EnableViewState="False"></asp:GridView>
            <hr />
            テーブルの全レコード
            <asp:GridView ID="AllRecord_GridView" runat="server" EmptyDataText="（選択されたレコードはありません）" EnableViewState="False"></asp:GridView>
            <hr />
            <p>
            パラメータ部に「aaa」を入力して「文字列編集」ボタンおよび「パラメータクエリ」ボタンをクリックして取得されるレコードを確認してください。<br />
            次に、パラメータ部に「aaa' OR '1' = '1」を入力して「文字列編集」ボタンおよび「パラメータクエリ」ボタンをクリックして取得されるレコードを確認してください。
            </p>
        </div>
    </form>
</body>
</html>