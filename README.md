# SQLインジェクションのサンプル

## 用意するデータベース
ADO.NETのサンプルと共通のデータベース（ADONET）を使用します。<br>
テーブルとサンプルデータの作成については、DatabaseフォルダのMyTable.sqlを参照してください。

## WebForm1.aspx
SQLインジェクションのテストを行なうことができます。<br>
WebForm1.aspx.cs内ののWebForm1.getConnectionString()メソッド内でデータベースへの接続文字列を生成していますので、接続先データベースやアカウント情報を変更する場合にはこのメソッド内の設定を変更してください。